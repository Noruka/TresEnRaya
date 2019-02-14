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
        private Button[,] boton = new Button[3, 3];

        int jugadorActivo = 0;

        static Jugador jugador0 = new Jugador(0, "x");
        static Jugador jugador1 = new Jugador(1, "o");

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

        //Actualiza los datos de los jugadores al hacer la tirada
        //Le resta fichas al objeto jugador y le suma turnos. Los turnos nunca se muestran son mas para hacer debbug o analisis de datos
        public void UpdateJugador()
        {
            switch (jugadorActivo)
            {
                case 0:
                    UpdatePerfil();
                    jugadores[jugadorActivo].Fichas--;
                    jugadores[jugadorActivo].Turnos++;
                    break;

                case 1:
                    UpdatePerfil();
                    jugadores[jugadorActivo].Fichas--;
                    jugadores[jugadorActivo].Turnos++;
                    break;
                default:
                    break;
            }
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
                default:
                    break;
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

                if (boton[i, i].Tag.Equals("x"))
                {
                    contadorX++;
                    Console.WriteLine("DDX-" + i + "-" + i + ": " + contadorX);
                }
                if (boton[i, i].Tag.Equals("o"))
                {
                    contadorO++;
                    Console.WriteLine("DDO-" + i + "-" + i + ": " + contadorO);
                }

                if (contadorX == 3)
                {
                    jugador0.Ganador = true;
                    Console.WriteLine("Jugador X gana!");
                    MessageBox.Show("Jugador X gana!");
                    Application.Exit();
                }
                if (contadorO == 3)
                {
                    jugador1.Ganador = true;
                    Console.WriteLine("Jugador O gana!");
                    MessageBox.Show("Jugador O gana!");
                    Application.Exit();
                }



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



                if (boton[i, j].Tag.Equals("x"))
                {
                    contadorX++;
                    Console.WriteLine("DAX-" + i + "-" + j + ": " + contadorX);
                }
                if (boton[i, j].Tag.Equals("o"))
                {
                    contadorO++;
                    Console.WriteLine("DAO-" + i + "-" + j + ": " + contadorO);
                }

                if (contadorX == 3)
                {
                    jugador0.Ganador = true;
                    Console.WriteLine("Jugador X gana!");
                    MessageBox.Show("Jugador X gana!");
                    Application.Exit();
                }
                if (contadorO == 3)
                {
                    jugador1.Ganador = true;
                    Console.WriteLine("Jugador O gana!");
                    MessageBox.Show("Jugador O gana!");
                    Application.Exit();
                }

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
                    if (boton[i, j].Tag.Equals("x"))
                    {
                        contadorX++;
                        Console.WriteLine("FX-" + i + "-" + j + ": " + contadorX);
                    }
                    if (boton[i, j].Tag.Equals("o"))
                    {
                        contadorO++;
                        Console.WriteLine("FO-" + i + "-" + j + ": " + contadorO);
                    }

                    if (contadorX == 3)
                    {
                        jugador0.Ganador = true;
                        Console.WriteLine("Jugador X gana!");
                        MessageBox.Show("Jugador X gana!");
                        Application.Exit();
                    }
                    if (contadorO == 3)
                    {
                        jugador1.Ganador = true;
                        Console.WriteLine("Jugador O gana!");
                        MessageBox.Show("Jugador O gana!");
                        Application.Exit();
                    }
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
                    if (boton[j, i].Tag.Equals("x"))
                    {
                        contadorX++;
                        Console.WriteLine("CX-" + i + "-" + j + ": " + contadorX);
                    }
                    if (boton[j, i].Tag.Equals("o"))
                    {
                        contadorO++;
                        Console.WriteLine("CO-" + i + "-" + j + ": " + contadorO);
                    }

                    if (contadorX == 3)
                    {
                        jugador0.Ganador = true;
                        Console.WriteLine("Jugador X gana!");
                        MessageBox.Show("Jugador X gana!");
                        Application.Exit();
                    }
                    if (contadorO == 3)
                    {
                        jugador1.Ganador = true;
                        Console.WriteLine("Jugador O gana!");
                        MessageBox.Show("Jugador O gana!");
                        Application.Exit();
                    }
                }

                contadorX = 0;
                contadorO = 0;
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

        //Ejecuciones que hacen todos los botones al ser pulsados individualmente.
        public void botonPulsado(Object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;

            //Control de usuario, comprueban si el jugador puede poner una ficha en el boton que ha seleccionado
            if (jugadores[jugadorActivo].Fichas > 0 && botonActual.Image == null)
            {
                //Si el jugador tiene fichas y el boton no esta ocupado, ejecuta la funcion de poner boton.
                PonerFicha(botonActual);
            }
            else
            {
                if (jugadores[jugadorActivo].Fichas > 0 && !(botonActual.Tag.Equals(jugadores[jugadorActivo].Tipo)))
                {
                    //Comprueba si estas intentando poner una ficha en el boton ocupado por otro jugador
                    MessageBox.Show("No puedes suplantar fichas de otros jugadores");
                }
                else
                {
                    //Comprueba si el jugador activo tiene fichas, si no tiene le permitira quitar fichas que sean suyas
                    if (jugadores[jugadorActivo].Fichas <= 0 && botonActual.Image != null)
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
                            MessageBox.Show("No puedes quitar fichas de otros jugadores");
                        }
                    }
                    else
                    {
                        if (jugadores[jugadorActivo].Fichas > 0)
                        {
                            //Si el jugador tiene fichas no le permitira quitar
                            MessageBox.Show("Aun tienes fichas, no puedes quitar aún");
                        }
                        else
                        {
                            //Si no tienen fichas, se le indicara al usuario que debe quitar una ficha para cambiarla de sitio.
                            MessageBox.Show("No te quedan fichas, quita una de tus fichas para cambiarla de lugar");
                        }

                    }
                }

            }


        }
    }
}
