using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Model
{
    public class TbDayDataValue
    {
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public DateTime CreationTime { get; set; }
        public long CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public int IndexId { get; set; }
        public decimal? IndexValue { get; set; }
        public int? FacId { get; set; }
        public DateTime? ReportingTime { get; set; }
        public string Remark { get; set; }
        public int? ParentFacId { get; set; }
        public string DateMonth { get; set; }

        public int IndexProducType { get; set; }

        public string DateDay { get; set; }
    }
}
