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
            var employees = this.employeeController.GetEmployeeForLogIn(this.usernameTextBox.Text, this.passwordTextBox.Text);

            foreach (var employee in employees)
            {

                if (employee.Username == this.usernameTextBox.Text && employee.Password == this.passwordTextBox.Text)
                {
                    EmployeeOptionsForm form = new EmployeeOptionsForm(employee.FirstName, employee.LastName, employee.IsAdmin);

                    Hide();
                    form.Closed += (s, args) => Close();
                    form.Show();
                }
            
            }

        }
    }
}
