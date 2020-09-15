namespace MXIC_PCCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MXIC_ScheduleSetting
    {
        [Key]
        public Guid ScheduleID { get; set; }

        [Required]
        [StringLength(50)]
        public string PoNo { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string DayWeek { get; set; }

        [Required]
        [StringLength(50)]
        public string EmpName { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkShift { get; set; }
    }
}
