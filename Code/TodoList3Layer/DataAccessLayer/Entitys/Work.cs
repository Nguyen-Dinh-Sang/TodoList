using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entitys
{
    public partial class Work
    {
        public Work()
        {
            Comment = new HashSet<Comment>();
            WorkEmployee = new HashSet<WorkEmployee>();
        }

        [Key]
        public int Id { get; set; }
        public int? IdWorkList { get; set; }
        public int? IdWorkStatus { get; set; }
        [StringLength(200)]
        public string WorkContent { get; set; }

        [ForeignKey(nameof(IdWorkList))]
        [InverseProperty(nameof(WorkList.Work))]
        public virtual WorkList IdWorkListNavigation { get; set; }
        [ForeignKey(nameof(IdWorkStatus))]
        [InverseProperty(nameof(WorkStatus.Work))]
        public virtual WorkStatus IdWorkStatusNavigation { get; set; }
        [InverseProperty("IdWorkNavigation")]
        public virtual ICollection<Comment> Comment { get; set; }
        [InverseProperty("IdWorkNavigation")]
        public virtual ICollection<WorkEmployee> WorkEmployee { get; set; }
    }
}
