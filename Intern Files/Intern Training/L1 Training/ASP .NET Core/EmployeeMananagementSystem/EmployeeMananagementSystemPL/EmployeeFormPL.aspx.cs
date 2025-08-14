using System;
using EmployeeManagementSystemMD.Models;
using EmployeeManagementSystemMD.BAL;

namespace EmployeeMananagementSystemPL
{
    public partial class EmployeeFormPL : System.Web.UI.Page
    {
        EmployeeBAL employeeBAL = new EmployeeBAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindGrid();
        }

        private void BindGrid()
        {
            grdEmployeeData.DataSource = employeeBAL.GetAllEmployees();
            grdEmployeeData.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee
            {
                EmployeeName = txtName.Text,
                Department = txtDept.Text,
                Email = txtEmail.Text,
                HireDate = DateTime.Parse(txtHireDate.Text)
            };
            employeeBAL.InsertEmployee(emp);
            BindGrid();
        }

        protected void grdEmployeeData_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            grdEmployeeData.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void grdEmployeeData_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(grdEmployeeData.DataKeys[e.RowIndex].Value);
            var row = grdEmployeeData.Rows[e.RowIndex];
            Employee emp = new Employee
            {
                EmployeeId = id,
                EmployeeName = ((System.Web.UI.WebControls.TextBox)row.Cells[1].Controls[0]).Text,
                Department = ((System.Web.UI.WebControls.TextBox)row.Cells[2].Controls[0]).Text,
                Email = ((System.Web.UI.WebControls.TextBox)row.Cells[3].Controls[0]).Text,
                HireDate = DateTime.Parse(((System.Web.UI.WebControls.TextBox)row.Cells[4].Controls[0]).Text)
            };
            employeeBAL.UpdateEmployee(emp);
            grdEmployeeData.EditIndex = -1;
            BindGrid();
        }

        protected void grdEmployeeData_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            grdEmployeeData.EditIndex = -1;
            BindGrid();
        }

        protected void grdEmployeeData_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grdEmployeeData.DataKeys[e.RowIndex].Value);
            employeeBAL.DeleteEmployee(id);
            BindGrid();
        }
    }
}
