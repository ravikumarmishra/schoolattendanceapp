using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using StudentAttendenceSystem.Business;
using StudentAttendenceSystem.Entities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAttendenceSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class StudentAttendenceController : Controller
    {
        public IAttendenceBusiness StudentAttendence { get; private set; }

        public StudentAttendenceController(IAttendenceBusiness attendence)
        {
            StudentAttendence = attendence;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Students> Get()
        {
            return StudentAttendence.GetAllStudentAttendence();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ObjectResult Post([FromBody]Students attendenceDetails)
        {
            if(attendenceDetails==null)
            {
                return new HttpOkObjectResult("No data Received in API");
            }
            else
            {
                StudentAttendence.InsertAttendance(attendenceDetails);
            }
            return new HttpOkObjectResult(attendenceDetails);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
