using System.Collections.Generic;
using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    public class MinMaxAlphaBetaWithOpen : MinMaxAlphaBeta
    {
        public MinMaxAlphaBetaWithOpen(int max, IHeuristicFunction heuristicFunction)
            : base(max, heuristicFunction)
        {
        }

        protected override ValoreMossa MaxValue(IGioco gioco, int depth, int alfa, int beta)
        {
            ValoreMossa mossa = PatternMatching(gioco);
            if (mossa != null)
                return mossa;
            else
            {
                return base.MaxValue(gioco, depth, alfa, beta);
            }

        }

        private ValoreMossa PatternMatching(IGioco gioco)
        {
            IList<IBuca> buche = gioco.Tavola.Buche;
            if (buche[0].Semi == 3 && buche[1].Semi == 3 && buche[2].Semi == 3 && buche[3].Semi == 3 && buche[4].Semi == 3 && buche[5].Semi == 3)
            {
                //ValoreMossa vm2 = new ValoreMossa(null, 5, 2);
                //return new ValoreMossa(vm2, 3, 2);
                return new ValoreMossa(null, 5, 1);
            }
            if (buche[0].Semi == 4 && buche[1].Semi == 4 && buche[2].Semi == 3 && buche[3].Semi == 3 && buche[4].Semi == 3 && buche[5].Semi == 0 && buche[6].Semi == 1)
            {
                ValoreMossa vm3 = new ValoreMossa(null, 1, 2);
                ValoreMossa vm2 = new ValoreMossa(vm3, 5, 2);
                return new ValoreMossa(vm2, 3, 2);
            }
            if (buche[0].Semi == 0 && buche[1].Semi == 0 && buche[2].Semi == 4 && buche[3].Semi == 1 && buche[4].Semi == 5 && buche[5].Semi == 0 && buche[6].Semi == 8 && buche[13].Semi == 8)
            {
                return new ValoreMossa(null, 4, 2);
            }
            return null;
        }
    }
}
