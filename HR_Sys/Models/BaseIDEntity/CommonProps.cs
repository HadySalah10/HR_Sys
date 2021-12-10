using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Sys.Models.BaseIDEntity
{
    public class CommonProps
    {
      [Key]
        public int id { get; set; }

        [ForeignKey("edit")]

        public int? editBy { get; set; }

        [ForeignKey("Delete")]

        public int? deletedBy { get; set; }

        [ForeignKey("Add")]

        public int? addBy { get; set; }

        public bool? lastEdit { get; set; }=true;
        public bool? isDeleted { get; set; } = false;


        public virtual HR edit { get; set; }


        public virtual HR Delete { get; set; }
        public virtual HR Add { get; set; }

      


    }
}
