﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extension
{
    public static class GetRowDataTable
    {
        private static List<string> NameCol { get; set; }
        static GetRowDataTable()
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
    }
}
