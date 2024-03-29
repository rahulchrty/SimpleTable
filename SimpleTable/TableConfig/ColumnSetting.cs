﻿using SimpleTable.ExceptionHandling;
using SimpleTable.Models;
using System.Reflection;

namespace SimpleTable.TableConfig
{
    internal class ColumnSetting
    {
        /// <summary>
        /// Get columns with their orders
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        /// <exception cref="InvalidColumnException"></exception>
        internal List<Column> GetColumns(Type type, List<Column> priorityColConfig)
        {
            List<Column> columns;
            Dictionary<int, string> properties = GetPropertiesByPropertyOrder(type);
            List<Column> colDetails = GetColumnAttributeDetailsByPropertyName(properties.Values.ToList(), type);
            if (!HasDuplicateColumn(colDetails))
            {
                columns = OrderColumns(properties, colDetails);
                if (priorityColConfig is not null && priorityColConfig.Count > 0)
                {
                    columns = SetupPriorityColConfig(columns, priorityColConfig);
                }
            }
            else
            {
                throw new InvalidColumnException($"Column order ambiguity.");
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
        private Dictionary<int, string> GetPropertiesByPropertyOrder(Type type)
        {
            Dictionary<int, string> properties = new();
            int propertyOrder = 0;
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
            return properties;
        }

        /// <summary>
        /// Get attribute details from the properties those have the attribute
        /// And set the column name
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        private List<Column> GetColumnAttributeDetailsByPropertyName(List<string> properties, Type type)
        {
            List<Column> colConfig = [];
            if (properties is not null)
            {
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

        /// <summary>
        /// Add the priority columns, this function can be useful for localization.
        /// Developer can override the fix column order and name with dynamically
        /// passed values. This will override all other configuration. However
        /// column order should always be unique.
        /// </summary>
        /// <param name="colConfig"></param>
        /// <param name="priorityColConfig"></param>
        /// <returns></returns>
        /// <exception cref="InvalidColumnException"></exception>
        private List<Column> SetupPriorityColConfig(List<Column> colConfig, List<Column> priorityColConfig)
        {
            List<Column> colConfigWithPriority = colConfig;
            foreach (var eachPriorityCol in priorityColConfig)
            {
                var col = colConfigWithPriority.Where(x => x.PropertyName.Equals(eachPriorityCol.PropertyName)).FirstOrDefault();
                if (col is not null)
                {
                    if (!string.IsNullOrWhiteSpace(eachPriorityCol.ColumnName))
                    {
                        colConfigWithPriority[colConfigWithPriority.IndexOf(col)].ColumnName = eachPriorityCol.ColumnName;
                    }
                    if (eachPriorityCol.Order > 0)
                    {
                        colConfigWithPriority[colConfigWithPriority.IndexOf(col)].Order = eachPriorityCol.Order;
                    }
                }
                else
                {
                    throw new InvalidColumnException("Invalid column property name.");
                }
            }
            if (HasDuplicateColumn(colConfigWithPriority))
            {
                colConfigWithPriority = PriorityColumnOrderProcessor(colConfigWithPriority, priorityColConfig);
            }
            return colConfigWithPriority;
        }

        /// <summary>
        /// Reorder the cols according to the orders provided in the priority config
        /// </summary>
        /// <param name="colConfigWithPriority"></param>
        /// <param name="colConfigs"></param>
        /// <returns></returns>
        private List<Column> PriorityColumnOrderProcessor(List<Column> colConfigWithPriority, List<Column> colConfigs)
        {
            List<Column> cols = colConfigWithPriority;
            List<Column> configs = colConfigs.Where(x => x.Order > 0).ToList();
            foreach (var eachConf in configs)
            {
                var colsToShift = cols.Where(x => !x.PropertyName.Equals(eachConf.PropertyName)).Where(y => y.Order >= eachConf.Order).OrderBy(x => x.Order).ToList();
                bool isColToShft = true;
                for (int i = 0; i < colsToShift.Count && isColToShft; i++)
                {
                    if (isColToShft)
                    {
                        colsToShift[i].Order += 1;
                        if (colsToShift.IndexOf(colsToShift[i]) + 1 == colsToShift.Count
                            || colsToShift[i].Order < colsToShift[colsToShift.IndexOf(colsToShift[i]) + 1].Order)
                        {
                            isColToShft = false;
                        }
                    }
                }
            }
            return cols.OrderBy(x => x.Order).ToList();
        }
    }
}