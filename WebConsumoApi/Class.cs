using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace ExcelReadData
{
    public class Service : IDisposable
    {
        #region **Private Variables**

        private TestDatabaseEntities _dbContext;

        #region **Constructor**

        public ImportExceltoDatabase()
        {
            _dbContext = new TestDatabaseEntities();
        }
        #endregion

        public bool ImportExceltoDatabase(string strFilePath, string connString)
        {
            bool result = false;
            OleDbConnection oledbConn = new OleDbConnection(connString);
            DataTable dt = new DataTable();
            try
            {
                oledbConn.Open();
                using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn))
                {
                    OleDbDataAdapter oleda = new OleDbDataAdapter();
                    oleda.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    oleda.Fill(ds);

                    dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        table tblObj = new table();
                        foreach (DataRow row in dt.Rows)
                        {
                            tblObj.Name = row["Name"].ToString();
                            tblObj.Name = row["Address"].ToString();
                            tblObj.Salary = (int)row["Salary"];
                            tblObj.Age = (int)row["Age"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            finally
            {
                oledbConn.Close();
            }
            return result;
        }
    }
}
