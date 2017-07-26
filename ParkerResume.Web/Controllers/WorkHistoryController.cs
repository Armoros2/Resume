using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ParkerResume.Web.Controllers
{
    public class WorkHistoryController : Controller 
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(JobEntry model)
        {
            var savedJobs = new List<JobEntry>();
            var jobsFilePath = Server.MapPath("~/Public/data/jobs.json");
            if (System.IO.File.Exists(jobsFilePath))
            {
                using (var tw = new StreamReader(jobsFilePath, true))
                {
                    var contents = tw.ReadToEnd();
                    savedJobs = JsonConvert.DeserializeObject<List<JobEntry>>(contents);
                    tw.Close();
                }
            }

            if (savedJobs == null)
            {
                savedJobs = new List<JobEntry>();
            }

            savedJobs.Add(model);
            using (var tw = new StreamWriter(jobsFilePath, false))
            {
                tw.Write(JsonConvert.SerializeObject(savedJobs));
                tw.Close();
            }

            return View("Index");
        }
    }

    public class JobEntry
    {
        public string JobTitle { get; set; }
        public string Period { get; set; }
    }
}
