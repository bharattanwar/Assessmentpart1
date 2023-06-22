using System;
using System.ComponentModel.DataAnnotations;

namespace AssessmentPart1.Models
{
    public class Assessment_part_1
    {
        [Key]
        public int Engagement_Information  { get; set; }

        public string? Contact_Information  { get; set; }

        public string? Vendor_Profile  { get; set; }

        public string? Engagement_Questions  { get; set; }
        
    }
}





