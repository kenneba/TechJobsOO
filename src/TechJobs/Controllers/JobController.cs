using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;
using TechJobs.Models;
using System.Collections.Generic;




namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // COMPLETE #1 - get the Job with the given ID and pass it into the view
            jobData.Find(id);
            return View();
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        // TODO #6 - Validate the ViewModel and if valid, create a 
        // new Job and add it to the JobData data store. Then
        // redirect to the Job detail (Index) action/view for the new Job.

        //Utilize the isValid method of the ModelState class and check if it is valid.
        //If it's valid, create an instance of Job passing in apprpriate parameters
        //Add a new Job to the Jobs Property of the jobData instance
        //then if it's still true, return a redirect to it's apprpriate place
        //If it's not valid, return the default view

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            if (ModelState.IsValid)
            {
                Job newJob = new Job
                {   
                    Name = newJobViewModel.Name,
                    Employer = jobData.Employers.Find(int.Parse(newJobViewModel.EmployerID.Value)),
                    CoreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetency.ID),
                    Location = jobData.Locations.Find(newJobViewModel.Location.ID),
                    PositionType = jobData.PositionTypes.Find(newJobViewModel.PositionType.ID)
                };

                jobData.Jobs.Add(newJob);


                return Redirect($"/Job?id={newJob.ID}");
            }

            return View(newJobViewModel);
        }
    }
}
