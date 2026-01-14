namespace arab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int szavakdb = int.Parse(Console.ReadLine());
            string szo = Console.ReadLine();
            string mgh = "euioa";
            string eredmeny = "";

            for (int i = 0; i < szo.Length-2; i++)
            {
                if ( !(mgh.Contains(szo[i]) && szo[i+1]!=' ' &&  szo[i + 2] != ' ' && !mgh.Contains(szo[i+1]) && !mgh.Contains(szo[i + 2])) )
                {
                    //eredmeny += szo[i];
                    eredmeny = szo[i]+eredmeny;
                }
            }

            eredmeny = szo[szo.Length - 2] + eredmeny;
            eredmeny = szo[szo.Length - 1] + eredmeny;
            Console.WriteLine(eredmeny);
        }
    }
}
