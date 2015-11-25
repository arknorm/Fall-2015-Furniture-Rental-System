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
    public partial class ItemUpdateForm : Form
    {
        private readonly ItemController itemController;

        private int itemID;

        public ItemUpdateForm(Item anItem)
        {
            InitializeComponent();

            itemController = new ItemController();

            this.categoryTextBox.Text = anItem.Category;
            this.styleTextBox.Text = anItem.Style;
            this.colorTextBox.Text = anItem.Color;
            this.dailyRateTextBox.Text = anItem.DailyRate.ToString();
            this.fineRateTextBox.Text = anItem.FineRate.ToString();
            this.quantityTextBox.Text = anItem.Quantity.ToString();

            this.itemID = anItem.ItemID;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

            var updatedItem = new Item()
            {
                ItemID = this.itemID,
                Category = this.categoryTextBox.Text,
                Style = this.styleTextBox.Text,
                Color = this.colorTextBox.Text,
                DailyRate = double.Parse(this.dailyRateTextBox.Text),
                FineRate = double.Parse(this.fineRateTextBox.Text),
                Quantity = Int32.Parse(this.quantityTextBox.Text)
            };

            this.itemController.UpdateItem(updatedItem);

            new ManageItemsForm().Show();

            Dispose();
        }
    }
}
