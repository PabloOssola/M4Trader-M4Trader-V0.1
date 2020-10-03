using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    [Table("Plazos", Schema = "orden_owner")]
    public class PlazoEntity
    {
        [Key]
        public byte IdPlazo { get; set; }

        public string Descripcion { get; set; }
    }
}
