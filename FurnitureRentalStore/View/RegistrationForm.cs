using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FurnitureRentalStore.Controller;
using FurnitureRentalStore.Model;
using FurnitureRentalStore.View.DialogBox;

namespace FurnitureRentalStore.View
{
    public partial class RegistrationForm : Form
    {
        private MemberController memberController;

        #region Private Data Members

        private bool validFirstName;
        private bool validLastName;

        private bool validEmail;
        private bool validSsn;
        private bool validPhone;

        private bool validAddress1;
        private bool validCity;
        private bool validState;
        private bool validZip;

        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationForm"/> class.
        /// </summary>
        public RegistrationForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            String ssn = this.ssnTextBox.Text;

            if (new Regex(@"^\d{3}-\d{2}-\d{4}$").IsMatch(this.ssnTextBox.Text))
            {
                ssn = this.ssnTextBox.Text.Replace("-", "");
            }

            this.memberController = new MemberController();

            var newMember = new Member()
            {
                FirstName = this.firstNameTextBox.Text,
                LastName = this.lastNameTextBox.Text,
                Email = this.emailTextBox.Text,
                Phone = this.phoneTextBox.Text,
                Address1 = this.address1TextBox.Text,
                Address2 = this.address2TextBox.Text,
                City = this.cityTextBox.Text,
                State = this.stateTextBox.Text,
                Zip = this.zipTextBox.Text,
                Ssn = ssn
            };

            this.memberController.Add(newMember);

            var successfulDialog = new SuccessfulRegistrationDialogBox { StartPosition = FormStartPosition.CenterScreen };

            successfulDialog.ShowDialog(this);
            successfulDialog.Dispose();

            Dispose();
        }

        /// <summary>
        /// Determines whether the specified validEmail is valid.
        /// </summary>
        /// <param name="email">The validEmail.</param>
        /// <returns></returns>
        private bool IsValidEmail(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return mail.Address.Contains(".") && mail.Address == email && !mail.Address.EndsWith(".");
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validates the SSN.
        /// </summary>
        /// <param name="ssn">The SSN.</param>
        /// <returns></returns>
        private bool IsValidSsn(String ssn)
        {
            return new Regex(@"^\d{3}\-?\d{2}\-?\d{4}$").IsMatch(ssn);
        }

        /// <summary>
        /// Determines whether the specified phone number is a valid phone number.
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <returns></returns>
        private bool IsValidPhone(String phone)
        {
            Regex regex = new Regex(@"^([0-9][\-]*){10,}$");
            return regex.IsMatch(phone);
        }

        private void EnableRegistration()
        {
            this.btnRegister.Enabled = this.validFirstName && this.validLastName && this.validEmail && this.validSsn &&
                this.validPhone && this.validAddress1 && this.validCity && this.validState && this.validZip;
        }

        /// <summary>
        /// Handles the TextChanged event of the phoneTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            this.validPhone = this.ToggleLabels(this.IsValidPhone(this.phoneTextBox.Text), this.phoneCorrectLabel, this.phoneIncorrectLabel);
        }

        /// <summary>
        /// Handles the TextChanged event of the ssnTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ssnTextBox_TextChanged(object sender, EventArgs e)
        {
            this.validSsn = this.ToggleLabels(this.IsValidSsn(this.ssnTextBox.Text), this.ssnCorrectLabel, this.ssnIncorrectLabel);
        }

        /// <summary>
        /// Handles the TextChanged event of the emailTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            this.validEmail = this.ToggleLabels(this.IsValidEmail(this.emailTextBox.Text), this.emailCorrectLabel, this.emailIncorrectLabel);
        }

        /// <summary>
        /// Handles the TextChanged event of the firstNameTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.validFirstName = this.ToggleLabels(!String.IsNullOrEmpty(this.firstNameTextBox.Text), this.firstNameCorrectLabel, this.firstNameIncorrectLabel);
        }

        /// <summary>
        /// Handles the TextChanged event of the lastNameTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.validLastName = this.ToggleLabels(!String.IsNullOrEmpty(this.lastNameTextBox.Text), this.lastNameCorrectLabel, this.lastNameIncorrectLabel);
        }

        /// <summary>
        /// Handles the TextChanged event of the address1TextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void address1TextBox_TextChanged(object sender, EventArgs e)
        {
            this.validAddress1 = this.ToggleLabels(!String.IsNullOrEmpty(this.address1TextBox.Text), this.address1CorrectLabel, this.address1IncorrectLabel);
        }

        /// <summary>
        /// Handles the TextChanged event of the cityTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cityTextBox_TextChanged(object sender, EventArgs e)
        {
            this.validCity = this.ToggleLabels(!String.IsNullOrEmpty(this.cityTextBox.Text), this.cityCorrectLabel, this.cityIncorrectLabel);
        }

        /// <summary>
        /// Handles the TextChanged event of the stateTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void stateTextBox_TextChanged(object sender, EventArgs e)
        {
            this.validState = this.ToggleLabels(!String.IsNullOrEmpty(this.stateTextBox.Text), this.stateCorrectLabel, this.stateIncorrectLabel);
        }

        /// <summary>
        /// Handles the TextChanged event of the zipTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void zipTextBox_TextChanged(object sender, EventArgs e)
        {
            this.validZip = this.ToggleLabels(!String.IsNullOrEmpty(this.zipTextBox.Text), this.zipCorrectLabel, this.zipIncorrectLabel);
        }

        /// <summary>
        /// Handles the KeyPress event of the zipTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void zipTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /// <summary>
        /// Handles the KeyPress event of the firstNameTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void firstNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        /// <summary>
        /// Handles the KeyPress event of the ssnTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void ssnTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /// <summary>
        /// Toggles the labels.
        /// </summary>
        /// <param name="statement">if set to <c>true</c> [statement].</param>
        /// <param name="correctLabel">The correct label.</param>
        /// <param name="incorrectLabel">The incorrect label.</param>
        private bool ToggleLabels(bool statement, Label correctLabel, Label incorrectLabel)
        {
            this.EnableRegistration();
            if (statement)
            {
                correctLabel.Visible = true;
                incorrectLabel.Visible = false;
                return true;
            }

            incorrectLabel.Visible = true;
            correctLabel.Visible = false;
            return false;
        }

        /// <summary>
        /// Handles the Click event of the btnClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func = null;

            func = controls =>
            {
                foreach (Control control in controls)
                {
                    if (control is TextBox)
                    {
                        (control as TextBox).Clear();
                    }
                    else
                    {
                        func(control.Controls);
                    }
                }
            };

            func(Controls);
        }
    }
}
