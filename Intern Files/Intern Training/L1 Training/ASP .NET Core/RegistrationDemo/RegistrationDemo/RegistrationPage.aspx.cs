using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace RegistrationDemo
{
    public partial class RegistrationPage : System.Web.UI.Page
    {
        string connStr = "Server=127.0.0.1;Port=3306;Database=EmployeeDB;User=root;Password=root";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSubmit.Text = "Register";
                LoadEmployees();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd;

                    if (!string.IsNullOrEmpty(hfEmployeeId.Value))
                    {
                        // Update existing employee
                        string updateQuery = @"UPDATE Employees SET Name=@Name, Age=@Age, DateOfJoining=@DOJ,
                                           Department=@Dept, Email=@Email, Phone=@Phone WHERE Id=@Id";
                        cmd = new MySqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@Id", hfEmployeeId.Value);
                    }
                    else
                    {
                        // Insert new employee
                        string insertQuery = @"INSERT INTO Employees (Name, Age, DateOfJoining, Department, Email, Phone)
                                           VALUES (@Name, @Age, @DOJ, @Dept, @Email, @Phone)";
                        cmd = new MySqlCommand(insertQuery, conn);
                    }

                    cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(txtAge.Text));
                    cmd.Parameters.AddWithValue("@DOJ", Convert.ToDateTime(txtDOJ.Text));
                    cmd.Parameters.AddWithValue("@Dept", ddlDept.SelectedValue);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());

                    try
                    {
                        cmd.ExecuteNonQuery();
                        lblMessage.Text = string.IsNullOrEmpty(hfEmployeeId.Value) ? "Employee registered successfully!" : "Employee updated successfully!";
                        lblMessage.ForeColor = System.Drawing.Color.LightGreen;
                        ClearForm();
                        btnSubmit.Text = "Register";
                        LoadEmployees();
        
                    }
                catch (Exception ex)
                    {
                        lblMessage.Text = "Error: " + ex.Message;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }

            protected void rptEmployees_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
            {
                int id = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "Edit")
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string query = "SELECT * FROM Employees WHERE Id=@Id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Id", id);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            hfEmployeeId.Value = reader["Id"].ToString();
                            txtName.Text = reader["Name"].ToString();
                            txtAge.Text = reader["Age"].ToString();
                            txtDOJ.Text = Convert.ToDateTime(reader["DateOfJoining"]).ToString("yyyy-MM-dd");
                            string dept = reader["Department"].ToString().Trim();
                            ListItem item = ddlDept.Items.FindByValue(dept);
                            if (item != null)
                            {
                                ddlDept.ClearSelection();
                                item.Selected = true;
                            }
                            txtEmail.Text = reader["Email"].ToString();
                            txtPhone.Text = reader["Phone"].ToString();

                            btnSubmit.Text = "Update";
                        }
                    }
                }
                else if (e.CommandName == "Delete")
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string query = "DELETE FROM Employees WHERE Id=@Id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }

                    lblMessage.Text = "Employee deleted successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.OrangeRed;
                    LoadEmployees();
                }
            }

            private void LoadEmployees()
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT * FROM Employees ORDER BY Id DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    rptEmployees.DataSource = dt;
                    rptEmployees.DataBind();
                }
            }

            private void ClearForm()
            {
                hfEmployeeId.Value = "";
                txtName.Text = "";
                txtAge.Text = "";
                txtDOJ.Text = "";
                ddlDept.SelectedIndex = 0;
                txtEmail.Text = "";
                txtPhone.Text = "";
            }
    }
}