using BlazorApp.Entities;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace BlazorApp.Components.Pages
{
    public partial class ShainEditor
    {
        [Parameter] 
        public ShainInfo EditShainInfo { get; set; } = default!;
    }
}
