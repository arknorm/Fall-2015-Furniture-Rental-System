using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurnitureRentalStore.View
{
    public partial class EmployeeOptionsForm : Form
    {

        public EmployeeOptionsForm(string employeeFirstName, string employeeLastName)
        {
            InitializeComponent();

            welcomeLabel.Text = "Welcome: " + employeeFirstName + " " + employeeLastName;
        }
    }
}
