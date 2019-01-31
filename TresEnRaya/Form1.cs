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

        private Button[,] boton = new Button[3, 3];

        int jugadorActivo = 0, contadorJ1 = 3, contadorJ2 = 3;

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

            UpdateJugador();
        }

        //Selecciona uno de los dos jugadores al azar para empezar la partida.
        public int InicioRandom()
        {
            Random r = new Random();
            int num = r.Next(1, 3);
            return num;
        }

        public void UpdateJugador()
        {
            switch (jugadorActivo)
            {
                case 1: pbJugador.Image = TresEnRaya.Properties.Resources.x_asset; break;
                case 2: pbJugador.Image = TresEnRaya.Properties.Resources.o_asset; break;
                default:
                    break;
            }
        }

        //Ejecuciones que hacen todos los botones al ser pulsados individualmente.
        public void botonPulsado(Object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;

            switch (jugadorActivo)
            {
                case 1:
                    botonActual.Image = TresEnRaya.Properties.Resources.btn_x_asset;
                    jugadorActivo = 2;
                    UpdateJugador();
                    break;

                case 2:
                    botonActual.Image = TresEnRaya.Properties.Resources.btn_o_asset;
                    jugadorActivo = 1;
                    UpdateJugador();
                    break;
                default:
                    break;
            }
        }
    }
}
