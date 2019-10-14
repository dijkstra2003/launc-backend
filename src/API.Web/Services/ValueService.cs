using System;
using System.Threading.Tasks;

namespace API.Web.Services
{
    public interface IValueService
    {
        int FetchValue(int value);
    }

    public class ValueService : IValueService
    {
        public int FetchValue(int value) => value;
    }
}