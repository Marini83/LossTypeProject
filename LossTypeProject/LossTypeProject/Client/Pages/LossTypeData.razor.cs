using LossTypeProject.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LossTypeProject.Client.Pages
{
    public class LossTypeDataBase : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }

        protected List<LossType> lossTypeList = new();
        protected List<LossType> searchLossTypeList = new();
        protected LossType lossType = new();
        protected string SearchString { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await GetLossType();
        }

        protected async Task GetLossType()
        {
            lossTypeList = await Http.GetFromJsonAsync<List<LossType>>("api/LossType");
            searchLossTypeList = lossTypeList;
        }

        protected void FilterLossType()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                lossTypeList = searchLossTypeList
                    .Where(x => x.LossTypeDescription.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1)
                    .ToList();
            }
            else
            {
                lossTypeList = searchLossTypeList;
            }
        }

        protected void DeleteConfirm(int lossTypeID)
        {
            lossType = lossTypeList.FirstOrDefault(x => x.LossTypeID == lossTypeID);
        }

        protected async Task DeleteLossType(int lossTypeID)
        {
            await Http.DeleteAsync("api/LossType/" + lossTypeID);
            await GetLossType();
        }

        public void ResetSearch()
        {
            SearchString = string.Empty;
            lossTypeList = searchLossTypeList;
        }
    }
}
