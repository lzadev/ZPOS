using System.Collections.Generic;
using System.Threading.Tasks;
using ZPOS.UI.Models;

namespace ZPOS.UI.Interfaces
{
    public interface IUser
    {
        Task<IEnumerable<UserVM>> GetUsers();
    }
}
