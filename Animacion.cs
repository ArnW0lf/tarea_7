using System.Collections.Generic;

namespace Tarea3Grafica
{
    public class Animacion
    {
        private readonly List<Escena> escenas;  // Lista para almacenar las escenas en secuencia
        public int TiempoActual { get; }
        public int c { get; }
        public int t { get; }
        public Animacion()
        {
            escenas = new List<Escena>();
        }

        // Método para agregar una escena a la animación
        public void AgregarEscena(Escena escena)
        {
            escenas.Add(escena);
        }

        
        // Método para ejecutar todas las escenas en secuencia
        public void EjecutarAnimacion()
        {
            foreach (var escena in escenas)
            {
                escena.EjecutarEscena(TiempoActual, c, t);  // Ejecuta cada escena en el orden en que fue agregada
            }
        }
    }
}
