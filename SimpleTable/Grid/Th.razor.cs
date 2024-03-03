using Microsoft.AspNetCore.Components;
using SimpleTable.Utilities;

namespace SimpleTable
{
    public partial class Th
    {
        #region Fields
        private CssClassBuilder _classBuilder { get; set; }
        private CssClassBuilder _styleBuilder { get; set; }
        private string _classes => _classBuilder.GetClassNames;
        private string _styles => _styleBuilder.GetCssStyles;
        private ISizing? _width {  get; set; }
        private IAlignment? _fixed { get; set; }
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
        public ISizing? Width { get => _width; set => _width = value; }
        [Parameter]
        public IAlignment? Fixed { get => _fixed; set => _fixed = value; }
        #endregion Properties

        #region Constructor
        public Th()
        {
            _classBuilder = new(AddCssClasses);
            _styleBuilder = new(AddCssStyle);
        }
        #endregion Constructor

        #region Methods
        public void AddCssClasses()
        {
            CssExternalClass();
            CssFixedCol();
        }
        public void AddCssStyle()
        {
            SetStyle();
            SetWidth();
            SetFixPosition();
        }
        private void CssExternalClass()
        {
            if (!string.IsNullOrWhiteSpace(Class))
            {
                _classBuilder.SetCssClass(Class.Trim(), true);
            }
        }
        private void CssFixedCol()
        {
            if (_fixed is not null)
            {
                _classBuilder.SetCssClass(Constants.FixedHeader, true);
            }
        }
        private void SetStyle()
        {
            if (!string.IsNullOrWhiteSpace(Style))
            {
                _styleBuilder.SetCssStyle(Style);
            }
        }
        private void SetWidth()
        {
            if (_width is not null)
            {
                _styleBuilder.SetCssStyle($"min-width: {_width.Measurement.Width}{_width.Measurement.Unit};");
            }
        }
        private void SetFixPosition()
        {
            if (_fixed is not null)
            {
                _styleBuilder.SetCssStyle(_fixed.Style ?? string.Empty);
            }
        }
        #endregion Methods
    }
}
