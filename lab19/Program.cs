using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab19
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputers = new List<Computer>()
            {
                new Computer(){Kod = 1, Name="Acer", Process= "Intel-Core i5", ClockSpeed=3.14, Ozy=8, HardDiskSpaceGb=1000, VideoCardMemory=2, Price= 45000, Kolichestvo=35},
                new Computer(){Kod = 2, Name="Acer", Process= "Intel-Core i7", ClockSpeed=5, Ozy=16, HardDiskSpaceGb=2000, VideoCardMemory=6, Price= 80000, Kolichestvo=3},
                new Computer(){Kod = 3, Name="Asus", Process= "Intel-Core i3", ClockSpeed=2.8, Ozy=4, HardDiskSpaceGb=500, VideoCardMemory=2, Price= 30000, Kolichestvo=15},
                new Computer(){Kod = 4, Name="Asus", Process= "Intel-Core i5", ClockSpeed=6.5, Ozy=8, HardDiskSpaceGb=1500, VideoCardMemory=4, Price= 50000, Kolichestvo=40},
                new Computer(){Kod = 5, Name="lenovo", Process= "Intel-Core i7", ClockSpeed=4.2, Ozy=10, HardDiskSpaceGb=2500, VideoCardMemory=6, Price= 60000, Kolichestvo=13},
                new Computer(){Kod = 6, Name="lenovo", Process= "Intel-Core i3", ClockSpeed=2.8, Ozy=4, HardDiskSpaceGb=700, VideoCardMemory=2, Price= 35000, Kolichestvo=20}
            };
            //вывод компьютеров по интересуещему процессору
            Console.WriteLine("Введите интересующий процессор");
            string proc = Console.ReadLine();
            List<Computer> compProc = (from c in listComputers
                                       where c.Process == proc
                                       select c).ToList();
            foreach (Computer c in compProc)
                Console.WriteLine($"{c.Kod} {c.Name} {c.Process} {c.ClockSpeed} {c.Ozy} {c.HardDiskSpaceGb} {c.VideoCardMemory} {c.Price} {c.Kolichestvo}");
            Console.WriteLine();

            //вывод компьютеров по интересующему ОЗУ
            Console.WriteLine("Введите интересующий размер ОЗУ");
            int ozu = Convert.ToInt32(Console.ReadLine());
            IEnumerable<Computer> compOzu = listComputers
                                       .Where (c =>c.Ozy>= ozu
                                       ).ToList();
            foreach (Computer c in compOzu)
                Console.WriteLine($"{c.Kod} {c.Name} {c.Process} {c.ClockSpeed} {c.Ozy} {c.HardDiskSpaceGb} {c.VideoCardMemory} {c.Price} {c.Kolichestvo}");
            Console.WriteLine();

            //сортировка списка по стоимости
            Console.WriteLine("Отсортированный список компьютеров по стоимости");
            List<Computer> compSort = (from c in listComputers
                                       orderby c.Price
                                       select c).ToList();
            foreach (Computer c in compSort)
                Console.WriteLine($"{c.Kod} {c.Name} {c.Process} {c.ClockSpeed} {c.Ozy} {c.HardDiskSpaceGb} {c.VideoCardMemory} {c.Price} {c.Kolichestvo}");
            Console.WriteLine();

            //группировка по типу процессора
            Console.WriteLine("Группировка по типу процессора");
            var compGroup = from c in listComputers
                            group c by c.Process;

            foreach (var procGr in compGroup)
            {
                Console.WriteLine(procGr.Key);
                foreach (var compGr in procGr)
                {
                    Console.WriteLine($"{compGr.Kod} {compGr.Name} {compGr.Process} {compGr.ClockSpeed} {compGr.Ozy} {compGr.HardDiskSpaceGb} {compGr.VideoCardMemory} {compGr.Price} {compGr.Kolichestvo}");
                }
            }
            Console.WriteLine();

            //самый дорогой компьютер
            Console.WriteLine("Самый дешевый компьютер");
            var minP = listComputers.
                Min(min => min.Price);
            List<Computer> compMin = (from c in listComputers
                                       where c.Price==minP
                                       select c).ToList();
                                       
            foreach (Computer c in compMin)
                Console.WriteLine($"{c.Kod} {c.Name} {c.Process} {c.ClockSpeed} {c.Ozy} {c.HardDiskSpaceGb} {c.VideoCardMemory} {c.Price} {c.Kolichestvo}");
            Console.WriteLine();

            //самый дорогой компьютер
            Console.WriteLine("Самый дешевый компьютер");
            var maxP = listComputers.
                Max(max => max.Price);
            List<Computer> compMax = (from c in listComputers
                                      where c.Price == maxP
                                      select c).ToList();

            foreach (Computer c in compMax)
                Console.WriteLine($"{c.Kod} {c.Name} {c.Process} {c.ClockSpeed} {c.Ozy} {c.HardDiskSpaceGb} {c.VideoCardMemory} {c.Price} {c.Kolichestvo}");
            Console.WriteLine();

            //есть ли хотя бы один компьютер в количестве не менее 30 штук
            IEnumerable<Computer> compKol = listComputers
                                       .Where(c => c.Price >= 30
                                       ).ToList();
           
            if (compKol.Count()>=1)
            {
                Console.WriteLine("Есть хотя бы один компьютер в количестве более 30 шт.");
            }
            else
                Console.WriteLine("Нет компьютеров в количестве более 30 шт.");

            Console.ReadKey();

        }
    }
    class Computer
    {
        public int Kod { get; set; }
        public string Name { get; set; }
        public string Process { get; set; }
        public double ClockSpeed { get; set; }
        public int Ozy { get; set; }
        public double HardDiskSpaceGb { get; set; }
        public int VideoCardMemory { get; set; }
        public double Price { get; set; }
        public int Kolichestvo { get; set; }
    }
}
