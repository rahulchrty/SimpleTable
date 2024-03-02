using Microsoft.AspNetCore.Components;
using SimpleTable.Utilities;

namespace SimpleTable
{
    public partial class THead
    {
        #region Fields
        private CssClassBuilder _classBuilder { get; set; }
        private string _classes => _classBuilder.GetClassNames;
        #endregion Fields

        #region Properties
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public string Id { get; set; } = string.Empty;
        [Parameter]
        public string Style { get; set; } = string.Empty;
        [Parameter]
        public string Class { get; set; } = string.Empty;
        [Parameter]
        public bool HeaderBG {  get; set; } = false;
        #endregion Properties

        #region Constructor
        public THead()
        {
            _classBuilder = new(AddCssClasses);
        }
        #endregion Constructor

        #region Methods
        public void AddCssClasses()
        {
            CssExternalClass();
            CssHeaderBackground();
        }
        private void CssExternalClass()
        {
            if (!string.IsNullOrWhiteSpace(Class))
            {
                _classBuilder.SetCssClass(Class.Trim(), true);
            }
        }
        private void CssHeaderBackground()
        {
            if(HeaderBG)
            {
                _classBuilder.SetCssClass(Constants.HeaderBackground, HeaderBG);
            }
        }
        #endregion Methods
    }
}
