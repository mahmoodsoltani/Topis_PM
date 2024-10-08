
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PM.Models  
{
  [MetadataType(typeof(PM_MenuItemMetaData))]
  public partial class PM_MenuItem
   {
   }
   public class PM_MenuItemMetaData
    {
        public int PM_MenuItemID { get; set; }

        public string NameOption { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ImageClass { get; set; }
        public string ActiveLi { get; set; }
        public bool status { get; set; }
        public int? ParentId { get; set; }
        public int? Id_Role { get; set; }
        public bool IsParent { get; set; }
        public string FunctionCall { get; set; }
        public string ActionParameter { get; set; }
        public string Creator { get; set; }
        public string Ctime { get; set; }
        public string Modifier { get; set; }
        public string Mtime { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }

    }
 }


