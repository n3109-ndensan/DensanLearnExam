using BlazorApp.Entities;
using BlazorApp.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Components.Pages
{
    public partial class TaskAdd : IDisposable
    {
        private MyTask myTask = default!;
        bool isError = false;
        private EditContext editContext = default!;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            myTask = new MyTask("", DateTime.Today, CommonConstants.TaskStatus.Pending, "");
            editContext = new(myTask);
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

        async Task PlaceTask()
        {
            await Task.Yield();

            if (myTask != null)
            {
                if (sessionState.HasState)
                {
                    List<MyTask> list = sessionState.State!;
                    list.Add(myTask);
                    sessionState.State = list;
                }
                else
                {
                    List<MyTask> list = new();
                    list.Add(myTask);
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
