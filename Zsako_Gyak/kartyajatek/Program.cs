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
            int index = 0;
            for(int k = 0; k < kartyaSzam[0]; k++) { 
                for(int i = 0; i < botond.Count; i++)
                {
                    if(min > Math.Abs(aliz[k] - botond[i]))
                    {
                        min = Math.Abs(aliz[k] - botond[i]);
                        index = i;

                    }
                }
                botond.RemoveAt(index);
            }
        }
    }
}
