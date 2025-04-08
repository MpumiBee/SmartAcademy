using SmartAcademyBackend.DTOs.SubscriptionDTOs;
using SmartAcademyBackend.Entities;

namespace SmartAcademyBackend.Service.SubscriptionService
{
    public interface ISubscriptionService
    {
        Task<SubscriptionPlans?> AddNewSubscription(AddSubscriptionPlanDTO newSubscription);
        Task<List<GetSubscriptionPlansDTO>?> GetAllSubscriptionPlans();
        Task<string> EditSubscriptionDetails(int subscriptionId, EditSubscriptionPlanDTO editedSubscription);
        Task<string> deletedSubscription(int subscriptionId);
        Task<List<GetSubscriptionPlansDTO>?> AdminGetAllSubscriptionPlans();
    }
}
