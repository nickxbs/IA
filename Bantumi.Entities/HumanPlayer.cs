using System;
using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    [Serializable]
    public class HumanPlayer : AbsAIPlayer, IAIPlayer
    {

        public override int Elaborazione(IGioco gioco)
        {
            return 0;
        }
        public int ChiediMossa()
        {
            return 0;
        }

    }
}