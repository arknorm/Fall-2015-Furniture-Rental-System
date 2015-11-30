using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FurnitureRentalStore.Controller;
using FurnitureRentalStore.Model;

namespace FurnitureRentalStore.View
{
    public partial class MemberSearchForm : Form
    {
        private readonly MemberController controller;
        private Member member;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberSearchForm"/> class.
        /// </summary>
        public MemberSearchForm()
        {
            this.InitializeComponent();
            this.controller = new MemberController();
        }

        /// <summary>
        /// Handles the Click event of the searchButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            if (this.IsValidPhone(this.phoneTextBox.Text))
            {
                this.member = this.controller.GetByPhone(this.phoneTextBox.Text);
            }
            else
            {
                this.member = this.controller.GetByName(this.nameTextBox.Text);
            }

            this.nameLabel.Text = this.member.FirstName + " " + member.LastName;
            this.emailLabel.Text = this.member.Email;
            this.phoneLabel.Text = this.member.Phone;
            this.addressLabel.Text = this.member.Address1 + " " + member.Address2 + "\r\n" + member.City + ", " + member.State + "\r\n" + member.Zip;
            this.memberIDLabel.Text = this.member.MemberId.ToString();
            foreach (var label in this.Controls)
            {
                Label lb = label as Label;
                if (lb != null)
                {
                    lb.Visible = true;
                }
            }

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

        /// <summary>
        /// Handles the TextChanged event of the nameTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            this.searchButton.Enabled = !string.IsNullOrEmpty(this.nameTextBox.Text);
        }

        /// <summary>
        /// Handles the TextChanged event of the phoneTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            this.searchButton.Enabled = this.IsValidPhone(this.phoneTextBox.Text);
        }
    }
}
