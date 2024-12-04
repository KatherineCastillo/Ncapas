using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KatherineCastilloEntidadNegocio
{
    public class Producto
    {
        
        public int Id { get; set; }
       
        public string Nombre { get; set; }

        

        public decimal Precio { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }

        public Categoria? categoria { get; set; }





    }
}
