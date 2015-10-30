using System;
using System.Windows.Forms;

namespace FurnitureRentalStore.View
{
    public partial class EmployeeOptionsForm : Form
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeOptionsForm"/> class.
        /// </summary>
        /// <param name="employeeFirstName">First name of the employee.</param>
        /// <param name="employeeLastName">Last name of the employee.</param>
        public EmployeeOptionsForm(string employeeFirstName, string employeeLastName)
        {
            this.InitializeComponent();

            this.welcomeLabel.Text = "Welcome: " + employeeFirstName + " " + employeeLastName;
        }

        /// <summary>
        /// Handles the Click event of the registerCustomerButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void registerCustomerButton_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();

            registrationForm.Show();

            Hide();
        }
    }
}
