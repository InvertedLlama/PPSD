using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPSDPart2.Interfaces
{
    public interface IDataSource
    {
        event EventHandler DataChanged;
        IList<string> FieldNames { get; }
        Dictionary<string, List<string>> Data { get; }
        List<string> getDataColumn(string field);

    }
}
