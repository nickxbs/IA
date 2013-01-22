using System;
using System.Collections.Generic;
using System.Linq;
using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    public class MinMaxAlphaBeta : AbsAIPlayer
    {
        private readonly IHeuristicFunction _heuristicFunction;
        protected int _max;
        protected List<int> mossaMultipla;
        protected int _valoreMassimo;
        public MinMaxAlphaBeta(int max)
        {
            _heuristicFunction = new HeuristicFunctionDescnedent();
            if (max == 0)
                _max = 1;
            _max = (max * 2) - 1;
        }


        public MinMaxAlphaBeta(int max, IHeuristicFunction heuristicFunction)
        {
            _heuristicFunction = heuristicFunction;
            if (max == 0)
                _max = 1;
            _max = (max * 2) - 1;
        }

        public override int Elaborazione(IGioco gioco)
        {
            if (mossaMultipla == null || mossaMultipla.Count == 0)
            {
                ValoreMossa val = MaxValue(gioco.Clone(), 0, -1000, 1000);
                mossaMultipla = new List<int>();
                ValoreMossa valTmp = val.ProssimaMossa;
                while (valTmp != null && valTmp.Lato == val.Lato)
                {
                    mossaMultipla.Add(valTmp.Mossa);
                    valTmp = valTmp.ProssimaMossa;
                }

                _valoreMassimo = val.Valore;
                return val.Mossa;
            }
            else
            {
                int mossa = mossaMultipla[0];
                mossaMultipla.RemoveAt(0);
                return mossa;

            }

        }

        protected virtual ValoreMossa MaxValue(IGioco gioco, int depth, int alfa, int beta)
        {
            ValoreMossa resultMove = null;
            if (depth <= _max && !gioco.Finito)
            {
                ITavola tavola = gioco.Tavola;
                Lato latoStep = gioco.ProssimoTurno;

                int[] heuristc = _heuristicFunction.HeuristicFunction(gioco.Clone());
                for (int j = 0; j < heuristc.Length; ++j)
                {
                    int i = heuristc[j];
                    OperationCount++;
                    IGioco giocoClone = gioco.Clone();
                    giocoClone.Muovi(i);
                    bool cambioTurno = gioco.ProssimoTurno != giocoClone.ProssimoTurno;
                    ValoreMossa valoreProssimaMossa = null;
                    if (!giocoClone.Finito)
                    {
                        if (!cambioTurno)
                            valoreProssimaMossa = MaxValue(giocoClone, depth, alfa, beta);
                        else
                            valoreProssimaMossa = MinValue(giocoClone, depth + 1, alfa, beta);
                    }
                    ValoreMossa valore = new ValoreMossa(valoreProssimaMossa, i, ValoreAttuale(giocoClone));
                    if (null == resultMove)//inizializzazione
                    {
                        resultMove = valore;
                    }
                    else
                    {
                        resultMove = AggiornoValore(resultMove, valore, latoStep);
                    }
                    if (resultMove.Valore > beta)
                        return resultMove;
                    alfa = resultMove.Valore > alfa ? resultMove.Valore : alfa;
                }

            }
            return resultMove;

        }

        private ValoreMossa MinValue(IGioco gioco, int depth, int alfa, int beta)
        {
            ValoreMossa resultMove = null;
            if (depth <= _max && !gioco.Finito)
            {

                ITavola tavola = gioco.Tavola;
                Lato latoStep = gioco.ProssimoTurno;

                int[] heuristc = _heuristicFunction.HeuristicFunction(gioco.Clone());
                for (int j = 0; j < heuristc.Length; ++j)
                {
                    int i = heuristc[j];
                    OperationCount++;
                    IGioco giocoClone = gioco.Clone();
                    giocoClone.Muovi(i);
                    bool cambioTurno = gioco.ProssimoTurno != giocoClone.ProssimoTurno;
                    ValoreMossa valoreProssimaMossa = null;
                    if (!giocoClone.Finito)
                    {
                        if (!cambioTurno)
                            valoreProssimaMossa = MinValue(giocoClone, depth, alfa, beta);
                        else
                            valoreProssimaMossa = MaxValue(giocoClone, depth + 1, alfa, beta);
                    }

                    ValoreMossa valore = new ValoreMossa(valoreProssimaMossa, i, ValoreAttuale(giocoClone));
                    if (null == resultMove)//inizializzazione
                    {
                        resultMove = valore;
                    }
                    else
                    {
                        resultMove = AggiornoValore(resultMove, valore, latoStep);
                    }
                    if (resultMove.Valore < alfa)
                        return resultMove;
                    beta = resultMove.Valore < beta ? resultMove.Valore : beta;

                }
            }
            return resultMove;
        }
    }
}
