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
    public partial class EmployeeUpdateForm : Form
    {

        private readonly EmployeeController employeeController;

        private int employeeID;

        public EmployeeUpdateForm(Employee anEmployee)
        {
            InitializeComponent();

            employeeController = new EmployeeController();

            this.firstNameTextBox.Text = anEmployee.FirstName;
            this.lastNameTextBox.Text = anEmployee.LastName;
            this.adminCheckBox.Checked = anEmployee.IsAdmin;
            this.usernameTextBox.Text = anEmployee.Username;
            this.passwordTextBox.Text = anEmployee.Password;
            this.emailTextBox.Text = anEmployee.Email;

            this.employeeID = anEmployee.EmployeeId;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {


            var updatedEmployee = new Employee()
            {
                EmployeeId = this.employeeID,
                FirstName = this.firstNameTextBox.Text,
                LastName = this.lastNameTextBox.Text,
                IsAdmin = this.adminCheckBox.Checked,
                Username = this.usernameTextBox.Text,
                Password = this.passwordTextBox.Text,
                Email = this.emailTextBox.Text
            };

            this.employeeController.UpdateEmployee(updatedEmployee);

            new ManageEmployeesForm().Show();

            Dispose();
        }
    }
}
