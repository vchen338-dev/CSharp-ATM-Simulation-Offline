namespace ATM_Simulation__Offline_
{
    partial class AccountSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountSettings));
            this.txtNewPin = new System.Windows.Forms.TextBox();
            this.txtCurrentPin = new System.Windows.Forms.TextBox();
            this.btnChangePin = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtConfirmPin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNewPin
            // 
            this.txtNewPin.Font = new System.Drawing.Font("Arial Narrow", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPin.ForeColor = System.Drawing.Color.Gray;
            this.txtNewPin.Location = new System.Drawing.Point(119, 110);
            this.txtNewPin.Name = "txtNewPin";
            this.txtNewPin.Size = new System.Drawing.Size(134, 38);
            this.txtNewPin.TabIndex = 0;
            this.txtNewPin.Text = "New Pin";
            this.txtNewPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCurrentPin
            // 
            this.txtCurrentPin.Font = new System.Drawing.Font("Arial Narrow", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPin.ForeColor = System.Drawing.Color.Gray;
            this.txtCurrentPin.Location = new System.Drawing.Point(124, 240);
            this.txtCurrentPin.Name = "txtCurrentPin";
            this.txtCurrentPin.Size = new System.Drawing.Size(132, 29);
            this.txtCurrentPin.TabIndex = 1;
            this.txtCurrentPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCurrentPin.UseSystemPasswordChar = true;
            // 
            // btnChangePin
            // 
            this.btnChangePin.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChangePin.Location = new System.Drawing.Point(124, 299);
            this.btnChangePin.Name = "btnChangePin";
            this.btnChangePin.Size = new System.Drawing.Size(124, 45);
            this.btnChangePin.TabIndex = 2;
            this.btnChangePin.Text = "Change";
            this.btnChangePin.UseVisualStyleBackColor = true;
            this.btnChangePin.Click += new System.EventHandler(this.btnChangePin_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(340, 415);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(26, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "x";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtConfirmPin
            // 
            this.txtConfirmPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPin.Location = new System.Drawing.Point(119, 169);
            this.txtConfirmPin.Name = "txtConfirmPin";
            this.txtConfirmPin.Size = new System.Drawing.Size(134, 38);
            this.txtConfirmPin.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter Current Pin";
            // 
            // AccountSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(378, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConfirmPin);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnChangePin);
            this.Controls.Add(this.txtCurrentPin);
            this.Controls.Add(this.txtNewPin);
            this.Name = "AccountSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewPin;
        private System.Windows.Forms.TextBox txtCurrentPin;
        private System.Windows.Forms.Button btnChangePin;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtConfirmPin;
        private System.Windows.Forms.Label label1;
    }
}