using LossTypeProject.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LossTypeProject.Client.Pages
{
    public class UserDataBase : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }

        protected List<User> usrList = new();
        protected List<User> searchUsrList = new();
        protected User usr = new();
        protected string SearchString { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await GetUser();
        }

        protected async Task GetUser()
        {
            usrList = await Http.GetFromJsonAsync<List<User>>("api/User");
            searchUsrList = usrList;
        }

        protected void FilterUsr()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                usrList = searchUsrList
                    .Where(x => x.UserName.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1)
                    .ToList();
            }
            else
            {
                usrList = searchUsrList;
            }
        }

        protected void DeleteConfirm(int userID)
        {
            usr = usrList.FirstOrDefault(x => x.UserID == userID);
        }

        protected async Task DeleteUser(int usrID)
        {
            await Http.DeleteAsync("api/User/" + usrID);
            await GetUser();
        }

        public void ResetSearch()
        {
            SearchString = string.Empty;
            usrList = searchUsrList;
        }
    }
}
