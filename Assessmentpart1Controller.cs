using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Assessment_part_1.Models;

namespace AssessmentPart1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssessmentPart1 : ControllerBase
    {
        private readonly Assessmentpart1Context _dbContext;

        public AssessmentPart1(Assessmentpart1Context dbcontext)
        {
            this._dbContext = dbcontext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AssessmentPart1>> GetVendors()
        {
            var assessments = _dbContext.Vendors.ToList();
            return Ok(assessments);
        }

        [HttpGet("{id}")]
        public ActionResult<AssessmentPart1> GetAssessment(int id)
        {
            var assessment = _dbContext.Vendors.Find(id);
            if (assessment == null)
            {
                return NotFound();
            }
            return Ok(assessment);
        }

        

    //     [HttpPut("{id}")]
    //     public IActionResult UpdateAssessment(int id, AssessmentPart1 updatedAssessment)
    //     {
    //         var assessment = _dbcontext.Assessments.Find(id);
    //         if (assessment == null)
    //         {
    //             return NotFound();
    //         }

    //         assessment.Contact_Information = updatedAssessment.Contact_Information;
    //         assessment.Vendor_Profile = updatedAssessment.Vendor_Profile;
    //         assessment.Engagement_Questions = updatedAssessment.Engagement_Questions;

    //         _dbcontext.SaveChanges();
    //         return NoContent();
    //     }

        
    // }
}
}
