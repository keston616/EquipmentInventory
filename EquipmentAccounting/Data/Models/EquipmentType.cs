using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentAccounting.Data.Models
{
    [Table("EquipmentType")]
    public class EquipmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
