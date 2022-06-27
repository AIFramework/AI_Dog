using AI.DataStructs.Algebraic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIDog.Graphs.BaseGraph
{
    /// <summary>
    /// Вершина
    /// </summary>
    [Serializable]
    public class Vertex
    {
        public Vector VertexVector { get; set; }
        public string Name { get; set; }

        public Vertex(string name, Vector vector)
        {
            Name = name;
            VertexVector = vector;
        }

        public Vertex(string name)
        {
            Name = name;
            VertexVector = new Vector();
        }

        /// <summary>
        /// Получение верщины по имени
        /// </summary>
        /// <param name="vertices">Вершины</param>
        /// <param name="name">Имя</param>
        public static Vertex FromName(Vertex[] vertices, string name) 
        {
            foreach (var item in vertices)
            {
                if(item.Name == name) return item;
            }

            throw new Exception($"no Vertex with name: \"{name}\"");
        }
    }
}
