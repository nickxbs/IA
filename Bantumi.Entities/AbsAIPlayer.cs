using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    [Serializable]
    public abstract class AbsAIPlayer : IAIPlayer
    {
        public Lato LatoPlayer
        {
            get;
            set;
        }

        public Int64 OperationCount
        {
            get;
            set;
        }

        public abstract int Elaborazione(IGioco gioco);

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

        protected int ValoreAttuale(IGioco giocoClone)
        {
            int valoreAttuale;
            if (LatoPlayer == Lato.A)
            {
                valoreAttuale = giocoClone.Tavola.Buche[6].Semi - giocoClone.Tavola.Buche[13].Semi;
            }
            else
            {
                valoreAttuale = giocoClone.Tavola.Buche[13].Semi - giocoClone.Tavola.Buche[6].Semi;
            }
            return valoreAttuale;
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
