using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Sys.Models

{
    public class commonprops
    {
        public int id { get; set; }
        public int? added_by { get; set; }
        public int? edit_by { get; set; }
        public int? deleted_by { get; set; }
        public bool? last_edit { get; set; }
        public bool? is_deleted { get; set; }

        [ForeignKey("hr_add")]
        public int hr_addid { get; set; }
        public virtual HR hr_add { get; set; }
        [ForeignKey("hr_edit")]
        public int hr_edit { get; set; }
        public virtual HR hr_editid { get; set; }

        [ForeignKey("hr_delete")]
        public int hr_delete { get; set; }
        public virtual HR hr_deleteid { get; set; }

    }
}
