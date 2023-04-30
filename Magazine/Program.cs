using Magazine_manager;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace Magazine_manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MagazineManager m = new();

            m.AddMagazine();
            m.AddMagazine();

            m.Save("magasines.xml");

            MagazineManager b = new("magasines.xml");
            b.Show();
        }
    }
}