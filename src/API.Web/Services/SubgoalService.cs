using System.Linq;
using System.Threading.Tasks;
using API.Core.Entities;
using API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Web.Services
{
    public interface ISubgoalService
    {
        SubGoal GetSubGoal(int id);
        Task<SubGoal> GetSubGoalAsync(int id);
        Task UpdateGoalAsync(SubGoal goal);
        Task UpdateGoalAmountAsync(SubGoal goal);
    }

    public class SubgoalService : ISubgoalService
    {
        private readonly DataContext _ctx;

        public SubgoalService(DataContext ctx)
        {
            _ctx = ctx;
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

        public async Task UpdateGoalAsync(SubGoal goal)
        {
            _ctx.Subgoal.Update(goal);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateGoalAmountAsync(SubGoal subgoal)
        {
            if (subgoal == null) return;

            var sum = await _ctx.MolliePayment
                .Include(x => x.SubGoal)
                .Where(x => x.SubGoal.Id == subgoal.Id)
                .Where(x => x.Status == Payment.PaymentStatus.PAID)
                .SumAsync(x => x.Amount);

            subgoal.CurrentAmount = sum;

            await UpdateGoalAsync(subgoal);
        }
    }
}