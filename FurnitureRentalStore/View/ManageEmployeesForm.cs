using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FurnitureRentalStore.Controller;
using FurnitureRentalStore.Model;

namespace FurnitureRentalStore.View
{
    public partial class ManageEmployeesForm : Form
    {

        private readonly EmployeeController employeeController;

        public ManageEmployeesForm()
        {
            InitializeComponent();

            this.employeeController = new EmployeeController();

            populateDataGridView(this.employeeController.GetAllEmployees());

            this.editEmployeeButton.Enabled = false;
            this.deleteEmployeeButton.Enabled = false;
        }

        private void populateDataGridView(List<Employee> employees)
        {
            this.employeeBindingSource.Clear();

            foreach (var item in employees)
            {
                this.employeeBindingSource.Add(item);
            }
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            new EmployeeSetupForm().Show();

            Dispose();
        }

        private void editEmployeeButton_Click(object sender, EventArgs e)
        {

            DataGridViewRow selectedRow = employeeDataGridView.SelectedRows[0];

            int employeeID = Int32.Parse(selectedRow.Cells["employeeIdDataGridViewTextBoxColumn"].Value.ToString());

            Employee anEmployee = this.employeeController.GetEmployeeByID(employeeID);

            new EmployeeUpdateForm(anEmployee).Show();

            Dispose();


        }

        private void deleteEmployeeButton_Click(object sender, EventArgs e)
        {


            DataGridViewRow selectedRow = employeeDataGridView.SelectedRows[0];

            int employeeID = Int32.Parse(selectedRow.Cells["employeeIdDataGridViewTextBoxColumn"].Value.ToString());

            employeeController.DeleteEmployee(employeeID);

            populateDataGridView(this.employeeController.GetAllEmployees());
        }

        private void employeeDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            this.editEmployeeButton.Enabled = true;
            this.deleteEmployeeButton.Enabled = true;
        }
    }
}
