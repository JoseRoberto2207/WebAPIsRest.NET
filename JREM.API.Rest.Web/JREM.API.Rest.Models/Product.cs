using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JREM.API.Rest.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

    }
}
