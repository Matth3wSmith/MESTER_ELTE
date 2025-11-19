using System.Net.WebSockets;

namespace tanev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] honap = [31,28,31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
            string[] napok = [ "", "hétfő", "kedd", "szerda", "csütörtök", "péntek", "szombat", "vasárnap"];

            int ev = int.Parse(Console.ReadLine());
            //Szökőév ellenőrzés
            //Az évszám maradék nélkül osztható 4-gyel, de nem osztható 100-zal,
            //kivéve, ha az évszám osztható 400 - zal.
            ev += 1;
            if ((ev%4 == 0 && ev%100 != 0) || ev % 400 == 0) honap[1] = 29;
            ev -= 1;
            int elsejenap = int.Parse(Console.ReadLine());
            int[] husvetvasarnap = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            List<string> szunetek = new List<string>();

            //Tanév kezdés
            //Képlet az első hétfő kiszámítására: Hétfő = 1 + (7 - nap) % 7
            szunetek.Add(ev+"."+"9."+ (elsejenap!=1 ? (1 + (7 - elsejenap) % 7):elsejenap));
            Console.WriteLine(szunetek[0]);
            //Őszi szünet
            Console.WriteLine(String.Join(" ",osziSzunet(ev,honap,napok)));
            //Téli szünet
            Console.WriteLine(String.Join(" ", teliSzunet(ev,honap,napok)));
            //húsvéti szünet    
            Console.WriteLine(String.Join(" ", husvetiSzunet(ev,husvetvasarnap[0],husvetvasarnap[1], honap, napok)));

            //Utolsó tanítási nap
            int napokszama = honap.Sum() - honap[5] - honap[6] - honap[7] + 1;
            int juli1 = napokszama % 7;
            int utolsoTanNap = 0;
            utolsoTanNap = juli1 != 5 ?  1 + (5 - juli1) + 7 :  1+14;
            Console.WriteLine(new DateTime(ev + 1, 6, utolsoTanNap).ToString("yyyy.M.d."));


        }
        static string[] husvetiSzunet(int ev, int husvetHonap, int vasarnap, int[] honap, string[] nappok)
        {
            int utolsoTanNap = vasarnap <= 9 ? honap[2]+vasarnap - 7 - 2 : vasarnap-7-2;
            int elsoTanNap = vasarnap + 2;
            return [new DateTime(ev+1, vasarnap<=9 ? 3:4, utolsoTanNap).ToString("yyyy.M.d."), new DateTime(ev + 1, 4, elsoTanNap).ToString("yyyy.M.d.")];

        }
        static string[] teliSzunet(int ev, int[] honap, string[] nappok)
        {
            //A téli szünet két teljes hét, úgy, hogy tartalmazza karácsonyt
            //és az újévet is, valamint az azt megelőző szombat-vasárnap.
            int napokszama = honap[8] + honap[9] + honap[10] + 24;
            int nap24 = napokszama % 7;
            int nap1 = (napokszama-24+honap[11])%7;
            int utolsoTanNap = 24 - (nap24 + 2);
            int elsoTanNap = nap1 == 1 ? nap1:  1 + nap1 + 1;

            return [new DateTime(ev, 12, utolsoTanNap).ToString("yyyy.M.d."), new DateTime(ev+1, 1, elsoTanNap).ToString("yyyy.M.d.")];


        }


        static string[] osziSzunet(int ev, int[] honap, string[] nappok)
        {
            //Az őszi szünet az október 23.-adikát tartalmazó
            //teljes hét, az őt megelőző szombattal és vasárnappal együtt.

            //Nap kiszámolása: szeptember 1-től október 23-ig  számoljuk a napokat és 7-tel osztva a
            //maradék lesz hogy melyik nap;
            int napokszama = honap[8] + 23;
            int nap23 = napokszama % 7;
            int utolsoTanNap = 23-(nap23 + 2);
            int elsoTanNap = 23+ (7 - nap23 + 1);

            return [ new DateTime(ev, 10, utolsoTanNap).ToString("yyyy.M.d."), new DateTime(ev, 10, elsoTanNap).ToString("yyyy.M.d.")] ;
            
        }



    }
}
