using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaurusBetaX.Model;

namespace TaurusBetaX.Interfaces
{
    public interface ILoginProvider
    {
        Task<AuthInfo> LoginAsync();
    }
}
