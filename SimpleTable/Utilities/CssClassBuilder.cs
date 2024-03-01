using System.Text;

namespace SimpleTable.Utilities
{
    internal class CssClassBuilder
    {
        #region Fields
        private Action _cssClassMethod;
        private StringBuilder _classBuilder = new();
        private Dictionary<string, bool> _classBuilderDictionary = new();
        #endregion Fields

        #region Properties
        internal string GetClassNames
        {
            get
            {
                _cssClassMethod();
                foreach (var eachBuilder in _classBuilderDictionary)
                {
                    if (eachBuilder.Value)
                    {
                        _ = _classBuilder.Append(eachBuilder.Key).Append(Constants.CssDelemeter);
                    }
                }
                return _classBuilder.ToString().TrimEnd();
            }
        }
        #endregion Properties

        #region Constructor
        internal CssClassBuilder(Action cssClassMthod)
        {
            _cssClassMethod = cssClassMthod;
        }
        #endregion Constructor

        #region Methods
        internal void SetCssClass(string cssClassName, bool isRequired)
        {
            if (!string.IsNullOrWhiteSpace(cssClassName))
            {
                if (!_classBuilderDictionary.ContainsKey(cssClassName))
                {
                    _classBuilderDictionary.Add(cssClassName, isRequired);
                }
                else
                {
                    _classBuilderDictionary[cssClassName] = isRequired;
                }
            }
        }
        #endregion Methods
    }
}
