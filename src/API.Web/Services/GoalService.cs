using API.Core.Entities;
using API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Web.Services
{
    public interface IGoalService
    {
        EntityEntry<Goal> Create(
            DateTime GoalStart,
            DateTime GoalEnd,
            int MinAmount
        );
        
        Goal GetGoal(int id);
        Task<Goal> GetGoalAsync(int id);
        Task UpdateGoalAsync(Goal goal);
        Task UpdateGoalAmountAsync(Goal goal);
    }

    public class GoalService : IGoalService
    {
        private readonly DataContext _ctx;

        public GoalService(
            DataContext ctx
        ) {
            _ctx = ctx;
        }

        public EntityEntry<Goal> Create(
            DateTime goalStart,
            DateTime goalEnd,
            int minAmount
        ) {
            var goal = _ctx.Goal.Add(new Goal {
                GoalStart = goalStart,
                GoalEnd = goalEnd,
                MinAmount = minAmount
            });

            _ctx.SaveChanges();

            return goal;
        }

        public Goal GetGoal(int id)
        {
            return _ctx.Goal.Find(id);
        }

        public async Task<Goal> GetGoalAsync(int id)
        {
            return await _ctx.Goal
                .FindAsync(id)
                .AsTask();
        }

        public async Task UpdateGoalAsync(Goal goal)
        {
            _ctx.Goal.Update(goal);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateGoalAmountAsync(Goal goal)
        {
            if (goal == null) { return; }

            var sum = await _ctx.MolliePayment
                .Include(x => x.Goal)
                .Where(x => x.Goal.Id == goal.Id)
                .Where(x => x.Status == Payment.PaymentStatus.PAID)
                .SumAsync(x => x.Amount);

            goal.CurrentAmount = sum;

            await UpdateGoalAsync(goal);
        }
    }
}