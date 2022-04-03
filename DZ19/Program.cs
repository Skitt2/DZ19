using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ19
{
    class PC
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeCPU { get; set; }
        public double FrequencyCPU { get; set; }
        public int RAM { get; set; }
        public int HDD { get; set; }
        public int VRAM { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<PC> pCs = new List<PC>()
            {
                new PC(){ Id=1, Name="Dell", TypeCPU="intel", FrequencyCPU=3.1, RAM=2048, HDD=256, VRAM=1024, Price=160, Total=2},
                new PC(){ Id=2, Name="LG", TypeCPU="intel", FrequencyCPU=1.8, RAM=1024, HDD=512, VRAM=2048, Price=200, Total=45},
                new PC(){ Id=3, Name="Asus", TypeCPU="intel", FrequencyCPU=3.4, RAM=4096, HDD=1024, VRAM=4096, Price=240, Total=16},
                new PC(){ Id=4, Name="MSI", TypeCPU="AMD", FrequencyCPU=4.1, RAM=4096, HDD=2048, VRAM=6144, Price=300, Total=12},
                new PC(){ Id=5, Name="Acer", TypeCPU="intel", FrequencyCPU=4.6, RAM=8192, HDD=2048, VRAM=8192, Price=400, Total=11},
                new PC(){ Id=6, Name="HP", TypeCPU="AMD", FrequencyCPU=2.2, RAM=2048, HDD=192, VRAM=512, Price=180, Total=35},
                new PC(){ Id=7, Name="Lenovo", TypeCPU="AMD", FrequencyCPU=3.8, RAM=16384, HDD=6144, VRAM=2048, Price=350, Total=25},
                new PC(){ Id=8, Name="Samsung", TypeCPU="intel", FrequencyCPU=1.6, RAM=1024, HDD=256, VRAM=2048, Price=100, Total=22}
            };

            Console.WriteLine("Введите названием  марки компьютера");
            string name = Console.ReadLine();
            List<PC> pCs1 = pCs.Where(x => x.Name == name).ToList();
            Print(pCs1);

            Console.WriteLine("Введите объем ОЗУ");
            int ram = Convert.ToInt32(Console.ReadLine());
            List<PC> pCs2 = pCs.Where(x => x.RAM >= ram).ToList();
            Print(pCs2);

            List<PC> pCs3 = pCs.OrderBy(x => x.Price).ToList();
            Print(pCs3);

            IEnumerable<IGrouping<string, PC>> pCs4 = pCs.GroupBy(x => x.TypeCPU);
            foreach (IGrouping<string, PC> gr in pCs4)
            {
                Console.WriteLine(gr.Key);
                foreach (PC p in gr)
                {
                    Console.WriteLine($"{p.Id} марка {p.Name} процессор {p.TypeCPU} частота {p.FrequencyCPU} ОЗУ {p.RAM} HDD {p.HDD} VRAM {p.VRAM} стоимость {p.Price} количество {p.Total}");
                }
            }

            PC pCs5 = pCs.OrderByDescending(x => x.Price).FirstOrDefault();
            Console.WriteLine($"самый дорогой компьютер {pCs5.Id} марка {pCs5.Name} процессор {pCs5.TypeCPU} частота {pCs5.FrequencyCPU} ОЗУ {pCs5.RAM} HDD {pCs5.HDD} VRAM {pCs5.VRAM} стоимость {pCs5.Price} количество {pCs5.Total}");

            PC pCs6 = pCs.OrderByDescending(x => x.Price).LastOrDefault();
            Console.WriteLine($"самый бюджетный компьютер {pCs6.Id} марка {pCs6.Name} процессор {pCs6.TypeCPU} частота {pCs6.FrequencyCPU} ОЗУ {pCs6.RAM} HDD {pCs6.HDD} VRAM {pCs6.VRAM} стоимость {pCs6.Price} количество {pCs6.Total}");

            Console.WriteLine("есть ли хотя бы один компьютер в количестве не менее 30 штук ? - {0}", pCs.Any(x=>x.Total>20));

            Console.ReadKey();
        }
        static void Print(List<PC> pCs)
        {
            foreach (PC p in pCs)
            {
                Console.WriteLine($"{p.Id} марка {p.Name} процессор {p.TypeCPU} частота {p.FrequencyCPU} ОЗУ {p.RAM} HDD {p.HDD} VRAM {p.VRAM} стоимость {p.Price} количество {p.Total}");
            }
            Console.WriteLine();
        }
    }
}
