namespace WindowsFormsApp2
{
    partial class UC_menu
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button_wyloguj = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelHaslo1 = new System.Windows.Forms.Label();
            this.labelLogin1 = new System.Windows.Forms.Label();
            this.l_login = new System.Windows.Forms.Label();
            this.l_nazwisko = new System.Windows.Forms.Label();
            this.l_imie = new System.Windows.Forms.Label();
            this.groupBoxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBoxLogin.Controls.Add(this.l_login);
            this.groupBoxLogin.Controls.Add(this.l_nazwisko);
            this.groupBoxLogin.Controls.Add(this.l_imie);
            this.groupBoxLogin.Controls.Add(this.label2);
            this.groupBoxLogin.Controls.Add(this.labelHaslo1);
            this.groupBoxLogin.Controls.Add(this.labelLogin1);
            this.groupBoxLogin.Controls.Add(this.button1);
            this.groupBoxLogin.Controls.Add(this.button_wyloguj);
            this.groupBoxLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBoxLogin.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLogin.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxLogin.Size = new System.Drawing.Size(250, 306);
            this.groupBoxLogin.TabIndex = 18;
            this.groupBoxLogin.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Test połączenia";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_wyloguj
            // 
            this.button_wyloguj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_wyloguj.Location = new System.Drawing.Point(21, 254);
            this.button_wyloguj.Margin = new System.Windows.Forms.Padding(2);
            this.button_wyloguj.Name = "button_wyloguj";
            this.button_wyloguj.Size = new System.Drawing.Size(205, 28);
            this.button_wyloguj.TabIndex = 6;
            this.button_wyloguj.Text = "Wyloguj";
            this.button_wyloguj.UseVisualStyleBackColor = true;
            this.button_wyloguj.Click += new System.EventHandler(this.button_wyloguj_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(27, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Login";
            // 
            // labelHaslo1
            // 
            this.labelHaslo1.AutoSize = true;
            this.labelHaslo1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHaslo1.ForeColor = System.Drawing.SystemColors.Control;
            this.labelHaslo1.Location = new System.Drawing.Point(27, 62);
            this.labelHaslo1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHaslo1.Name = "labelHaslo1";
            this.labelHaslo1.Size = new System.Drawing.Size(91, 23);
            this.labelHaslo1.TabIndex = 11;
            this.labelHaslo1.Text = "Nazwisko";
            // 
            // labelLogin1
            // 
            this.labelLogin1.AutoSize = true;
            this.labelLogin1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLogin1.ForeColor = System.Drawing.SystemColors.Control;
            this.labelLogin1.Location = new System.Drawing.Point(27, 28);
            this.labelLogin1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLogin1.Name = "labelLogin1";
            this.labelLogin1.Size = new System.Drawing.Size(49, 23);
            this.labelLogin1.TabIndex = 10;
            this.labelLogin1.Text = "Imię";
            // 
            // l_login
            // 
            this.l_login.AutoSize = true;
            this.l_login.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_login.ForeColor = System.Drawing.SystemColors.Control;
            this.l_login.Location = new System.Drawing.Point(135, 97);
            this.l_login.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_login.Name = "l_login";
            this.l_login.Size = new System.Drawing.Size(58, 23);
            this.l_login.TabIndex = 15;
            this.l_login.Text = "Login";
            // 
            // l_nazwisko
            // 
            this.l_nazwisko.AutoSize = true;
            this.l_nazwisko.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_nazwisko.ForeColor = System.Drawing.SystemColors.Control;
            this.l_nazwisko.Location = new System.Drawing.Point(135, 62);
            this.l_nazwisko.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_nazwisko.Name = "l_nazwisko";
            this.l_nazwisko.Size = new System.Drawing.Size(91, 23);
            this.l_nazwisko.TabIndex = 14;
            this.l_nazwisko.Text = "Nazwisko";
            // 
            // l_imie
            // 
            this.l_imie.AutoSize = true;
            this.l_imie.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_imie.ForeColor = System.Drawing.SystemColors.Control;
            this.l_imie.Location = new System.Drawing.Point(135, 28);
            this.l_imie.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_imie.Name = "l_imie";
            this.l_imie.Size = new System.Drawing.Size(49, 23);
            this.l_imie.TabIndex = 13;
            this.l_imie.Text = "Imię";
            // 
            // UC_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxLogin);
            this.Name = "UC_menu";
            this.Size = new System.Drawing.Size(252, 308);
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.Button button_wyloguj;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label l_login;
        private System.Windows.Forms.Label l_nazwisko;
        private System.Windows.Forms.Label l_imie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelHaslo1;
        private System.Windows.Forms.Label labelLogin1;
    }
}
