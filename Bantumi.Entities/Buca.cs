using System;
using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
        [Serializable]

    public class Buca : IBuca
    {
        public Buca(int semi, int indice)
        {
            Indice = indice;
            Semi = semi;
            if (indice <= 6)
                Lato = Lato.A;
            else
                Lato = Lato.B;
        }

        public int Indice
        {
            get;
            set;
        }

        public int Semi { get; set; }

        public Lato Lato
        {
            get;
            set;
        }
    }
}