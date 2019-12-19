using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System.Data;
using NPOI.HSSF.UserModel;

namespace Anno.Npoi
{
    /// <summary>
    /// Excel 帮助类
    /// </summary>
    public class ExcelHelper : IDisposable
    {
        private string fileName = null; //文件名
        private FileStream fs = null;
        private bool disposed;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fileName"></param>
        public ExcelHelper(string fileName)
        {
            this.fileName = fileName;
            disposed = false;
        }

        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public int DataTableToExcel(DataTable data, bool isColumnWritten)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;
            try
            {
                IWorkbook work = CreateExcel();
                sheet = work.GetSheetAt(work.ActiveSheetIndex);
                if (isColumnWritten == true) //写入DataTable的列名
                {
                    IRow row = sheet.CreateRow(0);
                    ICellStyle style = work.CreateCellStyle();
                    style.BorderBottom = BorderStyle.Thin;
                    style.Alignment = HorizontalAlignment.Center;
                    IFont font = work.CreateFont();
                    font.IsBold = true;
                    font.FontHeight = 300;
                    font.FontName = "楷体";
                    row.HeightInPoints = 50;
                    row.HeightInPoints = 20;
                    style.SetFont(font);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        ICell cell = row.CreateCell(j);
                        cell.CellStyle = style;
                        cell.SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    ICellStyle style = work.CreateCellStyle();
                    style.Alignment = HorizontalAlignment.Center;
                    IFont font = work.CreateFont();
                    font.FontName = "仿宋";
                    style.SetFont(font);
                    IRow row = sheet.CreateRow(count);
                    font.FontHeight = 250;
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        ICell cell = row.CreateCell(j);
                        cell.CellStyle = style;
                        cell.SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                SaveFile(work, fileName);
                return count;
            }
            catch (Exception ex)
            {
                Log.Log.Error(ex, typeof(ExcelHelper));
                return -1;
            }
        }

        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <returns>返回的DataTable</returns>
        public DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                IWorkbook workbook = new XSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 释放占用
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 释放占用
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (fs != null)
                        fs.Close();
                }

                fs = null;
                disposed = true;
            }
        }

        /// <summary>
        /// 复制模板 防止多用户操作同一个模板
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string CopyExcelTemplate(string templateName, string fileName)
        {
            //如果不存在Data文件夹 创建
            if (Directory.Exists(Path.Combine(PathUtil.BaseDir, "Excel", "Data")) == false)
            {
                Directory.CreateDirectory(Path.Combine(PathUtil.BaseDir, "Excel", "Data"));
            }
            string path = Path.Combine(PathUtil.BaseDir, "Excel", templateName + ".xls");
            string userpath = Path.Combine(PathUtil.BaseDir, "Excel", "Data", fileName + ".xls");
            if (File.Exists(userpath))
            {
                File.Delete(userpath);
            }
            if (File.Exists(path))
            {
                File.Copy(path, userpath, true);
            }
            if (File.Exists(userpath))
            {
                return userpath;
            }
            else
                return null;
        }
        public IWorkbook CreateExcel(ExcelType? excelType = ExcelType.XLS)
        {
            string path = Path.Combine(PathUtil.BaseDir, "Excel", "bif.xls");
            IWorkbook workBook = WorkbookFactory.Create(path);
            return workBook;
        }
        private void SaveFile(IWorkbook work, string fileName)
        {
            MemoryStream ms = new MemoryStream();
            work.Write(ms);
            byte[] array = ms.ToArray();
            string filepath = Path.Combine(PathUtil.BaseDir, "Excel", "Data", fileName + ".xls");
            if (File.Exists(filepath))
                File.Delete(filepath);
            using (FileStream file = File.Open(filepath, FileMode.CreateNew))
            {
                file.Write(array, 0, array.Length);
                file.Flush();
            }
        }
    }
    /// <summary>
    /// Excel 类型
    /// </summary>
    public enum ExcelType
    {
        XLS,
        XLSX
    }
    /// <summary>
    /// 当前路径
    /// </summary>
    public static class PathUtil
    {
        /// <summary>
        /// 当前路径
        /// </summary>
        public static string BaseDir
        {
            get
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;

                int index = path.IndexOf("Bin", StringComparison.CurrentCultureIgnoreCase);
                if (index != -1)
                {
                    path = path.Substring(0, index);
                }
                return path;
            }
        }
    }
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 根据完整文件路径获取FileStream
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static FileStream GetFileStream(string fileName)
        {
            FileStream fileStream = null;
            if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
            {
                fileStream = new FileStream(fileName, FileMode.Open);
            }
            return fileStream;
        }
    }
}
