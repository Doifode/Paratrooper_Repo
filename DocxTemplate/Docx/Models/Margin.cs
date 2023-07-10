using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Docx.Models
{
    public class Margin
    {
        public int Id { get; set; }
        public int MarginTop { get; set; }
        public int MarginRight { get; set;}
        public int MarginBottom { get; set;}
        public int MarginLeft { get; set;}
    }
}