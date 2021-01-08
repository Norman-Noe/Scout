using Microsoft.Office.Interop.Access.Dao;
using Scout.UI.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

using System.IO;
using System.Linq;
using System.Text;

namespace Scout.UI.Helpers
{
    /* CRUD
     * TODO: Implement (Read)GetSample method
     * TODO: Implement UpDateSample method
     * TODO: Implement DeleteSample method
     */

    public class Helper_DB
    {



        #region ---- CRUD ----

        /// <summary>
        /// Add a row into a table
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <param name="TableName"></param>
        /// <param name="KeyValuePairs">Keys should be the column names, values are the column values</param>
        public static void AddRowToTable(string ConnectionString, string TableName, Dictionary<string, object> KeyValuePairs)
        {
            string columnNames = string.Empty, paramNames = string.Empty;
            string dbFilePath = string.Empty, documentFilePath = string.Empty, columnName = string.Empty;
            bool containsFile = false;
            int rowNumber;

            // create the strings necessary for the sql command
            foreach (string key in KeyValuePairs.Keys)
            {
                // ignore any file paths or attachments
                if (KeyValuePairs[key].GetType() == typeof(string) && File.Exists(KeyValuePairs[key].ToString()))
                {
                    containsFile = true;
                    documentFilePath = (string)KeyValuePairs[key];
                    columnName = key;
                }
                else
                {
                    columnNames += Helper_DB.CheckColumName(key);
                    paramNames += "@" + key;

                    if (key != KeyValuePairs.Keys.Last())
                    {
                        columnNames += ",";
                        paramNames += ",";
                    }
                }
            }

            string strSQL = "INSERT INTO " + TableName + "(" + columnNames + ") VALUES (" + paramNames + ")";

            // create a connection to DB
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                if (containsFile) dbFilePath = conn.DataSource;                                 // extract the db file path from connection string

                // create a command, and set it's connection
                OleDbCommand cmd = new OleDbCommand(strSQL, conn);

                try
                {
                    // open connection
                    conn.Open();

                    foreach (string key in KeyValuePairs.Keys)
                    {
                        // ignore any file paths or attachements
                        if (KeyValuePairs[key].GetType() == typeof(string) && File.Exists(KeyValuePairs[key].ToString()))
                        {
                            //byte[] fileBytes = File.ReadAllBytes((string)KeyValuePairs[key]);
                            //OleDbParameter paramData = new OleDbParameter("FileData", OleDbType.Binary, fileBytes.Length);
                            //paramData.Value = fileBytes;
                            //cmd.Parameters.Add(paramData);
                        }
                        else cmd.Parameters.AddWithValue(key, KeyValuePairs[key]);
                    }

                    try
                    {
                        Console.WriteLine("----Adding Data----");
                        cmd.ExecuteNonQuery();

                        rowNumber = GetNumberOfRows(conn, TableName);

                        Console.WriteLine("\tData added");
                    }
                    catch (OleDbException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection Failed");
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            if (containsFile && File.Exists(dbFilePath))
            {
                // add file to db
                AddDocumentToTable(dbFilePath, TableName, columnName, documentFilePath, rowNumber);
            }

            Console.WriteLine("----Done Adding Row To Table----");
        }


        #endregion


        #region ---- PRIVATE METHODS ----

        /// <summary>
        /// Check if the column name is in square brackets
        /// If a column name has a space in it (ex. GLASS SAMPLES), then is must be 
        /// encapsulated with square brackets (ex. [GLASS SAMPLES]
        /// </summary>
        /// <param name="ColumName"></param>
        /// <returns>SQL Safe string</returns>
        private static string CheckColumName(string ColumnName)
        {
            if (ColumnName.StartsWith("[") && ColumnName.EndsWith("]")) return ColumnName;
            else return string.Format("[{0}]", ColumnName);
        }


        /// <summary>
        /// Get the number of rows in a table
        /// </summary>
        /// <param name="Connection"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        private static int GetNumberOfRows(OleDbConnection Connection, string TableName)
        {
            string dataReader = "SELECT count(*) from " + TableName;
            OleDbCommand reader = new OleDbCommand(dataReader, Connection);
            var rowNumber = reader.ExecuteScalar();
            return (int)rowNumber;
        }


        /// <summary>
        /// Add a single file to a table
        /// </summary>
        /// <param name="DBFilePath">Full file path of the DB</param>
        /// <param name="TableName">Table Name</param>
        /// <param name="ColumnName">Column name where the attachemnt will be attached</param>
        /// <param name="DocumentFilePath">List containing the FULL file path of the documents</param>
        /// <param name="RowIndex">Index of the row where the document should be insterted</param>
        private static void AddDocumentToTable(string DBFilePath, string TableName, string ColumnName, string DocumentFilePath, int RowIndex)
        {
            var dbe = new DBEngine();
            Database db = dbe.OpenDatabase(DBFilePath, ReadOnly: false);

            // first record set is the table
            //Recordset rs = db.OpenRecordset("SELECT * FROM " + TableName); // , RecordsetTypeEnum.dbOpenDynamic, 0, LockTypeEnum.dbOptimistic);
            Recordset rs = db.OpenRecordset(string.Format("SELECT {0} FROM {1} WHERE ID={2}", ColumnName, TableName, RowIndex));
            rs.MoveFirst();                                                                 // go to first entry
            rs.Edit();                                                                      // set to edit entry

            // second record set is the actual field / cell in the table
            Recordset2 rs2 = (Recordset2)rs.Fields[ColumnName].Value;

            Console.WriteLine("----Adding Document----");

            rs2.AddNew();
            Field2 f2 = (Field2)rs2.Fields["FileData"];
            f2.LoadFromFile(DocumentFilePath);                                              // add first document
            rs2.Update();                                                                   // Update saves the data

            rs2.Close();
            rs.Update();
            rs.Close();

            Console.WriteLine("----Done Adding Document To Table----");
        }

        #endregion
    }
}
