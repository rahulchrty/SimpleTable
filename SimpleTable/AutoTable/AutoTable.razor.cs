using Microsoft.AspNetCore.Components;
using SimpleTable.Models;
using SimpleTable.TableConfig;

namespace SimpleTable.AutoTable
{
    public partial class AutoTable<TSource>
    {
        #region Fields
        private List<Column> _colConfig => GetColumnConfig();
        private ColumnSetting _columnSetting;
        #endregion Fields

        #region Parameters
        [Parameter]
        public IEnumerable<TSource>? Source { get; set; }
        [Parameter]
        public List<Column>? ColumnLocalization { get; set; }
        #endregion Parameters
        public AutoTable()
        {
            _columnSetting = new();
        }

        private List<Column> GetColumnConfig()
        {
            try
            {
                List<Column> colConfig = [];
                if (Source is not null)
                {
                    colConfig = _columnSetting.GetColumns(typeof(TSource), ColumnLocalization);
                    return colConfig;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
