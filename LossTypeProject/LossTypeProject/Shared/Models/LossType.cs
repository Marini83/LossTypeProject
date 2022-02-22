using System;
using System.Collections.Generic;

namespace LossTypeProject.Server.Models
{
    public partial class LossType
    {
        public int LossTypeID { get; set; }
        public string LossTypeCode { get; set; } = null!;
        public string LossTypeDescription { get; set; } = null!;

    }
}
