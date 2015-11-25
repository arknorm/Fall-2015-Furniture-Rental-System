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

namespace FurnitureRentalStore.View
{

    public partial class QueryBuilderForm : Form
    {

        private QueryBuilderController queryBuilerController;

        public QueryBuilderForm()
        {
            InitializeComponent();

            queryBuilerController = new QueryBuilderController();
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();

            bindingSource1.DataSource = this.queryBuilerController.GetQueryResults(this.queryTextBox.Text);

            this.queryBuilderDataGridView.DataSource = bindingSource1;
        }
    }
}
