using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayler_wpf
{
    internal class Tip
    {
        public string name { get; set; }
        public string content;
        public DateTime date_execute;

        public Tip(string name, string content, DateTime date) {
            this.name = name;
            this.content = content;
            this.date_execute = date;
        }

    }
}
