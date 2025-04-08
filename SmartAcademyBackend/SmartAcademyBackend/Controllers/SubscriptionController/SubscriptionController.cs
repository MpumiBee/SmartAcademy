using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartAcademyBackend.DTOs.SubscriptionDTOs;
using SmartAcademyBackend.Service.SubscriptionService;

namespace SmartAcademyBackend.Controllers.SubscriptionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController(ISubscriptionService subscriptionService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> addNewSubscription(AddSubscriptionPlanDTO newSubscription)
        {
            var subscription = await subscriptionService.AddNewSubscription(newSubscription);

            if (subscription is null)
                return BadRequest();
            return Created();

        }

        [HttpGet("all-subscriptions")]
        public async Task<ActionResult<List<GetSubscriptionPlansDTO>>> AdminGetALLSubscriptions()
        {
            var subscription = await subscriptionService.AdminGetAllSubscriptionPlans();

            if (subscription is null)
                return NotFound();
            return Ok(subscription);

        }

        [HttpGet]
        public async Task<ActionResult<List<GetSubscriptionPlansDTO>>> GetALLSubscriptions()
        {
            var subscription = await subscriptionService.GetAllSubscriptionPlans();

            if (subscription is null)
                return NotFound();
            return Ok(subscription);

        }
        [HttpPut("{subscriptionId}")]
        public async Task<IActionResult> editSubscriptionPlan(int subscriptionId, EditSubscriptionPlanDTO editSubscription)
        {
            var subscription = await subscriptionService.EditSubscriptionDetails(subscriptionId, editSubscription);

            if (subscription == "subscription not found")
                return NotFound();
            return Ok(subscription);

        }
        [HttpDelete("{subscriptionId}")]
        public async Task<IActionResult> deleteSubscription(int subscriptionId)
        {
            await subscriptionService.deletedSubscription(subscriptionId);

            return NoContent();

        }
    }
}
