using System;
using System.Collections.Generic;
using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    public class MinMax : AbsAIPlayer
    {
        private readonly IHeuristicFunction _heuristicFunction;
        protected int _max;
        protected List<int> mossaMultipla;
        protected int _valoreMassimo;

        public MinMax(int max)
        {
            _heuristicFunction = new HeuristicFunctionDescnedent();
            if (max == 0)
                _max = 1;
            _max = (max * 2) - 1;
        }

        public override int Elaborazione(IGioco gioco)
        {
            if (mossaMultipla == null || mossaMultipla.Count == 0)
            {
                ValoreMossa val = MaxValue(gioco.Clone(), 0);
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

        protected ValoreMossa MaxValue(IGioco gioco, int depth)
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
                            valoreProssimaMossa = MaxValue(giocoClone.Clone(), depth);
                        else
                            valoreProssimaMossa = MinValue(giocoClone.Clone(), depth + 1);
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
                }
            }
            return resultMove;
        }

        private ValoreMossa MinValue(IGioco gioco, int depth)
        {
            ValoreMossa resultMove = null;
            if (depth <= _max && !gioco.Finito)
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
                        bool cambioTurno = gioco.ProssimoTurno != giocoClone.ProssimoTurno;
                        ValoreMossa valoreProssimaMossa = null;
                        if (!giocoClone.Finito)
                        {
                            if (!cambioTurno)
                                valoreProssimaMossa = MinValue(giocoClone.Clone(), depth);
                            else
                                valoreProssimaMossa = MaxValue(giocoClone.Clone(), depth + 1);
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


                    }
                }
            }
            return resultMove;
        }

    }
}
