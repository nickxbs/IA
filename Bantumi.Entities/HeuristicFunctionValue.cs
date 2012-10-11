using System.Collections.Generic;
using System.Linq;
using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    public class HeuristicFunctionValue : IHeuristicFunction
    {
        private readonly Lato _latoPlayer;

        public HeuristicFunctionValue(Lato latoPlayer)
        {
            _latoPlayer = latoPlayer;
        }

        public int[] HeuristicFunction(IGioco gioco)
        {
            Dictionary<int, decimal> outDic = new Dictionary<int, decimal>();
            for (int i = gioco.Tavola.Buche.Count - 2; i >= 0; --i)
            {
                IBuca p = gioco.Tavola.Buche[i];
                if (gioco.Tavola.Buche[i].Lato == gioco.ProssimoTurno && i != 6 && i != 13 && gioco.Tavola.Buche[i].Semi > 0 && !gioco.Finito)
                {
                    IGioco giocoClone = gioco.Clone();
                    giocoClone.Muovi(i);
                    bool cambioTurno = gioco.ProssimoTurno != giocoClone.ProssimoTurno;
                    decimal valore = (decimal)(cambioTurno ? Valore(giocoClone) : Valore(giocoClone) + 0.5);
                    outDic.Add(i, valore);

                }
            }
            return outDic.OrderByDescending(x => x.Value).Select(x => x.Key).ToArray();
        }

        private double Valore(IGioco giocoClone)
        {
            int valoreAttuale;
            if (_latoPlayer== Lato.A)
            {
                valoreAttuale = giocoClone.Tavola.Buche[6].Semi - giocoClone.Tavola.Buche[13].Semi;
            }
            else
            {
                valoreAttuale = giocoClone.Tavola.Buche[13].Semi - giocoClone.Tavola.Buche[6].Semi;
            }
            return valoreAttuale;

        }
    }
}