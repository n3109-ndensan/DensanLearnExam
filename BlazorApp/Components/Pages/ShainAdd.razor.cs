using BlazorApp.Entities;
using BlazorApp.Utils;
using BlazorApp.Utils.CommonConstants;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Components.Pages
{
    public partial class ShainAdd : IDisposable
    {
        private ShainInfo editShain = default!;
        bool isError = false;
        private EditContext editContext = default!;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            editShain = new ShainInfo("", DateTime.Today, ShainKbn.Regular, "");
            editContext = new(editShain);
            editContext.OnFieldChanged += HandleFieldChanged;
        }

        private void HandleFieldChanged(object? sender, FieldChangedEventArgs e)
        {
            if (editContext != null)
            {
                isError = !editContext.Validate();
            }
            StateHasChanged();
        }

        async Task PlaceShain()
        {
            await Task.Yield();

            if (editShain != null)
            {
                if (sessionState.HasState)
                {
                    List<ShainInfo> list = sessionState.State!;
                    list.Add(editShain);
                    sessionState.State = list;
                }
                else
                {
                    List<ShainInfo> list = new();
                    list.Add(editShain);
                    sessionState.State = list;
                }
            }
            NavigationManager.NavigateTo("/");
        }

        async Task Cancel()
        {
            await Task.Yield();

            isError = false;
            NavigationManager.NavigateTo("/");
        }

        public void Dispose()
        {
            if (editContext != null)
            {
                editContext.OnFieldChanged -= HandleFieldChanged;
            }
        }
    }


}
