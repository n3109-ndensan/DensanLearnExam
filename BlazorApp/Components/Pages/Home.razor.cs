using BlazorApp.Entities;
using BlazorApp.Utils;
using BlazorApp.Utils.CommonConstants;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace BlazorApp.Components.Pages
{
    public partial class Home
    {
        private List<ShainInfo> list = default!;

        private IList<ShainInfo> selectedShainInfo = default!;

        bool sessionExsists => sessionState.HasState;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            list = sessionExsists ? sessionState.State! : InitialShainInfo();

            list.Sort();

            if (!sessionExsists)
                sessionState.State = list;
        }

        async Task LoadShainInfo()
        {
            await Task.Yield();

            if (sessionExsists)
            {
                sessionState.State = list;
                return;
            }
        }

        List<ShainInfo> InitialShainInfo()
        {
            return new List<ShainInfo>
            {
                new ShainInfo("電算 1郎", DateTime.Today.AddDays(-5), ShainKbn.Regular, "Initial Shain 1"),
                new ShainInfo("電算 2郎", DateTime.Today.AddDays(-5), ShainKbn.Regular, "Initial Shain 2"),
                new ShainInfo("電算 3郎", DateTime.Today.AddDays(-4), ShainKbn.Commission, "Initial Shain 3"),
                new ShainInfo("電算 4郎", DateTime.Today.AddDays(-4), ShainKbn.Partner, "Initial Shain 4"),
                new ShainInfo("電算 5郎", DateTime.Today.AddDays(-3), ShainKbn.Partner, "Initial Shain 5"),
            };
        }

        protected void ShainAdd()
        {
            NavigationManager.NavigateTo("shain-add");
        }

        protected string GetFirstLine(string tgtStr)
        {
            if (string.IsNullOrEmpty(tgtStr)) return string.Empty;

            int idx = tgtStr.IndexOf("\n");
            //改行がない場合、そのまま返却
            if (idx < 0) return tgtStr;

            return tgtStr.Substring(0, idx);
        }

    }
}
