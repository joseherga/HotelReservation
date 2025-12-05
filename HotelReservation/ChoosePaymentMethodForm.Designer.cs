namespace HotelReservation
{
    partial class ChoosePaymentMethodForm
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
            this.btnCard = new ReaLTaiizor.Controls.Button();
            this.btnGCash = new ReaLTaiizor.Controls.Button();
            this.SuspendLayout();
            // 
            // btnCard
            // 
            this.btnCard.BackColor = System.Drawing.Color.Transparent;
            this.btnCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCard.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnCard.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCard.Image = null;
            this.btnCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCard.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnCard.Location = new System.Drawing.Point(87, 93);
            this.btnCard.Name = "btnCard";
            this.btnCard.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnCard.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnCard.Size = new System.Drawing.Size(141, 40);
            this.btnCard.TabIndex = 1;
            this.btnCard.Text = "Pay with Card";
            this.btnCard.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // btnGCash
            // 
            this.btnGCash.BackColor = System.Drawing.Color.Transparent;
            this.btnGCash.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnGCash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGCash.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnGCash.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnGCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnGCash.Image = null;
            this.btnGCash.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGCash.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnGCash.Location = new System.Drawing.Point(288, 93);
            this.btnGCash.Name = "btnGCash";
            this.btnGCash.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnGCash.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnGCash.Size = new System.Drawing.Size(170, 40);
            this.btnGCash.TabIndex = 1;
            this.btnGCash.Text = "Pay with Gcash";
            this.btnGCash.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnGCash.Click += new System.EventHandler(this.btnGCash_Click);
            // 
            // ChoosePaymentMethodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 161);
            this.Controls.Add(this.btnGCash);
            this.Controls.Add(this.btnCard);
            this.Name = "ChoosePaymentMethodForm";
            this.Text = "ChoosePaymentMethodForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.Button btnCard;
        private ReaLTaiizor.Controls.Button btnGCash;
    }
}