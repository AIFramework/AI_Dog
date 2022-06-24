using System;
using System.Collections.Generic;
using System.Linq;
using Many2Many = AI.ML.DataSets.Base.Many2ManyVectorClassifierDataset;
using M2MSample = AI.ML.DataSets.Base.Many2ManyVectorClassifier;
using AI.ML.NeuralNetwork;
using AI.ML.NeuralNetwork.CoreNNW.Layers;
using AI.ML.NeuralNetwork.CoreNNW;
using AI.ML.NeuralNetwork.CoreNNW.Activations;
using AI.ML.NeuralNetwork.CoreNNW.Loss;
using System.IO;
using AI.Extensions;
using AI.DataStructs.Algebraic;
using AI.DataStructs.Shapes;

namespace ControllerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] texts = File.ReadAllLines("dataset.txt");
            List<string> data = new List<string>();

            for (int i = 0; i < texts.Length; i++)
            {
                string[] strs = texts[i].Split();

                for (int j = 0; j < strs.Length - 2; j++)
                {
                    string outp = "";
                    for (int k = j; k < strs.Length; k++)
                    {
                        outp += strs[k] + " ";
                    }

                    data.Add(outp);
                }

            }



            Ex2(data.ToArray());
        }

        static char[] GetChars(string[] data)
        {
            HashSet<char> set = new HashSet<char>();
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    set.Add(data[i][j]);
                }
            }

            return set.ToArray();
        }
        static string[] PrepareTexts(string[] data)
        {
            string[] dataOut = new string[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                dataOut[i] = data[i].ToLower();
                dataOut[i] = dataOut[i].Replace(":", "").Replace(";", "");

                while (dataOut[i].Contains("  ")) dataOut[i] = dataOut[i].Replace("  ", " ");

                dataOut[i] = $":{dataOut[i]};";

            }

            dataOut.Shuffle();

            return dataOut;
        }
        static void Train(NeuralNetworkManager nnw, Many2Many dataset, int count)
        {
            nnw.EpochesToPass = 20;
            nnw.LearningRate = 0.0003f;
            nnw.GradientClipValue = 0.2f;
            nnw.ValSplit = 0;
            nnw.Loss = new CrossEntropyWithSoftmax();
            nnw.TrainNet(dataset.GetFeatures(), dataset.GetVectorLabels(count));
        }

        //One-hot -----------------------------
        #region One-hot

        static Vector GetDataOneHot(char[] chars, char ch)
        {
            Vector vect = new Vector(chars.Length);

            for (int i = 0; i < chars.Length; i++)
            {
                if (ch == chars[i])
                {
                    vect[i] = 1;
                    break;
                }
            }

            return vect;
        }

        #endregion

        // Emb --------------------------------
        #region Embeding
        private static void Ex2(string[] texts)
        {
            string[] trainData = PrepareTexts(texts);//data.ToArray());
            char[] chars = GetChars(trainData);
            Many2Many dataset = DataSetEmb(trainData, chars);
            NNW lstm = GetNNWEmb(chars.Length);
            //NNW lstm = NNW.Load("pretrain1.net");//
            NeuralNetworkManager neuralNetwork = new NeuralNetworkManager(lstm);
            Train(neuralNetwork, dataset, chars.Length);
            while (true)
            {
                Console.WriteLine("\nВведите фразу: ");
                string inp = ":" + Console.ReadLine().ToLower();
                Console.WriteLine("Генерация нейронкой: ");
                var outp = PredictEmb(inp, chars, lstm);
                Console.WriteLine($"{outp.Item1}, \t уверенность: {outp.Item2}");
            }
        }
        static Vector GetDataEmb(char[] chars, char ch)
        {
            int i = 0;
            for (; i < chars.Length; i++)
                if (ch == chars[i]) break;
            return new Vector((double)i);
        }
        static Many2Many DataSetEmb(string[] data, char[] chars)
        {
            Many2Many dataset = new Many2Many();
            for (int i = 0; i < data.Length; i++)
            {
                List<Vector> inp = new List<Vector>();
                List<int> outp = new List<int>();

                for (int j = 0; j < data[i].Length - 1; j++)
                {
                    inp.Add(GetDataEmb(chars, data[i][j]));
                    outp.Add(GetDataOneHot(chars, data[i][j + 1]).MaxElementIndex());
                }

                dataset.Add(new M2MSample(outp, inp));
            }

            return dataset;
        }
        static NNW GetNNWEmb(int inps)
        {
            NNW lstm = new NNW();
            lstm.AddNewLayer(new Shape3D(1), new EmbedingLayer(inps, 32));
            lstm.AddNewLayer(new ControllerL(50));
            lstm.AddNewLayer(new FeedForwardLayer(inps, new SoftmaxUnit()));
            return lstm;
        }
        // Возвращает спрогнозированную строку и вероятность
        static Tuple<string, double> PredictEmb(string start, char[] chars, NNW nNW)
        {
            Random rnd = new Random();
            List<char> listChar = new List<char>();
            nNW.ResetState();
            Vector st;
            GraphCPU graph = new GraphCPU();

            for (int i = 0; i < start.Length - 1; i++)
            {
                st = GetDataEmb(chars, start[i]);
                nNW.Forward(new NNValue(st), graph);
            }

            st = GetDataEmb(chars, start[start.Length - 1]);
            Vector outp = nNW.Forward(new NNValue(st), graph).ToVector();

            double prob;// вероятности на каждом шаге

            int ind = AI.Statistics.RandomItemSelection<int>.GetIndex(outp * outp, rnd);
            char ch = chars[ind];
            listChar.Add(ch);
            int count = 0;

            prob = outp[ind];

            while (ch != ';' && count < 500)
            {
                outp = nNW.Forward(new NNValue(GetDataEmb(chars, ch)), graph).ToVector();
                ind = AI.Statistics.RandomItemSelection<int>.GetIndex(outp * outp, rnd);
                prob *= outp[ind];
                ch = chars[ind];
                listChar.Add(ch);
                count++;
            }

            string text = new string(listChar.ToArray()); // спрогнозированный текст

            return new Tuple<string, double>(text, prob);
        }
        #endregion
    }
}

