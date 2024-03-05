using Microsoft.AspNetCore.Components;
using SimpleTable.ExceptionHandling;
using SimpleTable.Models;
using System.Reflection;

namespace SimpleTable.AutoTable
{
    public partial class AutoTable<TSource>
    {
        #region Fields
        private List<ColumnConfig> _colConfig => GetColumnConfig();
        #endregion Fields

        #region Parameters
        [Parameter]
        public IEnumerable<TSource>? Source { get; set; }
        #endregion Parameters
        public AutoTable()
        {

        }

        private List<ColumnConfig> GetColumnConfig()
        {
            try
            {
                List<ColumnConfig> colConfig = [];
                string colName = string.Empty;
                int colOrder = 0;
                int colOrderIncrimental = 0;
                if (Source is not null && Source.Any())
                {
                    Type type = typeof(TSource);
                    List<PropertyInfo> properties = type.GetProperties().ToList();
                    foreach (var eachProp in properties)
                    {
                        DataColumn columnAttr = (DataColumn)Attribute.GetCustomAttribute(eachProp, typeof(DataColumn));
                        if (string.IsNullOrWhiteSpace(columnAttr?.Name))
                        {
                            colName = eachProp.Name;
                        }
                        else
                        {
                            colName = columnAttr.Name;
                        }
                        if (!colConfig.Where(x => x.Order == columnAttr.Order).Any())
                        {
                            if (columnAttr is not null)
                            {
                                colOrder = columnAttr.Order;
                            }
                            colConfig.Add(new() { ColumnName = colName, PropertyName = eachProp.Name, Order = colOrder });
                        }
                        else
                        {
                            throw new InvalidColumnOrderException(columnAttr.Order);
                        }
                    }
                }
                return colConfig.OrderBy(x => x.Order).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private List<ColumnConfig> GetColumnAttributeDetails()
        {
            try
            {
                List<ColumnConfig> colConfig = [];
                if (Source is not null && Source.Any())
                {
                    Type type = typeof(TSource);
                    List<PropertyInfo> properties = [.. type.GetProperties()];
                    foreach (var eachProp in properties)
                    {
                        DataColumn columnAttr = (DataColumn)Attribute.GetCustomAttribute(eachProp, typeof(DataColumn));
                        if (columnAttr is not null)
                        {
                            colConfig.Add(new() { ColumnName = columnAttr.Name, PropertyName = eachProp.Name, Order = columnAttr.Order });
                        }
                    }
                }
                else
                {
                    throw new InvalidSourceException();
                }
                return colConfig;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
