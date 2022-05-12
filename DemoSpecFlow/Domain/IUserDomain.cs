using System.Threading.Tasks;

namespace DemoSpecFlow.Domain
{
    public interface IUserDomain
    {
        Task ModifyUserAmountAsync(string user, decimal amount);
    }
}