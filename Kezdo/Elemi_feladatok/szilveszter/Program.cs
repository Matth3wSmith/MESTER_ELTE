using System;
using System.Collections.Generic;
using System.Linq;
namespace szilveszter
{
    internal class Program
    {
        static void Main(string[] args)
        {
             // Bemenet olvasása
        string[] input = Console.ReadLine().Split(' ');
        int ev = int.Parse(input[0]);
        int honap = int.Parse(input[1]);
        int nap = int.Parse(input[2]);
        int ora = int.Parse(input[3]);
        int perc = int.Parse(input[4]);
        int masodperc = int.Parse(input[5]);

        DateTime kezdet = new DateTime(ev, honap, nap, ora, perc, masodperc);
        DateTime cel = new DateTime(ev, 12, 31, 23, 59, 59);

        // Naptári különbség kiszámítása
        int evKul = 0, honapKul = 0, napKul = 0, oraKul = 0, percKul = 0, masodpercKul = 0;
        DateTime temp = new DateTime(kezdet.Year, kezdet.Month, kezdet.Day, kezdet.Hour, kezdet.Minute, kezdet.Second);

        // Évek
        while (temp.AddYears(1).Year <= ev)
        {
            temp = temp.AddYears(1);
            evKul++;
        }

        // Hónapok
        while (temp.AddMonths(1).Month <= 12)
        {
            temp = temp.AddMonths(1);
            honapKul++;
        }

        // Napok
        while (temp.AddDays(1).Day <= 31)
        {
            temp = temp.AddDays(1);
            napKul++;
        }

        // Órák
        while (temp.AddHours(1).Hour <= 23)
        {
            temp = temp.AddHours(1);
            oraKul++;
        }

        // Percek
        while (temp.AddMinutes(1).Minute < 60)
        {
            temp = temp.AddMinutes(1);
            percKul++;
        }

        // Másodpercek
        while (temp.AddSeconds(1).Minute < 60)
        {
            temp = temp.AddSeconds(1);
            masodpercKul++;
        }

        // Kiírás csak a nem nulla értékekre
        string eredmeny = "";
        if (evKul > 0) eredmeny += $"{evKul} ev ";
        if (honapKul > 0) eredmeny += $"{honapKul} honap ";
        if (napKul > 0) eredmeny += $"{napKul} nap ";
        if (oraKul > 0) eredmeny += $"{oraKul} ora ";
        if (percKul > 0) eredmeny += $"{percKul} perc ";
        if (masodpercKul > 0) eredmeny += $"{masodpercKul} masodperc";

        Console.WriteLine(eredmeny.Trim());





            /*List<int> bemenet = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToList();
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

            Console.WriteLine(String.Join(" ", kimenet.Select((x, i) => x + szavak[i]).Where(x => int.Parse(x.Split(" ")[0]) != 0)));*/



        }
    }
}
