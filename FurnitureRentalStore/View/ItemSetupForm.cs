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
    public partial class ItemSetupForm : Form
    {

        private readonly ItemController itemController;

        public ItemSetupForm()
        {
            InitializeComponent();

            this.itemController = new ItemController();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            var newItem = new Item()
            {
                Category = this.categoryTextBox.Text,
                Style = this.styleTextBox.Text,
                Color = this.colorTextBox.Text,
                DailyRate = double.Parse(this.dailyRateTextBox.Text),
                FineRate = double.Parse(this.fineRateTextBox.Text),
                Quantity = Int32.Parse(this.quantityTextBox.Text)
            };

            this.itemController.Add(newItem);

            new ManageItemsForm().Show();

            Dispose();
        }
    }
}
