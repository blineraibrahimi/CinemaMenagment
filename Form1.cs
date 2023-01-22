using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Security.Policy;
using System.Diagnostics;

namespace MenaxhimiKinemas
{
    public partial class Cinema : Form
    {
        public Cinema()
        {
            InitializeComponent();
        }
      

        Technology objTech;
        Genre objGenre;
        TheatreRoom objTheatreRoom;
        List<Movies> MovieList = new List<Movies>()
        {
            new Movies ( "Deadpool", "Deadpool", new DateTime(2016, 6, 28), 213, false, 5.99 ),
            new Movies ( "Grown Ups", "Grown Ups",new DateTime(2012, 6, 28), 213, false, 9.29 ),
            new Movies ( "2012", "2012", new DateTime(2012, 9, 1), 213, false, 8.29 ),
            new Movies ( "Mean Girls", "Mean Girls", new DateTime(2016, 6, 28), 213, false, 5.99 ),
            new Movies ( "Barbie in the 12 Dancing Princesses", "Barbie in the 12 Dancing Princesses", new DateTime(2016, 6, 28), 213, true, 3.99 ),
            new Movies ( "Shrek", "Shrek", new DateTime(2016, 6, 28), 213, true, 5.99 ),
            new Movies ( "Beatuy & the Beast", "Beatuy & the Beast", new DateTime(2016, 6, 28), 213, true, 1.73 ),
            new Movies ( "Despicable Me", "Despicable Me", new DateTime(2016, 6, 28), 213, true, 5.99 ),
            new Movies ( "Black Panther: Wakanda Forever", "2012", new DateTime(2016, 6, 28), 213, false, 5.99 )
        };

        List<Subscription> subscriptionsList = new List<Subscription>()
        {
            new Subscription("blinera","bina",true)
        };

    //This button registers a new movie
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool safeForKids;
                DateTime date = dtpMovieLaunch.Value.Date;

                if (rbtnSafe.Checked == true)
                {
                    safeForKids = true;
                }
                else
                {
                    safeForKids = false;
                }
               
                Movies objMovies = new Movies(txtBMovieName.Text, txtbMovieDesc.Text ,date, Convert.ToInt32(txtbMovieLength.Text), safeForKids, Convert.ToDouble(txtMoviePrice.Text));
                MovieList.Add(objMovies);
                objTech = new Technology(cmbTech.Text);
                objGenre = new Genre(cmbGenre.Text);

                cmbMovieName.Items.Add(objMovies.Name_); 
                cmbRevMovName.Items.Add(objMovies.Name_);

                MessageBox.Show($"Movie name: {objMovies.Name_}\nMovie Description: {objMovies.MovieDescription}\nLaunch Year: {date.ToLongDateString()}\nMovie Length: {objMovies.MovieLength} minutes" 
                    +$"\nSafe for kids: {objMovies.SafeForKids}\nPrice: ${objMovies.Price}" +
                    $"\nTechnology: {objTech.ShowTech()}\nGenre: {objGenre.ShowGenre()} ",
                    "Your movie is saved successfully!",
                    MessageBoxButtons.OK);

                //clears the data
                txtBMovieName.Text = "";
                cmbGenre.Text = null;
                cmbTech.Text = null;
                txtbMovieLength.Text = null;
                txtbMovieDesc.Text = null;
                rbtnSafe.Checked = false;
                dtpMovieLaunch.Value = DateTime.Now;
                txtMoviePrice = null;

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        //This button will show in message box the saved data
        private void btnSaveRoom_Click(object sender, EventArgs e)
        {
            try
            {
                var number = numberOfChairs.Text;
                bool isTrue = int.TryParse(number, out var numOfChairs);

                //Checking if the input is correct or not
                if (isTrue)
                {
                    objTheatreRoom = new TheatreRoom(theatreRoomNametxt.Text, Convert.ToInt32(numberOfChairs.Text));
                    MessageBox.Show(objTheatreRoom.ShowValues(), "Your data is saved successfully!", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Please enter valid information!");
                    theatreRoomNametxt.Text = "";
                    numberOfChairs.Text = "";
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = txtDate.Value.Date;

                //lblRating.Text = "";

                if(numberOfSeats == null )
                {
                    throw new Exception("You can't book anymore tickets!");
                }
                if (cmbMovieName.SelectedItem == null || cmbSeat.SelectedItem == null)
                {
                    throw new Exception("Make sure that all your entries are correct!");
                }
                else
                {
                    if (cmbMovieName.SelectedItem.ToString() == "Deadpool ")
                    {
                        lblRating.Text += "This movie has the highest rating: 5.5!";
                    }
                    CheckIfSubEmailExists(txtSubEmail.Text);
                    //The datas are then passed down to the class, which are validated in the consturctor
                    Tickets objTickets = new Tickets(cmbMovieName.SelectedItem.ToString(), txtUserName.Text, txtContactNo.Text, cmbSeat.SelectedItem.ToString(), date, txtPrice.Text);
                    objTickets.SaveTicketToFile();
                    //Then the data is displayed on the message box using the method that was created in the class
                    MessageBox.Show(objTickets.ShowTicket(), "You have booked your ticket successfully!", MessageBoxButtons.OKCancel);
                    cmbSeat.Items.Remove(cmbSeat.SelectedItem.ToString());

                    btnReset_Click(sender, e);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        //When the selected movie is chosen, show the significant price on the textbox
        private void cmbMovieName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMoviePrice();
        }
        private void rbtnFifteen_CheckedChanged(object sender, EventArgs e)
        {
            GetMoviePrice();
        }
        private void rbtnThirty_CheckedChanged(object sender, EventArgs e)
        {
            GetMoviePrice();
        }

        //When this button is executed, it will close the form/program
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //When this button is executed, it will clear all the data chosen
        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbMovieName.Text = "Select a movie";
            txtUserName.Text = "";
            txtContactNo.Text = "";
            cmbSeat.Text = null;
            txtDate.Value = DateTime.Now;
            txtPrice.Text = "";
            rbtnFifteen.Checked = false;
            rbtnThirty.Checked = false;
            rbtnNoSub.Checked = false;
        }

        //When the form loads, the schedule table will be displayed through the method
        int[] numberOfSeats = new int[30];
        private void Cinema_Load(object sender, EventArgs e)
        {
            ShowSchedule();
            rbtMonth.Checked = true;

            foreach (Movies movie in MovieList)
            {
                cmbMovieName.Items.Add(movie.Name_);
                cmbRevMovName.Items.Add(movie.Name_);
            }
            for (int i = 0; i < numberOfSeats.Length; i++)
            {
                numberOfSeats[i] = i + 1;
                if (i <= 9)
                {
                    cmbSeat.Items.Add("Front Row: " + numberOfSeats[i]);
                }
                else if (i <= 19)
                {
                    cmbSeat.Items.Add("Middle Row: " + numberOfSeats[i]);
                }
                else 
                {
                    cmbSeat.Items.Add("Back Row: " + numberOfSeats[i]);
                }
            }
        }

        //Method that holds all the data in the schedule table
        public void ShowSchedule()
        {
            ArrayList row;
            foreach (Movies movie in MovieList)
            {
                row = new ArrayList();
                row.Add(movie.Name_);
                row.Add(DateTime.Now.ToShortDateString());
                row.Add("12 p.m");
                row.Add("2 p.m");
                row.Add("6 p.m");
                row.Add("9 p.m");
                dgv_Schedule.Rows.Add(row.ToArray());
            }
        }

        private void btnSaveReview_Click(object sender, EventArgs e)
        {
            try
            {
                Review review = new Review(cmbRevMovName.Text, txtReview.Text, Convert.ToInt32(txtRating.Text));
                review.SaveReviewToFile();

                MessageBox.Show("Your review is saved successfully!", "Review", 
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            try
            {
                bool subType = true;

                if(rbtMonth.Checked == true)
                {
                    subType = true;
                }
                else if (rbtYear.Checked == true)
                {
                    subType = false;
                }

                Subscription subscription = new Subscription(txtUsernameSubs.Text, txtEmailSubs.Text, subType);
                subscriptionsList.Add(subscription);
                //subscription.SaveSubscriptionToFile();

                MessageBox.Show("You have subscribed!", "Subscribed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public void GetMoviePrice()
        {
            foreach (Movies movie in MovieList)
            {
                if (cmbMovieName.SelectedItem.ToString() == movie.Name_)
                {
                    if (rbtnFifteen.Checked == true)
                    {
                        double originalprice = movie.Price;
                        double discount = originalprice * 0.15;
                        double newPrice = originalprice - discount;

                        txtPrice.Text = "$" + Convert.ToString(Math.Round((newPrice), 2));
                    }
                    else if (rbtnThirty.Checked == true)
                    {
                        double originalprice = movie.Price;
                        double discount = originalprice * 0.30;
                        double newPrice = originalprice - discount;

                        txtPrice.Text = "$" + Convert.ToString(Math.Round((newPrice), 2));
                    }
                    else
                    {
                        txtPrice.Text = "$" + Convert.ToString(movie.Price);
                    }
                }
            
            }

        }
        public void GetMoviePrice(bool subType)
        {
            foreach (Movies movie in MovieList)
            {
                if (cmbMovieName.SelectedItem.ToString() == movie.Name_)
                {
                    if (subExists == true)
                    {
                        if (subType == true)
                        {
                            double originalprice = movie.Price;
                            double discount = originalprice * 0.15;
                            double newPrice = originalprice - discount;

                            txtPrice.Text = "$" + Convert.ToString(Math.Round((newPrice), 2));
                        }
                        else if (subType == false)
                        {
                            double originalprice = movie.Price;
                            double discount = originalprice * 0.30;
                            double newPrice = originalprice - discount;

                            txtPrice.Text = "$" + Convert.ToString(Math.Round((newPrice), 2));
                        }

                    }
                    else
                    {
                        txtPrice.Text = "$" + Convert.ToString(movie.Price);
                    }
                }
            }

        }

        private void btnChristmasNight_Click(object sender, EventArgs e)
        {
            FrmEvents f2 = new FrmEvents();
            f2.ShowDialog();
        }

        bool subExists = false;
        public void CheckIfSubEmailExists(string email)
        {
            foreach (Subscription subscription in subscriptionsList)
            {
                if (subscription.Email.Equals(email))
                {
                    Console.WriteLine("Brotha, in christ u exist!");
                    subExists= true;
                    GetMoviePrice(subscription.SubscriptionType);
                }

            }

        }
    }
}