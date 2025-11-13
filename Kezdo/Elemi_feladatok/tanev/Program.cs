namespace tanev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] honap = [31,28,31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
            string[] nappok = [ "", "hétfő", "kedd", "szerda", "csütörtök", "péntek", "szombat", "vasárnap"];

            int ev = int.Parse(Console.ReadLine())+1;
            //Szökőév ellenőrzés
            //Az évszám maradék nélkül osztható 4-gyel, de nem osztható 100-zal,
            //kivéve, ha az évszám osztható 400 - zal.
            if ((ev%4 == 0 && ev%100 != 0) || ev % 400 == 0) honap[1] = 29;

            int elsejenap = int.Parse(Console.ReadLine());
            elsejenap = 2;
                int[] husvetvasarnap = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            List<string> szunetek = new List<string>();

            //Tanév kezdés
            szunetek.Add(ev-1+"."+"9."+ (elsejenap!=1? Convert.ToString(8-elsejenap+1):"1"));
            Console.WriteLine(szunetek[0]);
            //Őszi szünet kezdése
            //Nap kiszámolása: szeptember 1-től október 24-ig  számoljuk a napokat és 7-tel osztva a maradék lesz hogy melyik nap;




        }
    }
}
