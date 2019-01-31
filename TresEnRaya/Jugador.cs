using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TresEnRaya
{
    class Jugador
    {
        private int fichas;
        private int turnos;
        private Boolean ganador = false;
        private int id;
        private String tipo;

        public Jugador(int i, String t)
        {

            Id = i;
            Fichas = 3;
            Turnos = 0;
            Ganador = false;
            Tipo = t;

        }

        public int Fichas { get => fichas; set => fichas = value; }
        public int Turnos { get => turnos; set => turnos = value; }
        public bool Ganador { get => ganador; set => ganador = value; }
        public int Id { get => id; set => id = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
