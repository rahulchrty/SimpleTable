using Microsoft.AspNetCore.Components;
using SimpleTable.Utilities;

namespace SimpleTable
{
    public partial class THead
    {
        #region Fields
        private CssClassBuilder _classBuilder { get; set; }
        private string _classes => _classBuilder.GetClassNames;
        private string _cssClass {  get; set; } = string.Empty;
        private bool _headerBackground { get; set; }
        private bool _isFixed { get; set; }
        #endregion Fields

        #region Properties
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public string CssClass { get { return _cssClass; } set { _cssClass = value; } }
        [Parameter]
        public bool HeaderBackground { get { return _headerBackground; } set { _headerBackground = value; } }
        [Parameter]
        public bool FixedHeader { get { return _isFixed; } set { _isFixed = value; } }
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
            //CssDefault();
            //CssExternalClass();
            //CssHeaderBackground();
            //CssFixedHeader();
        }

        private void CssDefault()
        {
            _classBuilder.SetCssClass(Constants.Tr, true);
        }
        private void CssExternalClass()
        {
            if (!string.IsNullOrWhiteSpace(_cssClass))
            {
                _classBuilder.SetCssClass(_cssClass.Trim(), true);
            }
        }
        private void CssHeaderBackground()
        {
            if(_headerBackground)
            {
                _classBuilder.SetCssClass(Constants.HeaderBackground, _headerBackground);
            }
        }
        private void CssFixedHeader()
        {
            if (_isFixed)
            {
                _classBuilder.SetCssClass(Constants.Fixed, _isFixed);
            }
        }
        #endregion Methods
    }
}
