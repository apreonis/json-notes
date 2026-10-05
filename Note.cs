using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Note
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = "";

        public string Text { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string[] Tags { get; set; } = new string[0];
    }
}
