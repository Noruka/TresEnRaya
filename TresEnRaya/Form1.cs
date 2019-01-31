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

        int jugadorActivo = 0;

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
                    boton[i, j].Name = "btn"+i+j;
                    boton[i, j].Click += new EventHandler(this.botonPulsado);
                    this.Controls.Add(boton[i, j]);
                }
            }

            if (InicioRandom()==1)
            {
                
                jugadorActivo = 1;

            }
            if (InicioRandom() == 2)
            {
                pbJugador.Image = TresEnRaya.Properties.Resources.O_3enraya;
                jugadorActivo = 2;
            }
        }

        public int InicioRandom() {

            Random r = new Random();
            int num = r.Next(1, 3);
            return num;
        }

        void botonPulsado(Object sender, EventArgs e)
        {
            Button botonActual = (Button)sender;
            if (jugadorActivo == 1)
            {
                botonActual.Image = TresEnRaya.Properties.Resources.X_3enraya;
            }
            if (jugadorActivo == 2)
            {
                botonActual.Image = TresEnRaya.Properties.Resources.O_3enraya;
            }


        }
    }
}
