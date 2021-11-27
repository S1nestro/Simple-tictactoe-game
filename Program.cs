using System;
using System.Collections.Generic;

namespace tic_tac_toe_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] a = new char[9] { 'O', '.', 'X', '.', 'O', 'X', '.', '.', 'X' };
            TicTacToe.Check(a);
            /*{'O' , '.' ,‘X'}，
              {'.' , 'O' , 'X'},
              {'.' , '.' , 'X'}
            */
            char[] b = new char[9] { 'O', '.', 'X', '.', 'O', 'X', '.', '.', '.' };
            TicTacToe.Check(b);
            /*{'O' , '.' ,‘X'}，
              {'.' , 'O' , 'X'},
              {'.' , '.' , '.'}
           */
            char[] c = new char[9] { 'O', '.', 'X', '.', 'O', 'X', '.', '.', 'O' };
            TicTacToe.Check(c);
            /*{'O' , '.' ,‘X'}，
              {'.' , 'O' , 'X'},
              {'.' , '.' , 'O'}
           */
            char[] d = new char[9] { 'O', 'X', 'X', 'X', 'O', 'X', 'O', '.', 'O' };
            TicTacToe.Check(d);
            /*{'O' , 'X' ,‘X'}，
              {'X' , 'O' , 'X'},
              {'O' , '.' , 'O'}
           */
            char[] e = new char[9] { '.', '.', '.', '.', '.', '.', '.', '.', '1' };
            TicTacToe.Check(e);
            /*{'.' , '.' ,‘.'}，
              {'.' , '.' , '.'},
              {'.' , '.' , '1'}
           */
            char[] f = new char[9] { 'O', '.', 'X', 'O', 'X', '.', 'X', 'O', '.' };
            TicTacToe.Check(f);
            /*{'O' , '.' ,‘X'}，
              {'O' , 'X' , '.'},
              {'X' , 'O' , '.'}
           */
            char[] g = new char[9] { 'O', '.', 'X', 'O', 'X', 'X', 'O', 'X', '.' };
            TicTacToe.Check(g);
            /*{'O' , '.' ,‘X'}，
              {'O' , 'X' , 'X'},
              {'O' , 'X' , '.'}
           */
            char[] h = new char[9] { 'O', 'X', '.', 'O', 'X', '.', 'O', 'X', '.' };
            TicTacToe.Check(h);
            /*{'O' , 'X' ,‘.'}，
              {'O' , 'X' , '.'},
              {'O' , 'X' , '.'}
           */
        }


    }

    public static class TicTacToe
    {
        static List<int> list1 = new List<int>();//存放所有x位置的值
        static List<int> list2 = new List<int>();//存放所有o位置的值
        static string[] result = { "123", "456", "789", "147", "258", "369", "159", "357" };
        static List<string> allResult = new List<string>(result);

        public static void Check(char[] a)
        {
            list1.Clear();
            list2.Clear();
            int index = 1;
            int j = 1;
            foreach (char ch in a)
            {
                if (ch != 'O' && ch != 'X' && ch != '.')
                {
                    Console.WriteLine("Wait,what?");
                    return;
                }
                else if (ch == 'X')
                {
                    list1.Add(index);

                }
                index++;
            }
            foreach (char ch in a)
            {
                if (ch == 'O')
                {
                    list2.Add(j);
                }
                j++;
            }

            if (list1.Count < list2.Count)
            {
                Console.WriteLine("Wait,what?");
                return;
            }
            else if (list1.Count == list2.Count)
            {
                if (list1.Count >= 3)
                {
                    if (winOrLose(list1))
                    {
                        Console.WriteLine("Wait,what?");
                        return;
                    }
                    else if (winOrLose(list2) && !winOrLose(list1))
                    {
                        Console.WriteLine("O won");
                        return;
                    }
                    else 
                    {
                        Console.WriteLine("X's turn");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("X's turn");
                    return;
                }


            }
            else
            {
                if (list1.Count - list2.Count != 1)
                {
                    Console.WriteLine("Wait,what?");
                    return;
                }
                else
                {
                    if(list1.Count<3)
                    {
                        Console.WriteLine("O's turn");
                        return;
                    }
                    else
                    {
                        if(winOrLose(list1))
                        {
                            Console.WriteLine("X won");
                            return;
                        }
                        else if(winOrLose(list2))
                        {
                            Console.WriteLine("Wait,what?");
                            return;
                        }
                        else if(!winOrLose(list1) && !winOrLose(list2))
                        {
                            Console.WriteLine("Draw");
                            return;
                        }    
                    }
                }

            }

        }
        static bool winOrLose(List<int> list)
        {

            QuickSort(list, 0, list.Count - 1);
            string s1 = string.Join("", list);
            foreach (string s in allResult)
            { 
                if (s1.Contains(s))
                {
                    return true;
                }
               
            }
            return false;
        }

        static void QuickSort(List<int> list, int L, int R)
        {
            if (L > R)
            {
                return;
            }

            int Left = L;
            int Right = R;
            int pivot = list[Left];
            while (Left < Right)
            {
                while (Left < Right && list[Right] >= pivot)
                {
                    Right--;
                }

                if (Left < Right)
                {
                    list[Left] = list[Right];
                }

                while (Left < Right && list[Left] <= pivot)
                {
                    Left++;
                }

                if (Left < Right)
                {
                    list[Right] = list[Left];
                }

                if (Left >= Right)
                {
                    list[Left] = pivot;
                }
            }
            QuickSort(list, L, Right - 1);
            QuickSort(list, Right + 1, R);
        }

    }








}

