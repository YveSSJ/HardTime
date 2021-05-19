using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardTime.Domain
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
