using System;
using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    [Serializable]

    public class RandomPlayer : AbsAIPlayer, IAIPlayer
    {

        public override int Elaborazione(IGioco gioco)
        {
            Random r = new Random();

            if (LatoPlayer == Lato.A)
            {
                return r.Next(0, 6);
            }
            else
            {
                return r.Next(7, 13);
            }
        }

        public IGioco Gioco
        {
            set { var _gioco = value; }
        }
    }
}