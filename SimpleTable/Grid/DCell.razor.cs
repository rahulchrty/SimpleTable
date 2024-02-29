﻿using Microsoft.AspNetCore.Components;
using SimpleTable.Utilities;

namespace SimpleTable.Grid
{
    public partial class DCell
    {
        #region Fields
        private CssClassBuilder _classBuilder { get; set; }
        private string _classes => _classBuilder.GetClassNames;
        #endregion Fields

        #region Properties
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public string CssClass { get; set; } = string.Empty;
        #endregion Properties

        #region Constructor
        public DCell()
        {
            _classBuilder = new(AddCssClasses);
        }
        #endregion Constructor

        #region Methods
        public void AddCssClasses()
        {
            CssDefault();
            CssExternalClass();
        }

        private void CssDefault()
        {
            _classBuilder.SetCssClass(Constants.Tc, true);
        }
        private void CssExternalClass()
        {
            if (!string.IsNullOrWhiteSpace(CssClass))
            {
                _classBuilder.SetCssClass(CssClass.Trim(), true);
            }
        }
        #endregion Methods
    }
}