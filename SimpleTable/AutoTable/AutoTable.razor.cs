using Microsoft.AspNetCore.Components;
using SimpleTable.Models;
using System.Reflection;

namespace SimpleTable.AutoTable
{
    public partial class AutoTable<TSource>
    {
        #region Fields
        private List<KeyValuePair<string, Column>> _colParamConfig => GetParamName();
        #endregion Fields

        #region Parameters
        [Parameter]
        public IEnumerable<TSource>? Sources { get; set; }
        #endregion Parameters
        public AutoTable()
        {

        }

        private List<KeyValuePair<string, Column>> GetParamName()
        {
            try
            {
                List<KeyValuePair<string, Column>> colParamConfig = [];
                string colName = string.Empty;
                if (Sources is not null && Sources.Any())
                {
                    Type type = typeof(TSource);
                    List<PropertyInfo> properties = [.. type.GetProperties()];
                    foreach (var eachProp in properties)
                    {
                        ColumnConfig columnAttr = (ColumnConfig)Attribute.GetCustomAttribute(eachProp, typeof(ColumnConfig));
                        if (string.IsNullOrWhiteSpace(columnAttr?.Name))
                        {
                            colName = eachProp.Name;
                        }
                        else
                        {
                            colName = columnAttr.Name;
                        }
                        colParamConfig.Add(new KeyValuePair<string, Column>(colName, new Column { ColumnName = eachProp.Name, Order = columnAttr.Order }));
                    }
                }
                return colParamConfig.OrderBy(x => x.Value.Order).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
