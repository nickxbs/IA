using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    public class GiocoRuba2 : Gioco
    {
        public GiocoRuba2(ITavola tavola)
            : base(tavola)
        {
        }

        public GiocoRuba2(ITavola tavola, Lato prossimoLato)
            : base(tavola, prossimoLato)
        {
        }

        protected override void RubaSemi(int indiceBuca, Lato turno)
        {
            if (indiceBuca != 13 && indiceBuca != 6)
            {
                if (Tavola.Buche[indiceBuca].Semi == 1 && Tavola.Buche[12 - indiceBuca].Semi > 0)
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
    }
}
