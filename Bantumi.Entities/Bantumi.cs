using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    public class Bant
    {
        private readonly IGioco _gioco;
        private readonly IPlayer _playerA;
        private readonly IPlayer _playerB;

        //Strategy pattern
        public Bant(IGioco gioco, IPlayer playerA, IPlayer playerB)
        {
            _gioco = gioco;
            _playerA = playerA;
            _playerB = playerB;
            playerA.LatoPlayer = Lato.A;
            playerB.LatoPlayer = Lato.B;
            Start(gioco.ProssimoTurno);
        }public IPlayer GetPlayer(Lato lato)
        {
            if (lato == Lato.A)
            {
                return _playerA;
            }
            else
            {
                return _playerB;
            }
        }

        private void Start(Lato prossimoTurno)
        {
            while (_gioco.Vincitore != null && !_gioco.Parita)
            {
                if (prossimoTurno == Lato.A)
                {
                    if (_playerA is IAIPlayer)
                        _gioco.Muovi(((IAIPlayer)_playerA).Elaborazione(_gioco));
                }
                else
                {
                    if (_playerA is IAIPlayer)
                        _gioco.Muovi(((IAIPlayer)_playerB).Elaborazione(_gioco));
                }
            }
        }
    }
}
