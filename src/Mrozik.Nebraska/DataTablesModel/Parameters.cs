using System.Collections.Generic;
using Mrozik.Nebraska.Models;

namespace Mrozik.Nebraska.DataTablesModel
{
    public class Parameters
    {
        public int Draw { get; set; }

        public int Start { get; set; }
        public int Length { get; set; }

        public Search  /*Dictionary<string, string>*/ Search { get; set; }
        public IList<ColumnOrder/*Dictionary<string, string>*/> Order { get; set; }
        public IList<Column/*Dictionary<string, string>*/> Columns { get; set; }
    }
}