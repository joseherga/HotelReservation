namespace HotelReservation
{
    partial class MainMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.btnSearchRooms = new System.Windows.Forms.Button();
            this.btnViewReservations = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAdminPanel = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSearchRooms
            // 
            this.btnSearchRooms.Font = new System.Drawing.Font("Segoe Fluent Icons", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchRooms.Location = new System.Drawing.Point(30, 135);
            this.btnSearchRooms.Name = "btnSearchRooms";
            this.btnSearchRooms.Size = new System.Drawing.Size(250, 60);
            this.btnSearchRooms.TabIndex = 0;
            this.btnSearchRooms.Text = "Search Rooms";
            this.btnSearchRooms.UseVisualStyleBackColor = true;
            // 
            // btnViewReservations
            // 
            this.btnViewReservations.Font = new System.Drawing.Font("Segoe Fluent Icons", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReservations.Location = new System.Drawing.Point(30, 287);
            this.btnViewReservations.Name = "btnViewReservations";
            this.btnViewReservations.Size = new System.Drawing.Size(250, 60);
            this.btnViewReservations.TabIndex = 1;
            this.btnViewReservations.Text = "View Reservations";
            this.btnViewReservations.UseVisualStyleBackColor = true;
            this.btnViewReservations.Click += new System.EventHandler(this.btnViewReservations_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(897, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnAdminPanel
            // 
            this.btnAdminPanel.Font = new System.Drawing.Font("Segoe Fluent Icons", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminPanel.Location = new System.Drawing.Point(30, 437);
            this.btnAdminPanel.Name = "btnAdminPanel";
            this.btnAdminPanel.Size = new System.Drawing.Size(250, 60);
            this.btnAdminPanel.TabIndex = 3;
            this.btnAdminPanel.Text = "Admin Panel";
            this.btnAdminPanel.UseVisualStyleBackColor = true;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe Fluent Icons", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(25, 70);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(93, 21);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "Welcome, ";
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnAdminPanel);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnViewReservations);
            this.Controls.Add(this.btnSearchRooms);
            this.Name = "MainMenuForm";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.mainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchRooms;
        private System.Windows.Forms.Button btnViewReservations;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnAdminPanel;
        private System.Windows.Forms.Label lblWelcome;
    }
}