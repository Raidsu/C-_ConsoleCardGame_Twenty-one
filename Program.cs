using System;

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
     /*   static ushort getCardValue(ref CardRank rank)
        {
            switch (rank)
            {
                case CardRank.two: return 2; break;
                case CardRank.three: return 3; break;
                case CardRank.four: return 4; break;
                case CardRank.five: return 5; break;
                case CardRank.six: return 6; break;
                case CardRank.seven: return 7; break;
                case CardRank.eight: return 8; break;
                case CardRank.nine: return 9; break;
                case CardRank.ten: return 10; break;
                case CardRank.knave: return 2; break;
                case CardRank.queen: return 3; break;
                case CardRank.king: return 4; break;
                case CardRank.ace: return 11; break;
            }
        }
     */

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

            /*
             МЕТОД РАСПЕЧАТЫВАНИЯ КАРТ КОЛОДЫ (ИСПОЛЬЗУЕТСЯ ДЛЯ ОТЛАДКИ)
             */
            public static void printDeck(ref Cards[] cards)
            {
                for (ushort i = 0; i < cards.Length; i++)
                {
                   //вызываем метод печати номинала и масти карты
                    printCardValue(ref cards[i].rank, ref cards[i].suite);
                }
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

            //перетасовываем карты (метод из структуры Cards)
            Cards.shufleDeck(ref cards);

//распечатываем колоду (для отладки, закомментировать после проверки) (метод из структуры Cards)
//Cards.printDeck(ref cards);

            
            //Игра в "Бдэкджек" или "Очко" на 2 игроков


          
            




            

        }
    }
}
