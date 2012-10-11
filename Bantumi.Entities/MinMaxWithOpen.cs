using System.Collections.Generic;
using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    public class MinMaxWithOpen:MinMaxPlayer
    {

        public MinMaxWithOpen(int max)
            : base(max)
        {
        }

        protected override ValoreMossa GetValoreMossa(IGioco gioco, int depth)
        {
            ValoreMossa  mossa = PatternMatching(gioco);
            if (mossa != null)
                return mossa;
            else
            {
                return base.GetValoreMossa(gioco, depth);
            }

        }

        private ValoreMossa PatternMatching(IGioco gioco)
        {
            IList<IBuca> buche = gioco.Tavola.Buche;
            if (buche[0].Fagioli == 3 && buche[1].Fagioli == 3 && buche[2].Fagioli == 3 && buche[3].Fagioli == 3 && buche[4].Fagioli == 3 && buche[5].Fagioli == 3)
            {
                //ValoreMossa vm2 = new ValoreMossa(null, 5, 2);
                //return new ValoreMossa(vm2, 3, 2);
                return new ValoreMossa(null, 5, 1);
            }
            if (buche[0].Fagioli == 4 && buche[1].Fagioli == 4 && buche[2].Fagioli == 3 && buche[3].Fagioli == 3 && buche[4].Fagioli == 3 && buche[5].Fagioli == 0 && buche[6].Fagioli == 1)
            {
                ValoreMossa vm3 = new ValoreMossa(null, 1, 2);
                ValoreMossa vm2 = new ValoreMossa(vm3, 5, 2);
                return new ValoreMossa(vm2, 3, 2);
            }
            //if (buche[0].Fagioli == 0 && buche[1].Fagioli == 0 && buche[2].Fagioli == 4 && buche[3].Fagioli == 1 && buche[4].Fagioli == 5 && buche[5].Fagioli == 0 && buche[6].Fagioli == 8 && buche[13].Fagioli == 8)
            //{
            //    return new ValoreMossa(null, 4, 2);
            //}
            return null;

        }
    }
}
