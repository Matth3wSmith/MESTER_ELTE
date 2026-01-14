namespace aplusb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long[] szam1 = Console.ReadLine().Split(" ").Select(x => long.Parse(x)).ToArray();
            Console.WriteLine((szam1[0] + szam1[1]) + "\n" + (szam1[0] * szam1[1]));


        }
    }
}
