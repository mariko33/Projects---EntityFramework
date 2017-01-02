namespace HospitalSystemClient2
{
    partial class Form1
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
            this.FirstNamePatient = new System.Windows.Forms.TextBox();
            this.LastNamePatient = new System.Windows.Forms.TextBox();
            this.Adress = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FirstNamePatient
            // 
            this.FirstNamePatient.AccessibleDescription = "";
            this.FirstNamePatient.AccessibleName = "";
            this.FirstNamePatient.Location = new System.Drawing.Point(104, 24);
            this.FirstNamePatient.Name = "FirstNamePatient";
            this.FirstNamePatient.Size = new System.Drawing.Size(196, 20);
            this.FirstNamePatient.TabIndex = 0;
            this.FirstNamePatient.TextChanged += new System.EventHandler(this.FirstNamePatient_TextChanged);
            // 
            // LastNamePatient
            // 
            this.LastNamePatient.Location = new System.Drawing.Point(411, 24);
            this.LastNamePatient.Name = "LastNamePatient";
            this.LastNamePatient.Size = new System.Drawing.Size(181, 20);
            this.LastNamePatient.TabIndex = 1;
            this.LastNamePatient.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Adress
            // 
            this.Adress.Location = new System.Drawing.Point(104, 71);
            this.Adress.Name = "Adress";
            this.Adress.Size = new System.Drawing.Size(196, 20);
            this.Adress.TabIndex = 2;
            this.Adress.TextChanged += new System.EventHandler(this.Adress_TextChanged);
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(411, 71);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(181, 20);
            this.Email.TabIndex = 3;
            this.Email.TextChanged += new System.EventHandler(this.Email_TextChanged);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(169, 302);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 4;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(476, 302);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(87, 23);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "First Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Adress";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Email";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 384);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Adress);
            this.Controls.Add(this.LastNamePatient);
            this.Controls.Add(this.FirstNamePatient);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FirstNamePatient;
        private System.Windows.Forms.TextBox LastNamePatient;
        private System.Windows.Forms.TextBox Adress;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

