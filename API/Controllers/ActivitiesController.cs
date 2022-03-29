using System;
using System.Runtime.Remoting;
using System.Threading.Tasks;
using Application.Activites;
using Application.Activities;
using Domain;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   
    public class ActivitiesController : BaseApiController
    {
        
        [HttpGet]
       
         public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] 
         public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
           return await Mediator.Send(new Details.Query{Id =id});
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command {Activity = activity}));

        }
        
        [HttpPut("{id}")]

        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
           activity.Id = id;
           return Ok(await Mediator.Send(new Edit.Command{Activity = activity}));
        }
    }
}