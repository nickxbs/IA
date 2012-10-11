using System;
using Bantumi.Entities.Interface;

namespace Bantumi.Entities
{
    [Serializable]
    internal class Stato
    {
        public ITavola Tavola { get; set; }
        public IPlayer CurrentTurn { get; set; }

        public Stato(ITavola tavola, IPlayer currentTurn)
        {
            Tavola = tavola;
            CurrentTurn = currentTurn;
        }
    }
}