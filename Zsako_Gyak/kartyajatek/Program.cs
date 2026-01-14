namespace kartyajatek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> kartyaSzam = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> aliz = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> botond = Console.ReadLine().Split(' ').Select(int.Parse). ToList();
            int min = int.MaxValue;
            int osszeg = 0;
            int index = 0;
            //Ez nem teljesen jó
            /*for(int k = 0; k < kartyaSzam[0]; k++) { 
                min = int.MaxValue;
                for (int i = 0; i < botond.Count; i++)
                {
                    Console.WriteLine("aktuális");
                    Console.WriteLine(aliz[k]);
                    Console.WriteLine(botond[i]);
                    if(min > Math.Abs(aliz[k] - botond[i]))
                    {
                        min = Math.Abs(aliz[k] - botond[i]);
                        index = i;

                    }
                    Console.WriteLine(min);

                }
                botond.RemoveAt(index);
                osszeg += min;
            }*/

            //Legnagyobbak legkisebb különbsége
            aliz.Sort();
            aliz.Reverse();
            botond.Sort();
            botond.Reverse();
            for (int k = 0; k < kartyaSzam[0]; k++)
            {
                min = int.MaxValue;
                for (int i = 0; i < botond.Count; i++)
                {
                    /*Console.WriteLine("aktuális");
                    Console.WriteLine(aliz[k]);
                    Console.WriteLine(botond[i]);*/
                    if (i>0 && Math.Abs(aliz[i]-botond[i-1]) < Math.Abs(aliz[k] - botond[i]))
                    {
                        break;
                    }
                    else if (min > Math.Abs(aliz[k] - botond[i]))
                    {
                        min = Math.Abs(aliz[k] - botond[i]);
                        index = i;

                    }
                    //Console.WriteLine(min);

                }
                botond.RemoveAt(index);
                osszeg += min;
            }
            Console.WriteLine(osszeg);

        }
    }
}
