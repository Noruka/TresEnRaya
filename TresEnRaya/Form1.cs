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
        //public Form1()
        //{
        //    InitializeComponent();
        //}


        //Global
        private Button[,] boton = new Button[3, 3];

        int jugadorActivo = 0;

        static Jugador jugador1 = new Jugador(1, "x");
        static Jugador jugador2 = new Jugador(2, "o");

        Jugador[] jugadores = { jugador1, jugador2 };

        //EndGlobal

        //Constructor
        public Form1()
        {
            InitializeComponent();



            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    boton[i, j] = new Button();
                    boton[i, j].Width = 100;
                    boton[i, j].Height = 100;
                    boton[i, j].Top = i * 100;
                    boton[i, j].Left = j * 100;
                    boton[i, j].Image = null;
                    boton[i, j].Name = "btn" + i + j;
                    boton[i, j].Click += new EventHandler(this.botonPulsado);
                    this.Controls.Add(boton[i, j]);
                }
            }

            jugadorActivo = InicioRandom();

            UpdatePerfil();


        }

        //Selecciona uno de los dos jugadores al azar para empezar la partida.
        public int InicioRandom()
        {
            Random r = new Random();
            int num = r.Next(0, 1);
            return num;
        }

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

        //Ejecuciones que hacen todos los botones al ser pulsados individualmente.
        public void botonPulsado(Object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;

            if (jugadores[jugadorActivo].Fichas > 0 && botonActual.Image == null)
            {
                switch (jugadorActivo)
                {
                    case 0:
                        botonActual.Image = TresEnRaya.Properties.Resources.btn_x_asset;
                        botonActual.Image.Tag = "x";
                        UpdateJugador();
                        jugadorActivo = 1;
                        UpdatePerfil();
                        break;
                    case 1:
                        botonActual.Image = TresEnRaya.Properties.Resources.btn_o_asset;
                        botonActual.Image.Tag = "o";
                        UpdateJugador();
                        jugadorActivo = 0;
                        UpdatePerfil();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (jugadores[jugadorActivo].Fichas < 0 && botonActual.Image != null)
                {
                    if (botonActual.Image.Tag.Equals(jugadores[jugadorActivo].Tipo))
                    {
                        botonActual.Image = null;
                        botonActual.Image.Tag = null;
                        jugadores[jugadorActivo].Fichas++;
                        if (jugadorActivo == 0)
                        {
                            jugadorActivo = 1;
                        }
                        else
                        {
                            jugadorActivo = 0;
                        }
                        UpdatePerfil();
                    }

                }
                else {
                    MessageBox.Show("Aun tienes fichas, no puedes quitar aún");
                }

            }


        }
    }
}
