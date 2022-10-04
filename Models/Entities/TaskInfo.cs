﻿using System;
using System.Collections.Generic;

namespace Supabase.Microservices.Models.Entities
{
    /// <summary>
    /// Task table
    /// </summary>
    public partial class TaskInfo
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? AcceptanceCriteria { get; set; }
        public string? Nfr { get; set; }
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public long? OriginalEstimate { get; set; }
        public long? Completed { get; set; }
        public long? Remaining { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDatetime { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
