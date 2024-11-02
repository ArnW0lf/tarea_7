using System;
using System.Collections.Generic;
using OpenTK;

namespace Tarea3Grafica
{
    public class Objeto
    {
        private List<Parte> partes = new List<Parte>();
        private List<int> ids = new List<int>();
        public CentroDeMasa CentroDeMasa { get; private set; }

        public Objeto()
        {
            CentroDeMasa = new CentroDeMasa(0f, 0f, 0f);
        }

        public void Add(int id, Parte parte)
        {
            int index = ids.IndexOf(id);
            if (index >= 0)
            {
                partes[index] = parte;
            }
            else
            {
                ids.Add(id);
                partes.Add(parte);
            }
        }

        public Parte Get(int id)
        {
            int index = ids.IndexOf(id);
            if (index >= 0)
            {
                return partes[index];
            }
            return null;
        }

        public void Delete(int id)
        {
            int index = ids.IndexOf(id);
            if (index >= 0)
            {
                ids.RemoveAt(index);
                partes.RemoveAt(index);
            }
        }

        public void Draw()
        {
            foreach (var parte in partes)
            {
                parte.Draw();
            }
        }

        // Rotación progresiva basada en tiempo
        public void RotarObjeto(float anguloMaximo, Vector3 eje, int inicioMs, int finMs, int tiempoActual)
        {
            if (tiempoActual < inicioMs || tiempoActual > finMs) return;

            Vector3 centro = new Vector3(CentroDeMasa.X, CentroDeMasa.Y, CentroDeMasa.Z);
            float progreso = (tiempoActual - inicioMs) / (float)(finMs - inicioMs); // Progreso de 0 a 1
            float anguloAplicar = progreso * anguloMaximo;

            foreach (var parte in partes)
            {
                foreach (var poligono in parte.GetPoligonos())
                {
                    poligono.AplicarTransformacion(v => Transformacion.Rotar(v, centro, anguloAplicar, eje));
                }
            }
        }

        // Escalado progresivo basado en tiempo
        public void EscalarObjeto(Vector3 factorEscalado, int inicioMs, int finMs, int tiempoActual)
        {
            if (tiempoActual < inicioMs || tiempoActual > finMs) return;

            Vector3 centro = new Vector3(CentroDeMasa.X, CentroDeMasa.Y, CentroDeMasa.Z);
            float progreso = (tiempoActual - inicioMs) / (float)(finMs - inicioMs);
            Vector3 escalaAplicar = new Vector3(1 + progreso * (factorEscalado.X - 1),
                                                1 + progreso * (factorEscalado.Y - 1),
                                                1 + progreso * (factorEscalado.Z - 1));

            foreach (var parte in partes)
            {
                foreach (var poligono in parte.GetPoligonos())
                {
                    poligono.AplicarTransformacion(v => Transformacion.Escalar(v, centro, escalaAplicar));
                }
            }
        }

        // Traslación progresiva basada en tiempo
        public void TrasladarObjeto(Vector3 vectorTraslacion, int inicioMs, int finMs, int tiempoActual)
        {
            if (tiempoActual < inicioMs || tiempoActual > finMs) return;

            float progreso = (tiempoActual - inicioMs) / (float)(finMs - inicioMs);
            Vector3 desplazamientoAplicar = vectorTraslacion * progreso;

            foreach (var parte in partes)
            {
                foreach (var poligono in parte.GetPoligonos())
                {
                    poligono.AplicarTransformacion(v => Transformacion.Trasladar(v, desplazamientoAplicar));
                }
            }
        }

        // Movimiento progresivo basado en tiempo con desplazamiento hacia un punto destino
        public void MoverObjeto(Vector3 puntoDestino, int inicioMs, int finMs, int tiempoActual)
        {
            if (tiempoActual < inicioMs || tiempoActual > finMs) return;

            Vector3 posicionActual = new Vector3(CentroDeMasa.X, CentroDeMasa.Y, CentroDeMasa.Z);
            Vector3 direccion = Vector3.Normalize(puntoDestino - posicionActual);
            float distanciaTotal = Vector3.Distance(posicionActual, puntoDestino);
            float progreso = (tiempoActual - inicioMs) / (float)(finMs - inicioMs); // Progreso de 0 a 1
            float distanciaAplicar = progreso * distanciaTotal;

            Vector3 desplazamiento = direccion * distanciaAplicar;

            // Aplicar el desplazamiento
            TrasladarObjeto(desplazamiento, inicioMs, finMs, tiempoActual);

            // Recalcular el centro de masa
            CalcularCentroDeMasa();
        }

        // Método para calcular el centro de masa del objeto completo
        private void CalcularCentroDeMasa()
        {
            float sumaX = 0, sumaY = 0, sumaZ = 0;
            int totalPartes = partes.Count;

            if (totalPartes > 0)
            {
                foreach (var parte in partes)
                {
                    if (parte.CentroDeMasa != null)
                    {
                        sumaX += parte.CentroDeMasa.X;
                        sumaY += parte.CentroDeMasa.Y;
                        sumaZ += parte.CentroDeMasa.Z;
                    }
                }
                CentroDeMasa = new CentroDeMasa(sumaX / totalPartes, sumaY / totalPartes, sumaZ / totalPartes);
            }
        }
    }
}
