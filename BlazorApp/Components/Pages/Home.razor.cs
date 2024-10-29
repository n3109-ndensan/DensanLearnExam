using BlazorApp.Entities;
using BlazorApp.Utils;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace BlazorApp.Components.Pages
{
    public partial class Home
    {
        private List<MyTask> list = default!;

        private IList<MyTask> selectedMyTask = default!;

        bool sessionExsists => sessionState.HasState;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            list = sessionExsists ? sessionState.State! : InitialMyTask();

            list.Sort(new MyTask.SortComparer());

            if (!sessionExsists)
                sessionState.State = list;
        }

        async Task LoadMyTask()
        {
            await Task.Yield();

            if (sessionExsists)
            {
                sessionState.State = list;
                return;
            }
        }

        List<MyTask> InitialMyTask()
        {
            return new List<MyTask>
            {
                new MyTask("Task 1", DateTime.Today, CommonConstants.TaskStatus.Pending, "Initial Task 1"),
                new MyTask("Task 2", DateTime.Today.AddDays(1), CommonConstants.TaskStatus.Pending, "Initial Task 2"),
                new MyTask("Task 3", DateTime.Today.AddDays(2), CommonConstants.TaskStatus.Pending, "Initial Task 3"),
            };
        }

        protected void TaskAdd()
        {
            NavigationManager.NavigateTo("task-add");
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
