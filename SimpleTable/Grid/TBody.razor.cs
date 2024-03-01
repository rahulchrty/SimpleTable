using Microsoft.AspNetCore.Components;
using SimpleTable.Utilities;

namespace SimpleTable
{
    public partial class TBody
    {
        #region Fields
        private CssClassBuilder _classBuilder { get; set; }
        private string _classes => _classBuilder.GetClassNames;
        private string _cssClass { get; set; } = string.Empty;
        #endregion Fields

        #region Properties
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public string CssClass { get { return _cssClass; } set { _cssClass = value; } }
        #endregion Properties

        #region Constructor
        public TBody()
        {
            _classBuilder = new(AddCssClasses);
        }
        #endregion Constructor

        #region Methods
        public void AddCssClasses()
        {
            //CssExternalClass();
        }
        private void CssExternalClass()
        {
            if (!string.IsNullOrWhiteSpace(_cssClass))
            {
                _classBuilder.SetCssClass(_cssClass.Trim(), true);
            }
        }
        #endregion Methods
    }
}
