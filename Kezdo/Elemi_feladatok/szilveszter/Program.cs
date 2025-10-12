using System;
using System.Collections.Generic;
using System.Linq;
namespace szilveszter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> bemenet = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToList();
            List<int> kimenet = new List<int>();
            List<int> honapok = new List<int> { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            List<string> szavak = new List<string> { " honap ", " nap ", " ora ", " perc " ," masodperc " };
            for (int i = bemenet.Count-1; i >= 4; i--) {
                if (bemenet[i]!= 0 && 60 - bemenet[i] < 60)
                {
                    kimenet.Add(60 - bemenet[i]);
                    bemenet[i] = 0;
                    bemenet[i-1] += 1;
                }
            }
            if (bemenet[3] != 0 && 24 - bemenet[3] < 24)
            {
                kimenet.Add(24 - bemenet[3]);
                bemenet[3] = 0;
            }
            if (bemenet[2] != 1)
            {
                if (31 - bemenet[2] < 31)
                {
                    kimenet.Add(31 - bemenet[2]);
                    bemenet[2] = 0;
                }
                if (12 - bemenet[1] < 12)
                {
                    kimenet.Add(12 - bemenet[1]);
                    bemenet[1] = 0;
                }
            }
            else if (bemenet[2] == 1)
            {
                kimenet.Add(12 - bemenet[1] + 1);
            }
            kimenet.Reverse();

            Console.WriteLine(String.Join(" ", kimenet.Select((x, i) => x + szavak[i]).Where(x => int.Parse(x.Split(" ")[0]) != 0)));



        }
    }
}
