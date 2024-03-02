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
        public ISizing? Width { get; set; }
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
        }
        public void AddCssStyle()
        {
            SetStyle();
            SetWidth();
        }
        private void CssExternalClass()
        {
            if (!string.IsNullOrWhiteSpace(Class))
            {
                _classBuilder.SetCssClass(Class.Trim(), true);
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
            if (Width is not null)
            {
                _styleBuilder.SetCssStyle($"min-width: {Width.Measurement.Width}{Width.Measurement.Unit};");
            }
        }
        #endregion Methods
    }
}
