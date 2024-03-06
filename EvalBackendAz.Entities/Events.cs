using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvalBackendAz.Entities
{
    public class Events
    {
        [Key]
        public Guid Id {  get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateEvent { get; set; }

        public string Location { get; set; }
    }
}
