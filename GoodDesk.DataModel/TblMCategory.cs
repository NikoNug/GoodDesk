using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoodDesk.DataModel
{
    [Table("TBL_M_Categories")]
    public class TblMCategory
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted {  get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
