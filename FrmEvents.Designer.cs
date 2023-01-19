namespace MenaxhimiKinemas
{
    partial class FrmEvents
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEvents));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbChristmasMovie = new System.Windows.Forms.ComboBox();
            this.txtUserNameEvent = new System.Windows.Forms.TextBox();
            this.btnBook = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtChristmasDate = new System.Windows.Forms.DateTimePicker();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPickAMovie = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTime = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(40, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 398);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(373, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Description";
            // 
            // cmbChristmasMovie
            // 
            this.cmbChristmasMovie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChristmasMovie.FormattingEnabled = true;
            this.cmbChristmasMovie.Items.AddRange(new object[] {
            "Grinch",
            "Home Alone",
            "The Princess Switch",
            "Elf"});
            this.cmbChristmasMovie.Location = new System.Drawing.Point(495, 327);
            this.cmbChristmasMovie.Name = "cmbChristmasMovie";
            this.cmbChristmasMovie.Size = new System.Drawing.Size(238, 24);
            this.cmbChristmasMovie.TabIndex = 2;
            // 
            // txtUserNameEvent
            // 
            this.txtUserNameEvent.Location = new System.Drawing.Point(495, 366);
            this.txtUserNameEvent.Name = "txtUserNameEvent";
            this.txtUserNameEvent.Size = new System.Drawing.Size(238, 22);
            this.txtUserNameEvent.TabIndex = 3;
            // 
            // btnBook
            // 
            this.btnBook.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBook.Location = new System.Drawing.Point(495, 459);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(238, 23);
            this.btnBook.TabIndex = 4;
            this.btnBook.Text = "BOOK";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPrice.Location = new System.Drawing.Point(374, 411);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(48, 20);
            this.lblPrice.TabIndex = 24;
            this.lblPrice.Text = "Price";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(373, 280);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Date";
            // 
            // txtChristmasDate
            // 
            this.txtChristmasDate.Enabled = false;
            this.txtChristmasDate.Location = new System.Drawing.Point(495, 278);
            this.txtChristmasDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtChristmasDate.Name = "txtChristmasDate";
            this.txtChristmasDate.Size = new System.Drawing.Size(238, 22);
            this.txtChristmasDate.TabIndex = 22;
            this.txtChristmasDate.Value = new System.DateTime(2022, 12, 24, 0, 0, 0, 0);
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(495, 409);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(238, 22);
            this.txtPrice.TabIndex = 21;
            // 
            // lblPickAMovie
            // 
            this.lblPickAMovie.AutoSize = true;
            this.lblPickAMovie.BackColor = System.Drawing.Color.Transparent;
            this.lblPickAMovie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPickAMovie.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPickAMovie.Location = new System.Drawing.Point(374, 327);
            this.lblPickAMovie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPickAMovie.Name = "lblPickAMovie";
            this.lblPickAMovie.Size = new System.Drawing.Size(104, 20);
            this.lblPickAMovie.TabIndex = 25;
            this.lblPickAMovie.Text = "Pick a movie";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblUsername.Location = new System.Drawing.Point(374, 366);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(86, 20);
            this.lblUsername.TabIndex = 26;
            this.lblUsername.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(374, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(375, 80);
            this.label3.TabIndex = 27;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(374, 231);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Time";
            // 
            // cmbTime
            // 
            this.cmbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.Items.AddRange(new object[] {
            "14:00",
            "18:00",
            "21:00",
            "21:30"});
            this.cmbTime.Location = new System.Drawing.Point(495, 231);
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(238, 24);
            this.cmbTime.TabIndex = 29;
            this.cmbTime.SelectedIndexChanged += new System.EventHandler(this.cmbTime_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(309, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 49);
            this.label2.TabIndex = 30;
            this.label2.Text = "Christmas";
            // 
            // FrmEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(787, 528);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblPickAMovie);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtChristmasDate);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.txtUserNameEvent);
            this.Controls.Add(this.cmbChristmasMovie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Name = "FrmEvents";
            this.Text = "Events";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbChristmasMovie;
        private System.Windows.Forms.TextBox txtUserNameEvent;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker txtChristmasDate;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPickAMovie;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTime;
        private System.Windows.Forms.Label label2;
    }
}