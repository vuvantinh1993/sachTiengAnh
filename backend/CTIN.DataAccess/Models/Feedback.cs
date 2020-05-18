using CTIN.Common.Enums;
using CTIN.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.DataAccess.Models
{
    public class Feedback
    {
        [Key]
        public int id { get; set; }
        public string contentFeedback { get; set; }
        public string replyFeedback { get; set; }
        public DateTime? cretedDateFeedback { get; set; }
        public DateTime? replyDateFeedback { get; set; }
        public int? rateStar { get; set; } // đánh giá số sao về ứng dụng
        public StatusFeedbackEnum? statusFeedback { get; set; }
    }
}
