using Microsoft.EntityFrameworkCore;
using SmartAcademyBackend.Data;
using SmartAcademyBackend.DTOs.SubscriptionDTOs;
using SmartAcademyBackend.Entities;

namespace SmartAcademyBackend.Service.SubscriptionService
{
    public class SubscriptionService(SmartAcademyDbContext _context) : ISubscriptionService
    {
        public async Task<SubscriptionPlans?> AddNewSubscription(AddSubscriptionPlanDTO newSubscription)
        {
            if (newSubscription is null)
                return null;

            SubscriptionPlans subscription = new()
            {
                SubscriptionPlanName = newSubscription.SubscriptionPlanName,
                amount = newSubscription.amount,
                NumberOfLessons = newSubscription.NumberOfLessons,
                AttendanceType = newSubscription.AttendanceType,
                TeachingMode = newSubscription.TeachingMode
            };


            _context.Add(subscription);
            await _context.SaveChangesAsync();

            return subscription;
        }

        public async Task<string> deletedSubscription(int subscriptionId)
        {
            var subscription = await _context.SubscriptionPlans.FindAsync(subscriptionId);
            if (subscription is null)
                return "not found";
            subscription.isActive = false;
            await _context.SaveChangesAsync();
            return "deleted";
        }

        public async Task<string> EditSubscriptionDetails(int subscriptionId, EditSubscriptionPlanDTO editedSubscription)
        {
            var subscription = await _context.SubscriptionPlans
                                        .FindAsync(subscriptionId);
            if (subscription is null)
                return "subscription not found";

            subscription.AttendanceType = editedSubscription.AttendanceType;
            subscription.NumberOfLessons = editedSubscription.NumberOfLessons;
            subscription.amount = editedSubscription.amount;
            subscription.isActive = editedSubscription.isActive;
            subscription.TeachingMode = editedSubscription.TeachingMode;
            subscription.SubscriptionPlanName = editedSubscription.subscriptionName;

            await _context.SaveChangesAsync();

            return "updated";

        }

        public async Task<List<GetSubscriptionPlansDTO>?> GetAllSubscriptionPlans()
        {
            var subscriptions = await _context.SubscriptionPlans
                                         .Where(subscriptions => subscriptions.isActive != false)
                                         .Select(subscription => new GetSubscriptionPlansDTO(
                                                subscription.SubscriptionPlanId,
                                                subscription.NumberOfLessons,
                                                subscription.AttendanceType.ToString(),
                                                subscription.TeachingMode.ToString(),
                                                subscription.amount
                                         )).ToListAsync();

            if (subscriptions is null)
                return null;
            return subscriptions;
        }

        public async Task<List<GetSubscriptionPlansDTO>?> AdminGetAllSubscriptionPlans()
        {
            var subscriptions = await _context.SubscriptionPlans
                                         .Select(subscription => new GetSubscriptionPlansDTO(
                                                subscription.SubscriptionPlanId,
                                                subscription.NumberOfLessons,
                                                subscription.AttendanceType.ToString(),
                                                subscription.TeachingMode.ToString(),
                                                subscription.amount
                                         )).ToListAsync();

            if (subscriptions is null)
                return null;
            return subscriptions;
        }





    }
}
