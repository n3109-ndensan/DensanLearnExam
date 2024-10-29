using BlazorApp.Entities;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace BlazorApp.Components.Pages
{
    public partial class TaskEditor
    {
        [Parameter] 
        public MyTask MyEditTask { get; set; } = default!;
    }
}
