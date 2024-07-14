using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IO;
using System.Data.Common;
using System.Reflection;
using DeliManager.Models;

namespace DeliManager.Common
{
    public class SqlClientUtility
    {
        public static string ConnectionString = string.Empty;
        public static string MainConnectionString = string.Empty;
        public static string CoreConnectionString = string.Empty;

        public static DatabaseType DatabaseType = DatabaseType.MSSQL;
        
        public static DbProviderFactory factory = null;
        static SqlClientUtility()
        {
            //SQL Server
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
            //MYSQL
            DbProviderFactories.RegisterFactory("MySql.Data.MySqlClient", MySqlClientFactory.Instance);

            ReadConnectionStringConfig();

            if (DatabaseType == DatabaseType.MSSQL)
                factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            else
                factory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
        }

        public SqlClientUtility()
        {
        }

        public static void ReadConnectionStringConfig()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            
            DatabaseType = (DatabaseType)Enum.Parse(typeof(DatabaseType), root.GetValue<string>("DBType"));
            //CoreConnectionString = root.GetConnectionString("CoreConnectionString");
            if (DatabaseType == DatabaseType.MSSQL)
            {
                //ConnectionString = root.GetConnectionString("ConnectionString");
                MainConnectionString = root.GetConnectionString("MainConnectionString");
            }
            else
            {
                //ConnectionString = root.GetConnectionString("MySQlConnectionString");
                MainConnectionString = root.GetConnectionString("MySqlMainConnectionString");

                if (!ConnectionString.EndsWith(";"))
                    ConnectionString += ";";

                if (!MainConnectionString.EndsWith(";"))
                    MainConnectionString += ";";

                //ConnectionString = string.Format("{0}{1}", ConnectionString,  "Old Guids = true;Allow User Variables=True;");
                MainConnectionString = string.Format("{0}{1}", MainConnectionString, "Old Guids = true;Allow User Variables=True;");
            }
        }

        #region SqlUtility
        /// <summary>
        /// 規定値に設定された SQLServer への <see cref="SqlConnection"/> を生成します。
        /// </summary>
        /// <returns>規定値に設定された SQLServer への <see cref="SqlConnection"/> 。</returns>
        /// <exception cref="ArgumentException"><see cref="FrameworkSettings"/> の設定に誤りがあります。</exception>
        /// <remarks>
        /// <see cref="CreateSqlConnection(string)"/> を使用します。
        /// </remarks>
        public static SqlConnection CreateSqlConnection()
        {
            return CreateSqlConnection(null);
        }

        /// <summary>
        /// 指定された接続設定の SQLServer への <see cref="SqlConnection"/> を生成します。
        /// </summary>
        /// <param name="sqlConnectionSettingName">対象の設定名。</param>
        /// <returns>指定された接続設定の SQLServer への <see cref="SqlConnection"/> 。</returns>
        /// <exception cref="ArgumentException"><see cref="FrameworkSettings"/> の設定に誤りがあります。</exception>
        /// <remarks>
        /// <para>
        /// [<see cref="SqlConnection.ConnectionString"/>]
        /// <see cref="SqlConnectionSetting.SqlConnectionString"/> の設定値を反映します。
        /// </para>
        /// </remarks>
        public static SqlConnection CreateSqlConnection(
            string sqlConnectionSettingName)
        {
            //var setting = FrameworkSettings.Default.SqlConnectionSettings.Settings.GetSetting(sqlConnectionSettingName);
            //var cn = new SqlConnection(setting.SqlConnectionString);
            //ReadConnectionStringConfig();
            var cn = new SqlConnection(MainConnectionString);
            return cn;
        }

        /// <summary>
        /// 規定値に設定された SQLServer への <see cref="SqlConnection"/> を生成し、接続を開いた上で返します。
        /// </summary>
        /// <returns>規定値に設定された SQLServer への <see cref="SqlConnection"/> 。</returns>
        /// <exception cref="ArgumentException"><see cref="FrameworkSettings"/> の設定に誤りがあります。</exception>
        /// <remarks>
        /// <see cref="CreateSqlConnectionWithOpen(string)"/> を使用します。
        /// </remarks>
        public static SqlConnection CreateSqlConnectionWithOpen()
        {
            return CreateSqlConnectionWithOpen(null);
        }

        /// <summary>
        /// 指定された接続設定の SQLServer への <see cref="SqlConnection"/> を生成し、接続を開いた上で返します。
        /// </summary>
        /// <param name="sqlConnectionSettingName">対象の設定名。</param>
        /// <returns>指定された接続設定の SQLServer への <see cref="SqlConnection"/> 。</returns>
        /// <exception cref="ArgumentException"><see cref="FrameworkSettings"/> の設定に誤りがあります。</exception>
        /// <remarks>
        /// <see cref="CreateSqlConnection(string)"/> を使用します。
        /// <see cref="SqlConnection.State"/> が <see cref="ConnectionState.Closed"/> であれば、 <see cref="SqlConnection.Open"/> を実行します。
        /// </remarks>
        public static SqlConnection CreateSqlConnectionWithOpen(
            string sqlConnectionSettingName)
        {
            var cn = SqlClientUtility.CreateSqlConnection(
                sqlConnectionSettingName);

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            return cn;
        }
    #endregion

    //same function as current. CreateConnection and CreateDbConnection.
    //we can use CreateConnection for sql later.
        public static DbConnection CreateConnection()
        {
            DbConnection conn = factory.CreateConnection();
            conn.ConnectionString = ConnectionString;
            return conn;
        }

        public static DbConnection CreateDbConnection()
        {
            DbConnection conn = factory.CreateConnection();
            conn.ConnectionString = ConnectionString;
            return conn;
        }

        public static DbCommand CreateDbCommand(string tsql, DbConnection connection)
        {
            DbCommand cmd = connection.CreateCommand();
            cmd.CommandText = tsql;
            return cmd;
        }

        /// <summary>
        /// This is generic method
        /// </summary>
        /// <returns></returns>
        public static DbConnection CreateMainConnection()
        {
            DbConnection conn = factory.CreateConnection();
            conn.ConnectionString = MainConnectionString;
            return conn;
        }

        public static DbCommand CreateCommand()
        {
            return factory.CreateCommand();
        }

        protected DbDataAdapter CreateDataAdapter()
        {
            DbDataAdapter adt = factory.CreateDataAdapter();
            return adt;
        }

        //    public BaseDA()
        //     {
        //         ap.Value.ConnectionString = Configuration.GetSection("AppConfig").GetSection("ConnectionString").Value;
        //         ap.Value.MainConnectionString = Configuration.GetSection("AppConfig").GetSection("MainConnectionString").Value;
        //         // ConnectionString = "server=127.0.0.1;port=3306;database=hti_db;user=root;password=10adm!n29";
        //         // Configuration.GetConnectionString("DefaultConnection");
        //         // Microsoft.Extensions.Configuration.GetConnectionString("WebConfigurationManager.AppSettings["StorageConnectionString"]");
        //     }

        // local server
        //public static string ConnectionString = "server=172.16.1.2;port=3306;database=figw_web;user=sa;password=10adm!n29;charset=utf8;";

        //local
        //public static string ConnectionString = "server=127.0.0.1;port=3306;database=figw_web;user=root;password=10Adm!n29;charset=utf8;";

        // UAT - Testing
        //public static string ConnectionString = "server=127.0.0.1;port=3306;database=fishery_uat;user=root;password=10Adm!n29;charset=utf8;";

        // Server for 150.95.89.9 UAT Server
        //public static string ConnectionString = "Data Source=150-95-89-9\\SQLEXPRESS17;Initial Catalog=Bank_FY_2020_21_FIGW;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;user Id=sa;password=10adm!n29;";
        //public static string MainConnectionString = "Data Source=150-95-89-9\\SQLEXPRESS17;Initial Catalog=ClusterAppProjects;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;user Id=sa;password=10adm!n29;";
        // GTB
        //public static string ConnectionString = "Data Source=GTB_FIGATEWAY01\\SQLEXPRESS17;Initial Catalog=Bank_FY_2020_21_FIGW;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;user Id=sa;password=10adm!n29;";
        //public static string MainConnectionString = "Data Source=GTB_FIGATEWAY01\\SQLEXPRESS17;Initial Catalog=ClusterAppProjects;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;user Id=sa;password=10adm!n29;";
        // IW
        //public static string ConnectionString = "Data Source=DC-FIGATEWAY01\\SQL17EXPRESS;Initial Catalog=Bank_FY_2020_21_FIGW;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;user Id=sa;password=10Adm!n29;";
        //public static string MainConnectionString = "Data Source=DC-FIGATEWAY01\\SQL17EXPRESS;Initial Catalog=ClusterAppProjects;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;user Id=sa;password=10Adm!n29;";
        // MWD Server
        //public static string ConnectionString = "Data Source=WIN-CF33GOFB7NQ\\SQLEXPRESS;Initial Catalog=Bank_FY_2020_21_FIGW;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;User ID=sa;Password=10adm!n29";
        //public static string MainConnectionString = "Data Source=WIN-CF33GOFB7NQ\\SQLEXPRESS;Initial Catalog=ClusterAppProjects;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;User ID=sa;Password=10adm!n29";
        // MFTB Server
        //public static string ConnectionString = "Data Source=GATEWAY-SERVER\\sqlexpress;Initial Catalog=Bank_FY_2020_21_FIGW;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;User ID=sa;Password=10adm!n29";
        //public static string MainConnectionString = "Data Source=GATEWAY-SERVER\\sqlexpress;Initial Catalog=ClusterAppProjects;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;User ID=sa;Password=10adm!n29";

        // Local RGBPC-1
        //public static string ConnectionString = "Data Source=RGBPC-1\\SQLEXPRESS;Initial Catalog=Bank_FY_2020_21_FIGW;Connect Timeout=120;Min Pool Size=5;Integrated Security=true;";
        //public static string MainConnectionString = "Data Source=RGBPC-1\\SQLEXPRESS;Initial Catalog=ClusterAppProjects;Connect Timeout=120;Min Pool Size=5;Integrated Security=true;";
        /* Local Server */
        //public static string ConnectionString = "Data Source=rgbgi\\rgbdb3;Initial Catalog=Bank_FY_2020_21_FIGW;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;user id=sa;password=10adm!n29";
        //public static string MainConnectionString = "Data Source=rgbgi\\rgbdb3;Initial Catalog=ClusterAppProjects;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;user id=sa;password=10adm!n29";
        // PK
        //public static string ConnectionString = "Data Source=PhyoKo\\SQLEXPRESS172;Initial Catalog=Bank_FY_2020_21_FIGW;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;user id=sa;password=10adm!n29";
        //public static string MainConnectionString = "Data Source=PhyoKo\\SQLEXPRESS172;Initial Catalog=ClusterAppProjects;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;user id=sa;password=10adm!n29";

        //PWT
        //public static string ConnectionString = "Data Source=(local)\\sql17Express;Initial Catalog=Bank_FY_2020_21_FIGW;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;user id=sa;password=10Adm!n29";
        //public static string MainConnectionString = "Data Source=(local)\\sql17Express;Initial Catalog=ClusterAppProjects;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;user id=sa;password=10Adm!n29";

        //MZT
        // public static string ConnectionString = "Data Source=(local)\\sql17Express;Initial Catalog=Bank_FY_2020_21_FIGW;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;user id=sa;password=sa";
        // public static string MainConnectionString = "Data Source=(local)\\sql17Express;Initial Catalog=ClusterAppProjects;Connect Timeout=120;Min Pool Size=5;Integrated Security=false;user id=sa;password=sa";


        //Local 
        // public static string ConnectionString = "Data Source=DESKTOP-L5TC6I5\\SQLEXPRESS;Initial Catalog=Bank_FY_2020_21_FIGW;Connect Timeout=120;Min Pool Size=5;Integrated Security=true;";
        // public static string MainConnectionString = "Data Source=DESKTOP-L5TC6I5\\SQLEXPRESS;Initial Catalog=ClusterAppProjects;Connect Timeout=120;Min Pool Size=5;Integrated Security=true;";

        //SKS
        // public static string ConnectionString = "Data Source=DESKTOP-L5TC6I5\\SQLEXPRESS;Initial Catalog=Bank_FY_2020_21_FIGW;Connect Timeout=120;Min Pool Size=5;Integrated Security=true;";
        // public static string MainConnectionString = "Data Source=DESKTOP-L5TC6I5\\SQLEXPRESS;Initial Catalog=ClusterAppProjects;Connect Timeout=120;Min Pool Size=5;Integrated Security=true;";


        //public BaseDA()
        //{
        //    //ConnectionString = "server=127.0.0.1;port=3306;database=hti_db;user=root;password=10adm!n29";
        //    //configuration.GetConnectionString("DefaultConnection");
        //    //Microsoft.Extensions.Configuration.GetConnectionString("WebConfigurationManager.AppSettings["StorageConnectionString"]");
        //}

        // private MySqlConnection GetConnection()
        // {
        //     return new MySqlConnection(ConnectionString);
        // }

        public SqlConnection GetSQLConnection()
        {
            return new SqlConnection(ConnectionString);
        }
     
        public static string SQLSafe(string argSQL)
        {
            if (string.IsNullOrEmpty(argSQL))
                argSQL = "";
            else
                argSQL = argSQL.Replace("'", "''").Trim();
            return argSQL;
        }
        public static string GetLastSavedBy(string param1, string param2)
        {
            return "IIF(" + param2 + " IS Null, " + param1 + ", " + param2 + ")";
        }
        public static string GetLastSavedDate01(string param1, string param2)
        {
            return "IF(" + param2 + " IS Null, " + param1 + ", " + param2 + ") AS lastSavedDate";
        }
        public static string GetLastSavedBy02(string param1, string param2)
        {
            //return "IF(" + param2 + " IS Null, " + param1 + ", " + param2 + ") AS lastSavedBy";
            return "CreatedBy AS lastSavedBy";
        }
        public static string GetQueryStringBySearch02( string searchingColumns, string TemplatedId,string cbm_reference_number,string fromDate,string toDate,string userId,string status,string Event)
        {
            StringBuilder sbStatus = new StringBuilder();
            StringBuilder sbEventCode = new StringBuilder();
            string[] SearchColum = searchingColumns.Split(",");
            if (status != null && status != "ALL")
            {
                string[] Status = status.Split(",");
                for (int i = 0; i < Status.Length; i++)
                {
                    sbStatus.Append("'" + Status[i] + "'");
                    if (i < Status.Length - 1)
                    {
                        sbStatus.Append(",");
                    }
                }
            }
            else
            {
                sbStatus.Append("");
            }
            if (Event != null && Event != "0")
            {
                string[] EventCode = Event.Split(",");
                for (int i = 0; i < EventCode.Length; i++)
                {
                    sbEventCode.Append("'" + EventCode[i] + "'");
                    if (i < EventCode.Length - 1)
                    {
                        sbEventCode.Append(",");
                    }
                }
            }
            else
            {
                sbEventCode.Append("");
            }
            string whereCondition = string.Empty;
            List<string> conditions = new List<string>();
            // if seq no filter
            if (!String.IsNullOrEmpty(TemplatedId))
                conditions.Add(" " + SearchColum[0] + " LIKE N'%" + TemplatedId + "%' ");
            if (!String.IsNullOrEmpty(cbm_reference_number))
                conditions.Add(" " + SearchColum[1] + " LIKE N'%" + cbm_reference_number + "%' ");
            if (!String.IsNullOrEmpty(sbStatus.ToString()))
                conditions.Add(" " + SearchColum[2] + " in  " + "(" + sbStatus + ")"+" ");
            if (!String.IsNullOrEmpty(fromDate) && !String.IsNullOrEmpty(toDate))
                conditions.Add("date_format(" + SearchColum[3] + ",'%Y%m%d') between date_format('" + fromDate + "','%Y%m%d') and date_format('" + toDate + "','%Y%m%d')");
            if (!String.IsNullOrEmpty(userId))
                conditions.Add(" " + SearchColum[4] + " LIKE N'%" + userId + "%' ");
            if (!String.IsNullOrEmpty(sbEventCode.ToString()))
                conditions.Add(" " + SearchColum[5] + " in  " + "(" + sbEventCode + ")"+" ");
            if (conditions.Count > 0)
            {
                whereCondition = " Where " + string.Join(" AND ", conditions); // seqno == 'adsfs' and id == 'asdfs';
            }
            return whereCondition;
        }
        public static string GetQueryStringBySearchMIS( string searchingColumns,string branch_codeKey,string fromDate,string createdBy)
        {
            StringBuilder sb = new StringBuilder();
            string[] SearchColum = searchingColumns.Split(",");
            if (branch_codeKey != null && branch_codeKey != "ALL")
            {
                sb.Append("'" + branch_codeKey + "'");
            }
            else
            {
                sb.Append("");
            }
            string whereCondition = string.Empty;
            List<string> conditions = new List<string>();
            
            if (!String.IsNullOrEmpty(fromDate))
                conditions.Add("date_format(" + SearchColum[0] + ",'%Y%m%d') = date_format('" + fromDate + "','%Y%m%d')");
            if (!String.IsNullOrEmpty(sb.ToString()))
                conditions.Add(" " + SearchColum[1] + " in  " + "(" + sb + ")"+" ");
            if (!String.IsNullOrEmpty(createdBy))
                conditions.Add("UPPER(" + SearchColum[2] + ") = UPPER('" + createdBy + "')");
            if (conditions.Count > 0)
            {
                whereCondition = " Where " + string.Join(" AND ", conditions);
            }
            return whereCondition;
        }
        public static string GetQueryStringBySearch( string searchingColumns, string searchKeyword )
        {
            // Searching Filter
            string sWhere = "";
            if (searchKeyword != "" && searchingColumns != null && searchingColumns != "") 
            {
                string[] columns = searchingColumns.Split(",");
                sWhere = " WHERE (";
                for (var i = 0; i < columns.Length; i++) {
                if(columns[i] == "lastSavedBy") columns[i] = GetLastSavedBy("createdBy", "updatedBy"); // to check createdBy and updatedBy
                if(columns[i] == "lastSavedDate") columns[i] = GetLastSavedBy("createdDate", "updatedDate"); // to check createdDate and updatedDate
                sWhere += columns[i] + " LIKE " + "N\'%" +  SQLSafe(searchKeyword) + "%\'" + " OR ";
                }
                sWhere = sWhere.Length >= 4 ? sWhere.Substring(0, sWhere.Length - 4) : sWhere;
                sWhere += ")";
            }
            return sWhere;
        }
        public static string GetQueryStringByOrderPagin( int currentPage, int rowPerPage, string sortBy, bool isAsc)
        {
            // Ordering
            string sOrder = "";
            if ( sortBy != "" ) 
            {
                sOrder += "ORDER BY " + sortBy;
                if ( isAsc ) sOrder += " ASC";
                else sOrder += " DESC";
            }
            else sOrder = "";
            
            // Paging
            string sLimit = "";
            if ( sOrder != "" && currentPage * rowPerPage - rowPerPage >= 0 && rowPerPage != -1 ) 
            {
                sLimit += "OFFSET " + (currentPage * rowPerPage - rowPerPage) + " ROWS FETCH NEXT " + rowPerPage + " ROWS ONLY";
            }
            string sQuery = sOrder + " " + sLimit;
            return sQuery;
        }
        public static string GetQueryStringByOrderPagin02( int currentPage, int rowPerPage, string sortBy, bool isAsc)
        {
            // Ordering
            string sOrder = "";
            if ( sortBy != "" ) 
            {
                sOrder += "ORDER BY " + sortBy;
                if ( isAsc ) sOrder += " ASC";
                else sOrder += " DESC";
            }
            else sOrder = "";
            
            // Paging
            string sLimit = "";
            if ( sOrder != "" && currentPage * rowPerPage - rowPerPage >= 0 && rowPerPage != -1 ) 
            {
                //sLimit += "OFFSET " + (currentPage * rowPerPage - rowPerPage) + " ROWS FETCH NEXT " + rowPerPage + " ROWS ONLY";
                sLimit += "LIMIT " + (currentPage * rowPerPage - rowPerPage) + ","  + rowPerPage;
            }
            string sQuery = sOrder + " " + sLimit;
            return sQuery;
        }
        public static string GetQueryStringByOrderPagin03( string sortBy, bool isAsc)
        {
            // Ordering
            string sOrder = "";
            if ( sortBy != "" ) 
            {
                sOrder += "ORDER BY " + sortBy;
                if ( isAsc ) sOrder += " ASC";
                else sOrder += " DESC";
            }
            else sOrder = "";
            
            string sQuery = sOrder;
            return sQuery;
        }
        public static string GetQueryStringByFilter(string sWhere, string filters, string filterName) 
        {
            string str  = "";
            if ( filterName != "" && filters != null && filters != "")
            {
                str = sWhere == "" ? "WHERE " : " AND ";
                string[] ftr = filters.Split(",");
                str +=  "("; 
                for(int i = 0; i < ftr.Length; i++) {
                ftr[i] =  " " + filterName + " = '" + ftr[i] + "'";
                }
                str +=  string.Join(" OR ", ftr);
                str +=  " )"; 
            }
            return str;
        }
        public static string GetQueryStringByFilterData(int currentPage, int rowPerPage,string table,string UpstrmMsgSeqtlNb,string TransactionIds,string Status,string searchingColumns )
        {
            //string sWhere = "";
            string[] SearchColum = searchingColumns.Split(",");
            StringBuilder sb = new StringBuilder();
            if(Status != null && Status != "ALL"){
                string[] status = Status.Split(",");
                for (int i = 0; i < status.Length; i++)
                {
                    sb.Append("'" + status[i] + "'");
                    if (i < status.Length - 1) {
                            sb.Append(",");
                        }
                }
            }
            else {
                sb.Append("''");
            }
            StringBuilder tsql = new StringBuilder();
            // tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
            // tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
            // tsql.AppendFormat("WHERE ("+ SearchColum[0]  +" LIKE N'%{0}%' OR "+ SearchColum[1] +" LIKE N'%{1}%' OR " + SearchColum[2] + " IN ({2}) ",TransactionIds,UpstrmMsgSeqtlNb,sb.ToString());
            // tsql.AppendFormat("OR " + SearchColum[3] +" LIKE N'%{0}%')" ,"");

            if(!String.IsNullOrEmpty(TransactionIds) && !String.IsNullOrEmpty(UpstrmMsgSeqtlNb) && !String.IsNullOrEmpty(Status)) // 3 not blank
            {
                tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
                tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
                tsql.AppendFormat("WHERE ("+ SearchColum[0]  +" LIKE N'%{0}%' AND "+ SearchColum[1] +" LIKE N'%{1}%' AND " + SearchColum[2] + " IN ({2}) ",TransactionIds,UpstrmMsgSeqtlNb,sb.ToString());
            }
            else if(!String.IsNullOrEmpty(TransactionIds) && String.IsNullOrEmpty(UpstrmMsgSeqtlNb) && String.IsNullOrEmpty(Status) ) // 1 not blank
            {
                tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
                tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
                tsql.AppendFormat("WHERE ("+ SearchColum[0]  +" LIKE N'%{0}%') ",TransactionIds);
            }
            else if(String.IsNullOrEmpty(TransactionIds) && !String.IsNullOrEmpty(UpstrmMsgSeqtlNb) && String.IsNullOrEmpty(Status) ) // 1 not blank
            {
                tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
                tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
                tsql.AppendFormat("WHERE ("+ SearchColum[1]  +" LIKE N'%{0}%') ",UpstrmMsgSeqtlNb);
            }
            else if(String.IsNullOrEmpty(TransactionIds) && String.IsNullOrEmpty(UpstrmMsgSeqtlNb) && !String.IsNullOrEmpty(Status) ) // 1 not blank
            {
                tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
                tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
                tsql.AppendFormat("WHERE ("+ SearchColum[2] + " IN ({0}) ) ",sb.ToString());
            }
            else if(!String.IsNullOrEmpty(TransactionIds) && !String.IsNullOrEmpty(UpstrmMsgSeqtlNb) && String.IsNullOrEmpty(Status) ) // 2 not blank
            {
                tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
                tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
                tsql.AppendFormat("WHERE ("+ SearchColum[0]  +" LIKE N'%{0}%' AND "+ SearchColum[1] +" LIKE N'%{1}%' ) ",TransactionIds,UpstrmMsgSeqtlNb);
            }
            else if(!String.IsNullOrEmpty(TransactionIds) && String.IsNullOrEmpty(UpstrmMsgSeqtlNb) && !String.IsNullOrEmpty(Status) ) // 2 not blank
            {
                tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
                tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
                tsql.AppendFormat("WHERE ("+ SearchColum[0]  +" LIKE N'%{0}%' AND " + SearchColum[1] + " IN ({1}) ) ",TransactionIds,sb.ToString());
            }
            else if(String.IsNullOrEmpty(TransactionIds) && !String.IsNullOrEmpty(UpstrmMsgSeqtlNb) && !String.IsNullOrEmpty(Status) ) // 2 not blank
            {
                tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
                tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
                tsql.AppendFormat("WHERE ("+ SearchColum[0]  +" LIKE N'%{0}%' AND " + SearchColum[1] + " IN ({1}) ) ",UpstrmMsgSeqtlNb,sb.ToString());
            }
            else if(String.IsNullOrEmpty(TransactionIds) && String.IsNullOrEmpty(UpstrmMsgSeqtlNb) && String.IsNullOrEmpty(Status)) // 2 not blank
            {
                tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
                tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
            }
            tsql.Append(GetQueryStringByOrderPagin(currentPage,rowPerPage,"lastSavedDate",false));
            return tsql.ToString();
        }
        public static string GetQuerySearch(string status,string seqNbFrom,string seqNbTo,DateTime? fromDate,DateTime? toDate,string searchingColumns)
        {
            string[] SearchColum = searchingColumns.Split(",");
            StringBuilder tsql = new StringBuilder();
            StringBuilder seqNb = new StringBuilder();
            StringBuilder date = new StringBuilder();
            if(!String.IsNullOrEmpty(seqNbFrom) && !String.IsNullOrEmpty(seqNbTo))
            {
                seqNb.AppendFormat("BETWEEN '{0}' AND '{1}'",seqNbFrom,seqNbTo );
            }
            else {
                seqNb.Append("");
            }
            if((fromDate != null) && (toDate != null))
            {
                date.AppendFormat("BETWEEN '{0}' AND '{1}'",fromDate,toDate);
            }
            else {
                seqNb.Append("");
            }
            if(!String.IsNullOrEmpty(status) && String.IsNullOrEmpty(seqNb.ToString()) && String.IsNullOrEmpty(date.ToString())) // 3 not blank
            {
                tsql.AppendFormat(" WHERE ("+ SearchColum[1]  +" =  '{0}' ) ",status);
            }
            else if(!String.IsNullOrEmpty(status) && !String.IsNullOrEmpty(seqNb.ToString()) && String.IsNullOrEmpty(date.ToString()) ) // 1 not blank
            {
                tsql.AppendFormat(" WHERE ("+ SearchColum[1]  +" =  '{0}' ) ",status);
                tsql.AppendFormat(" AND ("+ SearchColum[0]  +" {0} ) ",seqNb.ToString());
            }
            else if(!String.IsNullOrEmpty(status) && String.IsNullOrEmpty(seqNb.ToString()) && !String.IsNullOrEmpty(date.ToString()) ) // 1 not blank
            {
                tsql.AppendFormat(" WHERE ("+ SearchColum[1]  +" =  '{0}' ) ",status);
                tsql.AppendFormat(" AND ("+ SearchColum[2]  +" {0} ) ",date.ToString());
            }
            return tsql.ToString();
        }
        public static string GetQueryStringByFilterDataEN(int currentPage, int rowPerPage,string table,string DwnstrmMsgSeqtlNb,string TransactionIds,string Status,string fromDate,string toDate,string searchingColumns )
        {
            //string sWhere = "";
            string[] SearchColum = searchingColumns.Split(",");
            StringBuilder sb = new StringBuilder();
            StringBuilder dt = new StringBuilder();
            if(Status != null && Status != "ALL"){
                string[] status = Status.Split(",");
                for (int i = 0; i < status.Length; i++)
                {
                    sb.Append("'" + status[i] + "'");
                    if (i < status.Length - 1) {
                            sb.Append(",");
                        }
                }
            }
            else {
                sb.Append("''");
            }
             if((fromDate != null) && (toDate != null))
            {
                dt.AppendFormat("BETWEEN '{0}' AND '{1}'",fromDate,toDate);
            }
            else {
                dt.Append("");
            }
            StringBuilder tsql = new StringBuilder();
            //tsql.Append(" SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; ");
            if (!String.IsNullOrEmpty(TransactionIds) && !String.IsNullOrEmpty(DwnstrmMsgSeqtlNb) && !String.IsNullOrEmpty(Status)) // 3 not blank
            {
                tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
                tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
                tsql.AppendFormat("WHERE ("+ SearchColum[0]  +" LIKE N'%{0}%' AND "+ SearchColum[1] +" LIKE N'%{1}%' AND " + SearchColum[2] + " IN ({2}) ",TransactionIds,DwnstrmMsgSeqtlNb,sb.ToString());
            }
            else if(!String.IsNullOrEmpty(TransactionIds) && String.IsNullOrEmpty(DwnstrmMsgSeqtlNb) && String.IsNullOrEmpty(Status) ) // 1 not blank
            {
                tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
                tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
                tsql.AppendFormat("WHERE ("+ SearchColum[0]  +" LIKE N'%{0}%') ",TransactionIds);
            }
            else if(String.IsNullOrEmpty(TransactionIds) && !String.IsNullOrEmpty(DwnstrmMsgSeqtlNb) && String.IsNullOrEmpty(Status) ) // 1 not blank
            {
                tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
                tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
                tsql.AppendFormat("WHERE ("+ SearchColum[1]  +" LIKE N'%{0}%') ",DwnstrmMsgSeqtlNb);
            }
            else if(String.IsNullOrEmpty(TransactionIds) && String.IsNullOrEmpty(DwnstrmMsgSeqtlNb) && !String.IsNullOrEmpty(Status) ) // 1 not blank
            {
                tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
                tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
                tsql.AppendFormat("WHERE ("+ SearchColum[2] + " IN ({0}) ) ",sb.ToString());
            }
            else if(!String.IsNullOrEmpty(TransactionIds) && !String.IsNullOrEmpty(DwnstrmMsgSeqtlNb) && String.IsNullOrEmpty(Status) ) // 2 not blank
            {
                tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
                tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
                tsql.AppendFormat("WHERE ("+ SearchColum[0]  +" LIKE N'%{0}%' AND "+ SearchColum[1] +" LIKE N'%{1}%' ) ",TransactionIds,DwnstrmMsgSeqtlNb);
            }
            else if(!String.IsNullOrEmpty(TransactionIds) && String.IsNullOrEmpty(DwnstrmMsgSeqtlNb) && !String.IsNullOrEmpty(Status) ) // 2 not blank
            {
                tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
                tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
                tsql.AppendFormat("WHERE ("+ SearchColum[0]  +" LIKE N'%{0}%' AND " + SearchColum[1] + " IN ({1}) ) ",TransactionIds,sb.ToString());
            }
            else if(String.IsNullOrEmpty(TransactionIds) && !String.IsNullOrEmpty(DwnstrmMsgSeqtlNb) && !String.IsNullOrEmpty(Status) ) // 2 not blank
            {
                tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
                tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
                tsql.AppendFormat("WHERE ("+ SearchColum[0]  +" LIKE N'%{0}%' AND " + SearchColum[1] + " IN ({1}) ) ",DwnstrmMsgSeqtlNb,sb.ToString());
            }
            else if(String.IsNullOrEmpty(TransactionIds) && String.IsNullOrEmpty(DwnstrmMsgSeqtlNb) && String.IsNullOrEmpty(Status)) // 2 not blank
            {
                tsql.AppendFormat("SELECT * , IIF(updatedDate IS Null, createdDate, updatedDate) AS lastSavedDate, ");
                tsql.AppendFormat("IIF(updatedBy IS Null, createdBy, updatedBy) AS lastSavedBy FROM {0} ",table);
            }
            tsql.Append(GetQueryStringByOrderPagin(currentPage,rowPerPage,"lastSavedDate",false));
            //tsql.Append(" SET SESSION TRANSACTION ISOLATION LEVEL REPEATABLE READ ; ");
            return tsql.ToString();
        }
        public static string  GetFilterData(int currentPage,int rowPerPage,string table,string field,string UpstrmMsgSeqtlNb,string TransactionIds,string status,string fromDate,string toDate,string messageType,string searchingColumns)
        {
            StringBuilder tsql = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            string[] SearchColum = searchingColumns.Split(",");
            if(status != null && status != "ALL"){
                string[] Status = status.Split(",");
                for (int i = 0; i < Status.Length; i++)
                {
                    sb.Append("'" + Status[i] + "'");
                    if (i < Status.Length - 1) {
                            sb.Append(",");
                        }
                }
            }
            else {
                sb.Append("");
            }
            string whereCondition = string.Empty;
            List<string> conditions = new List<string>();
            // if seq no filter
            if(!String.IsNullOrEmpty(UpstrmMsgSeqtlNb))
                conditions.Add(" "+ SearchColum[1]  +" LIKE N'%"+ UpstrmMsgSeqtlNb + "%' ");
            if(!String.IsNullOrEmpty(TransactionIds))
                conditions.Add(" "+ SearchColum[0]  +" LIKE N'%"+ TransactionIds + "%' ");
            if(!String.IsNullOrEmpty(sb.ToString()))
                conditions.Add(" "+ SearchColum[2]  +" =  "+ sb + " ");
            if(!String.IsNullOrEmpty(fromDate) && !String.IsNullOrEmpty(toDate))
                //conditions.Add(" "+ SearchColum[3]  +" BETWEEN "+ fromDate + " AND "+ toDate +" ");
                //conditions.Add(@" "+ SearchColum[3]  +" >=  '"+ fromDate + "' AND "+ "" + SearchColum[3] + " <= '" + toDate +"' ");
                conditions.Add("date_format("+ SearchColum[3]  +",'%Y%m%d') between date_format('"+ fromDate +"','%Y%m%d') and date_format('"+ toDate +"','%Y%m%d')");
            if(!String.IsNullOrEmpty(messageType))
                conditions.Add(" "+ SearchColum[4]  +" LIKE N'%"+ messageType + "%' ");
            if (conditions.Count > 0)
            {
                whereCondition = " Where " + string.Join(" AND ", conditions); // seqno == 'adsfs' and id == 'asdfs';
            }
            tsql.Append(" SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; ");
            tsql.AppendFormat(" SET @PageNumber = {0}; ",currentPage);
            tsql.AppendFormat(" SET @RowspPage = {0}; ",rowPerPage);
            tsql.Append(" SET @TotalRecordCount = 0; ");

            tsql.AppendFormat(" SELECT COUNT({0}) INTO @TotalRecordCount ",field);
            tsql.AppendFormat(" FROM {0} {1};", table,whereCondition); //  where status ='' and msgseqno = ''

            tsql.Append("    SELECT *, UpdatedDate AS lastSavedDate ,@TotalRecordCount as TotalRecordCount FROM(SELECT *, ROW_NUMBER() OVER(ORDER BY UpdatedDate DESC) AS NUMBER ");
            tsql.AppendFormat(" FROM {0} {1} ", table,whereCondition);
            tsql.Append(" )  AS TABLE1   WHERE NUMBER BETWEEN((@PageNumber - 1) * @RowspPage + 1) ");
            tsql.Append(" AND(@PageNumber * @RowspPage)  ORDER BY UpdatedDate DESC; ");
            tsql.Append(" SET SESSION TRANSACTION ISOLATION LEVEL REPEATABLE READ; ");

            return tsql.ToString();
        }
        public static string GetFilterDataMIS(int currentPage, int rowPerPage, string table, string field, string TemplatedId, string cbm_reference_number, string status, string fromDate, string toDate, string userid, string searchingColumns)
        {
            StringBuilder tsql = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            string[] SearchColum = searchingColumns.Split(",");
            if (status != null && status != "ALL")
            {
                string[] Status = status.Split(",");
                for (int i = 0; i < Status.Length; i++)
                {
                    sb.Append("'" + Status[i] + "'");
                    if (i < Status.Length - 1)
                    {
                        sb.Append(",");
                    }
                }
            }
            else
            {
                sb.Append("");
            }
            string whereCondition = string.Empty;
            List<string> conditions = new List<string>();
            // if seq no filter
            if (!String.IsNullOrEmpty(TemplatedId))
                conditions.Add(" " + SearchColum[0] + " LIKE N'%" + TemplatedId + "%' ");
            if (!String.IsNullOrEmpty(cbm_reference_number))
                conditions.Add(" " + SearchColum[1] + " LIKE N'%" + cbm_reference_number + "%' ");
            if (!String.IsNullOrEmpty(sb.ToString()))
                conditions.Add(" " + SearchColum[2] + " in  " + "(" + sb + ")"+" ");
            if (!String.IsNullOrEmpty(fromDate) && !String.IsNullOrEmpty(toDate))
                conditions.Add("date_format(" + SearchColum[3] + ",'%Y%m%d') between date_format('" + fromDate + "','%Y%m%d') and date_format('" + toDate + "','%Y%m%d')");
            if (!String.IsNullOrEmpty(userid))
                conditions.Add(" " + SearchColum[4] + " LIKE N'%" + userid + "%' ");
            if (conditions.Count > 0)
            {
                whereCondition = " Where " + string.Join(" AND ", conditions); // seqno == 'adsfs' and id == 'asdfs';
            }
            tsql.Append(" SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; ");
            tsql.AppendFormat(" SET @PageNumber = {0}; ", currentPage);
            tsql.AppendFormat(" SET @RowspPage = {0}; ", rowPerPage);
            tsql.Append(" SET @TotalRecordCount = 0; ");

            tsql.AppendFormat(" SELECT COUNT({0}) INTO @TotalRecordCount ", field);
            tsql.AppendFormat(" FROM {0} {1};", table, whereCondition); //  where status ='' and msgseqno = ''

            tsql.Append("    SELECT *, UpdatedDate AS lastSavedDate ,@TotalRecordCount as TotalRecordCount FROM(SELECT *, ROW_NUMBER() OVER(ORDER BY UpdatedDate DESC) AS NUMBER ");
            tsql.AppendFormat(" FROM {0} {1} ", table, whereCondition);
            tsql.Append(" )  AS TABLE1   WHERE NUMBER BETWEEN((@PageNumber - 1) * @RowspPage + 1) ");
            tsql.Append(" AND(@PageNumber * @RowspPage)  ORDER BY report_date DESC; ");
            tsql.Append(" SET SESSION TRANSACTION ISOLATION LEVEL REPEATABLE READ; ");
            return tsql.ToString();
        }

        public static string GetFilterDataMIS02(int currentPage, int rowPerPage, string table, string field, string TemplatedId, string cbm_reference_number, string status, string fromDate, string toDate, string userid, string searchingColumns)
        {
            StringBuilder tsql = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            string[] SearchColum = searchingColumns.Split(",");
            if (status != null && status != "ALL")
            {
                string[] Status = status.Split(",");
                for (int i = 0; i < Status.Length; i++)
                {
                    sb.Append("'" + Status[i] + "'");
                    if (i < Status.Length - 1)
                    {
                        sb.Append(",");
                    }
                }
            }
            else
            {
                sb.Append("");
            }
            string whereCondition = string.Empty;
            List<string> conditions = new List<string>();
            // if seq no filter
            if (!String.IsNullOrEmpty(TemplatedId))
                conditions.Add(" " + SearchColum[0] + " LIKE N'%" + TemplatedId + "%' ");
            if (!String.IsNullOrEmpty(cbm_reference_number))
                conditions.Add(" " + SearchColum[1] + " LIKE N'%" + cbm_reference_number + "%' ");
            if (!String.IsNullOrEmpty(sb.ToString()))
                conditions.Add(" " + SearchColum[2] + " in  " + "(" + sb + ")"+" ");
            if (!String.IsNullOrEmpty(fromDate) && !String.IsNullOrEmpty(toDate))
                conditions.Add("date_format(" + SearchColum[3] + ",'%Y%m%d') between date_format('" + fromDate + "','%Y%m%d') and date_format('" + toDate + "','%Y%m%d')");
            if (!String.IsNullOrEmpty(userid))
                conditions.Add(" " + SearchColum[4] + " LIKE N'%" + userid + "%' ");
            if (conditions.Count > 0)
            {
                whereCondition = " Where " + string.Join(" AND ", conditions); // seqno == 'adsfs' and id == 'asdfs';
            }
            tsql.Append(" SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; ");
            tsql.AppendFormat(" SET @PageNumber = {0}; ", currentPage);
            tsql.AppendFormat(" SET @RowspPage = {0}; ", rowPerPage);
            tsql.Append(" SET @TotalRecordCount = 0; ");

            tsql.AppendFormat(" SELECT COUNT({0}) INTO @TotalRecordCount ", field);
            tsql.AppendFormat(" FROM {0} {1};", table, whereCondition); //  where status ='' and msgseqno = ''

            tsql.Append("    SELECT *, UpdatedDate AS lastSavedDate ,@TotalRecordCount as TotalRecordCount FROM(SELECT *, ROW_NUMBER() OVER(ORDER BY UpdatedDate DESC) AS NUMBER ");
            tsql.AppendFormat(" FROM {0} {1} ", table, whereCondition);
            tsql.Append(" )  AS TABLE1   WHERE NUMBER BETWEEN((@PageNumber - 1) * @RowspPage + 1) ");
            tsql.Append(" AND(@PageNumber * @RowspPage)  ORDER BY report_date DESC; ");
            tsql.Append(" SET SESSION TRANSACTION ISOLATION LEVEL REPEATABLE READ; ");
            return tsql.ToString();
        }
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        object value = dr[column.ColumnName];
                        if (value == DBNull.Value)
                            value = null;
                        pro.SetValue(obj, value, null);
                    }
                    else
                        continue;
                }
            }
            return obj;
        }

        #region DataTable Save
        public ResultStatus CopyTo(DataTable dataTable, string tableName, string connectionString)
        {
            ResultStatus resultStatus = new ResultStatus();
            if ((dataTable == null) || (dataTable.Rows.Count == 0)) return resultStatus;

            if (string.IsNullOrEmpty(tableName))
                tableName = dataTable.TableName;

            if (string.IsNullOrEmpty(tableName)) return resultStatus;
            if (string.IsNullOrEmpty(connectionString)) connectionString = SqlClientUtility.MainConnectionString;

            int recordCount = dataTable.Rows.Count;

            bool retry = false;
            int errorRepeatCount = 0;
            do
            {
                retry = false;
                //SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    //connection.Open();

                    //using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            //resultStatus = this.CopyTo(dataTable, tableName, connection, transaction);
                            if (DatabaseType == DatabaseType.MSSQL)
                                resultStatus = this.CopyTo(connectionString, dataTable, tableName);
                            else
                                resultStatus = this.CopyToDb(connectionString, dataTable, tableName);

                            if (!resultStatus.Status)
                            {
                                //LOG.Error(resultStatus.Error);
                                //LOG.Error("Transaction will retry after 5 Sec");
                                System.Threading.Thread.Sleep(5000);
                                retry = true;
                                throw new Exception("error occured");// resultStatus.Message;
                            }
                            else
                            {
                                //transaction.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            retry = true;

                            //if (connection.State == ConnectionState.Open)
                            //    transaction.Rollback();
                            resultStatus.Status = false;
                            resultStatus.Message = ex.Message;

                            errorRepeatCount++;
                            if (errorRepeatCount % 10 == 0)
                            {
                                //LOG.SendMail(ex.Message);
                            }
                        }
                    }
                }
                finally
                {
                    //if (connection.State == ConnectionState.Open) connection.Close();
                }
               

            } while (retry);

            return resultStatus;
        }
        /// <summary>
        /// For MS SQL Server
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dataTable"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public ResultStatus CopyTo(string connectionString, DataTable dataTable, string tableName)
        {
            ResultStatus resultStatus = new ResultStatus();
            if ((dataTable == null) || (dataTable.Rows.Count == 0)) return resultStatus;

            if (string.IsNullOrEmpty(tableName))
                tableName = dataTable.TableName;

            if (string.IsNullOrEmpty(tableName)) return resultStatus;

            int recordCount = dataTable.Rows.Count;

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.UseInternalTransaction))
            {
                bulkCopy.DestinationTableName = tableName;
                bulkCopy.BatchSize = 0;// 500;
                bulkCopy.BulkCopyTimeout = 600;
                bulkCopy.NotifyAfter = 0;// 1000;

                try
                {
                    bulkCopy.WriteToServer(dataTable);
                    //resultStatus.RecordAffected = bulkCopy.RowsCopiedCount();
                    //if (recordCount != resultStatus.RecordAffected)
                    //{
                    //    throw new Exception("Record Count does not match.");
                    //}
                }
                catch (Exception exp)
                {
                    resultStatus.Status = false;
                    resultStatus.Message = exp.Message;
                }
            }

            return resultStatus;
        }

        /// <summary>
        /// For MySql Server
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dataTable"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public ResultStatus CopyToDb(string connectionString, DataTable dataTable, string tableName)
        {
            ResultStatus resultStatus = new ResultStatus();
            if ((dataTable == null) || (dataTable.Rows.Count == 0)) return resultStatus;

            if (string.IsNullOrEmpty(tableName))
                tableName = dataTable.TableName;

            if (string.IsNullOrEmpty(tableName)) return resultStatus;

            int recordCount = dataTable.Rows.Count;
            DbConnection connection = CreateDbConnection();
            connection.ConnectionString = connectionString;
            try
            {
                List<string> columnNames = new List<string>();
                List<string> valueNames = new List<string>();
                foreach (DataColumn c in dataTable.Columns)
                {
                    if (c.AutoIncrement) continue; // do not want to add auto nb column.
                    columnNames.Add("`" + c.ColumnName + "`");
                    valueNames.Add(string.Format("@{0}", c.ColumnName));
                }
                string columns = string.Join(",", columnNames);
                string values = string.Join(",", valueNames);

                String sqlCommandInsert = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", tableName, columns, values);


                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sqlCommandInsert;
                    cmd.CommandTimeout = 0;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        cmd.Parameters.Clear();
                        foreach (DataColumn col in dataTable.Columns)
                            cmd.ParametersAddWithValue("@" + col.ColumnName, row[col]);
                        int inserted = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exp)
            {
                resultStatus.Status = false;
                resultStatus.Message = exp.Message;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return resultStatus;
        }

        public ResultStatus CopyTo(DataTable dataTable, string tableName, SqlConnection connection, SqlTransaction transaction)
        {
            ResultStatus resultStatus = new ResultStatus();
            if ((dataTable == null) || (dataTable.Rows.Count == 0)) return resultStatus;

            if (string.IsNullOrEmpty(tableName))
                tableName = dataTable.TableName;

            if (string.IsNullOrEmpty(tableName)) return resultStatus;
            if ((connection == null) || (connection.State == ConnectionState.Closed)) return resultStatus;

            int recordCount = dataTable.Rows.Count;

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock, transaction))
            {
                bulkCopy.DestinationTableName = tableName;
                bulkCopy.BatchSize = 0;// 500;
                bulkCopy.BulkCopyTimeout = 0; //600;
                bulkCopy.NotifyAfter = 0;// 1000;

                try
                {
                    bulkCopy.WriteToServer(dataTable);
                    //resultStatus.RecordAffected = bulkCopy.RowsCopiedCount();
                    //if (recordCount != resultStatus.RecordAffected)
                    //{
                    //    throw new Exception("Record Count does not match.");
                    //}
                }
                catch (Exception exp)
                {
                    resultStatus.Status = false;
                    resultStatus.Message = exp.Message;
                }
            }

            return resultStatus;
        }

        public ResultStatus CopyTo(DataTable dataTable, string tableName, DbConnection connection, DbTransaction transaction)
        {
            ResultStatus resultStatus = new ResultStatus();
            if ((dataTable == null) || (dataTable.Rows.Count == 0)) return resultStatus;

            if (string.IsNullOrEmpty(tableName))
                tableName = dataTable.TableName;

            if (string.IsNullOrEmpty(tableName)) return resultStatus;
            if ((connection == null) || (connection.State == ConnectionState.Closed)) return resultStatus;

            int recordCount = dataTable.Rows.Count;
            try
            {
                List<string> columnNames = new List<string>();
                List<string> valueNames = new List<string>();
                foreach (DataColumn c in dataTable.Columns)
                {
                    columnNames.Add(c.ColumnName);
                    valueNames.Add(string.Format("@{0}", c.ColumnName));
                }
                string columns = string.Join(",", columnNames);
                string values = string.Join(",", valueNames);

                String sqlCommandInsert = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", tableName, columns, values);

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sqlCommandInsert;
                    cmd.Transaction = transaction;
                    cmd.CommandTimeout = 0;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        cmd.Parameters.Clear();
                        foreach (DataColumn col in dataTable.Columns)
                            cmd.ParametersAddWithValue("@" + col.ColumnName, row[col]);
                        int inserted = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exp)
            {
                resultStatus.Status = false;
                resultStatus.Message = exp.Message;
            }

            return resultStatus;
        }
        #endregion
    }
    internal static class DbCommandExtensions
    {
        internal static int ParametersAddWithValue<T>(this IDbCommand cmd,
            string name, T value)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            return cmd.Parameters.Add(p);
        }

        internal static int ParametersAddWithValue<T>(this IDbCommand cmd,
            string name, Nullable<T> value) where T : struct
        {
            var p = cmd.CreateParameter();
            p.ParameterName = name;
            p.Value = value.HasValue ? (object)value : DBNull.Value;
            return cmd.Parameters.Add(p);
        }

        internal static int ParametersAddWithValue(this IDbCommand cmd,
            string name, string value)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = name;
            p.Value = string.IsNullOrEmpty(value) ? DBNull.Value : (object)value;
            return cmd.Parameters.Add(p);
        }

        internal static IDbDataParameter AddOutputParameter(this IDbCommand cmd,
            string name, DbType dbType)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = name;
            p.DbType = dbType;
            p.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p);
            return p;
        }

     
    }

    public enum DatabaseType
    {
        MSSQL,
        MYSQL
    }
}
