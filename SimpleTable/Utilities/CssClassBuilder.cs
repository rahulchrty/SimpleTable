using System.Text;

namespace SimpleTable.Utilities
{
    internal class CssClassBuilder
    {
        #region Fields
        private Action _cssMethod;
        private StringBuilder _classBuilder = new();
        private StringBuilder _styleBuilder = new();
        private Dictionary<string, bool> _classBuilderDictionary = new();
        private List<string> _styles = new();
        #endregion Fields

        #region Properties
        internal string GetClassNames
        {
            get
            {
                _cssMethod();
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
        internal string GetCssStyles
        {
            get
            {
                _cssMethod();
                foreach (string eachStyle in _styles)
                {
                    _ = _styleBuilder.Append(eachStyle).Append(Constants.CssDelemeter);
                }
                return _styleBuilder.ToString().TrimEnd();
            }
        }
        #endregion Properties

        #region Constructor
        internal CssClassBuilder(Action cssMthod)
        {
            _cssMethod = cssMthod;
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
        internal void SetCssStyle(string style)
        {
            _styles.Add(style);
        }
        #endregion Methods
    }
}
