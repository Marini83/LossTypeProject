using LossTypeProject.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LossTypeProject.Client.Pages
{
    public class AddEditUserBase : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int usrID { get; set; }

        protected string Title = "Add";
        public User usr = new();

        

        protected override async Task OnParametersSetAsync()
        {
            if (usrID != 0)
            {
                Title = "Edit";
                usr = await Http.GetFromJsonAsync<User>("api/User/" + usrID);
            }
        }

        protected async Task SaveUser()
        {
            if (usr.UserID != 0)
            {
                await Http.PutAsJsonAsync("api/User", usr);
            }
            else
            {
                await Http.PostAsJsonAsync("api/User", usr);
            }
            Cancel();
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo("/fetchuser");
        }
    }
}
