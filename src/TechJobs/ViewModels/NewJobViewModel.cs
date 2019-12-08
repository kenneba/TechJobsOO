using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobs.Data;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class NewJobViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        //[Required]
        [Display(Name = "Employer")]
        public Employer EmployerID { get; set; }

        //[Required]
        [Display(Name = "Location")]
        public Location Location { get; set; }

        //[Required]
        [Display(Name = "Core Competency")]
        public CoreCompetency CoreCompetency { get; set; }

        //[Required]
        [Display(Name = "Position Type")]
        public PositionType PositionType { get; set; }

        // Complete #3 - Included other fields needed to create a job,
        // with correct validation attributes and display names.

        // Use a list of select List items for Employers (and all fields below) while not forgetting the getter and setter and set that equal to a new list of SelectListItem

        public List<SelectListItem> Employers { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Locations { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CoreCompetencies { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> PositionTypes { get; set; } = new List<SelectListItem>();

        public NewJobViewModel()
        {
            JobData jobData = JobData.GetInstance();
          
            foreach (Employer field in jobData.Employers.ToList())
            {
                Employers.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            // Complete #4 - populate the other List<SelectListItem> 
            // collections needed in the view

            foreach (Location field in jobData.Locations.ToList())
            {
                Locations.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach (CoreCompetency field in jobData.CoreCompetencies.ToList())
            {
                CoreCompetencies.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach (PositionType field in jobData.PositionTypes.ToList())
            {
                PositionTypes.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
        }
    }
}
