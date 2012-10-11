using System;

namespace Bantumi.Entities.Interface
{
    public interface IGioco 
    {
        void Muovi(int indiceBuca);
        bool MossaValida(int indiceBuca);
        Lato ProssimoTurno { get; }
        bool Finito { get; }
        ITavola Tavola { get; }
        string Vincitore { get; }
        bool Parita { get; }        
        IGioco Clone();
    }
}