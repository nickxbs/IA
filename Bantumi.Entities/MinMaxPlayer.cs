using System;
using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    [Serializable]
    public class MinMaxPlayer : AbsMinMax
    {
        public MinMaxPlayer(int max)
        {
            if (max == 0)
                _max = 1;
            _max = (max * 2) - 1;
        }

        protected override ValoreMossa GetValoreMossa(IGioco gioco, int depth)
        {
            ValoreMossa resultMove = null;

            if (depth <= _max)
            {
                ITavola tavola = gioco.Tavola;
                Lato latoStep = gioco.ProssimoTurno;

                for (int i = tavola.Buche.Count - 2; i >= 0; --i)
                {
                    IBuca p = tavola.Buche[i];
                    if (p.Lato == latoStep && i != 6 && i != 13 && p.Semi > 0 && !gioco.Finito)
                    {
                        OperationCount++;
                        IGioco giocoClone = gioco.Clone();
                        giocoClone.Muovi(i);
                        int valoreAttuale = ValoreAttuale(giocoClone);
                        ValoreMossa valoreProssimaMossa;
                        if (!giocoClone.Finito)
                        {
                            bool cambioTurno = gioco.ProssimoTurno != giocoClone.ProssimoTurno;
                            valoreProssimaMossa = ValoreProssimaMossa(depth, giocoClone.Clone(), cambioTurno);
                        }
                        else
                        {
                            valoreProssimaMossa = null;
                        }
                        ValoreMossa m = new ValoreMossa(valoreProssimaMossa, i, valoreAttuale);

                        if (null == resultMove)//inizializzazione
                        {
                            resultMove = m;
                        }
                        else
                        {
                            resultMove = AggiornoValore(resultMove, m, latoStep);
                        }
                    }
                }
            }
            return resultMove;
        }
    }
}
