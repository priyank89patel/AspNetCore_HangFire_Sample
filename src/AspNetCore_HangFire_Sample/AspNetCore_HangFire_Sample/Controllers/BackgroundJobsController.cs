using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore_HangFire_Sample.Models;
using AspNetCore_HangFire_Sample.Services;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_HangFire_Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackgroundJobsController : ControllerBase
    {
        private readonly IExecuteBackgroundJob _backgroundJobService;
        public BackgroundJobsController(IExecuteBackgroundJob backgroundJobService)
        {
            _backgroundJobService = backgroundJobService;
        }

        [Route("schedule")]
        [HttpPost]
        public IActionResult ScheduleBackgroundJobs([FromBody] IEnumerable<BackgroundJobParameters> backgroundJobs)
        {
            try
            {

                if (!backgroundJobs.Any())
                    return StatusCode(400, "Background Jobs are missing");

                foreach (var job in backgroundJobs)
                {
                    RecurringJob.AddOrUpdate<IExecuteBackgroundJob>(job.Name, (j) => j.Execute(job), Cron.Daily);

                    //Execute immediately (only for testing purposes)
                    RecurringJob.Trigger(job.Name);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("jobs")]
        [HttpGet]
        public IActionResult GetScheduledBackgroundJobs()
        {
            var jobs = new List<BackgroundJobParameters> { new BackgroundJobParameters { Name = "Test exe", ExePath = "C:\\Test\\Test.exe", Arguments = "", WorkingDirectory = "C:\\Test" } };
            return Ok(jobs);
        }
    }
}