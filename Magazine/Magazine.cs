
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Magazine_manager
{
    [KnownType(typeof(Article))]
    [KnownType(typeof(List<Article>))]
    [Serializable]
    public class Magazine : ISerializable,IEnumerable<Article>
    {
        private List<Article> articles;
      
        public string Name { get; }

        public string Publishing { get;}

        public DateTime Date { get; }

        public int PagesCount { get; }

        public Magazine(string name,string publishing,int pages,DateTime date)
        {
            articles = new List<Article>();
            Date = date;
            Publishing = publishing ?? "Invalid Publishing";
            PagesCount = pages ;
            Name = name ?? "Invalid name";
        }

        public void AddArticle(Article? article)
        {
            if(article!=null) articles.Add(article);
        }

        public Magazine(SerializationInfo info, StreamingContext context)
        {
            object? tmp = info.GetValue("Articles", typeof(object));
            articles = tmp as List<Article> ?? new List<Article>();
            Name = info.GetString("Name") ?? "Invalid name";
            Publishing = info.GetString("Publishing") ?? "Invalid Publishing";
            Date = info.GetDateTime("date");
            PagesCount = info.GetInt32("PagesCount");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
            info.AddValue("Articles", articles);
            info.AddValue("Name", Name);
            info.AddValue("Publishing", Publishing);
            info.AddValue("date", Date);
            info.AddValue("PagesCount", PagesCount);

        }

        public IEnumerator<Article> GetEnumerator() => articles.GetEnumerator();
       
        IEnumerator IEnumerable.GetEnumerator() => articles.GetEnumerator();

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($" Magazine \"{Name}\"");
            sb.AppendLine($" Pages : {PagesCount}");
            sb.AppendLine($" Publishing : {Publishing}");
            sb.AppendLine($" Date : {Date.ToShortDateString()}");
            sb.AppendLine(" \"Articles\"");
            foreach (var item in articles)
                sb.AppendLine(item.ToString());
            return sb.ToString();
        }
    }
}
