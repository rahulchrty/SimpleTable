using Microsoft.AspNetCore.Components;
using SimpleTable.Utilities;

namespace SimpleTable.Grid
{
    public partial class Table
    {
        #region Fields
        private CssClassBuilder _classBuilder {  get; set; }
        private string _classes => _classBuilder.GetClassNames;
        private bool _isBordered { get; set; }
        private bool _isStriped { get; set; }
        private bool _isBorderless { get; set; }
        #endregion Fields

        #region Params
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public string CssClass { get; set; } = string.Empty;
        [Parameter]
        public bool Bordered { get { return _isBordered; } set { _isBordered = true; } }
        [Parameter]
        public bool Borderless { get { return _isBorderless; } set { _isBorderless = true; } }
        [Parameter]
        public bool Striped { get { return _isStriped; } set { _isStriped = true; } }
        #endregion Params

        #region Constructor
        public Table() 
        {
            _classBuilder = new(AddCssClasses);
        }
        #endregion Constructor

        #region Methods
        protected void AddCssClasses()
        {
            CssDefault();
            CssExternalClass();
            CssBordered();
            CssBorderless();
            CssStriped();
        }

        private void CssDefault()
        {
            _classBuilder.Append(Constants.Container);
            _classBuilder.Append(Constants.BasicBorder);
        }

        private void CssExternalClass()
        {
            if (!string.IsNullOrWhiteSpace(CssClass))
            {
                _classBuilder.Append(CssClass.Trim());
            }
        }

        private void CssBordered()
        {
            if (_isBordered)
            {
                _isBorderless = false;
                _classBuilder.Append(Constants.Bordered);
            }
        }

        private void CssBorderless()
        {
            if (_isBorderless)
            {
                _classBuilder.Append(Constants.Borderless);
            }
        }

        private void CssStriped()
        {
            if (_isStriped)
            {
                _classBuilder.Append(Constants.Striped);
            }
        }
        #endregion Methods
    }
}
