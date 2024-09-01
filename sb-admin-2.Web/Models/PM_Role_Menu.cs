
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_Role_MenuMetaData))]
  public partial class PM_Role_Menu
   {
   }
   public class PM_Role_MenuMetaData
    {
        public int PM_Role_MenuID { get; set; }
        public int Id_Role { get; set; }
        public int Id_MenuItem { get; set; }
        public string Creator { get; set; }
        public string Ctime { get; set; }
        public string Modifier { get; set; }
        public string Mtime { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }

    }
 }


