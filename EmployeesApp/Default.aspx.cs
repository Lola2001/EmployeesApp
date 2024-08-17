using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeesApp
{
    public partial class Default : Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                EmployeeService employeeService = new EmployeeService();

                List<Employee> employees = await employeeService.GetEmployeeDataAsync();
                List<Employee> orderedEmployees = employees.OrderByDescending(emp => emp.TotalHoursWorked).ToList();
               
                EmployeeGridView.DataSource = orderedEmployees;
                EmployeeGridView.DataBind();

               
            }
        }

        protected void EmployeeGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var employee = (Employee)e.Row.DataItem;
                if (employee.TotalHoursWorked < 100)
                {
                    e.Row.CssClass = "highlight";
                }
            }
        }
    }
}
