using System.Threading.Tasks;

namespace DemoSpecFlow.Domain
{
    public class UserDomain : IUserDomain
    {
        public async Task ModifyUserAmountAsync(string user, decimal amount)
        {
            //fake 
            await Task.Delay(50);
        }
    }
}