using Bantumi.Entities;
using Bantumi.Entities.Interface;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void Elaborazione_SideA_ReturnRandomNumBetween0And5()
        {
            IAIPlayer player = new RandomPlayer();
            player.LatoPlayer=Lato.A;
            int i = player.Elaborazione(null);
            Assert.GreaterOrEqual(i, 0);
            Assert.GreaterOrEqual(5, i);
        }
        [Test]
        public void Elaborazione_SideB_ReturnRandomNumBetween7And12()
        {
            IAIPlayer player = new RandomPlayer();
            player.LatoPlayer = Lato.B;

            int i = player.Elaborazione(null);
            Assert.GreaterOrEqual(i, 7);
            Assert.GreaterOrEqual(12, i);
        }
    }
}
