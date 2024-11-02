using System;
using System.Collections.Generic;
using OpenTK;

namespace Tarea3Grafica
{
    public enum TipoTransformacion
    {
        Trasladar,
        Rotar,
        Escalar
    }

    public class Accion
    {
        // Clase para almacenar los detalles de una transformación
        private class Transformacion
        {
            public TipoTransformacion Tipo { get; }
            public Parte Parte { get; }
            public Vector3 ParametroVector { get; }
            public Vector3 Eje { get; }
            public int IdPoligono { get; }
            public Parte ParteConectada { get; }
            public float AnguloMaximo { get; }
            public int InicioMs { get; set; }
            public int FinMs { get; set; }
            public int TiempoActual { get; }

            // Constructor para traslación y escalado
            public Transformacion(TipoTransformacion tipo, Parte parte, Vector3 parametroVector, int inicioMs, int finMs, int tiempoActual)
            {
                Tipo = tipo;
                Parte = parte;
                ParametroVector = parametroVector;
                InicioMs = inicioMs;
                FinMs = finMs;
                TiempoActual = tiempoActual;
            }

            // Constructor para rotación simple
            public Transformacion(TipoTransformacion tipo, Parte parte, Vector3 eje, int idPoligono, float anguloMaximo, int inicioMs, int finMs, int tiempoActual)
            {
                Tipo = tipo;
                Parte = parte;
                Eje = eje;
                IdPoligono = idPoligono;
                AnguloMaximo = anguloMaximo;
                InicioMs = inicioMs;
                FinMs = finMs;
                TiempoActual = tiempoActual;
            }

            // Constructor para rotación con parte conectada
            public Transformacion(TipoTransformacion tipo, Parte parte, Vector3 eje, int idPoligono, Parte parteConectada, float anguloMaximo, int inicioMs, int finMs, int tiempoActual)
            {
                Tipo = tipo;
                Parte = parte;
                Eje = eje;
                IdPoligono = idPoligono;
                ParteConectada = parteConectada;
                AnguloMaximo = anguloMaximo;
                InicioMs = inicioMs;
                FinMs = finMs;
                TiempoActual = tiempoActual;
            }
        }

        private IList<Transformacion> transformaciones = new List<Transformacion>();
        private int tiempoActual;

        public Accion(int tiempoInicial)
        {
            tiempoActual = tiempoInicial;
        }

        // Métodos para agregar transformaciones con tiempo
        public void AgregarTraslacion(Parte parte, Vector3 desplazamiento, int inicioMs, int finMs, int tiempoActual)
        {
            transformaciones.Add(new Transformacion(TipoTransformacion.Trasladar, parte, desplazamiento, inicioMs, finMs, tiempoActual));
        }
        /*
        public void AgregarEscalado(Parte parte, Vector3 factorEscalado)
        {
            transformaciones.Add(new Transformacion(TipoTransformacion.Escalar, parte, factorEscalado, 0, 0), tiempoActual); // Escalado no depende de tiempo
        }*/

        public void AgregarRotacion(Parte parte, Vector3 eje, int idPoligono, float anguloMaximo, int inicioMs, int finMs, int tiempoActual)
        {
            transformaciones.Add(new Transformacion(TipoTransformacion.Rotar, parte, eje, idPoligono, anguloMaximo, inicioMs, finMs, tiempoActual));
        }

        public void AgregarRotacionConParteConectada(Parte parte, Vector3 eje, int idPoligono, Parte parteConectada, float anguloMaximo, int inicioMs, int finMs, int tiempoActual)
        {
            transformaciones.Add(new Transformacion(TipoTransformacion.Rotar, parte, eje, idPoligono, parteConectada, anguloMaximo, inicioMs, finMs, tiempoActual));
        }

        // Ejecutar transformaciones con soporte para el tiempo actual

        public void EjecutarTransformaciones(int tiempoActual, int numRepeticiones, int incrementoTiempo)
        {
            this.tiempoActual = tiempoActual;

            for (int i = 0; i < numRepeticiones; i++)
            {
                // Guardar los valores iniciales de InicioMs y FinMs
                int inicioOriginal = transformaciones[0].InicioMs;
                int finOriginal = transformaciones[0].FinMs;

                foreach (var transformacion in transformaciones)
                {
                    switch (transformacion.Tipo)
                    {
                        case TipoTransformacion.Escalar:
                            transformacion.Parte.EscalarParte(transformacion.ParametroVector, transformacion.InicioMs, transformacion.FinMs);
                            break;

                        case TipoTransformacion.Rotar:
                            if (transformacion.ParteConectada != null)
                            {
                                transformacion.Parte.RotarPartePoli2(
                                    transformacion.AnguloMaximo,
                                    transformacion.Eje,
                                    transformacion.IdPoligono,
                                    transformacion.ParteConectada,
                                    transformacion.InicioMs,
                                    transformacion.FinMs,
                                    tiempoActual
                                );
                            }
                            else
                            {
                                transformacion.Parte.RotarPartePoli(
                                    transformacion.AnguloMaximo,
                                    transformacion.Eje,
                                    transformacion.IdPoligono,
                                    transformacion.InicioMs,
                                    transformacion.FinMs,
                                    tiempoActual
                                );
                            }
                            break;
                    }

                    // Restaurar los valores iniciales de InicioMs y FinMs para la siguiente iteración
                    transformacion.InicioMs = inicioOriginal;
                    transformacion.FinMs = finOriginal;
                }

                // Incrementar InicioMs y FinMs después de que todas las transformaciones se hayan ejecutado en esta iteración
                if (i < numRepeticiones - 1)
                {
                    foreach (var transformacion in transformaciones)
                    {
                        transformacion.InicioMs += incrementoTiempo;
                        transformacion.FinMs += incrementoTiempo;
                    }
                }
            }
        }




        // Método para actualizar el tiempo actual si es necesario
        public void ActualizarTiempo(int nuevoTiempo)
        {
            this.tiempoActual = nuevoTiempo;
        }
    }
}
