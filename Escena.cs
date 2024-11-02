using System;
using System.Collections.Generic;

namespace Tarea3Grafica
{
    public class Escena
    {
        private readonly Queue<Accion> acciones;  // Cola para almacenar las acciones en orden

        public int TiempoActual { get; }
        public int c { get; }
        public int t {  get; }
        public Escena()
        {
            acciones = new Queue<Accion>();
        }

        // Método para agregar una acción a la escena
        public void AgregarAccion(Accion accion)
        {
            acciones.Enqueue(accion);
        }

        
        // Método para ejecutar las acciones en secuencia
        public void EjecutarEscena(int TiempoActual,int c,int t)
        {
            while (acciones.Count > 0)
            {
                // Extrae la primera acción de la cola
                Accion accionActual = acciones.Dequeue();
                accionActual.EjecutarTransformaciones(TiempoActual, c, t); // Ejecuta la acción
            }
        }
    }
}
