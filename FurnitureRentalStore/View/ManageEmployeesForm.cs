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
    }
}
