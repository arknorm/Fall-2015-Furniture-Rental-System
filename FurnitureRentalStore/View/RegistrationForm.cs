using System;
using System.Windows.Forms;
using FurnitureRentalStore.Controller;
using FurnitureRentalStore.Model;

namespace FurnitureRentalStore.View
{
    public partial class RegistrationForm : Form
    {
        private MemberController memberController;

        public RegistrationForm()
        {
            this.InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.memberController = new MemberController();

            var newMember = new Member()
            {
                FirstName = this.txtFirstName.Text,
                LastName = this.txtLastName.Text,
                Email = this.txtEmail.Text,
                Phone = this.txtPhone.Text,
                Address1 = this.txtAddress1.Text,
                Address2 = this.txtAddress2.Text,
                City = this.txtCity.Text,
                State = this.txtState.Text,
                Zip = this.txtZip.Text,
                Ssn = this.txtSSN.Text,
            };

            this.memberController.Add(newMember);

            Hide();

        }
    }
}
