using Microsoft.AspNetCore.Components;
using SimpleTable.Utilities;

namespace SimpleTable.Grid
{
    public partial class Table
    {
        #region Fields
        private CssClassBuilder _classBuilder {  get; set; }
        private string _classes => _classBuilder.GetClassNames;
        private bool _isBasicBorder { get; set; } = true;
        private bool _isBordered { get; set; }
        private bool _isBorderless { get; set; }
        private bool _isStriped { get; set; }
        private bool _isScrollable { get; set; } 
        #endregion Fields

        #region Params
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public string CssClass { get; set; } = string.Empty;
        [Parameter]
        public bool Bordered { get { return _isBordered; } set { _isBordered = value; } }
        [Parameter]
        public bool Borderless { get { return _isBorderless; } set { _isBorderless = value; } }
        [Parameter]
        public bool Striped { get { return _isStriped; } set { _isStriped = value; } }
        [Parameter]
        public bool Scrollable { get { return _isScrollable; } set { _isScrollable = value; } }
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
            CssScrollable();
        }

        private void CssDefault()
        {
            if (_isBasicBorder)
            {
                _classBuilder.SetCssClass(Constants.BasicBorder, _isBasicBorder);
            }
        }

        private void CssExternalClass()
        {
            if (!string.IsNullOrWhiteSpace(CssClass))
            {
                _classBuilder.SetCssClass(CssClass.Trim(), true);
            }
        }

        private void CssBordered()
        {
            if (_isBordered)
            {
                _isBasicBorder = false;
                _isBorderless = false;
                _classBuilder.SetCssClass(Constants.BasicBorder, _isBasicBorder);
                _classBuilder.SetCssClass(Constants.Borderless, _isBorderless);
                _classBuilder.SetCssClass(Constants.Bordered, _isBordered);
            }
        }

        private void CssBorderless()
        {
            if (_isBorderless)
            {
                if (!_isBordered)
                {
                    _isBasicBorder = false;
                    _classBuilder.SetCssClass(Constants.BasicBorder, _isBasicBorder);
                    _classBuilder.SetCssClass(Constants.Borderless, _isBorderless);
                }
            }
        }
        private void CssStriped()
        {
            if (_isStriped)
            {
                _classBuilder.SetCssClass(Constants.Striped, _isStriped);
            }
        }
        private void CssScrollable()
        {
            if (_isScrollable)
            {
                _classBuilder.SetCssClass(Constants.Scrollable, _isScrollable);
            }
        }
        #endregion Methods
    }
}
