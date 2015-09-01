using System.Security.Principal;

namespace yesmarket.Identity
{
    public class WindowsIdentityResolver : IWindowsIdentityResolver
    {
        public WindowsIdentity GetCurrent()
        {
            return WindowsIdentity.GetCurrent();
        }
    }
}