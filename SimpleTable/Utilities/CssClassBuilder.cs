using System.Text;

namespace SimpleTable.Utilities
{
    internal class CssClassBuilder
    {
        #region Fields
        private Action _cssClassMethod;
        private StringBuilder _classBuilder = new();
        #endregion Fields

        #region Properties
        internal string GetClassNames { get 
            {
                this._cssClassMethod();
                return this._classBuilder.ToString().TrimEnd();
            } 
        }
        #endregion Properties

        #region Constructor
        internal CssClassBuilder(Action cssClassMthod)
        {
            this._cssClassMethod = cssClassMthod;
        }
        #endregion Constructor

        #region Methods
        internal void Append(string cssClassName)
        {
            if (!string.IsNullOrWhiteSpace(cssClassName))
            {
                _classBuilder.Append(cssClassName).Append(Constants.CssDelemeter);
            }
        }
        #endregion Methods
    }
}
