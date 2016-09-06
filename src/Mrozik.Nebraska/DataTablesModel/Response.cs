using System.Collections.Generic;

namespace Mrozik.Nebraska.DataTablesModel
{
    public class Response<T>
    {
        public int Draw { get; }
        public int RecordsTotal { get; }
        public int RecordsFiltered { get; }
        public IEnumerable<T> Data { get; }

        public Response(int draw, int recordsTotal, int recordsFiltered, IEnumerable<T> data)
        {
            Draw = draw;
            RecordsTotal = recordsTotal;
            RecordsFiltered = recordsFiltered;
            Data = data;
        }
    }
}