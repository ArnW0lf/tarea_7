using OpenTK.Graphics;
using System.Collections.Generic;

namespace Tarea3Grafica
{
    public class Vertice
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vertice(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        private static Poligono CrearPoligonoConColor(Color4 color, params Vertice[] vertices)
        {
            var poligono = new Poligono();
            for (int i = 0; i < vertices.Length; i++)
            {
                poligono.Add(i, vertices[i]);
            }
            poligono.Color = color;
            return poligono;
        }

        public static Dictionary<string, Poligono> CrearPoligonos()
        {
            var poligonos = new Dictionary<string, Poligono>();

            // Colores
            var amarillo = new Color4(1.0f, 1.0f, 0.0f, 1.0f);
            var blanco = new Color4(1.0f, 1.0f, 1.0f, 1.0f);
            var verde = new Color4(0.0f, 1.0f, 0.0f, 1.0f);
            var rojo = new Color4(1.0f, 0.0f, 0.0f, 0.0f);

            // Crear los polígonos para la parte vertical
            poligonos["caraFrontalV"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(0.2f, 0.8f, 0.0f),
                new Vertice(0.2f, -0.8f, 0.0f),
                new Vertice(-0.2f, -0.8f, 0.0f),
                new Vertice(-0.2f, 0.8f, 0.0f));

            poligonos["caraTraseraV"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(0.2f, 0.8f, 0.4f),
                new Vertice(0.2f, -0.8f, 0.4f),
                new Vertice(-0.2f, -0.8f, 0.4f),
                new Vertice(-0.2f, 0.8f, 0.4f));

            poligonos["caraDerechaV"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(0.2f, 0.8f, 0.4f),
                new Vertice(0.2f, -0.8f, 0.4f),
                new Vertice(0.2f, -0.8f, 0.0f),
                new Vertice(0.2f, 0.8f, 0.0f));

            poligonos["caraIzquierdaV"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(-0.2f, 0.8f, 0.0f),
                new Vertice(-0.2f, 0.8f, 0.4f),
                new Vertice(-0.2f, -0.8f, 0.4f),
                new Vertice(-0.2f, -0.8f, 0.0f));

            poligonos["caraSuperiorV"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(0.2f, 0.8f, 0.4f),
                new Vertice(0.2f, 0.8f, 0.0f),
                new Vertice(-0.2f, 0.8f, 0.0f),
                new Vertice(-0.2f, 0.8f, 0.4f));

            poligonos["caraInferiorV"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(0.2f, -0.8f, 0.0f),
                new Vertice(0.2f, -0.8f, 0.4f),
                new Vertice(-0.2f, -0.8f, 0.4f),
                new Vertice(-0.2f, -0.8f, 0.0f));

            // Crear los polígonos para la parte superior de la T
            poligonos["caraTraseraH"] = CrearPoligonoConColor(
                blanco,
                new Vertice(0.7f, 1.1f, 0.0f),
                new Vertice(0.7f, 0.8f, 0.0f),
                new Vertice(-0.7f, 0.8f, 0.0f),
                new Vertice(-0.7f, 1.1f, 0.0f));

            poligonos["caraFrontalH"] = CrearPoligonoConColor(
                blanco,
                new Vertice(0.7f, 1.1f, 0.4f),
                new Vertice(0.7f, 0.8f, 0.4f),
                new Vertice(-0.7f, 0.8f, 0.4f),
                new Vertice(-0.7f, 1.1f, 0.4f));

            poligonos["caraDerechaH"] = CrearPoligonoConColor(
                blanco,
                new Vertice(0.7f, 1.1f, 0.4f),
                new Vertice(0.7f, 0.8f, 0.4f),
                new Vertice(0.7f, 0.8f, 0.0f),
                new Vertice(0.7f, 1.1f, 0.0f));

            poligonos["caraIzquierdaH"] = CrearPoligonoConColor(
                blanco,
                new Vertice(-0.7f, 1.1f, 0.0f),
                new Vertice(-0.7f, 0.8f, 0.0f),
                new Vertice(-0.7f, 0.8f, 0.4f),
                new Vertice(-0.7f, 1.1f, 0.4f));

            poligonos["caraSuperiorH"] = CrearPoligonoConColor(
                blanco,
                new Vertice(0.7f, 1.1f, 0.4f),
                new Vertice(0.7f, 1.1f, 0.0f),
                new Vertice(-0.7f, 1.1f, 0.0f),
                new Vertice(-0.7f, 1.1f, 0.4f));

            poligonos["caraInferiorH"] = CrearPoligonoConColor(
                blanco,
                new Vertice(0.7f, 0.8f, 0.0f),
                new Vertice(0.7f, 0.8f, 0.4f),
                new Vertice(-0.7f, 0.8f, 0.4f),
                new Vertice(-0.7f, 0.8f, 0.0f));

            //CABECA
            poligonos["caraFrontalC"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.63f, 0.07f, 0.25f),
                new Vertice(1.63f, -0.05f, 0.25f),
                new Vertice(1.63f, -0.05f, 0.15f),
                new Vertice(1.63f, 0.07f, 0.15f));

            poligonos["caraTraseraC"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, 0.07f, 0.25f),
                new Vertice(1.75f, -0.05f, 0.25f),
                new Vertice(1.75f, -0.05f, 0.15f),
                new Vertice(1.75f, 0.07f, 0.15f));

            poligonos["caraDerechaC"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, 0.07f, 0.25f),
                new Vertice(1.75f, -0.05f, 0.25f),
                new Vertice(1.63f, -0.05f, 0.25f),
                new Vertice(1.63f, 0.07f, 0.25f));

            poligonos["caraIzquierdaC"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, 0.07f, 0.15f),
                new Vertice(1.75f, -0.05f, 0.15f),
                new Vertice(1.63f, -0.05f, 0.15f),
                new Vertice(1.63f, 0.07f, 0.15f));

            poligonos["caraSuperiorC"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, 0.075f, 0.25f),
                new Vertice(1.75f, 0.075f, 0.15f),
                new Vertice(1.63f, 0.075f, 0.15f),
                new Vertice(1.63f, 0.075f, 0.25f));

            poligonos["caraInferiorC"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.05f, 0.15f),
                new Vertice(1.75f, -0.05f, 0.25f),
                new Vertice(1.63f, -0.05f, 0.25f),
                new Vertice(1.63f, -0.05f, 0.15f));

            //tronco

            poligonos["caraFrontalT"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.75f, -0.1f, 0.1f),
                new Vertice(1.75f, -0.4f, 0.1f),
                new Vertice(1.65f, -0.4f, 0.1f),
                new Vertice(1.63f, -0.1f, 0.1f));

            poligonos["caraTraseraT"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.75f, -0.1f, 0.3f),
                new Vertice(1.75f, -0.4f, 0.3f),
                new Vertice(1.63f, -0.4f, 0.3f),
                new Vertice(1.63f, -0.1f, 0.3f));
            
            poligonos["caraDerechaT"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.75f, -0.1f, 0.3f),
                new Vertice(1.75f, -0.4f, 0.3f),
                new Vertice(1.75f, -0.4f, 0.1f),
                new Vertice(1.75f, -0.1f, 0.1f));
            
            poligonos["caraIzquierdaT"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.63f, -0.1f, 0.3f),
                new Vertice(1.63f, -0.4f, 0.3f),
                new Vertice(1.63f, -0.4f, 0.1f),
                new Vertice(1.63f, -0.1f, 0.1f));
            
            poligonos["caraSuperiorT"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.75f, -0.1f, 0.3f),
                new Vertice(1.75f, -0.1f, 0.1f),
                new Vertice(1.63f, -0.1f, 0.1f),
                new Vertice(1.63f, -0.1f, 0.3f));
            
            poligonos["caraInferiorT"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.75f, -0.4f, 0.1f),
                new Vertice(1.75f, -0.4f, 0.3f),
                new Vertice(1.63f, -0.4f, 0.3f),
                new Vertice(1.63f, -0.4f, 0.1f));

            //brazo derecho
            poligonos["caraFrontalBD"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.75f, -0.1f, 0.0f),
                new Vertice(1.75f, -0.3f, 0.0f),
                new Vertice(1.65f, -0.3f, 0.0f),
                new Vertice(1.65f, -0.1f, 0.0f));

            poligonos["caraTraseraBD"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.75f, -0.1f, 0.1f),
                new Vertice(1.75f, -0.3f, 0.1f),
                new Vertice(1.65f, -0.3f, 0.1f),
                new Vertice(1.65f, -0.1f, 0.1f));
            
            poligonos["caraDerechaBD"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.75f, -0.1f, 0.1f),
                new Vertice(1.75f, -0.3f, 0.1f),
                new Vertice(1.75f, -0.3f, 0.0f),
                new Vertice(1.75f, -0.1f, 0.0f));

            poligonos["caraIzquierdaBD"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.65f, -0.1f, 0.1f),
                new Vertice(1.65f, -0.3f, 0.1f),
                new Vertice(1.65f, -0.3f, 0.0f),
                new Vertice(1.65f, -0.1f, 0.0f));

            poligonos["caraSuperiorBD"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.75f, -0.1f, 0.1f),
                new Vertice(1.75f, -0.1f, 0.0f),
                new Vertice(1.65f, -0.1f, 0.0f),
                new Vertice(1.65f, -0.1f, 0.1f));

            poligonos["caraInferiorBD"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.75f, -0.3f, 0.0f),
                new Vertice(1.75f, -0.3f, 0.1f),
                new Vertice(1.65f, -0.3f, 0.1f),
                new Vertice(1.65f, -0.3f, 0.0f));

            //antebrazo derecho
            poligonos["caraFrontalAD"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.3f, 0.0f),
                new Vertice(1.75f, -0.5f, 0.0f),
                new Vertice(1.65f, -0.5f, 0.0f),
                new Vertice(1.65f, -0.3f, 0.0f));

            poligonos["caraTraseraAD"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.3f, 0.1f),
                new Vertice(1.75f, -0.5f, 0.1f),
                new Vertice(1.65f, -0.5f, 0.1f),
                new Vertice(1.65f, -0.3f, 0.1f));

            poligonos["caraDerechaAD"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.3f, 0.1f),
                new Vertice(1.75f, -0.5f, 0.1f),
                new Vertice(1.75f, -0.5f, 0.0f),
                new Vertice(1.75f, -0.3f, 0.0f));

            poligonos["caraIzquierdaAD"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.65f, -0.3f, 0.1f),
                new Vertice(1.65f, -0.5f, 0.1f),
                new Vertice(1.65f, -0.5f, 0.0f),
                new Vertice(1.65f, -0.3f, 0.0f));

            poligonos["caraSuperiorAD"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.3f, 0.1f),
                new Vertice(1.75f, -0.3f, 0.0f),
                new Vertice(1.65f, -0.3f, 0.0f),
                new Vertice(1.65f, -0.3f, 0.1f));

            poligonos["caraInferiorAD"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.5f, 0.0f),
                new Vertice(1.75f, -0.5f, 0.1f),
                new Vertice(1.65f, -0.5f, 0.1f),
                new Vertice(1.65f, -0.5f, 0.0f));

            //brazo izquierdo
            poligonos["caraFrontalBI"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.75f, -0.1f, 0.3f),
                new Vertice(1.75f, -0.3f, 0.3f),
                new Vertice(1.65f, -0.3f, 0.3f),
                new Vertice(1.65f, -0.1f, 0.3f));

            poligonos["caraTraseraBI"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.75f, -0.1f, 0.4f),
                new Vertice(1.75f, -0.3f, 0.4f),
                new Vertice(1.65f, -0.3f, 0.4f),
                new Vertice(1.65f, -0.1f, 0.4f));

            poligonos["caraDerechaBI"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.75f, -0.1f, 0.4f),
                new Vertice(1.75f, -0.3f, 0.4f),
                new Vertice(1.75f, -0.3f, 0.3f),
                new Vertice(1.75f, -0.1f, 0.3f));

            poligonos["caraIzquierdaBI"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.65f, -0.1f, 0.4f),
                new Vertice(1.65f, -0.3f, 0.4f),
                new Vertice(1.65f, -0.3f, 0.3f),
                new Vertice(1.65f, -0.1f, 0.3f));

            poligonos["caraSuperiorBI"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.75f, -0.1f, 0.4f),
                new Vertice(1.75f, -0.1f, 0.3f),
                new Vertice(1.65f, -0.1f, 0.3f),
                new Vertice(1.65f, -0.1f, 0.4f));

            poligonos["caraInferiorBI"] = CrearPoligonoConColor(
                verde,
                new Vertice(1.75f, -0.3f, 0.3f),
                new Vertice(1.75f, -0.3f, 0.4f),
                new Vertice(1.65f, -0.3f, 0.4f),
                new Vertice(1.65f, -0.3f, 0.3f));
            
            //antebrazo izquierdo
            poligonos["caraFrontalAI"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.3f, 0.3f),
                new Vertice(1.75f, -0.5f, 0.3f),
                new Vertice(1.65f, -0.5f, 0.3f),
                new Vertice(1.65f, -0.3f, 0.3f));

            poligonos["caraTraseraAI"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.3f, 0.4f),
                new Vertice(1.75f, -0.5f, 0.4f),
                new Vertice(1.65f, -0.5f, 0.4f),
                new Vertice(1.65f, -0.3f, 0.4f));

            poligonos["caraDerechaAI"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.3f, 0.4f),
                new Vertice(1.75f, -0.5f, 0.4f),
                new Vertice(1.75f, -0.5f, 0.3f),
                new Vertice(1.75f, -0.3f, 0.3f));

            poligonos["caraIzquierdaAI"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.65f, -0.3f, 0.4f),
                new Vertice(1.65f, -0.5f, 0.4f),
                new Vertice(1.65f, -0.5f, 0.3f),
                new Vertice(1.65f, -0.3f, 0.3f));

            poligonos["caraSuperiorAI"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.3f, 0.4f),
                new Vertice(1.75f, -0.3f, 0.3f),
                new Vertice(1.65f, -0.3f, 0.3f),
                new Vertice(1.65f, -0.3f, 0.4f));

            poligonos["caraInferiorAI"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.5f, 0.3f),
                new Vertice(1.75f, -0.5f, 0.4f),
                new Vertice(1.65f, -0.5f, 0.4f),
                new Vertice(1.65f, -0.5f, 0.3f));
            //Muslo derecho
            poligonos["caraFrontalMD"] = CrearPoligonoConColor(
                rojo,
                new Vertice(1.75f, -0.4f, 0.1f),
                new Vertice(1.75f, -0.6f, 0.1f),
                new Vertice(1.65f, -0.6f, 0.1f),
                new Vertice(1.65f, -0.4f, 0.1f));

            poligonos["caraTraseraMD"] = CrearPoligonoConColor(
                rojo,
                new Vertice(1.75f, -0.4f, 0.2f),
                new Vertice(1.75f, -0.6f, 0.2f),
                new Vertice(1.65f, -0.6f, 0.2f),
                new Vertice(1.65f, -0.4f, 0.2f));

            poligonos["caraDerechaMD"] = CrearPoligonoConColor(
                rojo,
                new Vertice(1.75f, -0.4f, 0.2f),
                new Vertice(1.75f, -0.6f, 0.2f),
                new Vertice(1.75f, -0.6f, 0.1f),
                new Vertice(1.75f, -0.4f, 0.1f));

            poligonos["caraIzquierdaMD"] = CrearPoligonoConColor(
                rojo,
                new Vertice(1.65f, -0.4f, 0.2f),
                new Vertice(1.65f, -0.6f, 0.2f),
                new Vertice(1.65f, -0.6f, 0.1f),
                new Vertice(1.65f, -0.4f, 0.1f));

            poligonos["caraSuperiorMD"] = CrearPoligonoConColor(
                rojo,
                new Vertice(1.75f, -0.4f, 0.2f),
                new Vertice(1.75f, -0.4f, 0.1f),
                new Vertice(1.65f, -0.4f, 0.1f),
                new Vertice(1.65f, -0.4f, 0.2f));

            poligonos["caraInferiorMD"] = CrearPoligonoConColor(
                rojo,
                new Vertice(1.75f, -0.6f, 0.1f),
                new Vertice(1.75f, -0.6f, 0.2f),
                new Vertice(1.65f, -0.6f, 0.2f),
                new Vertice(1.65f, -0.6f, 0.1f));

            //pierna derecha
            poligonos["caraFrontalPD"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.6f, 0.1f),
                new Vertice(1.75f, -0.8f, 0.1f),
                new Vertice(1.65f, -0.8f, 0.1f),
                new Vertice(1.65f, -0.6f, 0.1f));

            poligonos["caraTraseraPD"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.6f, 0.2f),
                new Vertice(1.75f, -0.8f, 0.2f),
                new Vertice(1.65f, -0.8f, 0.2f),
                new Vertice(1.65f, -0.6f, 0.2f));

            poligonos["caraDerechaPD"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.6f, 0.2f),
                new Vertice(1.75f, -0.8f, 0.2f),
                new Vertice(1.75f, -0.8f, 0.1f),
                new Vertice(1.75f, -0.6f, 0.1f));

            poligonos["caraIzquierdaPD"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.65f, -0.6f, 0.2f),
                new Vertice(1.65f, -0.8f, 0.2f),
                new Vertice(1.65f, -0.8f, 0.1f),
                new Vertice(1.65f, -0.6f, 0.1f));

            poligonos["caraSuperiorPD"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.6f, 0.2f),
                new Vertice(1.75f, -0.6f, 0.1f),
                new Vertice(1.65f, -0.6f, 0.1f),
                new Vertice(1.65f, -0.6f, 0.2f));

            poligonos["caraInferiorPD"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.8f, 0.1f),
                new Vertice(1.75f, -0.8f, 0.2f),
                new Vertice(1.65f, -0.8f, 0.2f),
                new Vertice(1.65f, -0.8f, 0.1f));
            //Muslo izquierdo
            poligonos["caraFrontalMI"] = CrearPoligonoConColor(
                rojo,
                new Vertice(1.75f, -0.4f, 0.2f),
                new Vertice(1.75f, -0.6f, 0.2f),
                new Vertice(1.65f, -0.6f, 0.2f),
                new Vertice(1.65f, -0.4f, 0.2f));

            poligonos["caraTraseraMI"] = CrearPoligonoConColor(
                rojo,
                new Vertice(1.75f, -0.4f, 0.3f),
                new Vertice(1.75f, -0.6f, 0.3f),
                new Vertice(1.65f, -0.6f, 0.3f),
                new Vertice(1.65f, -0.4f, 0.3f));

            poligonos["caraDerechaMI"] = CrearPoligonoConColor(
                rojo,
                new Vertice(1.75f, -0.4f, 0.3f),
                new Vertice(1.75f, -0.6f, 0.3f),
                new Vertice(1.75f, -0.6f, 0.2f),
                new Vertice(1.75f, -0.4f, 0.2f));

            poligonos["caraIzquierdaMI"] = CrearPoligonoConColor(
                rojo,
                new Vertice(1.65f, -0.4f, 0.3f),
                new Vertice(1.65f, -0.6f, 0.3f),
                new Vertice(1.65f, -0.6f, 0.2f),
                new Vertice(1.65f, -0.4f, 0.2f));

            poligonos["caraSuperiorMI"] = CrearPoligonoConColor(
                rojo,
                new Vertice(1.75f, -0.4f, 0.3f),
                new Vertice(1.75f, -0.4f, 0.2f),
                new Vertice(1.65f, -0.4f, 0.2f),
                new Vertice(1.65f, -0.4f, 0.3f));

            poligonos["caraInferiorMI"] = CrearPoligonoConColor(
                rojo,
                new Vertice(1.75f, -0.6f, 0.2f),
                new Vertice(1.75f, -0.6f, 0.3f),
                new Vertice(1.65f, -0.6f, 0.3f),
                new Vertice(1.65f, -0.6f, 0.2f));

            //Pierna Izquierda
            poligonos["caraFrontalPI"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.6f, 0.2f),////////////////////
                new Vertice(1.75f, -0.8f, 0.2f),
                new Vertice(1.65f, -0.8f, 0.2f),
                new Vertice(1.65f, -0.6f, 0.2f));

            poligonos["caraTraseraPI"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.6f, 0.3f),
                new Vertice(1.75f, -0.8f, 0.3f),
                new Vertice(1.65f, -0.8f, 0.3f),
                new Vertice(1.65f, -0.6f, 0.3f));

            poligonos["caraDerechaPI"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.6f, 0.3f),
                new Vertice(1.75f, -0.8f, 0.3f),
                new Vertice(1.65f, -0.8f, 0.2f),
                new Vertice(1.65f, -0.6f, 0.2f));

            poligonos["caraIzquierdaPI"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.65f, -0.6f, 0.3f),
                new Vertice(1.65f, -0.8f, 0.3f),
                new Vertice(1.65f, -0.8f, 0.2f),
                new Vertice(1.65f, -0.6f, 0.2f));

            poligonos["caraSuperiorPI"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.6f, 0.3f),
                new Vertice(1.75f, -0.6f, 0.2f),
                new Vertice(1.75f, -0.6f, 0.2f),
                new Vertice(1.75f, -0.6f, 0.3f));

            poligonos["caraInferiorPI"] = CrearPoligonoConColor(
                amarillo,
                new Vertice(1.75f, -0.8f, 0.2f),
                new Vertice(1.75f, -0.8f, 0.3f),
                new Vertice(1.65f, -0.8f, 0.3f),
                new Vertice(1.65f, -0.8f, 0.2f));
            return poligonos;
        }
    }
}