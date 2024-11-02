using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Tarea3Grafica
{
    public class Game : GameWindow
    {
        private Objeto objetoT, muñeco;

        private Accion accion;
        private Escena escena;
        private Animacion animacion;

        private Stopwatch tiempoAplicacion;


        private Escenario escenario;
        private Parte parteVertical, parteHorizontal;

        private Parte Cabeza, torso, BrazoDerecho, AntebrazoDerecho, BrazoIzquierdo, AntebrazoIzquierdo,
                        MusloDerecho, PiernaDerecha, MusloIzquierdo, PiernaIzquierda;


        private float angleX = 0.0f, angleY = 0.0f;
        private const int WindowWidth = 800, WindowHeight = 800;

        public Game() : base(WindowWidth, WindowHeight, GraphicsMode.Default, "")
        {
            escenario = new Escenario();
            InicializarEscenario();

            
            var poligonos = Vertice.CrearPoligonos();
            List<Vertice> verticesParaSerializar = new List<Vertice>();

            // Extraer los vértices de cada polígono
            foreach (KeyValuePair<string, Poligono> poligono in poligonos)
            {
                verticesParaSerializar.AddRange(poligono.Value.GetVertices());
            }

            JsonHelper.Serializar(verticesParaSerializar, "vertices.json");

            var verticesDeserializados = JsonHelper.Deserializar("vertices.json");


        }

        private void InicializarEscenario()
        {
            
            muñeco = CrearMuñeco();
            objetoT = CrearObjetoT();

            Cabeza = CrearCabeza();
            torso = CrearTorso();
            BrazoDerecho = CrearBrazoDerecho();
            AntebrazoDerecho = CrearAntebrazoDerecho();
            BrazoIzquierdo = CrearBrazoIzquierdo();
            AntebrazoIzquierdo = CrearAntebrazoIzquierdo();
            MusloDerecho = CrearMusloDerecho();
            PiernaDerecha = CrearPiernaDerecha();
            MusloIzquierdo = CrearMusloIzquierdo();
            PiernaIzquierda = CrearPiernaIzquierdo();

            parteVertical = CrearParteVertical();
            parteHorizontal = CrearParteHorizontal();


            objetoT.Add(1, parteVertical);
            objetoT.Add(2, parteHorizontal);

            muñeco.Add(9, Cabeza);
            muñeco.Add(1, torso);
            muñeco.Add(2, BrazoDerecho);
            muñeco.Add(3, AntebrazoDerecho);
            muñeco.Add(4, BrazoIzquierdo);
            muñeco.Add(5, AntebrazoIzquierdo);
            muñeco.Add(6, MusloDerecho);
            muñeco.Add(7, PiernaDerecha);
            muñeco.Add(8, MusloIzquierdo);
            muñeco.Add(10, PiernaIzquierda);

            escenario.Add(1, objetoT);
            escenario.Add(2, muñeco);

        }

        private Objeto CrearObjetoT() {
            var objetoT = new Objeto();
            objetoT.Add(1, parteHorizontal);
            objetoT.Add(2, parteVertical);

            return objetoT;
        }

        private Objeto CrearMuñeco() {
            var muñeco = new Objeto();
            muñeco.Add(1, Cabeza);
            muñeco.Add(2, torso);
            muñeco.Add(3, BrazoDerecho);
            muñeco.Add(4, AntebrazoDerecho);
            muñeco.Add(5, BrazoIzquierdo);
            muñeco.Add(6, AntebrazoIzquierdo);
            muñeco.Add(7, MusloDerecho);
            muñeco.Add(8, PiernaDerecha);
            muñeco.Add(9, MusloIzquierdo);
            muñeco.Add(10, PiernaIzquierda);

            return muñeco;
        }

        private Parte CrearParteVertical()
        {
            var parteVertical = new Parte();
            var poligonos = Vertice.CrearPoligonos();
            parteVertical.Add(1, poligonos["caraFrontalV"]);
            parteVertical.Add(2, poligonos["caraTraseraV"]);
            parteVertical.Add(3, poligonos["caraDerechaV"]);
            parteVertical.Add(4, poligonos["caraIzquierdaV"]);
            parteVertical.Add(5, poligonos["caraSuperiorV"]);
            parteVertical.Add(6, poligonos["caraInferiorV"]);

            return parteVertical;
        }

        private Parte CrearCabeza()
        {
            var cabeza = new Parte();
            var poligonos = Vertice.CrearPoligonos();
            cabeza.Add(1, poligonos["caraFrontalC"]);
            cabeza.Add(2, poligonos["caraTraseraC"]);
            cabeza.Add(3, poligonos["caraDerechaC"]);
            cabeza.Add(4, poligonos["caraIzquierdaC"]);
            cabeza.Add(5, poligonos["caraSuperiorC"]);
            cabeza.Add(6, poligonos["caraInferiorC"]);

            return cabeza;
        }

        private Parte CrearTorso()
        {
            var torso = new Parte();
            var poligonos = Vertice.CrearPoligonos();
            torso.Add(1, poligonos["caraFrontalT"]);
            torso.Add(2, poligonos["caraTraseraT"]);
            torso.Add(3, poligonos["caraDerechaT"]);
            torso.Add(4, poligonos["caraIzquierdaT"]);
            torso.Add(5, poligonos["caraSuperiorT"]);
            torso.Add(6, poligonos["caraInferiorT"]);

            return torso;
        }

        private Parte CrearBrazoDerecho()
        {
            var BrazoDerecho = new Parte();
            var poligonos = Vertice.CrearPoligonos();
            BrazoDerecho.Add(1, poligonos["caraFrontalBD"]);
            BrazoDerecho.Add(2, poligonos["caraTraseraBD"]);
            BrazoDerecho.Add(3, poligonos["caraDerechaBD"]);
            BrazoDerecho.Add(4, poligonos["caraIzquierdaBD"]);
            BrazoDerecho.Add(5, poligonos["caraSuperiorBD"]);
            BrazoDerecho.Add(6, poligonos["caraInferiorBD"]);

            return BrazoDerecho;
        }

        private Parte CrearAntebrazoDerecho()
        {
            var AntebrazoDerecho = new Parte();
            var poligonos = Vertice.CrearPoligonos();
            AntebrazoDerecho.Add(1, poligonos["caraFrontalAD"]);
            AntebrazoDerecho.Add(2, poligonos["caraTraseraAD"]);
            AntebrazoDerecho.Add(3, poligonos["caraDerechaAD"]);
            AntebrazoDerecho.Add(4, poligonos["caraIzquierdaAD"]);
            AntebrazoDerecho.Add(5, poligonos["caraSuperiorAD"]);
            AntebrazoDerecho.Add(6, poligonos["caraInferiorAD"]);

            return AntebrazoDerecho;
        }

        private Parte CrearBrazoIzquierdo()
        {
            var BrazoIzquierdo = new Parte();
            var poligonos = Vertice.CrearPoligonos();
            BrazoIzquierdo.Add(1, poligonos["caraFrontalBI"]);
            BrazoIzquierdo.Add(2, poligonos["caraTraseraBI"]);
            BrazoIzquierdo.Add(3, poligonos["caraDerechaBI"]);
            BrazoIzquierdo.Add(4, poligonos["caraIzquierdaBI"]);
            BrazoIzquierdo.Add(5, poligonos["caraSuperiorBI"]);
            BrazoIzquierdo.Add(6, poligonos["caraInferiorBI"]);

            return BrazoIzquierdo;
        }

        private Parte CrearAntebrazoIzquierdo()
        {
            var AntebrazoIzquierdo = new Parte();
            var poligonos = Vertice.CrearPoligonos();
            AntebrazoIzquierdo.Add(1, poligonos["caraFrontalAI"]);
            AntebrazoIzquierdo.Add(2, poligonos["caraTraseraAI"]);
            AntebrazoIzquierdo.Add(3, poligonos["caraDerechaAI"]);
            AntebrazoIzquierdo.Add(4, poligonos["caraIzquierdaAI"]);
            AntebrazoIzquierdo.Add(5, poligonos["caraSuperiorAI"]);
            AntebrazoIzquierdo.Add(6, poligonos["caraInferiorAI"]);

            return AntebrazoIzquierdo;
        }

        private Parte CrearMusloDerecho()
        {
            var MusloDerecho = new Parte();
            var poligonos = Vertice.CrearPoligonos();
            MusloDerecho.Add(1, poligonos["caraFrontalMD"]);
            MusloDerecho.Add(2, poligonos["caraTraseraMD"]);
            MusloDerecho.Add(3, poligonos["caraDerechaMD"]);
            MusloDerecho.Add(4, poligonos["caraIzquierdaMD"]);
            MusloDerecho.Add(5, poligonos["caraSuperiorMD"]);
            MusloDerecho.Add(6, poligonos["caraInferiorMD"]);

            return MusloDerecho;
        }
        private Parte CrearPiernaDerecha()
        {
            var PiernaDerecha = new Parte();
            var poligonos = Vertice.CrearPoligonos();
            PiernaDerecha.Add(1, poligonos["caraFrontalPD"]);
            PiernaDerecha.Add(2, poligonos["caraTraseraPD"]);
            PiernaDerecha.Add(3, poligonos["caraDerechaPD"]);
            PiernaDerecha.Add(4, poligonos["caraIzquierdaPD"]);
            PiernaDerecha.Add(5, poligonos["caraSuperiorPD"]);
            PiernaDerecha.Add(6, poligonos["caraInferiorPD"]);

            return PiernaDerecha;
        }

        private Parte CrearMusloIzquierdo()
        {
            var MusloIzquierdo = new Parte();
            var poligonos = Vertice.CrearPoligonos();
            MusloIzquierdo.Add(1, poligonos["caraFrontalMI"]);
            MusloIzquierdo.Add(2, poligonos["caraTraseraMI"]);
            MusloIzquierdo.Add(3, poligonos["caraDerechaMI"]);
            MusloIzquierdo.Add(4, poligonos["caraIzquierdaMI"]);
            MusloIzquierdo.Add(5, poligonos["caraSuperiorMI"]);
            MusloIzquierdo.Add(6, poligonos["caraInferiorMI"]);

            return MusloIzquierdo;
        }

        private Parte CrearPiernaIzquierdo()
        {
            var PiernaIzquierda = new Parte();
            var poligonos = Vertice.CrearPoligonos();
            PiernaIzquierda.Add(1, poligonos["caraFrontalPI"]);
            PiernaIzquierda.Add(2, poligonos["caraTraseraPI"]);
            PiernaIzquierda.Add(3, poligonos["caraDerechaPI"]);
            PiernaIzquierda.Add(4, poligonos["caraIzquierdaPI"]);
            PiernaIzquierda.Add(5, poligonos["caraSuperiorPI"]);
            PiernaIzquierda.Add(6, poligonos["caraInferiorPI"]);

            return PiernaIzquierda;
        }



        /// /////////////////LETRA T //////////////////////
        private Parte CrearParteHorizontal()
        {
            var parteHorizontal = new Parte();
            var poligonos = Vertice.CrearPoligonos();
            parteHorizontal.Add(1, poligonos["caraTraseraH"]);
            parteHorizontal.Add(2, poligonos["caraFrontalH"]);
            parteHorizontal.Add(3, poligonos["caraDerechaH"]);
            parteHorizontal.Add(4, poligonos["caraIzquierdaH"]);
            parteHorizontal.Add(5, poligonos["caraSuperiorH"]);
            parteHorizontal.Add(6, poligonos["caraInferiorH"]);

            return parteHorizontal;
        }

        public void ProbarAnimacion()
        {
            int tiempoActual = (int)tiempoAplicacion.ElapsedMilliseconds;
            var accion = new Accion(tiempoActual);
            var escena = new Escena();
            var escena2 = new Escena();
            var escena3 = new Escena();
            var accion2 = new Accion(tiempoActual);
            var accion3 = new Accion(tiempoActual);
            var accion4 = new Accion(tiempoActual);
            var animacion = new Animacion();


            accion.AgregarRotacionConParteConectada(MusloDerecho, new Vector3(0.0f, 0.0f, 1.0f), 5, PiernaDerecha, -25.0f, 0, 1000, tiempoActual);
            accion.AgregarRotacion(PiernaDerecha, new Vector3(0.0f, 0.0f, 1.0f), 5, 20.0f, 0, 1000, tiempoActual);
            accion.AgregarRotacionConParteConectada(BrazoIzquierdo, new Vector3(0.0f, 0.0f, 1.0f), 5, AntebrazoIzquierdo, -25.0f, 0, 1000, tiempoActual);
            accion.AgregarRotacion(AntebrazoIzquierdo, new Vector3(0.0f, 0.0f, 1.0f), 5, -20.0f, 0, 1000, tiempoActual);
            accion.AgregarRotacionConParteConectada(MusloIzquierdo, new Vector3(0.0f, 0.0f, 1.0f), 5, PiernaIzquierda, 20.0f, 0, 1000, tiempoActual);
            accion.AgregarRotacion(PiernaIzquierda, new Vector3(0.0f, 0.0f, 1.0f), 5, 20.0f, 0, 1000, tiempoActual);
            accion.AgregarRotacionConParteConectada(BrazoDerecho, new Vector3(0.0f, 0.0f, 1.0f), 5, AntebrazoDerecho, 25.0f, 0, 1000, tiempoActual);
            
            accion2.AgregarRotacionConParteConectada(MusloDerecho, new Vector3(0.0f, 0.0f, 1.0f), 5, PiernaDerecha, 0.1f, 3000, 4000, tiempoActual);
            accion2.AgregarRotacion(PiernaDerecha, new Vector3(0.0f, 0.0f, 1.0f), 5, 20.0f, 0, 1000, tiempoActual);
            accion2.AgregarRotacionConParteConectada(BrazoIzquierdo, new Vector3(0.0f, 0.0f, 1.0f), 5, AntebrazoIzquierdo, 0.1f, 3000, 4000, tiempoActual);
            accion2.AgregarRotacion(AntebrazoIzquierdo, new Vector3(0.0f, 0.0f, 1.0f), 5, -20.0f, 0, 1000, tiempoActual);
            accion2.AgregarRotacionConParteConectada(MusloIzquierdo, new Vector3(0.0f, 0.0f, 1.0f), 5, PiernaIzquierda, 0.1f, 3000, 4000, tiempoActual);
            accion2.AgregarRotacion(PiernaIzquierda, new Vector3(0.0f, 0.0f, 1.0f), 5, 20.0f, 0, 1000, tiempoActual);
            accion2.AgregarRotacionConParteConectada(BrazoDerecho, new Vector3(0.0f, 0.0f, 1.0f), 5, AntebrazoDerecho, 0.1f, 3000, 4000, tiempoActual);
            
            accion3.AgregarRotacionConParteConectada(MusloDerecho, new Vector3(0.0f, 0.0f, 1.0f), 5, PiernaDerecha, -25.0f, 4000, 5000, tiempoActual);
            accion3.AgregarRotacion(PiernaDerecha, new Vector3(0.0f, 0.0f, 1.0f), 5, 20.0f, 0, 1000, tiempoActual);
            accion3.AgregarRotacionConParteConectada(BrazoIzquierdo, new Vector3(0.0f, 0.0f, 1.0f), 5, AntebrazoIzquierdo, -25.0f, 4000, 5000, tiempoActual);
            accion3.AgregarRotacion(AntebrazoIzquierdo, new Vector3(0.0f, 0.0f, 1.0f), 5, -20.0f, 0, 1000, tiempoActual);
            accion3.AgregarRotacionConParteConectada(MusloIzquierdo, new Vector3(0.0f, 0.0f, 1.0f), 5, PiernaIzquierda, 20.0f, 4000, 5000, tiempoActual);
            accion3.AgregarRotacion(PiernaIzquierda, new Vector3(0.0f, 0.0f, 1.0f), 5, 20.0f, 0, 1000, tiempoActual);
            accion3.AgregarRotacionConParteConectada(BrazoDerecho, new Vector3(0.0f, 0.0f, 1.0f), 5, AntebrazoDerecho, 25.0f, 4000, 5000, tiempoActual);



            muñeco.TrasladarObjeto(new Vector3(-0.008f, 0.0f, 0.0f), 0, 3000, tiempoActual);
            muñeco.TrasladarObjeto(new Vector3(0.0f, 0.064f, 0.0f), 3000, 4000, tiempoActual);
            muñeco.TrasladarObjeto(new Vector3(-0.012f, 0.0f, 0.0f), 4000, 6000, tiempoActual);


            escena.AgregarAccion(accion);

            escena2.AgregarAccion(accion2);
            escena3.AgregarAccion(accion3);

            animacion.AgregarEscena(escena);

            escena.EjecutarEscena( tiempoActual,3,1000);
            escena2.EjecutarEscena(tiempoActual, 1, 1000);
            escena3.EjecutarEscena(tiempoActual, 2, 1000);

            
            //animacion.EjecutarAnimacion();


        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-2, 2, -2, 2, -2, 2);

            tiempoAplicacion = Stopwatch.StartNew();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            escenario.Draw();

            SwapBuffers();
        }

        
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            
            ProbarAnimacion();
        }
    }
}


