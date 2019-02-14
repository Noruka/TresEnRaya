using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TresEnRaya
{
    public partial class Form1 : Form
    {
        //Global
        //Crea el array bidimensional de botones
        private Button[,] boton = new Button[3, 3];
        //crea variable global para seguir que jugador es el que esta activo
        int jugadorActivo = 0;
        //Crea los dos jugadores
        static Jugador jugador0 = new Jugador("x");
        static Jugador jugador1 = new Jugador("o");
        //Crea y guarda el array de jugadores para ir mirando sus clases dependiendo del jugador activo.
        Jugador[] jugadores = { jugador0, jugador1 };
        //EndGlobal

        //Constructor
        public Form1()
        {
            InitializeComponent();
            //Generar botones y aplicar propiedades
            //genera una matriz de 3x3 botones empezando por abajo
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    boton[i, j] = new Button();
                    boton[i, j].Width = 100;
                    boton[i, j].Height = 100;
                    boton[i, j].Top = 300 - (i * 100);
                    boton[i, j].Left = 100 * j;
                    boton[i, j].Image = null;
                    boton[i, j].Tag = "-";
                    boton[i, j].Name = "btn" + i + j;
                    boton[i, j].Click += new EventHandler(this.botonPulsado);
                    this.Controls.Add(boton[i, j]);
                }
            }
            //Elige un jugador al azar
            jugadorActivo = InicioRandom();
            //Actualiza el perfil de jugador activo
            UpdatePerfil();
        }
        //Devuelve un numero random entre 0 y 1 para seleccionar un jugador inicial
        public int InicioRandom()
        {
            Random r = new Random();
            int num = r.Next(0, 2);
            return num;
        }

        //Esta funcion actualiza la imagen que muestra el jugador activo
        public void UpdatePerfil()
        {
            switch (jugadorActivo)
            {
                case 0: pbJugador.Image = TresEnRaya.Properties.Resources.x_asset; break;
                case 1: pbJugador.Image = TresEnRaya.Properties.Resources.o_asset; break;
                default:
                    break;
            }
        }
        //Actualiza los datos de los jugadores al hacer la tirada
        //Le resta fichas al objeto jugador.
        public void UpdateJugador()
        {
            switch (jugadorActivo)
            {
                case 0:
                    UpdatePerfil();
                    jugadores[jugadorActivo].Fichas--;
                    break;
                case 1:
                    UpdatePerfil();
                    jugadores[jugadorActivo].Fichas--;
                    break;
            }
        }
        //Funcion que llamará a otras funciones para comprobar quien ha ganado
        public void CheckPartida()
        {
            CheckFilas();
            CheckColumnas();
            CheckDiagonalDesc();
            CheckDiagonalAsc();
        }
        //Funcion que comprueba si el boton pedido (por las posiciones) tiene el mismo tag que se pregunta.
        public Boolean CheckTag(int pos1, int pos2, String tag) {
            if (boton[pos1, pos2].Tag.Equals(tag))
                return true;
            else
                return false;
        }
        //Comprueba dado un boton si el tag es igual al del jugador actual
        public Boolean CheckTag(Button botonActual, String tag) {
            if (botonActual.Tag.Equals(tag))
                return true;
            else
                return false;
        }
        //Funcion que comprueba los contadores de las funciones de comprobacion de la matriz
        //para ver si algun jugador a ganado
        public void FuncGana(int x, int o) {
            if (x == 3)
            {
                Console.WriteLine("Jugador X gana!");
                MessageBox.Show("Jugador X gana!");
                Application.Exit();
            }
            if (o == 3)
            {
                Console.WriteLine("Jugador O gana!");
                MessageBox.Show("Jugador O gana!");
                Application.Exit();
            }
        }

        //Funciones de comprobacion de ganador
        //Funcion que comprueba la diagonal Descendente si el jugador a ganado
        public void CheckDiagonalDesc()
        {
            int contadorX = 0, contadorO = 0;
            for (int i = 0; i < boton.GetLength(0); i++)
            {
                Console.WriteLine("DD****************");
                if (CheckTag(i, i, "x"))
                {
                    contadorX++;
                    Console.WriteLine("DDX-" + i + "-" + i + ": " + contadorX);
                }
                if (CheckTag(i, i, "o"))
                {
                    contadorO++;
                    Console.WriteLine("DDO-" + i + "-" + i + ": " + contadorO);
                }
                FuncGana(contadorX, contadorO);
            }
        }
        //Funcion que comprueba la diagonal Ascendente si el jugador a ganado
        public void CheckDiagonalAsc()
        {
            int contadorX = 0, contadorO = 0;
            int j = 0;
            for (int i = boton.GetLength(0) - 1; i > -1; i--)
            {
                Console.WriteLine("DA****************");
                if (CheckTag(i, j, "x"))
                {
                    contadorX++;
                    Console.WriteLine("DAX-" + i + "-" + j + ": " + contadorX);
                }
                if (CheckTag(i, j, "o"))
                {
                    contadorO++;
                    Console.WriteLine("DAO-" + i + "-" + j + ": " + contadorO);
                }
                FuncGana(contadorX, contadorO);
                j++;
            }
        }
        //Funcion que comprueba las filas si el jugador a ganado
        public void CheckFilas()
        {
            int contadorX = 0, contadorO = 0;
            for (int i = 0; i < boton.GetLength(0); i++)
            {
                Console.WriteLine("F****************");
                for (int j = 0; j < boton.GetLength(0); j++)
                {
                    if (CheckTag(i, j, "x"))
                    {
                        contadorX++;
                        Console.WriteLine("FX-" + i + "-" + j + ": " + contadorX);
                    }
                    if (CheckTag(i, j, "o"))
                    {
                        contadorO++;
                        Console.WriteLine("FO-" + i + "-" + j + ": " + contadorO);
                    }
                    FuncGana(contadorX, contadorO);
                }
                contadorX = 0;
                contadorO = 0;
            }
        }
        //Funcion que comprueba las columnas si el jugador a ganado
        public void CheckColumnas()
        {
            int contadorX = 0, contadorO = 0;
            for (int i = 0; i < boton.GetLength(0); i++)
            {
                Console.WriteLine("C****************");
                for (int j = 0; j < boton.GetLength(0); j++)
                {
                    if (CheckTag(j, i, "x"))
                    {
                        contadorX++;
                        Console.WriteLine("CX-" + i + "-" + j + ": " + contadorX);
                    }
                    if (CheckTag(j, i, "o"))
                    {
                        contadorO++;
                        Console.WriteLine("CO-" + i + "-" + j + ": " + contadorO);
                    }
                    FuncGana(contadorX, contadorO);
                }
                contadorX = 0;
                contadorO = 0;
            }
        }
        //Comprueba si hay alguna imagen en el boton enviado
        public Boolean CheckImgNull(Button botonActual) {
            if (botonActual.Image == null)
                return true;
            else
                return false;
        }
        //Muestra un mensaje de error dependiendo del codigo enviado
        public void MostrarError(int numError) {
            switch (numError)
            {
                case 1: MessageBox.Show("No puedes suplantar fichas de otros jugadores"); break;
                case 2: MessageBox.Show("No puedes quitar fichas de otros jugadores"); break;
                case 3: MessageBox.Show("Aun tienes fichas, no puedes quitar aún"); break;
                case 4: MessageBox.Show("No te quedan fichas, quita una de tus fichas para cambiarla de lugar"); break;
                default:
                    break;
            }
        }
        //Ejecuciones que hacen todos los botones al ser pulsados individualmente.
        public void botonPulsado(Object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;
            //Control de usuario, comprueban si el jugador puede poner una ficha en el boton que ha seleccionado
            if (jugadores[jugadorActivo].Fichas > 0 && CheckImgNull(botonActual))
            {
                //Si el jugador tiene fichas y el boton no esta ocupado, ejecuta la funcion de poner boton.
                PonerFicha(botonActual);
            }
            else
            {
                if (jugadores[jugadorActivo].Fichas > 0 && !(CheckTag(botonActual, jugadores[jugadorActivo].Tipo)))
                {
                    //Comprueba si estas intentando poner una ficha en el boton ocupado por otro jugador
                    MostrarError(1);
                }
                else
                {
                    //Comprueba si el jugador activo tiene fichas, si no tiene le permitira quitar fichas que sean suyas
                    if (jugadores[jugadorActivo].Fichas <= 0 && !CheckImgNull(botonActual))
                    {
                        if (botonActual.Tag.Equals(jugadores[jugadorActivo].Tipo))
                        {
                            botonActual.Image = null;
                            botonActual.Tag = "-";
                            jugadores[jugadorActivo].Fichas++;
                            UpdatePerfil();
                        }
                        else
                        {
                            MostrarError(2);
                        }
                    }
                    else
                    {
                        if (jugadores[jugadorActivo].Fichas > 0)
                        {
                            //Si el jugador tiene fichas no le permitira quitar
                            MostrarError(3);
                        }
                        else
                        {
                            //Si no tienen fichas, se le indicara al usuario que debe quitar una ficha para cambiarla de sitio.
                            MostrarError(4);
                        }
                    }
                }
            }
        }
        //Funcion que se ejecuta para actualizar las imagenes de los botones, el tag, comprobar si el 
        //jugador activo a ganado y el cambio de jugador cuando este le hace click.
        public void PonerFicha(Button botonActual)
        {
            switch (jugadorActivo)
            {
                case 0:
                    botonActual.Image = TresEnRaya.Properties.Resources.btn_x_asset;
                    botonActual.Tag = "x";
                    CheckPartida();
                    UpdateJugador();
                    jugadorActivo = 1;
                    UpdatePerfil();
                    break;
                case 1:
                    botonActual.Image = TresEnRaya.Properties.Resources.btn_o_asset;
                    botonActual.Tag = "o";
                    CheckPartida();
                    UpdateJugador();
                    jugadorActivo = 0;
                    UpdatePerfil();
                    break;
            }
        }
    }
}
