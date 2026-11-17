using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace excersise2
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortInfo { get; set; }
        public Color PreferredColor { get; set; }

        public List<String> Tariffs { get; set; } = new List<String>();

    }
}
