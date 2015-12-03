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
    public partial class ReturnForm : Form
    {

        private RentalController rentalController;
        private ItemController itemController;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnForm"/> class.
        /// </summary>
        public ReturnForm()
        {
            this.InitializeComponent();
            this.rentalController = new RentalController();
            this.itemController = new ItemController();
        }

        /// <summary>
        /// Handles the Click event of the searchButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            var memberID = Convert.ToInt32(this.memberIDTextBox.Text);
            var rentalTransactionId = -1;
            var itemID = -1;

            var transactions = this.rentalController.GetAll();
            var rentals = this.rentalController.GetAllRentals();
            var items = this.itemController.GetAllItems();

            var memberTransactions = new List<RentalTransaction>();
            var memberRentals = new List<Rental>();
            var memberItems = new List<Item>();

            foreach (var transaction in transactions)
            {
                if (memberID == transaction.MemberId)
                {
                    memberTransactions.Add(transaction);
                }
            }

            if (memberTransactions.Count > 0)
            {
                rentalTransactionId = memberTransactions[0].RentalTransactionId;
            }

            foreach (var rental in rentals)
            {
                foreach (var transaction in transactions)
                {
                   
                }
                if (rentalTransactionId != -1)
                {
                    if (rental.RentalTransactionId == rentalTransactionId)
                    {
                        memberRentals.Add(rental);
                    }
                }
            }

            foreach (var item in items)
            {
               if (item.ItemID == )
            }


        }
    }
}
