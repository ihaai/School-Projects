using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SQLTask
{
    public class QueryManager
    {
        const string CONNECTION_STRING = @"CONNECTION_STRING_HERE";

        const string CREATE_TABLE_QUERY = "CREATE TABLE Exam_Container(" +
            "FileID INTEGER PRIMARY KEY IDENTITY(1, 1) NOT NULL," +
            "Specialty NVARCHAR(128) NOT NULL," +
            "Variant INTEGER NOT NULL," +
            "FileLocation VARCHAR(256) NOT NULL," +
            ")";

        const string INSERT_INTO_QUERY = "INSERT INTO Exam_Container (Specialty, Variant, FileLocation) VALUES (@S, @V, @F)";

        static SqlConnection SQLConnection = new SqlConnection(CONNECTION_STRING);
        static SqlCommand SQLCommand;
        static SqlDataReader SQLReader;

        public static void SetupDB()
        {
            SQLConnection.Open();

            SQLCommand = new SqlCommand(CREATE_TABLE_QUERY, SQLConnection);

            try
            {
                SQLCommand.ExecuteNonQuery();
            }
            catch (SqlException) { }

            SQLConnection.Close();
        }

        public static List<RuntimeData> GetRuntimeData()
        {
            List<RuntimeData> _ = new List<RuntimeData>();

            foreach (string outerData in ReadDataAsString("SELECT * FROM Exam_Container").Split(new[] { '\n' }))
            {
                if (String.IsNullOrEmpty(outerData))
                    continue;

                string[] innerData = outerData.Split(new[] { '|' });

                _.Add(new RuntimeData()
                {
                    ID = int.Parse(innerData[0]),
                    Specialty = innerData[1],
                    Variant = int.Parse(innerData[2]),
                    FileLocation = innerData[3]
                });
            }

            return _;
        }

        public static void InsertData(params object[] data)
        {
            SQLConnection.Open();

            SQLCommand = new SqlCommand(INSERT_INTO_QUERY, SQLConnection);
            SQLCommand.Parameters.AddWithValue("@S", data[0]);
            SQLCommand.Parameters.AddWithValue("@V", data[1]);
            SQLCommand.Parameters.AddWithValue("@F", data[2]);
            SQLCommand.ExecuteNonQuery();

            SQLConnection.Close();
        }

        public static string ReadDataAsString(string query)
        {
            StringBuilder dataBuilder = new StringBuilder();

            SQLConnection.Open();
            SQLCommand = new SqlCommand(query, SQLConnection);

            using (SQLReader = SQLCommand.ExecuteReader())
            {
                while (SQLReader.Read())
                {
                    for (int column = 0; column < SQLReader.FieldCount; column++)
                    {
                        dataBuilder.Append(SQLReader.GetValue(column) + "|");
                    }

                    dataBuilder.Append('\n');
                }
            }

            SQLConnection.Close();

            return dataBuilder.ToString();
        }

        public static void DropTable()
        {
            SQLConnection.Open();
            SQLCommand = new SqlCommand("DROP TABLE Exam_Container", SQLConnection);
            SQLCommand.ExecuteNonQuery();
            MessageBox.Show("Table dropped");
            SQLConnection.Close();
        }

        public static void StopConnection()
        {
            SQLConnection.Close();
        }
    }
}
