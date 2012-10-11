using System;
using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    [Serializable]
    public class MinMaxBetaPlayer : AbsMinMax
    {

        public MinMaxBetaPlayer(int max)
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
                int? beta = null;
                for (int i = tavola.Buche.Count - 2; i >= 0; --i)
                {
                    IBuca p = tavola.Buche[i];
                    if (p.Lato == latoStep && i != 6 && i != 13 && p.Semi > 0 && !gioco.Finito)
                    {
                        IGioco giocoClone = gioco.Clone();
                        giocoClone.Muovi(i);
                        int valoreAttuale = ValoreAttuale(giocoClone);

                        if (depth == _max - 1 && beta.HasValue && latoStep == LatoPlayer && valoreAttuale < beta.Value)
                        {
                            continue;
                        }
                        else
                        {
                            bool cambioTurno = gioco.ProssimoTurno != giocoClone.ProssimoTurno;
                            ValoreMossa valoreProssimaMossa;
                            if (!giocoClone.Finito)
                            {
                                valoreProssimaMossa = ValoreProssimaMossa(depth, giocoClone, cambioTurno);
                            }
                            else
                            {
                                valoreProssimaMossa = null;
                            }
                            ValoreMossa valore = new ValoreMossa(valoreProssimaMossa, i, valoreAttuale);
                            if (null == resultMove) //serve per il taglio
                            {
                                resultMove = valore;
                            }
                            else
                            {
                                resultMove = AggiornoValore(resultMove, valore, latoStep);
                                if (depth == _max - 1 && latoStep == LatoPlayer)
                                    beta = resultMove.Valore;
                            }
                        }
                    }
                }
            }
            return resultMove;
        }
    }
}
