using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Magazine_manager
{
    [Serializable]
    public class Article : ISerializable
    {
        public string Name { get; }
        public string Announce { get; }
        public int SymbolsCount { get; }

        public Article(string? name,string? announce,int sCount)
        {
            Name = name ?? "Invalid name";
            Announce = announce ?? "Invalid announce";
            SymbolsCount = sCount;
        }

        public Article(SerializationInfo info, StreamingContext context)
        {
            Name =     info.GetString("Name") ?? "Invalid name"; ;
            SymbolsCount =     info.GetInt32("SCount") ;
            Announce = info.GetString("Announce") ?? "Invalid announce";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("SCount", SymbolsCount);
            info.AddValue("Announce", Announce);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("   *Article*");
            sb.AppendLine($"  \"{Name}\"");
            sb.AppendLine($"  <<{Announce}>>");
            sb.AppendLine($"SymbolsCount : {SymbolsCount}");
            return sb.ToString();
        }
    }
}
