
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_ActionListMetaData))]
  public partial class Pm_ActionList
   {
   }
   public class PM_ActionListMetaData
    {
        public int PM_ActionlistID { get; set; }
        public string ControllerName { get; set; }
        public string Actionname { get; set; }
        public string Fa_ControllerName { get; set; }
        public string Fa_ActionName { get; set; }
        public int? Id_Role { get; set; }
        public string Creator { get; set; }
        public string Ctime { get; set; }
        public string Modifier { get; set; }
        public string Mtime { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }

    }
 }


