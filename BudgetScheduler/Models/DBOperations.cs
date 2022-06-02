using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetScheduler.Models
{
    internal class DBOperations
    {
        private const string _connectionString = "Data Source=DESKTOP-IIB45SI\\SQLEXPRESS;Initial Catalog=BudgetScheduler;Integrated Security=True";
        
        public static void AddOperation(Operation operation)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            
            SqlCommand command = new SqlCommand("INSERT INTO [Operations] (summ, type, category, commentary,date) VALUES(@summ,@type,@category,@commentary,@date)", conn);
            command.Parameters.AddWithValue("@summ", operation.Summ);
            command.Parameters.AddWithValue("@type", operation.Type);
            command.Parameters.AddWithValue("@category", operation.Category);
            command.Parameters.AddWithValue("@commentary", operation.Commentary);
            command.Parameters.AddWithValue("@date", operation.Date);

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception " + e.ToString());
            }
            finally
            {
                conn.Close();
            }

        }
        public static List<Operation> SelectOperations()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM [Operations]", conn);
            SqlDataReader reader = null;
            List<Operation> operations = new List<Operation>();

            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Operation operation = new Operation()
                    {
                        Summ = (float)reader.GetDouble(1),
                        Type = reader.GetString(2),
                        Category = reader.GetString(3),
                        Commentary = reader.GetString(4),
                        Date = reader.GetDateTime(5)
                    };
                    operations.Add(operation);

                }
            }
            catch(SqlException e)
            {
                Console.WriteLine("Exception " + e.ToString());
            }
            finally
            {
                reader?.Close();
                conn.Close();
            }
            return operations;
        }

        public static List<Operation> SelectOperations(DateTime period)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            
            SqlCommand command = new SqlCommand("SELECT * FROM [Operations] WHERE CONVERT(date,@date) BETWEEN @period AND @date", conn);
            command.Parameters.AddWithValue("date", DateTime.Today);
            command.Parameters.AddWithValue("period",period);

            SqlDataReader reader = null;
            List<Operation> operations = new List<Operation>();

            try
            {
                conn.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Operation operation = new Operation()
                    {
                        id = reader.GetInt32(0),
                        Summ = (float)reader.GetDouble(1),
                        Type = reader.GetString(2),
                        Category = reader.GetString(3),
                        Commentary = reader.GetString(4),
                        Date = reader.GetDateTime(5)
                    };
                    operations.Add(operation);

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Exception " + e.ToString());
            }
            finally
            {
                reader?.Close();
                conn.Close();
            }
            return operations;
        }
    }
}
