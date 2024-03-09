using Microsoft.AspNetCore.Components;
using SimpleTable.Models;
using SimpleTable.TableConfig;

namespace SimpleTable.AutoTable
{
    public partial class AutoTable<TSource>
    {
        #region Fields
        private List<Column> _colConfig => GetColumnConfig();
        #endregion Fields

        #region Parameters
        [Parameter]
        public IEnumerable<TSource>? Source { get; set; }
        #endregion Parameters
        public AutoTable()
        {
             
        }

        private List<Column> GetColumnConfig()
        {
            try
            {
                if (Source is not null)
                {
                    List<Column> colConfig = [];
                    ColumnSetting columnSetting = new();
                    colConfig = columnSetting.GetColumns(typeof(TSource));
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
