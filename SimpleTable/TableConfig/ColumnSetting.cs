using SimpleTable.ExceptionHandling;
using SimpleTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTable.TableConfig
{
    public class ColumnSetting<TSource>
    {
        public List<Column> GetColumn(TSource source)
        {
            List<Column> columns = new();
            Dictionary<int, string> properties = GetPropertiesByPropertyOrder(source);
            List<Column> colDetails = GetColumnAttributeDetailsByPropertyName(properties.Values.ToList());
            if(!HasDuplicateColumn(colDetails))
            {

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
        public Dictionary<int, string> GetPropertiesByPropertyOrder(TSource source)
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
        public List<Column> GetColumnAttributeDetailsByPropertyName(List<string> properties)
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
        public bool HasDuplicateColumn(List<Column> colDetails)
        {
            bool hasDuplicate = false;
            hasDuplicate = colDetails.GroupBy(x => x.Order).Where(g => g.Count() > 1).Any();
            return hasDuplicate;
        }

        public List<Column> OrderColumns(Dictionary<int, string> properties, List<Column> colDetails)
        {
            List<Column> columns = new();
            int colOrder = 0;
            columns = colDetails.Where(x => x.Order != 0).OrderBy(x=>x.Order).ToList();
            foreach (var eachCol in columns) { eachCol.Order = ++colOrder; }
            var colsWithoutOrder = properties.Where(x => colDetails.Where(x => x.Order == 0).Where(y=>y.PropertyName.Equals(x.Value)).Any()).ToList();
            var propsWithNoColAttr = properties.Where(x => !colDetails.Any(y => y.PropertyName.Equals(x.Value))).ToList();
            propsWithNoColAttr.AddRange(colsWithoutOrder);
            foreach (var eachProp in propsWithNoColAttr.OrderBy(x=>x.Key)) 
            {
                columns.Add(new Column
                {
                    ColumnName = eachProp.Value,
                    PropertyName = eachProp.Value,
                    Order = ++colOrder
                });
            }
            return columns;
        }
    }
}
