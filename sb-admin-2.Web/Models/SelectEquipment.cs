using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PM.Models
{
    public class SelectEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Id_Parent { get; set; }
        public int type { get; set; }

    }
}