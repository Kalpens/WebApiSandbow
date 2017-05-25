using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class Computer
    {
        [Key]
        public string MacAddress { get; set; }
        public bool OpenBrowser { get; set; }
        public string BrowserUrl { get; set; }
        public int browserAmmount { get; set; }

    }
}
