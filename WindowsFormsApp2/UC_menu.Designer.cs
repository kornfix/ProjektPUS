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
            this.components = new System.ComponentModel.Container();
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.btn_edycja_profilu = new System.Windows.Forms.Button();
            this.l_login = new System.Windows.Forms.Label();
            this.l_nazwisko = new System.Windows.Forms.Label();
            this.l_imie = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelHaslo1 = new System.Windows.Forms.Label();
            this.labelLogin1 = new System.Windows.Forms.Label();
            this.btn_lobby = new System.Windows.Forms.Button();
            this.button_wyloguj = new System.Windows.Forms.Button();
            this.timer_zalogowany = new System.Windows.Forms.Timer(this.components);
            this.groupBoxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBoxLogin.Controls.Add(this.btn_edycja_profilu);
            this.groupBoxLogin.Controls.Add(this.l_login);
            this.groupBoxLogin.Controls.Add(this.l_nazwisko);
            this.groupBoxLogin.Controls.Add(this.l_imie);
            this.groupBoxLogin.Controls.Add(this.label2);
            this.groupBoxLogin.Controls.Add(this.labelHaslo1);
            this.groupBoxLogin.Controls.Add(this.labelLogin1);
            this.groupBoxLogin.Controls.Add(this.btn_lobby);
            this.groupBoxLogin.Controls.Add(this.button_wyloguj);
            this.groupBoxLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBoxLogin.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxLogin.Size = new System.Drawing.Size(333, 377);
            this.groupBoxLogin.TabIndex = 18;
            this.groupBoxLogin.TabStop = false;
            // 
            // btn_edycja_profilu
            // 
            this.btn_edycja_profilu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_edycja_profilu.Location = new System.Drawing.Point(28, 219);
            this.btn_edycja_profilu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_edycja_profilu.Name = "btn_edycja_profilu";
            this.btn_edycja_profilu.Size = new System.Drawing.Size(273, 34);
            this.btn_edycja_profilu.TabIndex = 16;
            this.btn_edycja_profilu.Text = "Edycja profilu";
            this.btn_edycja_profilu.UseVisualStyleBackColor = true;
            this.btn_edycja_profilu.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // l_login
            // 
            this.l_login.AutoSize = true;
            this.l_login.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_login.ForeColor = System.Drawing.SystemColors.Control;
            this.l_login.Location = new System.Drawing.Point(180, 119);
            this.l_login.Name = "l_login";
            this.l_login.Size = new System.Drawing.Size(73, 29);
            this.l_login.TabIndex = 15;
            this.l_login.Text = "Login";
            // 
            // l_nazwisko
            // 
            this.l_nazwisko.AutoSize = true;
            this.l_nazwisko.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_nazwisko.ForeColor = System.Drawing.SystemColors.Control;
            this.l_nazwisko.Location = new System.Drawing.Point(180, 76);
            this.l_nazwisko.Name = "l_nazwisko";
            this.l_nazwisko.Size = new System.Drawing.Size(115, 29);
            this.l_nazwisko.TabIndex = 14;
            this.l_nazwisko.Text = "Nazwisko";
            // 
            // l_imie
            // 
            this.l_imie.AutoSize = true;
            this.l_imie.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_imie.ForeColor = System.Drawing.SystemColors.Control;
            this.l_imie.Location = new System.Drawing.Point(180, 34);
            this.l_imie.Name = "l_imie";
            this.l_imie.Size = new System.Drawing.Size(62, 29);
            this.l_imie.TabIndex = 13;
            this.l_imie.Text = "Imię";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(36, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 29);
            this.label2.TabIndex = 12;
            this.label2.Text = "Login";
            // 
            // labelHaslo1
            // 
            this.labelHaslo1.AutoSize = true;
            this.labelHaslo1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHaslo1.ForeColor = System.Drawing.SystemColors.Control;
            this.labelHaslo1.Location = new System.Drawing.Point(36, 76);
            this.labelHaslo1.Name = "labelHaslo1";
            this.labelHaslo1.Size = new System.Drawing.Size(115, 29);
            this.labelHaslo1.TabIndex = 11;
            this.labelHaslo1.Text = "Nazwisko";
            // 
            // labelLogin1
            // 
            this.labelLogin1.AutoSize = true;
            this.labelLogin1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLogin1.ForeColor = System.Drawing.SystemColors.Control;
            this.labelLogin1.Location = new System.Drawing.Point(36, 34);
            this.labelLogin1.Name = "labelLogin1";
            this.labelLogin1.Size = new System.Drawing.Size(62, 29);
            this.labelLogin1.TabIndex = 10;
            this.labelLogin1.Text = "Imię";
            // 
            // btn_lobby
            // 
            this.btn_lobby.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_lobby.Location = new System.Drawing.Point(28, 255);
            this.btn_lobby.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_lobby.Name = "btn_lobby";
            this.btn_lobby.Size = new System.Drawing.Size(273, 34);
            this.btn_lobby.TabIndex = 7;
            this.btn_lobby.Text = "Wyszukaj grę";
            this.btn_lobby.UseVisualStyleBackColor = true;
            this.btn_lobby.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_wyloguj
            // 
            this.button_wyloguj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_wyloguj.Location = new System.Drawing.Point(28, 313);
            this.button_wyloguj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_wyloguj.Name = "button_wyloguj";
            this.button_wyloguj.Size = new System.Drawing.Size(273, 34);
            this.button_wyloguj.TabIndex = 6;
            this.button_wyloguj.Text = "Wyloguj";
            this.button_wyloguj.UseVisualStyleBackColor = true;
            this.button_wyloguj.Click += new System.EventHandler(this.button_wyloguj_Click);
            // 
            // timer_zalogowany
            // 
            this.timer_zalogowany.Interval = 1000;
            this.timer_zalogowany.Tick += new System.EventHandler(this.timer_zalogowany_Tick);
            // 
            // UC_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxLogin);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UC_menu";
            this.Size = new System.Drawing.Size(336, 379);
            this.VisibleChanged += new System.EventHandler(this.UC_menu_VisibleChanged);
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.Button button_wyloguj;
        private System.Windows.Forms.Button btn_lobby;
        private System.Windows.Forms.Label l_login;
        private System.Windows.Forms.Label l_nazwisko;
        private System.Windows.Forms.Label l_imie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelHaslo1;
        private System.Windows.Forms.Label labelLogin1;
        private System.Windows.Forms.Button btn_edycja_profilu;
        private System.Windows.Forms.Timer timer_zalogowany;
    }
}
