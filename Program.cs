using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace logics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] var = { "W", "X", "Y", "Z" };

            Console.WriteLine("enter number of variables");

            int num =int.Parse(Console.ReadLine());

            if (num > 4 || num < 1)
            {
                Console.WriteLine("please enter 1:4 variables");
                return;
            }

            Console.WriteLine("enter K-map");

            string[] k = new string[(int)Math.Pow(2, num)];

            for(int i = 0; i < k.Length; i++)
            {
                k[i]=Console.ReadLine();
            }

            Console.WriteLine("the simplyfication is:");

            switch (num)
            {
                case 1:
                    Console.WriteLine((one(k, var[0])));
                    break;

                case 2:
                    Console.WriteLine(two(k, var[0], var[1]));
                    break;

                case 3:
                    Console.WriteLine(three(k, var[0], var[1], var[2]));
                    break;

                    case 4:
                    Console.WriteLine(four(k, var[0], var[1], var[2], var[3]));
                    break;
                
            }

        }


        static string one(string[] k, string variable)
        {
            string ones = "";  string zeros = "";
           

            for (int i = 0; i < k.Length; i++)
            {
                if (k[i] == "1")
                    ones = ones + variable + i;

                else 
                    zeros ="!" + zeros + variable + i;
            }

            if (ones == "")
                return "0";

            else if (zeros == "")
                return "1";

            else return ones + "+" + zeros;
        }





        static string two(string[]k , string var1 , string var2)
        {
            string[,] table = new string[2, 2];
            table[0, 0] = k[0];
            table[0, 1] = k[1];
            table[1, 0] = k[2];
            table[1, 1] = k[3];

            string ones = "";  string zeros = "";

            for (int i =0;i < 2; i++)
            {
                for (int j =0;j < 2;j++)
                {
                    if (table[i,j] == "1")
                        ones += "(" + var1 + i + "*" + var2 + j + ")";

                    else zeros += "(" + var1 + i + "*!" + var2 + j + ")";
                }
            }

            if (ones == "")
                return "0";

            else if (zeros == "")
                return "1";

            else return ones + "+" + zeros;
        }






        static string three(string[]k , string var1 , string var2 , string var3)
        {
            string[,] table = new string[2, 4];
            table[0, 0] = k[0];
            table[0, 1] = k[1];
            table[0, 3] = k[3];
            table[0, 2] = k[2];
            table[1, 0] = k[4];
            table[1, 1] = k[5];
            table[1, 3] = k[7];
            table[1, 2] = k[6];


            string ones = "";  string zeros = ""; 

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (table[i, j] == "1")
                        ones += "(" + var1 + i + var2 + (j / 2) + "*" + var3 + (j % 2) + ")";

                    else zeros += "(!" + var1 + i + "*!" + var2 + (j / 2) + "*!" + var3 + (j % 2) + ")";
                }
            }

            if (ones == "")
                return "0";

            else if (zeros == "")
                return "1";

            else return ones + "+" + zeros;
        }






        static string four(string[]k , string var1 , string var2 , string var3 , string var4)
        {
            string[,] table = new string[4, 4];
            table[0, 0] = k[0];
            table[0, 1] = k[1];
            table[0, 3] = k[3];
            table[0, 2] = k[2];
            table[1, 0] = k[4];
            table[1, 1] = k[5];
            table[1, 3] = k[7];
            table[1, 2] = k[6];
            table[3, 0] = k[8];
            table[3, 1] = k[9];
            table[3, 3] = k[11];
            table[3, 2] = k[10];
            table[2, 0] = k[12];
            table[2, 1] = k[13];
            table[2, 3] = k[15];
            table[2, 2] = k[14];


            string ones = ""; string zeros = "";

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (table[i, j] == "1")
                        ones += "(" + var1 + i + "*" + var2 + (j / 2) + "*" + var3 + (j % 2) + var4 + ")";

                    else zeros += "(!" + var1 + i + "*!" + var2 + (j / 2) + "*!" + var3 + (j % 2) + "*" + var4 + ")";
                }
            }

            if (ones == "")
                return "0";

            else if (zeros == "")
                return "1";

            else return ones + "+" + zeros;
        }

    }
}
