namespace HotelReservation
{
    partial class GCashPaymentForm
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
            this.pictureBoxQR = new System.Windows.Forms.PictureBox();
            this.btnConfirmPayment = new ReaLTaiizor.Controls.Button();
            this.LabelQR = new ReaLTaiizor.Controls.SmallLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxQR
            // 
            this.pictureBoxQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxQR.Location = new System.Drawing.Point(87, 38);
            this.pictureBoxQR.Name = "pictureBoxQR";
            this.pictureBoxQR.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxQR.TabIndex = 0;
            this.pictureBoxQR.TabStop = false;
            // 
            // btnConfirmPayment
            // 
            this.btnConfirmPayment.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirmPayment.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnConfirmPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmPayment.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnConfirmPayment.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnConfirmPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnConfirmPayment.Image = null;
            this.btnConfirmPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmPayment.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnConfirmPayment.Location = new System.Drawing.Point(125, 289);
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnConfirmPayment.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnConfirmPayment.Size = new System.Drawing.Size(120, 40);
            this.btnConfirmPayment.TabIndex = 1;
            this.btnConfirmPayment.Text = "Confirm";
            this.btnConfirmPayment.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnConfirmPayment.Click += new System.EventHandler(this.btnConfirmPayment_Click);
            // 
            // LabelQR
            // 
            this.LabelQR.AutoSize = true;
            this.LabelQR.BackColor = System.Drawing.Color.Transparent;
            this.LabelQR.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.LabelQR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.LabelQR.Location = new System.Drawing.Point(108, 255);
            this.LabelQR.Name = "LabelQR";
            this.LabelQR.Size = new System.Drawing.Size(160, 19);
            this.LabelQR.TabIndex = 2;
            this.LabelQR.Text = "Scan this QR with GCash";
            // 
            // GCashPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 353);
            this.Controls.Add(this.LabelQR);
            this.Controls.Add(this.btnConfirmPayment);
            this.Controls.Add(this.pictureBoxQR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GCashPaymentForm";
            this.Text = "GcashPaymentForm";
            this.Load += new System.EventHandler(this.GCashPaymentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxQR;
        private ReaLTaiizor.Controls.Button btnConfirmPayment;
        private ReaLTaiizor.Controls.SmallLabel LabelQR;
    }
}