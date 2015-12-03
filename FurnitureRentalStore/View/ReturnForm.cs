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

        private readonly RentalController rentalController;
        private readonly ItemController itemController;
        private readonly ReturnController returnController;
        private List<Rental> memberRentals;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnForm"/> class.
        /// </summary>
        public ReturnForm()
        {
            this.InitializeComponent();
            this.rentalController = new RentalController();
            this.itemController = new ItemController();
            this.returnController = new ReturnController();
            this.memberRentals= new List<Rental>();
        }

        /// <summary>
        /// Handles the Click event of the searchButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            var memberID = Convert.ToInt32(this.memberIDTextBox.Text);

            var transactions = this.rentalController.GetAll();
            var rentals = this.rentalController.GetAllRentals();
            var items = this.itemController.GetAllItems();

            var memberTransactions = new List<RentalTransaction>();
            this.memberRentals = new List<Rental>();
            var memberItems = new List<Item>();

            foreach (var transaction in transactions)
            {
                if (memberID == transaction.MemberId)
                {
                    memberTransactions.Add(transaction);
                }
            }

            foreach (var rental in rentals)
            {
                foreach (var transaction in memberTransactions)
                {
                    if (rental.RentalTransactionId == transaction.RentalTransactionId)
                    {
                        memberRentals.Add(rental);
                    }
                }
            }

            foreach (var item in items)
            {
                foreach (var rental in memberRentals)
                {
                    if (rental.ItemId == item.ItemID)
                    {
                        memberItems.Add(item);
                    }
                }
            }

            foreach (var item in memberItems)
            {
                this.itemBindingSource.Add(item);
            }

        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            var returnTransaction = new ReturnTransaction()
            {
                EmployeeId = LogInForm.LoggedInEmployee.EmployeeId,
                ReturnDate = DateTime.Now,
                TotalPrice = 0
            };

            this.returnController.Add(returnTransaction);

            foreach (DataGridViewRow row in this.returnDataGridView.SelectedRows)
            {

                var itemId = Convert.ToInt32(row.Cells[0].Value);
                var rentalTransactionID = 0;

                foreach (var rental in this.memberRentals)
                {
                    if (rental.ItemId == itemId)
                    {
                        rentalTransactionID = rental.RentalTransactionId;
                    }
                }

                Return newReturn = new Return()
                {
                    ReturnTransactionId = this.returnController.GetLastInsertedID(),
                    RentalTransactionId = rentalTransactionID,
                    ItemId = itemId,
                    FineTotal = 0,
                    QuantityReturned = Convert.ToInt32(row.Cells[6].Value)
                };
                this.returnController.Return(newReturn);
            }
        }
    }
}
