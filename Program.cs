using System;
using System.Threading;


namespace ConsoleCardGameTwentyOne
{
    class Program
    { 

        /*
         * 
         * НОМИНАЛЫ КАРТ
         * 
         */
        enum CardRank
        {
            two, 
            three,
            four,
            five,
            six,
            seven,
            eight,
            nine,
            ten,
            knave,
            queen,
            king,
            ace,
            max_rank
        }

        /*
         * 
         * МАСТИ КАРТ
         * 
         */
    enum CardSuite
        {
            spades, //пики
            hearts, //червы
            diamonds, //бубны
            clubs, //крести
            max_suite
        }


       /*
         * ПЕЧАТь В КОНСОЛЬ НОМИНАЛА И МАСТИ КАРТЫ
         */
        static void printCardValue(ref CardRank rank, ref CardSuite suite)
        {
            switch (rank)
            {
                case CardRank.two : Console.Write('2'); break;
                case CardRank.three: Console.Write('3'); break;
                case CardRank.four: Console.Write('4'); break;
                case CardRank.five: Console.Write('5'); break;
                case CardRank.six: Console.Write('6'); break;
                case CardRank.seven: Console.Write('7'); break;
                case CardRank.eight: Console.Write('8'); break;
                case CardRank.nine: Console.Write('9'); break;
                case CardRank.ten: Console.Write("10"); break;
                case CardRank.knave: Console.Write("Валет"); break;
                case CardRank.queen: Console.Write("Дама"); break;
                case CardRank.king: Console.Write("Король"); break;
                case CardRank.ace: Console.Write("Туз"); break;
            }

            switch (suite)
            {
                case CardSuite.spades: Console.WriteLine(" Пик"); break;
                case CardSuite.hearts: Console.WriteLine(" Червей"); break;
                case CardSuite.diamonds: Console.WriteLine(" Бубен"); break;
                case CardSuite.clubs: Console.WriteLine(" Крестей"); break;
            }
        }

        /*
         * МЕТОД, ВОЗВРАЩАЮЩИЙ КОЛИЧЕСТВО НАБРАННЫХ ОЧКОВ ЗА КАРТУ
         */
        static ushort getCardValue(ref CardRank rank)
        {
            switch (rank)
            {
                case CardRank.two: return 2;
                case CardRank.three: return 3;
                case CardRank.four: return 4;
                case CardRank.five: return 5;
                case CardRank.six: return 6;
                case CardRank.seven: return 7;
                case CardRank.eight: return 8;
                case CardRank.nine: return 9;
                case CardRank.ten: return 10;
                case CardRank.knave: return 2;
                case CardRank.queen: return 3;
                case CardRank.king: return 4;
                case CardRank.ace: return 11;
                default: throw new ArgumentOutOfRangeException();

            }
        }
     

        /*
         * 
         *СТРУКТУРА КАРТ
         * 
         */
        public struct Cards
        {
            CardRank rank;
            CardSuite suite;
            
            /*
             * МЕТОД ИНИЦИАЛИЗАЦИИ КОЛОДЫ КАРТ ПО ЭЛЕМЕНТАМ ПЕРЕЧИСЛЕНИЙ
              */
            public static void setCardsDeck(ref Cards[] cards)
            {
                ushort numOfCards = 0;

                for (ushort r = 0; r < (ushort)CardRank.max_rank; r++)
                {
                    for (ushort s = 0; s < (ushort)CardSuite.max_suite; s++)
                    {
                        cards[numOfCards].rank = (CardRank)r;
                        cards[numOfCards].suite = (CardSuite)s;
                        numOfCards++;
                    }
                }

            }

            //МЕТОД ВОЗВРАЩАЮЩИЙ ЗНАЧЕНИЕ КАРТЫ
            public static ushort getCard(ref Cards[] cards, ref ushort turn)
            {
                   
                return getCardValue(ref cards[turn].rank);
            }

            //МЕТОД ВЫВОДЯЩИЙ НА ЭКРАН ЗНАЧЕНИЕ КАРТЫ
            public static void printCard(ref Cards[] cards, ref ushort turn)
            {
                Console.Write("Вам выпала карта: ");
                printCardValue(ref cards[turn].rank, ref cards[turn].suite);
            }



            /*
             МЕТОД ПЕРЕТАСОВКИ КАРТ
             */
            public static void shufleDeck(ref Cards[] cards)
            {
                //подключаем ГСЧ
                Random random = new Random();

                //создаем переменную для получения рандомного числа
                ushort swapme;
                Cards temp;
                

                //цикл перемешивания карт (повторяется столько раз, сколько карт в колоде)
                for (ushort i=0;i<cards.Length;i++)
                {
                    //получаем случайное значение между 0 и количеством карт в колоде
                    swapme = (ushort)random.Next(0, (cards.Length) - 1);

                    temp = cards[i];
                    cards[i] = cards[swapme];
                    cards[swapme] = temp;

                }
                


            }

        }


        /*
         ФУНКЦИЯ ОПРЕДЕЛЯЮЩАЯ ТОГО КТО ХОДИТ ПЕРВЫМ
         */

        static bool isFirst(ref string player1, ref string player2)
        {
                        
            while (true)
            {
                Console.WriteLine($"Кто ходит первым? (введите число)\n 1 - {player1}\n2 - {player2}");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num == 1) return true;
                else if (num == 2) return false;
                else
                {
                    Console.WriteLine("Ошибка! Введите 1 или 2");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
        }

        /*
                 ФУНКЦИЯ ОПРЕДЕЛЯЮЩАЯ ХОЧЕТ ЛИ ИГРОК ВЗЯТЬ ЕЩЕ КАРТУ
        */

        static bool getAnswer(ref string player, ref ushort plcount, ref string opponent, ref ushort opcount)
        {
            
            
            while (true)
            {

                Console.WriteLine($"{player} - у вас {plcount} очков, у игрока {opponent} - {opcount} очков.");
                Console.WriteLine($"{player}, хотите взять еще карту?(введите число)\n 1 - Да\n2 - Нет");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num == 1) return true;
                else if (num == 2) return false;
                else
                {
                    Console.WriteLine("Ошибка! Введите 1 или 2");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
        }
        static bool getAnswer()
        {
            while (true)
            {

                Console.WriteLine($"1 - Да\n2 - Нет");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num == 1) return true;
                else if (num == 2) return false;
                else
                {
                    Console.WriteLine("Ошибка! Введите 1 или 2");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
        }


            /*
             МЕТОД ДОБОРА ИГРАЮЩИХ КАРТ
             */
            static void inGame(ref string player, ref ushort plcount, ref string opponent, ref ushort opcount, ref Cards[] cards, ref ushort turn)
        {
            bool agree = true; //хочет ли игрок взять еще одну карту
            while (true)
            {
                agree = getAnswer(ref player, ref plcount, ref opponent, ref opcount);
                if (agree == true)
                {
                    Console.Clear();
                    plcount += Cards.getCard(ref cards, ref turn);

                    Cards.printCard(ref cards, ref turn);

                    turn++;
                    

                    if (plcount > 21)
                    {

                        Console.WriteLine($"{player}, вы проиграли со счетом {plcount}\nПобедитель - {opponent}!");
                        break;
                    }
                    
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }
        }


        /*
         МЕТОД ИГРЫ В 21
         */
        static void gameTwentyOne (ref string player1, ref string player2, ref ushort pl1count, ref ushort pl2count, ref ushort turn, ref bool players, ref Cards[] cards)
        {
            //перетасовываем карты (метод из структуры Cards)
            Cards.shufleDeck(ref cards);

            //кто ходит первым
            players = isFirst(ref player1, ref player2);

                //меняем игроков местами если первым будет ходить изначальный "игрок 2"
                if (players == false)
                {
                    string temp;
                    temp = player1;
                    player1 = player2;
                    player2 = temp;
                }

                //игроки получают стартовые карты
                pl1count = Cards.getCard(ref cards, ref turn); //перегруженый метод (печатает колоду или возвращает значение номинала карты)
                turn++;
                pl2count = Cards.getCard(ref cards, ref turn);
                turn++;
                Console.Clear();
                Console.WriteLine($"Начальные карты розданы.");

                //играет 1 игрок
                inGame(ref player1, ref pl1count, ref player2, ref pl2count, ref cards, ref turn);
            if (pl1count < 21)
            {
                //играет 2 игрок
                inGame(ref player2, ref pl2count, ref player1, ref pl1count, ref cards, ref turn);
                
                if (pl1count > pl2count) Console.WriteLine($"Со счетом {pl1count} - {pl2count} побеждает {player1}");
                else if (pl1count > pl2count) Console.WriteLine($"НИЧЬЯ! Со счетом {pl1count} - {pl2count}");
                else Console.WriteLine($"Со счетом {pl2count} - {pl1count} побеждает {player2}");
            }

                
            
           
        }

        /*
         * 
         *ОСНОВНАЯ ФУНКЦИЯ
         * 
         */
        static void Main(string[] args)
        {
            //создаем массив карт (из расчета количество номиналов карт * количество мастей карт)
            Cards[] cards = new Cards[(ushort)CardRank.max_rank * (ushort)CardSuite.max_suite];

            //инициализируем колоду (метод из структуры Cards)
            Cards.setCardsDeck(ref cards);

            

//распечатываем колоду (для отладки, закомментировать после проверки) (метод из структуры Cards)
//Cards.printDeck(ref cards);


            //Игра в "Бдэкджек" или "Очко" на 2 игроков

            Console.WriteLine("Вас приветствует консольная игра (по упрощенным правилам) \"Очко\"\nДавайте знакомиться\nИгрок №1 введите имя:");
            string player1 = Console.ReadLine();
            Console.WriteLine("Игрок №2 введите имя:");
            string player2 = Console.ReadLine();
            Console.Clear();
            
            ushort pl1count = 0; //переменная подсчета очков игрока 1
            ushort pl2count = 0; //переменная подсчета очков игрока 2
            ushort turn = 0;     //переключение по элементам массива карт
            bool players=true; //переключатель игроков true - игрок 1, false - игрок 2
            bool again = true; //играем ли еще раз?

            while (again == true)
            {
                gameTwentyOne(ref player1, ref player2, ref pl1count, ref pl2count, ref turn, ref players, ref cards);
                Thread.Sleep(3000);
                Console.Clear();
                Console.WriteLine("Сыграем еще?");
                again = getAnswer();
                Console.Clear();

            }
            











        }
    }
}
