using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Sys.Models.BaseIDEntity
{
    public class CommonProps
    {
        public CommonProps()
        {
            hrAdd = new HR();
            hrEdit = new HR();
            hrDelete = new HR();

        }
        public int id { get; set; }
        [ForeignKey("hrAdd")]
        
        public int? addedBy { get; set; }
        [ForeignKey("hrEdit")]

        public int? editBy { get; set; }

        [ForeignKey("hrDelete")]

        public int? deletedBy { get; set; }
        public bool? lastEdit { get; set; }
        public bool? isDeleted { get; set; }


        public virtual HR hrAdd { get; set; }
        public virtual HR hrEdit { get; set; }

        public virtual HR hrDelete { get; set; }

    }
}
