using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StroitelstvoYaroMol.ClassFolder
{
    class DGClass
    {
        SqlConnection sqlConnection =
          new SqlConnection(@"Data Source=10.128.14.64\SQLEXPRESS;
                                Persist Security Info=True;
                                User ID=user82;
                                Password=wsruser82");
        SqlDataAdapter sqlDataAdapter;
        DataGrid dataGrid;
        DataTable dataTable;

        public DGClass(DataGrid dataGrid)
        {
            this.dataGrid = dataGrid;
        }

        public void LoadDG(string sqlComand)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter =
                    new SqlDataAdapter(sqlComand, sqlConnection);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
