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
    class CBClass
    {
        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=10.128.14.64\SQLEXPRESS;
                                Persist Security Info=True;
                                User ID=user22;
                                Password=wsruser22");
        SqlDataAdapter sqlDataAdapter;
        DataSet dataSet;

        public void LoadCBRole(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter("Select IdRole, RoleName " +
                    "From dbo.[Role] Order by IdRole ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "[Role]");
                comboBox.ItemsSource = dataSet
                    .Tables["[Role]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet
                    .Tables["[Role]"].Columns["RoleName"].ToString();
                comboBox.SelectedValuePath = dataSet
                    .Tables["[Role]"].Columns["IdRole"].ToString();
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
        public void LoadCBStatus(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter("Select Id, Name " +
                    "From dbo.[Status] Order by Id ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "[Status]");
                comboBox.ItemsSource = dataSet
                    .Tables["[Status]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet
                    .Tables["[Status]"].Columns["Name"].ToString();
                comboBox.SelectedValuePath = dataSet
                    .Tables["[Status]"].Columns["Id"].ToString();
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
