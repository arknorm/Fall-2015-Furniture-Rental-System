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
using FurnitureRentalStore.View;

namespace FurnitureRentalStore
{
    public partial class LogInForm : Form
    {

        private readonly EmployeeController employeeController;

        public LogInForm()
        {
            InitializeComponent();

            employeeController = new EmployeeController();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {

            var employees = employeeController.GetAllEmployees();

            foreach (var employee in employees)
            {

                if (employee.Username == this.usernameTextBox.Text && employee.Password == this.passwordTextBox.Text)
                {
                    EmployeeOptionsForm form = new EmployeeOptionsForm(employee.FirstName, employee.LastName);

                    form.Show();

                    Hide();

                }
            
            }

        }
    }
}
