using M4Trader.ordenes.server.MCContext.Entidades.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M4Trader.ordenes.server.MCContext.Entidades
{

    [Table("Theme", Schema = "shared_owner")]
    public class ThemeEntity
    {
        public ThemeEntity()
        {
            
        }
        [Key]
        public int IdTheme { get; set; }

        public int IdUsuario { get; set; }

        public string ThemeJSON { get; set; }
        
    }
}
