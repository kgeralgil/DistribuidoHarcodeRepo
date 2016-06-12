using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using Genesyslab.Desktop.Modules.Windows.Common.DimSize;
using System.ComponentModel;
using System.Windows;
using Genesyslab.Desktop.Infrastructure.DependencyInjection;
using System.IO;

namespace WpfApplication3.AREAS.CLASES_Y_UTILIDADES
{
    class SqlHelper_2
    {
        private static string connStr = "Data Source=.\\SQLEXPRESS; Initial Catalog=BEFORE_COBRANZA_EDICSEM; Integrated Security=SSPI;";
        public static int ExecuteNonQuery(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        return cmd.ExecuteNonQuery();
                        //Returns the value is insert, delete, update affects the number of lines
                    }
                }
                catch (Exception error)
                {
                    // Extract some information from this exception, and then 
                    // throw it to the parent method.
                    if (error.Source != null)
                        MessageBox.Show(error.ToString());
                    throw;
                }

            }
        }
        public static object ExecuteScalar(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    return cmd.ExecuteScalar();
                }

            }
        }
        //Only used to execute the query results relatively small SQL
        public static DataSet ExecuteDataSet(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dataset = new DataSet();
                        adapter.Fill(dataset);
                        return dataset;
                    }

                }
                catch (Exception error)
                {
                    // Extract some information from this exception, and then 
                    // throw it to the parent method.
                    if (error.Source != null)
                        MessageBox.Show(error.ToString());
                    return null;
                    throw;
                }
            }
        }
        //To prevent SQL injection attacks
        public static DataTable ExecuteDataTable(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.Parameters.AddRange(parameters);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dataset = new DataSet();
                        adapter.Fill(dataset);
                        return dataset.Tables[0];
                    }
                }
                catch (Exception error)
                {
                    // Extract some information from this exception, and then 
                    // throw it to the parent method.
                    if (error.Source != null)
                        MessageBox.Show(error.ToString());
                    return null;
                    throw;
                }

            }
        }
        public static Boolean executeProcedure(string nombreProcedure, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = nombreProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parameters);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                }
                catch (Exception error)
                {
                    // Extract some information from this exception, and then 
                    // throw it to the parent method.
                    if (error.Source != null)
                        MessageBox.Show(error.ToString());
                    return false;
                    throw;
                }

            }

        }
    }
}