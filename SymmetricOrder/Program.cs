using System;
using System.Collections.Generic;

namespace SymmetricOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            // source of the problem:
            // https://open.kattis.com/problems/symmetricorder

            
            int myCounter = 1;
            var generalList = new List<string>();

            while (true)
            {
                // must be:  1 =< (number of items) <= 15
                // (0) value for exit
                var n = SimpleConverter(Console.ReadLine()); 

                if (n == 0)
                    break;
                else if (n > 15 || n < 0)
                    continue;
                else
                {

                    var list = EnterList(n);

                    generalList.AddRange(ListOrder(list, n, myCounter));

                    myCounter++;
                }
            } // -- end while --

            ShowList(generalList);

        } // == end main ==

        public static string EnterRightString()
        {
            var str = " ";
            try
            {
                str = Console.ReadLine();

                // item length <= 25 && not contains a space
                if (str.Length > 25 || str.Contains(' '))
                    throw new FormatException();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("FormatException !!!!");
                str = EnterRightString();
                return str;
            }
            return str;
        }

        private static List<string> EnterList(int m)
        {
            var lst = new List<string>();
            for (int i = 0; i < m; i++)
            {
                lst.Add(EnterRightString());
            }
            return lst;
        }

        private static void ShowList(List<string> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                Console.WriteLine(l[i]);
            }
        }
        private static List<string> ListOrder(List<string> ls, int num, int round)
        {
            var oddList = new List<string>();
            var evenList = new List<string>();

            for (int i = 0; i < ls.Count; i++)
            {
                if (i % 2 == 0)
                   evenList.Add(ls[i]);
                else
                    oddList.Add(ls[i]);
            }

            var res = CombineTwoArrays(evenList, oddList, round);
            return res;
        }

        private static List<string> CombineTwoArrays(List<string> e, List<string> f, int q)
        {
            var myList = new List<string>();

            var str = $"SET {q}";
            myList.Add(str);

            f.Reverse();

            myList.AddRange(e);
            myList.AddRange(f);
            return myList;
        }
        private static int SimpleConverter(string str)
        {
            int num = 0;

            try
            {
                num = int.Parse(str);
            }

            catch (FormatException ex1)
            {
                Console.WriteLine(ex1.Message);
                Console.WriteLine("FormatException !!!!");
                str = Console.ReadLine();
                num = SimpleConverter(str);
                return num;
            }
            return num;
        }
    }
    // --- input ---
    //7
    //Bo
    //Pat
    //Jean
    //Kevin
    //Claude
    //William
    //Marybeth
    //6
    //Jim
    //Ben
    //Zoe
    //Joey
    //Frederick
    //Annabelle
    //5
    //John
    //Bill
    //Fran
    //Stan
    //Cece
    //0

    // --- output ---
    /*
     SET 1
     Bo
     Jean
     Claude
     Marybeth
     William
     Kevin
     Pat
     SET 2
     Jim
     Zoe
     Frederick
     Annabelle
     Joey
     Ben
     SET 3
     John
     Fran
     Cece
     Stan
     Bill
     */
}
