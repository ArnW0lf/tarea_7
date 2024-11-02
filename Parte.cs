using System;
using System.Collections.Generic;
using OpenTK;

namespace Tarea3Grafica
{
    public class Parte
    {
        private List<Poligono> poligonos = new List<Poligono>();
        private List<int> ids = new List<int>();
        public CentroDeMasa CentroDeMasa { get; private set; }

        private Dictionary<int, float> angulosAcumulados = new Dictionary<int, float>();

        public void Add(int id, Poligono poligono)
        {
            int index = ids.IndexOf(id);
            if (index >= 0)
            {
                poligonos[index] = poligono;
            }
            else
            {
                ids.Add(id);
                poligonos.Add(poligono);
            }
            CalcularCentroDeMasa();
        }

        public Poligono Get(int id)
        {
            int index = ids.IndexOf(id);
            return index >= 0 ? poligonos[index] : null;
        }

        public void Delete(int id)
        {
            int index = ids.IndexOf(id);
            if (index >= 0)
            {
                ids.RemoveAt(index);
                poligonos.RemoveAt(index);
            }
            CalcularCentroDeMasa();
        }

        public void Draw()
        {
            foreach (var poligono in poligonos)
            {
                poligono.Draw();
            }
        }

        public List<Poligono> GetPoligonos()
        {
            return poligonos;
        }

        private void CalcularCentroDeMasa()
        {
            float sumaX = 0, sumaY = 0, sumaZ = 0;
            int totalVertices = 0;

            foreach (var poligono in poligonos)
            {
                foreach (var vertice in poligono.GetVertices())
                {
                    sumaX += vertice.X;
                    sumaY += vertice.Y;
                    sumaZ += vertice.Z;
                    totalVertices++;
                }
            }

            if (totalVertices > 0)
            {
                CentroDeMasa = new CentroDeMasa(sumaX / totalVertices, sumaY / totalVertices, sumaZ / totalVertices);
            }
        }

        private Vector3 CalcularCentroDeMasaPoligono(Poligono poligono)
        {
            float sumaX = 0, sumaY = 0, sumaZ = 0;
            int totalVertices = 0;

            foreach (var vertice in poligono.GetVertices())
            {
                sumaX += vertice.X;
                sumaY += vertice.Y;
                sumaZ += vertice.Z;
                totalVertices++;
            }

            return totalVertices > 0 ? new Vector3(sumaX / totalVertices, sumaY / totalVertices, sumaZ / totalVertices) : Vector3.Zero;
        }

        // Método modificado para trasladar con tiempo
        public void TrasladarParte(Vector3 desplazamiento, int inicioMs, int finMs)
        {
            float duracion = (finMs - inicioMs) / 1000f;
            Vector3 velocidad = desplazamiento / duracion;

            foreach (var poligono in poligonos)
            {
                poligono.AplicarTransformacion(v => Transformacion.Trasladar(v, velocidad * duracion));
            }
            CalcularCentroDeMasa();
        }

        // Método modificado para rotar una parte con tiempo
        public void RotarPartePoli(float anguloMaximo, Vector3 eje, int idPoligono, int inicioMs, int finMs, int tiempoActual)
        {
            if (!angulosAcumulados.ContainsKey(idPoligono))
            {
                angulosAcumulados[idPoligono] = 0f;
            }

            if (tiempoActual < inicioMs || tiempoActual > finMs)
            {
                return;
            }

            float progreso = (tiempoActual - inicioMs) / (float)(finMs - inicioMs); // Progreso de 0 a 1

            float anguloDeseado = progreso * anguloMaximo;

            float anguloAplicar = anguloDeseado - angulosAcumulados[idPoligono];
            angulosAcumulados[idPoligono] = anguloDeseado;

            Poligono poligono = Get(idPoligono);
            if (poligono != null)
            {
                Vector3 centro = CalcularCentroDeMasaPoligono(poligono);
                
                foreach (var poligonoEnParte in poligonos)
                {
                    poligonoEnParte.AplicarTransformacion(v => Transformacion.Rotar(v, centro, anguloAplicar, eje));
                }

                CalcularCentroDeMasa();
            }
        }





        // Método modificado para rotar una parte y una parte conectada con tiempo
        public void RotarPartePoli2(float anguloMaximo, Vector3 eje, int idPoligono, Parte parteConectada, int inicioMs, int finMs, int tiempoActual)
        {
            if (tiempoActual < inicioMs || tiempoActual > finMs) return;

            if (!angulosAcumulados.ContainsKey(idPoligono))
            {
                angulosAcumulados[idPoligono] = 0f;
            }

            float progreso = (tiempoActual - inicioMs) / (float)(finMs - inicioMs);
            float anguloObjetivo = progreso * anguloMaximo;
            float anguloAplicar = anguloObjetivo - angulosAcumulados[idPoligono];
            angulosAcumulados[idPoligono] = anguloObjetivo;

            Poligono poligono = Get(idPoligono);
            if (poligono != null)
            {
                // Obtener el centro de masa del polígono de referencia
                Vector3 centro = CalcularCentroDeMasaPoligono(poligono);

                // Rotar todos los polígonos en la parte actual
                foreach (var poligonoEnParte in poligonos)
                {
                    poligonoEnParte.AplicarTransformacion(v => Transformacion.Rotar(v, centro, anguloAplicar, eje));
                }

                // Rotar también los polígonos de la parte conectada usando el mismo centro
                if (parteConectada != null)
                {
                    foreach (var poligonoEnParteConectada in parteConectada.GetPoligonos())
                    {
                        poligonoEnParteConectada.AplicarTransformacion(v => Transformacion.Rotar(v, centro, anguloAplicar, eje));
                    }
                }

                // Recalcular el centro de masa en ambas partes
                CalcularCentroDeMasa();
                parteConectada?.CalcularCentroDeMasa();
            }
        }





        public void EscalarParte(Vector3 factorEscalado, int inicioMs, int finMs)
        {
            float duracion = (finMs - inicioMs) / 1000f;
            Vector3 velocidadEscalado = factorEscalado / duracion;

            Vector3 centro = new Vector3(CentroDeMasa.X, CentroDeMasa.Y, CentroDeMasa.Z);
            foreach (var poligono in poligonos)
            {
                poligono.AplicarTransformacion(v => Transformacion.Escalar(v, centro, velocidadEscalado * duracion));
            }
            CalcularCentroDeMasa();
        }
    }
}