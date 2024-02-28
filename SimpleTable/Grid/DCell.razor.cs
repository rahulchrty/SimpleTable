using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTable.Grid
{
    public partial class DCell
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
