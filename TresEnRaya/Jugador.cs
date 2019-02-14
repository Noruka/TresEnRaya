using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TresEnRaya
{
    class Jugador
    {
        //Crear atributos privados
        private int fichas;
        private String tipo;

        //Constructor default, recibe el tipo(X o O) de jugador.
        public Jugador(String t)
        {
            Fichas = 3;
            Tipo = t;
        }
        //Getter and Setter
        public int Fichas { get => fichas; set => fichas = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
