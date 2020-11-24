using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Todo.Core.Query.Account.LoginQuery;
using Todo.Frontend.Core.State;
using Todo.Frontend.Core.State.Feature.TestFeature.State;
using Todo.Frontend.Infrastructure.Auth;

namespace Todo.Frontend.Components.Login
{
    public partial class LoginComponent : FluxorLayout
    {
        private LoginQuery form = new LoginQuery();

        private bool showMsg = false;

        public void Fire(MouseEventArgs e)
        {
            Facade.LoadTest();
        }

        public async Task Login()
        {
            Facade.Login(form);

            NavigationManager.NavigateTo("/test");
        }
    }
}