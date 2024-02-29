using Microsoft.AspNetCore.Components;
using SimpleTable.Utilities;

namespace SimpleTable.Grid
{
    public partial class Header
    {
        #region Fields
        private CssClassBuilder _classBuilder { get; set; }
        private string _classes => _classBuilder.GetClassNames;
        private bool _headerBackground { get; set; }
        #endregion Fields

        #region Properties
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public string CssClass { get; set; } = string.Empty;
        [Parameter]
        public bool HeaderBackground { get { return _headerBackground; } set { _headerBackground = value; } }
        #endregion Properties

        #region Constructor
        public Header()
        {
            _classBuilder = new(AddCssClasses);
        }
        #endregion Constructor

        #region Methods
        public void AddCssClasses()
        {
            CssDefault();
            CssExternalClass();
            CssHeaderBackground();
        }

        private void CssDefault()
        {
            _classBuilder.SetCssClass(Constants.Tr, true);
        }
        private void CssExternalClass()
        {
            if (!string.IsNullOrWhiteSpace(CssClass))
            {
                _classBuilder.SetCssClass(CssClass.Trim(), true);
            }
        }
        private void CssHeaderBackground()
        {
            if(_headerBackground)
            {
                _classBuilder.SetCssClass(Constants.HeaderBackground, _headerBackground);
            }
        }
        #endregion Methods
    }
}
