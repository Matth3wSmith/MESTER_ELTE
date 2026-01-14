using static System.Formats.Asn1.AsnWriter;

namespace focistat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] hazai = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] vendeg = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            /*int[] hazai = { 1, - 1, 3 };
            int[] vendeg = { 2, 4, -1 };*/

            int[] csop1 = { hazai[0], vendeg[1], vendeg[2] };
            int[] csop2 = { vendeg[0], hazai[1], hazai[2] };

            //Ki tudjuk számolni
            //1 adat nincs
            //ha 2 adat nincs:
            //   csak akkor tudjuk kiszámolni, ha a kapura rúgás 0
            csop1 = javit(csop1);
            csop2 = javit(csop2);

            hazai[0] = csop1[0];
            hazai[1] = csop2[1];
            hazai[2] = csop2[2];
            vendeg[0] = csop2[0];
            vendeg[1] = csop1[1];
            vendeg[2] = csop1[2];

            Console.WriteLine(String.Join(" ",hazai));
            Console.WriteLine(String.Join(" ",vendeg));


        }
        static int hibak(int[] csop)
        {
            return String.Join("",csop).Count(c => c == '-');
        }
        static int[] javit(int[] csop1)
        {
            if (hibak(csop1) == 1)
            {
                if (csop1[0] == -1)
                {
                    csop1[0] = csop1[2] - csop1[1];
                }
                else if (csop1[1] == -1)
                {
                    csop1[1] = csop1[2] - csop1[0];
                }
                else
                {
                    csop1[2] = csop1[0] + csop1[1];
                }
            }
            else if (csop1[2] == 0)
            {
                csop1[0] = 0;
                csop1[1] = 0;
            }

            return csop1;
        }
    }
}
