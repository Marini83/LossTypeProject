using LossTypeProject.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LossTypeProject.Client.Pages
{
    public class AddEditLossTypeBase : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int lossTypeID { get; set; }

        protected string Title = "Add";
        public LossType lossType = new();



        protected override async Task OnParametersSetAsync()
        {
            if (lossTypeID != 0)
            {
                Title = "Edit";
                lossType = await Http.GetFromJsonAsync<LossType>("api/LossType/" + lossTypeID);
            }
        }

        protected async Task SaveLossType()
        {
            if (lossType.LossTypeID != 0)
            {
                await Http.PutAsJsonAsync("api/LossType", lossType);
            }
            else
            {
                await Http.PostAsJsonAsync("api/LossType", lossType);
            }
            Cancel();
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo("/fetchlossType");
        }
    }
}
