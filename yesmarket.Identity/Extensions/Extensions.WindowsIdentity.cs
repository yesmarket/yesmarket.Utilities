using System.Security.Principal;

namespace yesmarket.Identity.Extensions
{
    public static class WindowsIdentityExtensions
    {
        public static string NameWithoutDomain(this WindowsIdentity value)
        {
            return value != null ? value.Name.Split('\\')[1] : string.Empty;
        }
    }
}
