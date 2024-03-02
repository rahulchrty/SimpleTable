using Microsoft.AspNetCore.Components;
using SimpleTable.Utilities;

namespace SimpleTable
{
    public partial class Table
    {
        #region Fields
        private CssClassBuilder _classBuilder { get; set; }
        private string _classes => _classBuilder.GetClassNames;
        private bool _isBasicBorder { get; set; } = true;
        private bool _isBordered { get; set; }
        private bool _isBorderless { get; set; }
        private bool _isStriped { get; set; }
        private string _scrollStyle { get; set; } = string.Empty;
        private ISizing _Scrollable { get; set;}
        #endregion Fields

        #region Params
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public string Id { get; set; } = string.Empty;
        [Parameter]
        public string Style { get; set; } = string.Empty;
        [Parameter]
        public string Class { get; set; } = string.Empty;
        [Parameter]
        public bool Bordered { get => _isBordered; set => _isBordered = value; }
        [Parameter]
        public bool Borderless { get => _isBorderless; set => _isBorderless = value; }
        [Parameter]
        public bool Striped { get => _isStriped; set => _isStriped = value; }
        [Parameter]
        public ISizing Scrollable { get => _Scrollable; set => _Scrollable = value; }
        #endregion Params

        #region Constructor
        public Table()
        {
            _classBuilder = new(AddCssClasses);
        }
        #endregion Constructor

        #region Methods
        protected override void OnParametersSet()
        {
            SetScrollable();
            base.OnParametersSet();
        }
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
            if (_isBasicBorder)
            {
                _classBuilder.SetCssClass(Constants.BasicBorder, _isBasicBorder);
            }
        }
        private void CssExternalClass()
        {
            if (!string.IsNullOrWhiteSpace(Class))
            {
                _classBuilder.SetCssClass(Class.Trim(), true);
            }
        }
        private void CssBordered()
        {
            if (_isBordered)
            {
                _isBasicBorder = false;
                _classBuilder.SetCssClass(Constants.BasicBorder, _isBasicBorder);
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
                    _isBordered = false;
                    _classBuilder.SetCssClass(Constants.BasicBorder, _isBasicBorder);
                    _classBuilder.SetCssClass(Constants.Bordered, _isBordered);
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
        private void SetScrollable()
        {
            if (_Scrollable is not null)
            {
                if (_Scrollable.Measurement.Height is not null)
                {
                    _scrollStyle = $"height:{_Scrollable.Measurement.Height}{_Scrollable.Measurement.Unit};";
                }
                if (_Scrollable.Measurement.Width is not null)
                {
                    _scrollStyle += $"width:{_Scrollable.Measurement.Width}{_Scrollable.Measurement.Unit};";
                }
            }
        }
        #endregion Methods
    }
}
