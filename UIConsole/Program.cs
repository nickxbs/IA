using System;
using System.Globalization;
using System.Threading;
using Bantumi.Entities;
using Bantumi.Entities.Interface;

namespace UIConsole
{
    public class Program
    {
        private static int sleepTime = 0;
        static void Main(string[] args)
        {
            int vittorieA = 0;
            int vittorieB = 0;
            int parita = 0;
            //while (true)
            //{
                ITavola tavola = new Tavola();
                IPlayer p1 = new MinMaxAlphaBeta(4,new HeuristicFunctionValue(Lato.A));
                IPlayer p2 =  new MinMaxAlphaBetaWithOpen(4,new HeuristicFunctionValue(Lato.B));
                //IPlayer p2 = new MinMaxPlayer(Convert.ToInt32(args[0]));
                IGioco gioco = new Gioco(tavola);
                Bant bantumi = new Bant(gioco, p1, p2);
                //gioco.Start();
                Render(gioco.Tavola);
                Console.WriteLine("Muove Player" + gioco.ProssimoTurno);
                Thread.Sleep(sleepTime);
                while (gioco.Vincitore == null && !gioco.Parita)
                {
                    IPlayer player = bantumi.GetPlayer(gioco.ProssimoTurno);
                    if (player is HumanPlayer)
                    {
                        if (gioco.ProssimoTurno == Lato.A)
                        {
                            Console.WriteLine("Player" + Lato.A + " scegli una buca fra 0 e 5");
                        }
                        else
                        {
                            Console.WriteLine("Player" + Lato.B + " scegli una buca fra 7 e 12");
                        }
                        gioco.Muovi(ReadValue(gioco));
                    }
                    else
                    {
                        if (player is IAIPlayer)
                        {
                            IAIPlayer aiPlayer = player as IAIPlayer;
                            int i = aiPlayer.Elaborazione(gioco);

                            Console.WriteLine("MUOVE" + i);

                            gioco.Muovi(i);

                        }
                    }

                    Render(gioco.Tavola);
                    Thread.Sleep(sleepTime);
                }
                if (gioco.Parita)
                {
                    Console.WriteLine("Parità");

                    parita++;
                }
                else
                {

                    if (gioco.Vincitore == Lato.A.ToString())
                    {
                        Console.WriteLine("Ha vinto Player" + gioco.Vincitore);
                        Console.ReadLine();
                        //vittorieA++;
                    }
                    if (gioco.Vincitore == Lato.B.ToString())
                    {
                        Console.WriteLine("Ha vinto Player" + gioco.Vincitore);
                        Console.ReadLine();
                        //vittorieB++;
                    }
                }

            //}
        }

        public static void Render(ITavola tavola)
        {
            Console.WriteLine(String.Format(" {0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}  ", " ", tavola.Buche[12].Semi, tavola.Buche[11].Semi, tavola.Buche[10].Semi, tavola.Buche[9].Semi, tavola.Buche[8].Semi, tavola.Buche[7].Semi, " "));
            Console.WriteLine(String.Format(" {0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}  ", tavola.Buche[13].Semi, " ", " ", " ", " ", " ", " ", tavola.Buche[6].Semi));
            Console.WriteLine(String.Format(" {0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}  ", " ", tavola.Buche[0].Semi, tavola.Buche[1].Semi, tavola.Buche[2].Semi, tavola.Buche[3].Semi, tavola.Buche[4].Semi, tavola.Buche[5].Semi, " "));
        }

        public static int ReadValue(IGioco gioco)
        {
            int val = -1;
            while (val < 0)
            {
                string s = Console.ReadLine();
                int tmpVal;
                if (int.TryParse(s, NumberStyles.None, null, out tmpVal) && tmpVal >= 0)
                {
                    if (gioco.MossaValida(tmpVal))
                        return tmpVal;

                }
                Console.WriteLine("Errore, mossa non valida!");
            }
            return val;
        }
    }
}
