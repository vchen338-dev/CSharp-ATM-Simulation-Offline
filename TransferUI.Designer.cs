namespace ATM_Simulation__Offline_
{
    partial class TransferUI
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
            System.Windows.Forms.Button btnTransfer;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferUI));
            this.txtRecipient = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            btnTransfer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRecipient
            // 
            this.txtRecipient.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRecipient.Font = new System.Drawing.Font("Arial", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecipient.Location = new System.Drawing.Point(113, 56);
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.Size = new System.Drawing.Size(188, 41);
            this.txtRecipient.TabIndex = 0;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAmount.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(112, 123);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(188, 39);
            this.txtAmount.TabIndex = 1;
            // 
            // txtPin
            // 
            this.txtPin.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPin.Location = new System.Drawing.Point(142, 195);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(122, 26);
            this.txtPin.TabIndex = 2;
            this.txtPin.UseSystemPasswordChar = true;
            // 
            // btnTransfer
            // 
            btnTransfer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            btnTransfer.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnTransfer.Location = new System.Drawing.Point(141, 254);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new System.Drawing.Size(123, 53);
            btnTransfer.TabIndex = 3;
            btnTransfer.Text = "Transfer";
            btnTransfer.UseVisualStyleBackColor = false;
            btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(379, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "X\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TransferUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(414, 423);
            this.Controls.Add(this.button1);
            this.Controls.Add(btnTransfer);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtRecipient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "TransferUI";
            this.Text = "Transfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRecipient;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Button button1;
    }
}