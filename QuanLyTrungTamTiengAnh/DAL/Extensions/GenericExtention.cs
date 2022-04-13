using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extensions
{
    public static class GenericExtention
    {
        private static List<string> NameCol { get; set; }
        static GenericExtention()
        {
            NameCol = new List<string>();
        }
        public static List<string> InitNameColumn(this DataTable dataTable)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                NameCol.Add(column.ColumnName.ToString());
            }
            return NameCol;
        }

        public static List<string> GetValueRow(this DataRow row, List<string> rowValue, List<string> nameCol)
        {
            for (int i = 0; i < nameCol.Count; i++)
            {
                rowValue.Add(row[nameCol[i]].ToString());
            }
            return rowValue;
        }

        public static List<List<string>> GetRows(this DataTable dataTable, List<string> listRow)
        {
            var collecttionRowData = new List<List<string>>();
            var NameColumn = dataTable.InitNameColumn();
            foreach (DataRow row in dataTable.Rows)
            {
                listRow = new List<string>();
                var data = row.GetValueRow(listRow, NameColumn);
                collecttionRowData.Add(data);
            }
            return collecttionRowData;

        }
    }
}
