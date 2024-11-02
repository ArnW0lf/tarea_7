using System.Collections.Generic;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using System.Linq;

namespace Tarea3Grafica
{
    public class Poligono
    {
        private Dictionary<int, Vertice> vertices = new Dictionary<int, Vertice>();
        public Color4 Color { get; set; }

        public void Add(int id, Vertice vertice)
        {
            vertices[id] = vertice;
        }

        public Vertice Get(int id)
        {
            return vertices.ContainsKey(id) ? vertices[id] : null;
        }

        public void Delete(int id)
        {
            vertices.Remove(id);
        }

        public void Draw()
        {
            GL.Begin(PrimitiveType.Polygon);
            GL.Color4(Color);
            foreach (var vertice in vertices.Values)
            {
                GL.Vertex3(vertice.X, vertice.Y, vertice.Z);
            }
            GL.End();
        }

        // Método público para obtener todos los vértices
        public IEnumerable<Vertice> GetVertices()
        {
            return vertices.Values;
        }

        // Aplicar una transformación a todos los vértices del polígono
        public void AplicarTransformacion(System.Func<Vector3, Vector3> transformacion)
        {
            List<int> keys = new List<int>(vertices.Keys);

            foreach (int key in keys)
            {
                Vertice vertice = vertices[key];
                Vector3 posicion = new Vector3(vertice.X, vertice.Y, vertice.Z);
                Vector3 nuevaPosicion = transformacion(posicion);
                vertices[key] = new Vertice(nuevaPosicion.X, nuevaPosicion.Y, nuevaPosicion.Z);
            }
        }
    }
}

