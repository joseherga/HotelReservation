using System;

namespace HotelReservation
{
    partial class OTPVerificationForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblOTP = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtOTP1 = new System.Windows.Forms.MaskedTextBox();
            this.txtOTP2 = new System.Windows.Forms.MaskedTextBox();
            this.txtOTP3 = new System.Windows.Forms.MaskedTextBox();
            this.txtOTP6 = new System.Windows.Forms.MaskedTextBox();
            this.txtOTP5 = new System.Windows.Forms.MaskedTextBox();
            this.txtOTP4 = new System.Windows.Forms.MaskedTextBox();
            this.lnkResend = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lnkResend);
            this.panel1.Controls.Add(this.txtOTP4);
            this.panel1.Controls.Add(this.txtOTP5);
            this.panel1.Controls.Add(this.txtOTP6);
            this.panel1.Controls.Add(this.txtOTP3);
            this.panel1.Controls.Add(this.txtOTP2);
            this.panel1.Controls.Add(this.txtOTP1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.lblOTP);
            this.panel1.Controls.Add(this.btnVerify);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Location = new System.Drawing.Point(439, 216);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 383);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 28);
            this.label1.TabIndex = 0;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            this.lbl1.Font = new System.Drawing.Font("Segoe UI Historic", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbl1.Location = new System.Drawing.Point(64, 204);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(299, 34);
            this.lbl1.TabIndex = 8;
            this.lbl1.Text = "Please enter the 6-digit one time password (OTP) \r\nthat we sent to your Email.";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(0, 0);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(132, 22);
            this.txtUsername.TabIndex = 13;
            // 
            // lblOTP
            // 
            this.lblOTP.AutoSize = true;
            this.lblOTP.BackColor = System.Drawing.Color.Transparent;
            this.lblOTP.Font = new System.Drawing.Font("Segoe UI Historic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOTP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblOTP.Location = new System.Drawing.Point(122, 28);
            this.lblOTP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOTP.Name = "lblOTP";
            this.lblOTP.Size = new System.Drawing.Size(194, 50);
            this.lblOTP.TabIndex = 6;
            this.lblOTP.Text = "Enter OTP";
            // 
            // btnVerify
            // 
            this.btnVerify.BackColor = System.Drawing.Color.Blue;
            this.btnVerify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerify.Font = new System.Drawing.Font("Segoe UI Historic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.ForeColor = System.Drawing.Color.White;
            this.btnVerify.Location = new System.Drawing.Point(110, 262);
            this.btnVerify.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(215, 46);
            this.btnVerify.TabIndex = 4;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = false;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(0, 0);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(132, 22);
            this.txtPassword.TabIndex = 14;
            // 
            // txtOTP1
            // 
            this.txtOTP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOTP1.Location = new System.Drawing.Point(55, 123);
            this.txtOTP1.Mask = "0";
            this.txtOTP1.Name = "txtOTP1";
            this.txtOTP1.Size = new System.Drawing.Size(50, 61);
            this.txtOTP1.TabIndex = 21;
            this.txtOTP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOTP1.TextChanged += new System.EventHandler(this.OTP_TextChanged);
            // 
            // txtOTP2
            // 
            this.txtOTP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOTP2.Location = new System.Drawing.Point(110, 123);
            this.txtOTP2.Mask = "0";
            this.txtOTP2.Name = "txtOTP2";
            this.txtOTP2.Size = new System.Drawing.Size(50, 61);
            this.txtOTP2.TabIndex = 22;
            this.txtOTP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOTP2.TextChanged += new System.EventHandler(this.OTP_TextChanged);
            // 
            // txtOTP3
            // 
            this.txtOTP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOTP3.Location = new System.Drawing.Point(165, 123);
            this.txtOTP3.Mask = "0";
            this.txtOTP3.Name = "txtOTP3";
            this.txtOTP3.Size = new System.Drawing.Size(50, 61);
            this.txtOTP3.TabIndex = 23;
            this.txtOTP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOTP3.TextChanged += new System.EventHandler(this.OTP_TextChanged);
            // 
            // txtOTP6
            // 
            this.txtOTP6.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOTP6.Location = new System.Drawing.Point(330, 123);
            this.txtOTP6.Mask = "0";
            this.txtOTP6.Name = "txtOTP6";
            this.txtOTP6.Size = new System.Drawing.Size(50, 61);
            this.txtOTP6.TabIndex = 24;
            this.txtOTP6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOTP6.TextChanged += new System.EventHandler(this.OTP_TextChanged);
            // 
            // txtOTP5
            // 
            this.txtOTP5.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOTP5.Location = new System.Drawing.Point(275, 123);
            this.txtOTP5.Mask = "0";
            this.txtOTP5.Name = "txtOTP5";
            this.txtOTP5.Size = new System.Drawing.Size(50, 61);
            this.txtOTP5.TabIndex = 25;
            this.txtOTP5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOTP5.TextChanged += new System.EventHandler(this.OTP_TextChanged);
            // 
            // txtOTP4
            // 
            this.txtOTP4.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOTP4.Location = new System.Drawing.Point(220, 123);
            this.txtOTP4.Mask = "0";
            this.txtOTP4.Name = "txtOTP4";
            this.txtOTP4.Size = new System.Drawing.Size(50, 61);
            this.txtOTP4.TabIndex = 26;
            this.txtOTP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOTP4.TextChanged += new System.EventHandler(this.OTP_TextChanged);
            // 
            // lnkResend
            // 
            this.lnkResend.AutoSize = true;
            this.lnkResend.Location = new System.Drawing.Point(191, 339);
            this.lnkResend.Name = "lnkResend";
            this.lnkResend.Size = new System.Drawing.Size(55, 16);
            this.lnkResend.TabIndex = 27;
            this.lnkResend.TabStop = true;
            this.lnkResend.Text = "Resend";
            this.lnkResend.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkResend_LinkClicked);
            // 
            // OTPVerificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HotelReservation.Properties.Resources.bytelodge__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1312, 814);
            this.Controls.Add(this.panel1);
            this.Name = "OTPVerificationForm";
            this.Text = "OTPVerificationForm";
            this.Load += new System.EventHandler(this.OTPVerificationForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblOTP;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.TextBox txtPassword;

        private System.Windows.Forms.MaskedTextBox txtOTP1;
        private System.Windows.Forms.MaskedTextBox txtOTP4;
        private System.Windows.Forms.MaskedTextBox txtOTP5;
        private System.Windows.Forms.MaskedTextBox txtOTP6;
        private System.Windows.Forms.MaskedTextBox txtOTP3;
        private System.Windows.Forms.MaskedTextBox txtOTP2;
        private System.Windows.Forms.LinkLabel lnkResend;
    }
}