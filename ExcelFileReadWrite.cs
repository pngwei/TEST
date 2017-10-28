using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GX.WFCommonUsed
{
    /// <summary>
    /// 首行处理模式
    /// </summary>
    public enum ExcelFirtRowHandleMode
    {
        /// <summary>
        /// 视为数据
        /// </summary>
        Data,
        /// <summary>
        /// 字段名
        /// </summary>
        FieldName,
        /// <summary>
        /// 标题
        /// </summary>
        Caption
    }


    public class ExcelColumnInfo
    {
        private string columnName;
        /// <summary>
        /// 字段名
        /// </summary>
        public string Name
        {
            get
            {
                return columnName;
            }
        }

        private int columnWidth;
        /// <summary>
        /// 以字符数计字段宽度
        /// </summary>
        public int Width
        {
            get
            {
                return columnWidth;
            }
        }
        public ExcelColumnInfo(string colName, int colWidth)
        {
            columnName = colName;
            columnWidth = colWidth;
        }

        public ExcelColumnInfo(string colName)
            : this(colName, 0)
        {
        }
    }


    public interface IExcelFileReadWrite
    {
        /// <summary>
        /// 将DataTable数据写入Excel文件
        /// </summary>
        /// <param name="saveName">保存文件名</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="structureTable">结构定义，为空时使用数据表定义的结构</param>
        /// <param name="fieldNamesList">指定输出字段</param>
        /// <param name="titleRowCount">标题栏行数，0表示不输出标题栏</param>
        /// <param name="fileTitle">文件标题</param>
        /// <param name="allStringField">是否全部字段按字符输出</param>
        /// <param name="firstRowHandleMode">首行处理模式</param>
        /// <returns></returns>
        bool WriteExecelFile(string saveName, DataTable dataTable, DataTable structureTable, List<string> fieldNamesList, int titleRowCount, string fileTitle, bool allStringField, ExcelFirtRowHandleMode firstRowHandleMode);

        /// <summary>
        /// 将DataTable数据写入Excel文件
        /// </summary>
        /// <param name="saveName">保存文件名</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="structureTable">结构定义，为空时使用数据表定义的结构</param>
        /// <param name="fieldNamesList">指定输出字段</param>
        /// <param name="titleRowCount">标题栏行数，0表示不输出标题栏</param>
        /// <param name="fileTitle">文件标题</param>
        /// <param name="allStringField">是否全部字段按字符输出</param>
        /// <param name="firstRowHandleMode">首行处理模式</param>
        /// <returns></returns>
        bool WriteExecelFile(string saveName, DataTable dataTable, DataTable structureTable, List<ExcelColumnInfo> fieldNamesList, int titleRowCount, string fileTitle, bool allStringField, ExcelFirtRowHandleMode firstRowHandleMode);

        /// <summary>
        /// 将DataTable数据写入Excel文件
        /// </summary>
        /// <param name="saveName">保存文件名</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="structureTable">结构定义，为空时使用数据表定义的结构</param>
        /// <param name="fieldNamesList">指定输出字段</param>
        /// <param name="titleRowCount">标题栏行数，0表示不输出标题栏</param>
        /// <param name="fileTitle">文件标题</param>
        /// <param name="allStringField">是否全部字段按字符输出</param>
        /// <param name="showBorder">是否显示边框</param>
        /// <param name="firstRowHandleMode">首行处理模式</param>
        /// <returns></returns>
        bool WriteExecelFile(string saveName, DataTable dataTable, DataTable structureTable, List<ExcelColumnInfo> fieldNamesList, int titleRowCount, string fileTitle, bool allStringField, bool showBorder, ExcelFirtRowHandleMode firstRowHandleMode);


        /// <summary>
        /// 将Excel表文件中读取表数据
        /// </summary>
        /// <param name="saveName">文件名</param>
        /// <param name="tableName">表名，空时读取第一页数据</param>
        /// <param name="structureTable">结构定义表，为空时自动判断结构</param>
        /// <param name="startRowIdx">开始读取数据的行编号，从0开始编号</param>
        /// <param name="firstRowHandleMode">首行处理模式</param>
        /// <returns></returns>
        DataTable ReadDataTable(string saveName, string tableName, DataTable structureTable, int startRowIdx, ExcelFirtRowHandleMode firstRowHandleMode);

        /// <summary>
        /// 显示保存Excel文件对象框
        /// </summary>
        /// <param name="title">提示信息</param>
        /// <param name="filter"></param>
        /// <param name="defaultFileName">缺省文件名</param>
        /// <returns>文件名或空</returns>
        string ShowSaveFileDialog(string title, string filter, string defaultFileName);

        string ShowOpenFileDialog(string title, string filter, string defaultFileName);
        string ExcelFileFilter
        {
            get;
        }
    }
}
