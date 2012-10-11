using System;
using System.Linq;
using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    [Serializable]
    public class Gioco : IGioco
    {
        public ITavola Tavola { get; private set; }
        private Lato _prossimoTurno;
        private bool _parita;
        public string Vincitore { get; private set; }

        public bool Parita
        {
            get { return _parita; }
        }



       
        public Gioco(ITavola tavola)
        {
            Tavola = tavola;
            _prossimoTurno = Lato.A;
            _parita = false;
        }
        public Gioco(ITavola tavola, Lato prossimoLato)
        {
            Tavola = tavola;
            _prossimoTurno = prossimoLato;
            _parita = false;
        }


        public void Muovi(int indiceBuca)
        {
            if (MossaValida(indiceBuca))
            {

                var Turno = indiceBuca < 6 ? Lato.A : Lato.B;
                var indice = indiceBuca;
                int numeroSemi = Tavola.Buche[indiceBuca].Semi;
                Tavola.Buche[indiceBuca].Semi = 0;
                for (; numeroSemi > 0; --numeroSemi)
                {
                    ++indice;
                    indice = indice % 14;
                    if ((indice == 6 && Turno == Lato.B) || (indice == 13 && Turno == Lato.A))
                        indice = ++indice % 14;
                    ++Tavola.Buche[indice].Semi;
                }

                RubaSemi(indice, Turno);
                CalcolaProssimoTurno(Turno, indice);
                if (Vittoria())
                {
                    Finito = true;
                    return;
                }
            }
        }

        private bool Vittoria()
        {
            if (Tavola.Buche[6].Semi > 18)
            {
                Vincitore = Lato.A.ToString();
                return true;
            }
            if (Tavola.Buche[13].Semi > 18)
            {
                Vincitore = Lato.B.ToString();
                return true;
            }
            if (Tavola.Buche[13].Semi == 18 && Tavola.Buche[6].Semi == 18)
            {
                _parita = true;
                return true;
            }

            int totaleSemi;
            if (_prossimoTurno == Lato.A)
                totaleSemi = (from buca in Tavola.Buche where buca.Indice < 6 select buca.Semi).Sum();
            else
            {
                totaleSemi = (from buca in Tavola.Buche where buca.Indice > 6 && buca.Indice < 13 select buca.Semi).Sum();
            }

            if (totaleSemi == 0)
            {
                if (Tavola.Buche[6].Semi > Tavola.Buche[13].Semi)
                    Vincitore = Lato.A.ToString();
                if (Tavola.Buche[6].Semi < Tavola.Buche[13].Semi)
                    Vincitore = Lato.B.ToString();
                if (Tavola.Buche[6].Semi == Tavola.Buche[13].Semi)
                    _parita = true;
                Finito = true;
                return true;
            }
            return false;
        }

        public bool MossaValida(int indiceBuca)
        {
            if (Tavola == null)
                return false;

            if (indiceBuca < 0 || indiceBuca > Tavola.Buche.Count || indiceBuca == 6 || indiceBuca == 13)
                return false;


            if (_prossimoTurno == Lato.A)
            {
                if (indiceBuca > 5)
                    return false;
            }
            if (_prossimoTurno == Lato.A)
            {
                if (indiceBuca > 5)
                    return false;
            }
            else
            {
                if (indiceBuca < 6 || indiceBuca > 13)
                    return false;
            }
            if (Tavola.Buche[indiceBuca].Semi == 0)
                return false;
            return true;
        }

        public Lato ProssimoTurno
        {
            get { return _prossimoTurno; }
        }

        public bool Finito
        {
            get;
            set;
        }

        private void CalcolaProssimoTurno(Lato turno, int indice)
        {
            if (indice == 6)
            {
                _prossimoTurno = Lato.A;
                return;
            }
            if (indice == 13)
            {
                _prossimoTurno = Lato.B;
                return;
            }

            _prossimoTurno = turno == Lato.A ? Lato.B : Lato.A;
        }
        protected virtual void RubaSemi(int indiceBuca, Lato turno)
        {
            if (indiceBuca != 13 && indiceBuca != 6)
            {
                if (Tavola.Buche[indiceBuca].Semi == 1)
                {
                    if (indiceBuca < 6 && turno == Lato.A)
                    {
                        int semi = Tavola.Buche[12 - indiceBuca].Semi + 1;
                        Tavola.Buche[12 - indiceBuca].Semi = 0;
                        Tavola.Buche[indiceBuca].Semi = 0;
                        Tavola.Buche[6].Semi += semi;

                        return;
                    }
                    if (indiceBuca > 6 && turno == Lato.B)
                    {
                        int semi = Tavola.Buche[12 - indiceBuca].Semi + 1;
                        Tavola.Buche[12 - indiceBuca].Semi = 0;
                        Tavola.Buche[indiceBuca].Semi = 0;
                        Tavola.Buche[13].Semi += semi;
                        return;
                    }
                }
            }
        }

        public IGioco Clone()
        {
            ITavola tavola = (ITavola)this.Tavola.Clone();
            Gioco newGame = new Gioco(tavola);
            newGame.Vincitore = this.Vincitore;
            newGame._parita = this.Parita;
            newGame._prossimoTurno = this.ProssimoTurno;

            return newGame;
        }

    }
}
