using AI.DataStructs.Algebraic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Graphs.BaseGraph
{
    public class Graph
    {
        public int NumberOfVertex { get; private set; }
        public int NumberOfArcs { get; protected set; } = 0;

        /// <summary>
        /// Матрица смежности
        /// </summary>
        Matrix _adjMatrix { get; set; }

        /// <summary>
        /// Создание графа
        /// </summary>
        /// <param name="nV">Число вершин</param>
        public Graph(int nV) 
        {
            _adjMatrix = new Matrix(nV, nV);
            NumberOfVertex = nV;
        }

        /// <summary>
        /// Создание обновление дуги
        /// </summary>
        /// <param name="v1">Исток</param>
        /// <param name="v2">Сток</param>
        /// <param name="w">Сила связи</param>
        public void AddSetArc(int v1, int v2, double w) 
        {
            double old = GetW(v1, v2);
            if (old == 0 && w != 0) NumberOfArcs++;
            if (old != 0 && w == 0) NumberOfArcs--;
            _adjMatrix[v1, v2] = w;
        }

        /// <summary>
        /// Удаление дуги
        /// </summary>
        /// <param name="v1">Исток</param>
        /// <param name="v2">Сток</param>
        public void DeleteArc(int v1, int v2) { AddSetArc(v1, v2, 0); }

        /// <summary>
        /// Получение силы связей 2х вершин
        /// </summary>
        public double GetW(int v1, int v2)
        {
            return _adjMatrix[v1, v2];
        }

        /// <summary>
        /// Вывод связанных вершин
        /// </summary>
        /// <param name="vertex">Вершина, для которой ищем связи</param>
        public int[] Adj(int vertex) 
        {
            List<int> verts = new List<int>();
            for (int i = 0; i < NumberOfVertex; i++)
            {
                if (GetW(vertex, i) != 0) verts.Add(i);
            }
            return verts.ToArray(); 
        }
        
        /// <summary>
        /// Вывод связанных вершин
        /// </summary>
        /// <param name="verts">Вершины, для которой ищем связи</param>
        public int[] Adj(int[] verts)
        {
            List<int> adjV = new List<int>();
            for (int i = 0; i < verts.Length; i++)
            {
                adjV.AddRange(Adj(verts[i]));
            }

            return adjV.ToArray();
        }

        /// <summary>
        /// Вектор весов связных вершин
        /// </summary>
        /// <param name="vertex">Вершина</param>
        /// <param name="adj">Связные</param>
        public Vector W(int vertex, int[] adj)
        {
            Vector vector = new Vector(adj.Length);

            for (int i = 0; i < adj.Length; i++)
                 vector[i] = GetW(vertex, adj[i]);
            
            return vector;
        }

        // ToDo: Доработать раннюю остановку
        /// <summary>
        /// Выдает конечные вершины через k шагов, возвращает вершины и вектор вероятностей
        /// </summary>
        /// <returns></returns>
        public Tuple<int[], Vector> GetVertexForKStep(int startVertex, int kStep=2) 
        {
            if (kStep == 0)
                return new Tuple<int[], Vector>(new[] { startVertex }, new Vector(1.0));

            int[] adj = Adj(startVertex);
            int[] endVert = new int[adj.Length];
            Array.Copy(adj, endVert, adj.Length);

            Vector adjVect = W(startVertex, endVert), 
                endVect = adjVect.Clone();

            for (int i = 1; i < kStep; i++) // Проход на к-шагов
            {
                adj = Adj(endVert); // Получение связанных вершин
                if (adj.Length == 0) // Условие ранней остановки
                {
                    endVect /= endVect.Sum();
                    return new Tuple<int[], Vector>(endVert, endVect);
                }

                adjVect = endVect[0]*W(endVert[0], adj);
                for (int j = 1; j < endVert.Length; j++)
                {
                    adjVect += endVect[j] * W(endVert[j], adj); // Расчет вероятностей по графу
                }

                endVect = adjVect.Clone();
                endVert = new int[adj.Length];
                Array.Copy(adj, endVert, adj.Length);
            }

            endVect /= endVect.Sum();
            return new Tuple<int[], Vector>(endVert, endVect);
        }

        /// <summary>
        /// Степень вершины в графе(число связей)
        /// </summary>
        /// <param name="g">Граф</param>
        /// <param name="vertex">Номер вершины</param>
        public static int Degree(Graph g, int vertex)
        {
            return g.Adj(vertex).Length;
        }

        /// <summary>
        /// Максимальная степень вершины в графе(число связей)
        /// </summary>
        /// <param name="g">Граф</param>
        public static int MaxDegree(Graph g)
        {
            int[] ds = new int[g.NumberOfVertex];
            for (int i = 0; i < g.NumberOfVertex; i++) ds[i] = Degree(g, i);
            return ds.Max();
        }

        /// <summary>
        /// Среднее число связей
        /// </summary>
        /// <param name="g">Граф</param>
        public static double AverageDegree(Graph g) 
        {
            return g.NumberOfArcs / g.NumberOfVertex;
        }

        /// <summary>
        /// Число петлей в графе
        /// </summary>
        /// <param name="g">Граф</param>
        public static int CountLoop(Graph g) 
        {
            int count = 0;
            for (int i = 0; i < g.NumberOfVertex; i++)
            {
                int[] vs = g.Adj(i);
                for (int j = 0; j < vs.Length; j++)
                {
                    if (vs[i] == i) count++;
                }
            }

            return count;
        }

    }
}
