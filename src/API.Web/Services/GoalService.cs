using API.Core.Entities;
using API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace API.Web.Services
{
    public interface IGoalService
    {
        EntityEntry<Goal> Create(
            DateTime GoalStart,
            DateTime GoalEnd,
            int MinAmount
        );
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
    }
}