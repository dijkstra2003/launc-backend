using API.Core.Entities;
using API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
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
        SubGoal GetSubGoal(int id);
        Task<SubGoal> GetSubGoalAsync(int id);

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

        public SubGoal GetSubGoal(int id)
        {
            return _ctx.Subgoal.Find(id);
        }

        public async Task<SubGoal> GetSubGoalAsync(int id)
        {
            return await _ctx.Subgoal
                .FindAsync(id)
                .AsTask();
        }
    }
}