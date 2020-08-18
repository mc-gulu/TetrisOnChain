using System.Collections.Generic;
using System.IO;
using ExcelDataReader;
using System.Data;
public class ExcelReader
{
    public class SheetData
    {
        public int rowCount = 0;
        public int columnCount = 0;
        private List<List<string>> table = new List<List<string>>();
        public List<List<string>> Table
        {
            get { return table; }
        }

        public string At(int row, int column)
        {
            return table[row][column];
        }
    }

    /// <summary>
    /// get data from Excel file by sheet.
    /// </summary>
    /// <param name="filePath">absolute file path on the disk</param>
    /// <param name="sheet">sheet index, from 0 to max</param>
    /// <returns></returns>
    /// 
    public static SheetData AsStringArray(string filePath, int sheet = 0)
    {
        //FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
        //IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

        DataSet result = excelDataReader.AsDataSet();
        SheetData sheetData = new SheetData();
        int columns = result.Tables[0].Columns.Count;
        int rows = result.Tables[0].Rows.Count;

        for (int i = 0; i < rows; i++)
        {
            List<string> rowData = new List<string>();
            for (int j = 0; j < columns; j++)
            {
                string nvalue = result.Tables[0].Rows[i][j].ToString();
                rowData.Add(nvalue);
            }
            sheetData.Table.Add(rowData);
        }

        sheetData.rowCount = rows;
        sheetData.columnCount = columns;

        stream.Close();


        return sheetData;
    }

    public static System.Data.DataTable GetDataTable(string filePath)
    {
        FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        DataSet result = excelReader.AsDataSet();
        return result.Tables[0];
    }

}