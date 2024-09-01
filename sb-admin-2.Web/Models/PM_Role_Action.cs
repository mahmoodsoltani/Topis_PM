
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_Role_ActionMetaData))]
  public partial class PM_Role_Action
   {
   }
   public class PM_Role_ActionMetaData
    {
        public int PM_Role_actionID { get; set; }
        public int? Id_Role { get; set; }
        public int Id_ActionList { get; set; }
        public string Creator { get; set; }
        public string Ctime { get; set; }
        public string Modifier { get; set; }
        public string Mtime { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }

    }
 }


