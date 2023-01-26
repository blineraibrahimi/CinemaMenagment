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
using System.Security.AccessControl;
using System.Security.Cryptography;


namespace MenaxhimiKinemas
{
    public partial class Cinema : Form
    {
        public Cinema()
        {
            InitializeComponent();
        }

        TheatreRoom objTheatreRoom;
        //list of movies to save
        List<Movies> MovieList = new List<Movies>()
        {
            new Movies ( "Deadpool", "Deadpool", new DateTime(2016, 6, 28), 213, false, 5.99, Movies.Genre.Action, Movies.Technology._2D ),
            new Movies ( "Grown Ups", "Grown Ups",new DateTime(2012, 6, 28), 213, false, 9.29, Movies.Genre.Comedy, Movies.Technology._3D ),
            new Movies ( "2012", "2012", new DateTime(2012, 9, 1), 213, false, 8.29, Movies.Genre.Action, Movies.Technology._2D ),
            new Movies ( "Mean Girls", "Mean Girls", new DateTime(2016, 6, 28), 213, false, 5.99, Movies.Genre.Adventure,Movies.Technology._3D ),
            new Movies ( "Barbie in the 12 Dancing Princesses", "Barbie in the 12 Dancing Princesses", new DateTime(2016, 6, 28), 213, true, 3.99, Movies.Genre.Barbie, Movies.Technology._2D ),
            new Movies ( "Shrek", "Shrek", new DateTime(2016, 6, 28), 213, true, 5.99, Movies.Genre.Barbie, Movies.Technology._2D),
            new Movies ( "Beatuy & the Beast", "Beatuy & the Beast", new DateTime(2016, 6, 28), 213, true, 1.73, Movies.Genre.Barbie , Movies.Technology._2D),
            new Movies ( "Despicable Me", "Despicable Me", new DateTime(2016, 6, 28), 213, true, 5.99, Movies.Genre.Barbie, Movies.Technology._3D ),
            new Movies ( "Black Panther: Wakanda Forever", "2012", new DateTime(2016, 6, 28), 213, false, 5.99, Movies.Genre.SciFi, Movies.Technology._2D )
        };

        //list of tickets
        List<Subscription> subscriptionsList = new List<Subscription>()
        {
            new Subscription(1,"blinera","blinera","blinera123",new DateTime(2016, 6, 28), "bina", true),
            new Subscription(2,"test","test", "test",new DateTime(2023, 1, 24), "test", false),
            new Subscription(3,"fjolla", "jahiu" ,"njomza321",new DateTime(2003, 11, 4), "njomza", true)
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

                //assines the value of combobox in enum format to pass to constructor
                string genreString = cmbGenre.SelectedItem.ToString();
                Movies.Genre genre = GetGenreEnum(genreString);

                string techString = cmbTech.SelectedItem.ToString();
                Movies.Technology tech = GetTechEnum(techString);

                Movies objMovies = new Movies(txtBMovieName.Text, txtbMovieDesc.Text, date, Convert.ToInt32(txtbMovieLength.Text), safeForKids, Convert.ToDouble(txtPriceMovie.Value), genre, tech);
                MovieList.Add(objMovies);

                cmbMovieName.Items.Add(objMovies.MovieName);
                cmbRevMovName.Items.Add(objMovies.MovieName);

                ShowSchedule();

                MessageBox.Show($"Movie name: {objMovies.MovieName}\nMovie Description: {objMovies.MovieDescription}\nLaunch Year: {date.ToLongDateString()}\nMovie Length: {objMovies.MovieLength} minutes"
                    + $"\nSafe for kids: {objMovies.SafeForKids}\nPrice: ${objMovies.Price}" +
                    $"\nTechnology: {objMovies.Tech}\nGenre: {objMovies.Category} ",
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
                txtPriceMovie.Value = 0;
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

                if (cmbSeat.Items.Count == 0)
                {
                    throw new Exception("You can't book anymore tickets!");
                }
                if (cmbMovieName.SelectedItem == null || cmbSeat.SelectedItem == null)
                {
                    throw new Exception("Make sure that all your entries are correct!");
                }
                else
                {
                    if (txtSubEmail.Text != "")
                    {
                        CheckIfSubEmailExists(txtSubEmail.Text);
                    }

                    TicketComboBox ticketComboBox = cmbSeat.SelectedItem as TicketComboBox;
                    //The datas are then passed down to the class, which are validated in the consturctor
                    MovieTicket objTickets = new MovieTicket(cmbMovieName.SelectedItem.ToString(), txtUserName.Text, txtContactNo.Text, ticketComboBox.Value, date, txtPrice.Text);

                    Movies movie = MovieList.Find(x => x.MovieName == cmbMovieName.SelectedItem.ToString());
                    movie.tickets.Add(objTickets);

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
            GetMoviePrice(false);
            //calls the method to add availabe seats for the selected movie
            AddSeats();
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
            txtSubEmail.Text = "";
        }

        //When the form loads, the schedule table will be displayed through the method
        private void Cinema_Load(object sender, EventArgs e)
        {
            ShowSchedule();
            //to set a default name when u want to subscribe
            rbtMonth.Checked = true;

            cmbGenre.Items.AddRange(Enum.GetNames(typeof(Movies.Genre)));
            cmbTech.Items.AddRange(Enum.GetNames(typeof(Movies.Technology)));

            foreach (Movies movie in MovieList)
            {
                cmbMovieName.Items.Add(movie.MovieName);
                cmbRevMovName.Items.Add(movie.MovieName);
            }
            //when you first load the program this returns an emply cmbseat because there is no movie selected
            AddSeats();
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

        int id = 1;
        private void btnSub_Click(object sender, EventArgs e)
        {
            try
            {
                bool subType = true;

                if (rbtMonth.Checked == true)
                {
                    subType = true;
                }
                else if (rbtYear.Checked == true)
                {
                    subType = false;
                }

                string emailExists = CheckIfUserExists(txtEmailSubs.Text);
                //if user exits display a message
                if (emailExists != null)
                {
                    MessageBox.Show(emailExists);
                }
                else
                {
                    Subscription subscription = new Subscription(id++, txtNameSubs.Text, txtLastnameSubs.Text, txtPersonalNo.Text, txtBirthdateSubs.Value.Date, txtEmailSubs.Text, subType);
                    subscriptionsList.Add(subscription);

                    MessageBox.Show("You have subscribed!", "Subscribed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnChristmasNight_Click(object sender, EventArgs e)
        {
            FrmEvents f2 = new FrmEvents();
            f2.ShowDialog();
        }


        //------------------------------- METHODS ---------------------------------------
        
        //Method that holds all the data in the schedule table
        public void ShowSchedule()
        {
            dgv_Schedule.Rows.Clear();
            ArrayList row;
            foreach (Movies movie in MovieList)
            {
                row = new ArrayList();
                row.Add(movie.MovieName);
                row.Add(DateTime.Now.ToShortDateString());
                row.Add("12 p.m");
                row.Add("2 p.m");
                row.Add("6 p.m");
                row.Add("9 p.m");
                dgv_Schedule.Rows.Add(row.ToArray());
            }
        }

        public void AddSeats()
        {
            //create a list to save the the tickets sold for each movie
            List<TicketComboBox> listOfMovieTicket = new List<TicketComboBox>();
            //this list gets the values from the method
            List<int> numberOfSeats = GetAvailableSeat();

            for (int i = 0; i < numberOfSeats.Count; i++)
            {
                if (i <= 9)
                {
                    listOfMovieTicket.Add(new TicketComboBox("Front Row: " + numberOfSeats[i], numberOfSeats[i]));
                }
                else if (i <= 19)
                {
                    listOfMovieTicket.Add(new TicketComboBox("Middle Row: " + numberOfSeats[i], numberOfSeats[i]));
                }
                else
                {
                    listOfMovieTicket.Add(new TicketComboBox("Back Row: " + numberOfSeats[i], numberOfSeats[i]));
                }
            }

            //gets the data from the list that is from the class ticketcombobox, that this class is used to fill the cmbseat
            //valueMember and Display member are used to identify what value a row in the cmb has(name), html input attributes
            cmbSeat.DataSource = listOfMovieTicket;
            cmbSeat.ValueMember = "Value";
            cmbSeat.DisplayMember = "Name";
        }

        public List<int> GetAvailableSeat()
        {
            //me marr emrin e filmit per me check
            //listen prej klases
            //edhe me i return data te listes
            if (cmbMovieName.SelectedItem is null)
            {
                return Enumerable.Range(0, 0).ToList();
            }

            Movies movie = MovieList.Find(x => x.MovieName == cmbMovieName.SelectedItem.ToString());

            //return empty list if the movie does not exist
            if (movie is null)
            {
                return Enumerable.Range(0, 0).ToList();
            }
            //fills the data automaticlly
            List<int> arr = Enumerable.Range(1, 30).ToList();

            List<MovieTicket> tickets = movie.tickets;

            foreach (MovieTicket ticket in tickets)
            {
                int vartest = arr.IndexOf(ticket.Seat);
                //finds index and removes of arr(array)
                arr.Remove(ticket.Seat);

            }

            return arr;
        }

        public void GetMoviePrice(bool subType)
        {
            foreach (Movies movie in MovieList)
            {
                if (cmbMovieName.SelectedItem.ToString() == movie.MovieName)
                {
                    if (subExists == true)
                    {
                        if (subType == true)
                        {
                            double originalprice = movie.Price;
                            double discount = originalprice * 0.15;
                            double newPrice = originalprice - discount;

                            txtPrice.Text = "$" + Convert.ToString(Math.Round((newPrice), 2));
                            subExists = false;
                        }
                        else if (subType == false)
                        {
                            double originalprice = movie.Price;
                            double discount = originalprice * 0.30;
                            double newPrice = originalprice - discount;

                            txtPrice.Text = "$" + Convert.ToString(Math.Round((newPrice), 2));
                            subExists = false;
                        }
                    }
                    else if (subExists == false)
                    {
                        txtPrice.Text = "$" + Convert.ToString(movie.Price);
                    }
                }
            }

        }

        public string CheckIfUserExists(string email)
        {
            Subscription sublist = subscriptionsList.Find(x => x.Email == email);

            if (sublist != null)
            {
                return "This email already exists. Please try a different email!";
            }

            return null;
        }

        bool subExists;
        public void CheckIfSubEmailExists(string email)
        {
            subExists = false;
            foreach (Subscription subscription in subscriptionsList)
            {
                if (subscription.Email.Equals(email))
                {
                    subExists = true;
                    GetMoviePrice(subscription.SubscriptionType);
                    return;
                }
            }

            if (subExists == false)
            {
                MessageBox.Show("This user does not exist, please check your email entry!");
            }
        }

        static Movies.Genre GetGenreEnum(string genreString)
        {
            if (Enum.TryParse<Movies.Genre>(genreString, true, out var genre))
            {
                return genre;
            }
            else
            {
                Console.WriteLine("Invalid genre entered. Please enter a valid genre.");
                return Movies.Genre.None;
            }
        }

        static Movies.Technology GetTechEnum(string techString)
        {
            if (Enum.TryParse<Movies.Technology>(techString, true, out var tech))
            {
                return tech;
            }
            else
            {
                Console.WriteLine("Invalid technology entered. Please enter a valid technology.");
                return Movies.Technology.None;
            }
        }
    }
}