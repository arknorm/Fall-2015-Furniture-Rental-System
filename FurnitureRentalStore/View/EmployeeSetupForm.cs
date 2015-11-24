using System;
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
    public partial class EmployeeSetupForm : Form
    {

        private readonly EmployeeController employeeController;

        public EmployeeSetupForm()
        {
            InitializeComponent();

            this.employeeController = new EmployeeController();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            var newEmployee = new Employee()
            {
                FirstName = this.firstNameTextBox.Text,
                LastName = this.lastNameTextBox.Text,
                IsAdmin = this.adminCheckBox.Checked,
                Username = this.usernameTextBox.Text,
                Password = this.passwordTextBox.Text,
                Email = this.emailTextBox.Text
            };

            this.employeeController.Add(newEmployee);

            new ManageEmployeesForm().Show();

            Dispose();
        }
    }
}
