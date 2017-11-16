using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Person
    {
        [Key]
        public int cardId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public List<Subject> subjects { get; set; }
    }
}
