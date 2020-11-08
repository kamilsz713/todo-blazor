using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Todo.Frontend.Components.Home
{
    public partial class HomeComponent : ComponentBase
    {
        public void LoadLoginPage(MouseEventArgs a)
        {
            NavigationManager.NavigateTo("/login");
        }

        public void LoadRegisterPage(MouseEventArgs e)
        {
            NavigationManager.NavigateTo("/register");
        }
    }
}