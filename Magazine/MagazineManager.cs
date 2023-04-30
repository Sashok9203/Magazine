using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Magazine_manager
{
    [KnownType(typeof(List<Magazine>))]
    internal class MagazineManager
    {
        private List<Magazine>? magazines;

        private DataContractSerializer? serializer = null ;

        private DataContractSerializer Serializer => serializer ??= new(typeof(List<Magazine>)); //Lazy load

        public MagazineManager() => magazines = new();

        public MagazineManager(string path) => Load(path);
       
        public void AddMagazine()
        {
                
            DateTime date = default;
            Console.Clear();

            Console.Write(" Enter magazine name : ");
            string?  name = Console.ReadLine();
            Console.Write(" Enter magazine publishing : ");
            string? publishing = Console.ReadLine();
            Console.Write(" Enter page count : ");
            int pages = Input.GetInt(0, int.MaxValue);

            do
            {
                Console.Write(" Enter year : ");
                int year = Input.GetInt(1800, int.MaxValue);
                Console.Write(" Enter month : ");
                int month = Input.GetInt(1, 12);
                Console.Write(" Enter day : ");
                int day = Input.GetInt(1, 31);
                try { date = new DateTime(year, month, day); }
                catch 
                {
                    Console.WriteLine("Such a date does not exist...");
                    Console.ReadKey();
                    continue;
                };
                if (date > DateTime.Now)
                {
                    Console.WriteLine("Invalid date...");
                    Console.ReadKey();
                    continue;
                }
            } while (date == default);
            Magazine m = new(name ?? "invalid name", publishing ??= "invalid publishing", pages, date);
            Console.Write(" Enter articles count : ");
            int ACont = Input.GetInt(0, int.MaxValue);
            for (int i = 0; i < ACont; i++)
            {
                Console.Write(" Enter article name : ");
                name = Console.ReadLine();
                Console.Write(" Enter article announce : ");
                publishing = Console.ReadLine();
                Console.Write(" Enter article symbols count : ");
                pages = Input.GetInt(0, int.MaxValue);
                m.AddArticle(new(name, publishing, pages));
            }
            magazines?.Add(m);

        }
        public void Show()
        {
            Console.Clear();
            if (magazines != null && magazines?.Count != 0)
                foreach (var magazine in magazines)
                    Console.WriteLine(magazine);
            else Console.WriteLine("Magazine manager is empty");
        }

        public void Save(string path)
        {
            using (Stream ms = new FileStream(path, FileMode.Create))
            {
                Serializer.WriteObject(ms, magazines);
            }
        }

        public void Load(string path)
        {
            using (Stream ms = new FileStream(path, FileMode.Open))
            {
                magazines = Serializer.ReadObject(ms) as List<Magazine> ?? new();
            }
        }
    }
}
