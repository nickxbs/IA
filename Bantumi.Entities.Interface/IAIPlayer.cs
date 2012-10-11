namespace Bantumi.Entities.Interface
{
    public interface IAIPlayer : IPlayer
    {
        long OperationCount { get; set; }

        int Elaborazione(IGioco gioco);
    }
}