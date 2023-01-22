using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenaxhimiKinemas
{
    public partial class FrmEvents : Form
    {
        public FrmEvents()
        {
            InitializeComponent();
            lblPrice.Visible = false;
            lblUsername.Visible = false;
            lblPickAMovie.Visible = false;
            txtPrice.Visible = false;
            txtUserNameEvent.Visible = false;
            btnBook.Visible = false;
            cmbChristmasMovie.Visible = false;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = txtChristmasDate.Value.Date;

                EventTicket tickets = new EventTicket(cmbChristmasMovie.SelectedItem.ToString(), date, txtUserNameEvent.Text, "3.99", cmbTime.SelectedItem.ToString());
                tickets.SaveTicketToFile();

                MessageBox.Show(tickets.ShowTicket(), "You have booked your ticket successfully!",
                    MessageBoxButtons.OKCancel);

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void cmbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblPrice.Visible = true;
                lblUsername.Visible = true;
                lblPickAMovie.Visible = true;
                txtPrice.Visible = true;
                txtUserNameEvent.Visible = true;
                btnBook.Visible = true;
                cmbChristmasMovie.Visible = true;

                txtPrice.Text = "$3.99";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
