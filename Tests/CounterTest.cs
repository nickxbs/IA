using Bantumi.Entities;
using Bantumi.Entities.Interface;
using NUnit.Framework;

namespace Tests
{

    [TestFixture]
    public class CounterTest
    {
        [Test]
        public void counterMinMaxNew1()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMax(1);
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(129, p1.OperationCount);

        }
        [Test]
        public void counterMinMaxNew2()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMax(2);
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(8727, p1.OperationCount);

        }
        [Test]
        public void counterMinMaxNew3()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMax(3);
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(882215, p1.OperationCount);

        }
        [Test]
        public void counterMinMaxNew4()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMax(4);
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(99569593, p1.OperationCount);

        }
        [Test]
        public void counterMinMaxAlfaBeta1HVal()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(1, new HeuristicFunctionValue(Lato.A));
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(97, p1.OperationCount);

        }
        [Test]
        public void counterMinMaxAlfaBeta2HVal()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(2, new HeuristicFunctionValue(Lato.A));
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(2405, p1.OperationCount);

        }
        [Test]
        public void counterMinMaxAlfaBeta3HVal()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(3, new HeuristicFunctionValue(Lato.A));
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(50387, p1.OperationCount);

        }
        [Test]
        public void counterMinMaxAlfaBeta4HVal()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(4, new HeuristicFunctionValue(Lato.A));
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(1148562, p1.OperationCount);

        }
        [Test]
        public void counterMinMaxAlfaBeta5HVal()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(5, new HeuristicFunctionValue(Lato.A));
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(23123673, p1.OperationCount);

        }



        [Test]
        public void counterMinMaxAlfaBeta1HAsc()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(1, new HeuristicFunctionAscendent());
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(112, p1.OperationCount);

        }
        [Test]
        public void counterMinMaxAlfaBeta2HAsc()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(2, new HeuristicFunctionAscendent());
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(3057, p1.OperationCount);

        }
        [Test]
        public void counterMinMaxAlfaBeta3HAsc()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(3, new HeuristicFunctionAscendent());
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(84577, p1.OperationCount);

        }
        [Test]
        public void counterMinMaxAlfaBeta4HAsc()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(4, new HeuristicFunctionAscendent());
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(2676841, p1.OperationCount);

        }
        [Test]
        public void counterMinMaxAlfaBeta5HAsc()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(5, new HeuristicFunctionAscendent());
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(81995855, p1.OperationCount);

        }



        //[Test]
        //public void counterMinMaxNew5()
        //{
        //    ITavola tavola = new Tavola();
        //    AbsAIPlayer p1 = new MinMax(5);
        //    IPlayer p2 = new HumanPlayer();
        //    IGioco gioco = new Gioco(tavola);
        //    Bant bantumi = new Bant(gioco, p1, p2);
        //    int i = p1.Elaborazione(gioco);
        //    Assert.AreEqual(10000000000, p1.OperationCount);

        //}

        //[Test]
        //public void counterMinMaxNew6()
        //{
        //    ITavola tavola = new Tavola();
        //    AbsAIPlayer p1 = new MinMax(6);
        //    IPlayer p2 = new HumanPlayer();
        //    IGioco gioco = new Gioco(tavola);
        //    Bant bantumi = new Bant(gioco, p1, p2);
        //    int i = p1.Elaborazione(gioco);
        //    Assert.AreEqual(129, p1.OperationCount);

        //}
        [Test]
        public void counterMinMaxAlfaBeta1()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(1);
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(83, p1.OperationCount);

        }
        [Test]
        public void counterMinMaxAlfaBeta2()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(2);
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(2209, p1.OperationCount);

        }
        [Test]
        public void counterMinMaxAlfaBeta3()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(3);
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(56770, p1.OperationCount);

        }
        [Test]
        public void counterMinMaxAlfaBeta4()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(4);
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(1320574, p1.OperationCount);

        }

        [Test]
        public void counterMinMaxAlfaBeta5()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(5);
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(25298451, p1.OperationCount);

        }

        //[Test]
        //public void counterMinMaxAlfaBeta6()
        //{
        //    ITavola tavola = new Tavola();
        //    AbsAIPlayer p1 = new MinMaxAlphaBeta(6);
        //    IPlayer p2 = new HumanPlayer();
        //    IGioco gioco = new Gioco(tavola);
        //    Bant bantumi = new Bant(gioco, p1, p2);
        //    int i = p1.Elaborazione(gioco);
        //    Assert.AreEqual(248178059, p1.OperationCount);

        //}

        [Test]
        public void counterMinMaxAlfaBeta7()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(7, new HeuristicFunctionValue(Lato.A));
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(0, p1.OperationCount);

        }
        [Test]
        public void counterMinMaxAlfaBeta9()
        {
            ITavola tavola = new Tavola();
            AbsAIPlayer p1 = new MinMaxAlphaBeta(9, new HeuristicFunctionValue(Lato.A));
            IPlayer p2 = new HumanPlayer();
            IGioco gioco = new Gioco(tavola);
            Bant bantumi = new Bant(gioco, p1, p2);
            int i = p1.Elaborazione(gioco);
            Assert.AreEqual(0, p1.OperationCount);

        }

    }

}
