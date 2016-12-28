using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windows_phone.articles
{
   public class Articles
    {
        public Article[] articles { get; set; }
    }
    public class Article
    {
    public string title { get; set; }
    public string details { get; set; }
    public string date { get; set; }
    public string image { get; set; }
}
}
