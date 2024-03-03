using Microsoft.AspNetCore.Components;
using SimpleTable.Utilities;

namespace SimpleTable
{
    public partial class Td
    {
        #region Fields
        private CssClassBuilder _classBuilder { get; set; }
        private CssClassBuilder _styleBuilder { get; set; }
        private string _classes => _classBuilder.GetClassNames;
        private string _styles => _styleBuilder.GetCssStyles;
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
        public IAlignment? Fixed { get => _fixed; set => _fixed = value; }
        #endregion Properties

        #region Constructor
        public Td()
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
                _classBuilder.SetCssClass(Constants.FixedCell, true);
            }
        }
        private void SetStyle()
        {
            if (!string.IsNullOrWhiteSpace(Style))
            {
                _styleBuilder.SetCssStyle(Style);
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
