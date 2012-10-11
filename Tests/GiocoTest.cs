using Bantumi.Entities;
using Bantumi.Entities.Interface;

using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class GiocoTest
    {
        [Test]
        public void Muovi_Buca0_Result_4SemiSemiBuca123TurnoSuccessivoNicola()
        {
            ITavola tavola = new Tavola();
            IGioco gioco = new Gioco(tavola);
            gioco.Muovi(0);
            Assert.AreEqual(0, tavola.Buche[0].Semi);
            Assert.AreEqual(4, tavola.Buche[1].Semi);
            Assert.AreEqual(4, tavola.Buche[2].Semi);
            Assert.AreEqual(4, tavola.Buche[3].Semi);
            Assert.AreEqual(Lato.B, gioco.ProssimoTurno);
        }

        [Test]
        public void Muovi_Buca3_Result_4SemiBuca45E1InBuca6TurnoSuccessivoPC()
        {
            ITavola tavola = new Tavola();
            IGioco gioco = new Gioco(tavola);
            gioco.Muovi(3);
            Assert.AreEqual(0, tavola.Buche[3].Semi);
            Assert.AreEqual(4, tavola.Buche[4].Semi);
            Assert.AreEqual(4, tavola.Buche[5].Semi);
            Assert.AreEqual(1, tavola.Buche[6].Semi);
            Assert.AreEqual(Lato.A, gioco.ProssimoTurno);
        }

        [Test]
        public void Muovi_Buca3e0_Result_4SemiBuca45E5InBuca6TurnoSuccessivoPC()
        {
            ITavola tavola = new Tavola();
            IGioco gioco = new Gioco(tavola); 
            gioco.Muovi(3);
            gioco.Muovi(0);
            Assert.AreEqual(0, tavola.Buche[0].Semi);
            Assert.AreEqual(4, tavola.Buche[1].Semi);
            Assert.AreEqual(4, tavola.Buche[2].Semi);
            Assert.AreEqual(0, tavola.Buche[3].Semi);
            Assert.AreEqual(4, tavola.Buche[4].Semi);
            Assert.AreEqual(4, tavola.Buche[5].Semi);
            Assert.AreEqual(5, tavola.Buche[6].Semi);
            Assert.AreEqual(Lato.B, gioco.ProssimoTurno);
        }
        [Test]
        public void Muovi_Buca3_12_Result_4SemiBuca45E1InBuca6TurnoSuccessivoPC()
        {
            ITavola tavola = new Tavola();
            IGioco gioco = new Gioco(tavola);
            gioco.Muovi(4);
            gioco.Muovi(12);

            Assert.AreEqual(4, tavola.Buche[0].Semi);
            Assert.AreEqual(4, tavola.Buche[1].Semi);
            Assert.AreEqual(3, tavola.Buche[2].Semi);
            Assert.AreEqual(3, tavola.Buche[3].Semi);
            Assert.AreEqual(0, tavola.Buche[4].Semi);
            Assert.AreEqual(4, tavola.Buche[5].Semi);
            Assert.AreEqual(1, tavola.Buche[6].Semi);
            Assert.AreEqual(4, tavola.Buche[7].Semi);
            Assert.AreEqual(3, tavola.Buche[8].Semi);
            Assert.AreEqual(3, tavola.Buche[9].Semi);
            Assert.AreEqual(3, tavola.Buche[10].Semi);
            Assert.AreEqual(3, tavola.Buche[11].Semi);
            Assert.AreEqual(0, tavola.Buche[12].Semi);
            Assert.AreEqual(1, tavola.Buche[13].Semi);
            Assert.AreEqual(Lato.A, gioco.ProssimoTurno);
        }


    }
}
