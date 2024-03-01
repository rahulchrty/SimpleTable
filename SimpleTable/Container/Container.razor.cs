using Microsoft.AspNetCore.Components;

namespace SimpleTable
{
    public partial class Container
    {
        #region Fields

        #endregion Fields
        #region Parameter
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        #endregion Parameter
    }
}
