using System;
using System.Collections.Generic;
using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    public abstract class AbsMinMax : AbsAIPlayer
    {
        protected  int _max;
        protected List<int> mossaMultipla;
        protected int _valoreMassimo;

        public override int Elaborazione(IGioco gioco)
        {
            
            if (mossaMultipla == null || mossaMultipla.Count == 0)
            {
                ValoreMossa val = GetValoreMossa(gioco.Clone(), 0);
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

        protected abstract ValoreMossa GetValoreMossa(IGioco gioco, int depth);
        
        protected int ValoreAttuale(IGioco prossimoGioco)
        {
            int valoreAttuale;
            if (LatoPlayer == Lato.A)
            {
                valoreAttuale = prossimoGioco.Tavola.Buche[6].Semi - prossimoGioco.Tavola.Buche[13].Semi;
            }
            else
            {
                valoreAttuale = prossimoGioco.Tavola.Buche[13].Semi - prossimoGioco.Tavola.Buche[6].Semi;
            }
            return valoreAttuale;
        }

        protected ValoreMossa ValoreProssimaMossa(int depth, IGioco giocoClone, bool cambioTurno)
        {
            ValoreMossa valoreProssimaMossa;
            if (!cambioTurno)
                valoreProssimaMossa = GetValoreMossa(giocoClone, depth);
            else
                valoreProssimaMossa = GetValoreMossa(giocoClone, depth + 1);
            return valoreProssimaMossa;
        }
        
        protected ValoreMossa AggiornoValore(ValoreMossa resultMove, ValoreMossa m, Lato latoStep)
        {
            if (latoStep == LatoPlayer)
            {
                if (m.Valore >= resultMove.Valore) //MAX: tengo sempre la migliore che poi ritorno
                {
                    resultMove = m;
                }
            }
            else
            {
                if (m.Valore <= resultMove.Valore) //MIN: tengo sempre la migliore che poi ritorno
                {
                    resultMove = m;
                }
            }
            return resultMove;
        }

        protected class ValoreMossa
        {
            private readonly ValoreMossa _nextMove;
            private readonly int _i;
            private readonly int _score;

            public ValoreMossa(ValoreMossa nextMove, int i, int score)
            {
                _nextMove = nextMove;
                _i = i;
                _score = score;
            }


            public int Valore
            {
                get { return (null == _nextMove) ? _score : _nextMove.Valore; }
            }

            public int Mossa
            {
                get { return _i; }
            }

            public Lato Lato
            {
                get
                {
                    if (_i < 6)
                        return Lato.A;
                    return Lato.B;
                }
            }

            public ValoreMossa ProssimaMossa
            {
                get { return _nextMove; }
            }
        }
    }

}
