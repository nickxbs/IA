using System;
using System.Collections.Generic;
using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    [Serializable]
    public class Tavola : ITavola
    {
        public Tavola()
        {
            const int SEMI = 3;
            const int BUCHE_PER_LATO = 6;
            const int NUMERO_BUCHE = (BUCHE_PER_LATO * 2) + 2;
            //Contract.Requires(numeroBuche==Buche.Count);

            Buche = new List<IBuca>(NUMERO_BUCHE);
            for (int i = 0; i < NUMERO_BUCHE; ++i)
            {
                if (i == 6 || i == 13)
                    Buche.Insert(i, new Buca(0, i));
                else
                    Buche.Insert(i, new Buca(SEMI, i));
            }
        }


        public IList<IBuca> Buche
        {
            get;
            private set;
        }

        public ITavola Clone()
        {
            ITavola tavola= new Tavola();
            IList<IBuca> buche = this.Buche;
            for (int i = 0; i < buche.Count; ++i)
            {
                tavola.Buche[i].Semi = buche[i].Semi;
            }      
            return tavola;
        }
    }
}
