using System.Collections.Generic;
using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    public class HeuristicFunctionDescnedent : IHeuristicFunction
    {
        public int[] HeuristicFunction(IGioco gioco)

        {
            List<int> outDic = new List<int>();
            for (int i = gioco.Tavola.Buche.Count - 2; i >= 0; --i)
            {
                if (gioco.Tavola.Buche[i].Lato == gioco.ProssimoTurno && i != 6 && i != 13 && gioco.Tavola.Buche[i].Semi > 0 && !gioco.Finito)
                {
                    outDic.Add(i);
                }
            }
            return outDic.ToArray();
        }
    }
}