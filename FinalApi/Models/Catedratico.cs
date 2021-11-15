using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalApi.Models
{
    public class Catedratico
    {
        public int Id {get; set;}
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string Activo { get; set; }
        public string Situacion { get; set; }
    }
}
