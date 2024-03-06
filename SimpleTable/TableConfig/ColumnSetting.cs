using SimpleTable.ExceptionHandling;
using SimpleTable.Models;
using System.Reflection;

namespace SimpleTable.TableConfig
{
    internal class ColumnSetting<TSource>
    {
        /// <summary>
        /// Get columns with their order
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <exception cref="InvalidColumnOrderException"></exception>
        internal List<Column> GetColumns(TSource source)
        {
            List<Column> columns;
            Dictionary<int, string> properties = GetPropertiesByPropertyOrder(source);
            List<Column> colDetails = GetColumnAttributeDetailsByPropertyName(properties.Values.ToList());
            if (!HasDuplicateColumn(colDetails))
            {
                columns = OrderColumns(properties, colDetails);
            }
            else
            {
                throw new InvalidColumnOrderException();
            }
            return columns;
        }

        /// <summary>
        /// Read the property names from the source object with thier order in the source's type. 
        /// The property names are collected automatically in the order those are arranged in the source's type.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <exception cref="InvalidSourceException"></exception>
        private Dictionary<int, string> GetPropertiesByPropertyOrder(TSource source)
        {
            Dictionary<int, string> properties = new();
            int propertyOrder = 0;
            if (source is not null)
            {
                Type type = typeof(TSource);
                List<PropertyInfo> propertiesInfo = [.. type.GetProperties()];
                if (propertiesInfo.Any())
                {
                    foreach (var eachProp in propertiesInfo)
                    {
                        properties.Add(++propertyOrder, eachProp.Name);
                    }
                }
                else
                {
                    throw new InvalidSourceException();
                }
            }
            return properties;
        }

        /// <summary>
        /// Get attribute details from the properties those have the attribute
        /// And set the column name
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        private List<Column> GetColumnAttributeDetailsByPropertyName(List<string> properties)
        {
            List<Column> colConfig = [];
            if (properties is not null)
            {
                Type type = typeof(TSource);
                foreach (var eachProp in properties)
                {
                    ColumnConfig columnAttr = (ColumnConfig)Attribute.GetCustomAttribute(type.GetProperty(eachProp), typeof(ColumnConfig));
                    if (columnAttr is not null)
                    {
                        if (!string.IsNullOrWhiteSpace(columnAttr.Name))
                        {
                            colConfig.Add(new() { ColumnName = columnAttr.Name, PropertyName = eachProp, Order = columnAttr.Order });
                        }
                        else
                        {
                            colConfig.Add(new() { ColumnName = eachProp, PropertyName = eachProp, Order = columnAttr.Order });
                        }
                    }
                }
            }
            return colConfig;
        }

        /// <summary>
        /// Check for duplicate column orders
        /// </summary>
        /// <param name="colDetails"></param>
        /// <returns></returns>
        private bool HasDuplicateColumn(List<Column> colDetails)
        {
            bool hasDuplicate = false;
            hasDuplicate = colDetails.Where(x => x.Order != 0).GroupBy(x => x.Order).Where(g => g.Count() > 1).Any();
            return hasDuplicate;
        }

        /// <summary>
        /// Order cols: Cols with an order will be arranged first order by assending order.
        /// Later the cols with no order will be added according to the property order.
        /// Cols start order number does not matter, in case if we have an order such that
        /// prop:order => prop1:22, prop2:34, prop9:23, prop6:16, prop11:55
        /// It will be ordered as prop6:1, prop1:2, prop9:3, prop2:4, prop11:5
        /// and followed by rest of the cols according to their propperty order in the type.
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="colDetails"></param>
        /// <returns></returns>
        private List<Column> OrderColumns(Dictionary<int, string> properties, List<Column> colDetails)
        {
            List<Column> columns = new();
            int colOrder = 0;
            columns = colDetails.Where(x => x.Order != 0).OrderBy(x => x.Order).ToList();
            foreach (var eachCol in columns) { eachCol.Order = ++colOrder; }
            var colsWithoutOrder = properties.Where(x => colDetails.Where(x => x.Order == 0).Where(y => y.PropertyName.Equals(x.Value)).Any()).ToList();
            var propsWithNoColAttr = properties.Where(x => !colDetails.Any(y => y.PropertyName.Equals(x.Value))).ToList();
            propsWithNoColAttr.AddRange(colsWithoutOrder);
            foreach (var eachProp in propsWithNoColAttr.OrderBy(x => x.Key))
            {
                columns.Add(new Column
                {
                    PropertyName = eachProp.Value,
                    ColumnName = colDetails.Where(x => x.PropertyName.Equals(eachProp.Value)).Any() 
                                    ? colDetails.Where(x => x.PropertyName.Equals(eachProp.Value)).Select(x => x.ColumnName).First()
                                    : eachProp.Value,
                    Order = ++colOrder
                });
            }
            return columns;
        }
    }
}