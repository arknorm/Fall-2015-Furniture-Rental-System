using System;
using System.Windows.Forms;
using FurnitureRentalStore.Controller;

namespace FurnitureRentalStore.View
{
    public partial class LogInForm : Form
    {

        private readonly EmployeeController employeeController;

        public LogInForm()
        {
            this.InitializeComponent();

            this.employeeController = new EmployeeController();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {

            var employees = this.employeeController.GetAllEmployees();

            foreach (var employee in employees)
            {

                if (employee.Username == this.usernameTextBox.Text && employee.Password == this.passwordTextBox.Text)
                {
                    EmployeeOptionsForm form = new EmployeeOptionsForm(employee.FirstName, employee.LastName);

                    this.Hide();
                    form.Closed += (s, args) => this.Close();
                    form.Show();
                }
            
            }

        }
    }
}
