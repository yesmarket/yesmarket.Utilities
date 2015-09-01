using System.Security.Principal;

namespace yesmarket.Identity
{
    public interface IWindowsIdentityResolver
    {
        WindowsIdentity GetCurrent();
    }
}