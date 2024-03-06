using Microsoft.AspNetCore.Components;
using SimpleTable.ExceptionHandling;
using SimpleTable.Models;
using System.Reflection;

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
                List<Column> colConfig = [];
                //List<Column> colAttrConfig  = GetColumnAttributeDetails();
                return colConfig;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
