namespace WindowsFormsApp2
{
    partial class UC_logowanie
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
            this.labelLogin1 = new System.Windows.Forms.Label();
            this.textBoxLogin1 = new System.Windows.Forms.TextBox();
            this.labelHaslo1 = new System.Windows.Forms.Label();
            this.textBoxHaslo1 = new System.Windows.Forms.TextBox();
            this.linkLabelZapomnialem = new System.Windows.Forms.LinkLabel();
            this.buttonZaloguj = new System.Windows.Forms.Button();
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.lb_ogolny = new System.Windows.Forms.Label();
            this.button_rejestracja = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bg_logowanie = new System.ComponentModel.BackgroundWorker();
            this.bg_wylogowywanie = new System.ComponentModel.BackgroundWorker();
            this.groupBoxLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLogin1
            // 
            this.labelLogin1.AutoSize = true;
            this.labelLogin1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLogin1.ForeColor = System.Drawing.SystemColors.Control;
            this.labelLogin1.Location = new System.Drawing.Point(20, 15);
            this.labelLogin1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLogin1.Name = "labelLogin1";
            this.labelLogin1.Size = new System.Drawing.Size(58, 23);
            this.labelLogin1.TabIndex = 0;
            this.labelLogin1.Text = "Login";
            // 
            // textBoxLogin1
            // 
            this.textBoxLogin1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxLogin1.Location = new System.Drawing.Point(21, 41);
            this.textBoxLogin1.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLogin1.Name = "textBoxLogin1";
            this.textBoxLogin1.Size = new System.Drawing.Size(206, 28);
            this.textBoxLogin1.TabIndex = 1;
            // 
            // labelHaslo1
            // 
            this.labelHaslo1.AutoSize = true;
            this.labelHaslo1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHaslo1.ForeColor = System.Drawing.SystemColors.Control;
            this.labelHaslo1.Location = new System.Drawing.Point(20, 71);
            this.labelHaslo1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHaslo1.Name = "labelHaslo1";
            this.labelHaslo1.Size = new System.Drawing.Size(58, 23);
            this.labelHaslo1.TabIndex = 2;
            this.labelHaslo1.Text = "Hasło";
            // 
            // textBoxHaslo1
            // 
            this.textBoxHaslo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxHaslo1.Location = new System.Drawing.Point(21, 97);
            this.textBoxHaslo1.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxHaslo1.Name = "textBoxHaslo1";
            this.textBoxHaslo1.PasswordChar = '*';
            this.textBoxHaslo1.Size = new System.Drawing.Size(206, 28);
            this.textBoxHaslo1.TabIndex = 3;
            // 
            // linkLabelZapomnialem
            // 
            this.linkLabelZapomnialem.ActiveLinkColor = System.Drawing.Color.Blue;
            this.linkLabelZapomnialem.AutoSize = true;
            this.linkLabelZapomnialem.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabelZapomnialem.LinkColor = System.Drawing.Color.White;
            this.linkLabelZapomnialem.Location = new System.Drawing.Point(21, 189);
            this.linkLabelZapomnialem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabelZapomnialem.Name = "linkLabelZapomnialem";
            this.linkLabelZapomnialem.Size = new System.Drawing.Size(129, 17);
            this.linkLabelZapomnialem.TabIndex = 5;
            this.linkLabelZapomnialem.TabStop = true;
            this.linkLabelZapomnialem.Text = "Zapomniałem hasło";
            // 
            // buttonZaloguj
            // 
            this.buttonZaloguj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonZaloguj.Location = new System.Drawing.Point(21, 129);
            this.buttonZaloguj.Margin = new System.Windows.Forms.Padding(2);
            this.buttonZaloguj.Name = "buttonZaloguj";
            this.buttonZaloguj.Size = new System.Drawing.Size(75, 28);
            this.buttonZaloguj.TabIndex = 4;
            this.buttonZaloguj.Text = "Zaloguj";
            this.buttonZaloguj.UseVisualStyleBackColor = true;
            this.buttonZaloguj.Click += new System.EventHandler(this.buttonZaloguj_Click);
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBoxLogin.Controls.Add(this.lb_ogolny);
            this.groupBoxLogin.Controls.Add(this.button_rejestracja);
            this.groupBoxLogin.Controls.Add(this.buttonZaloguj);
            this.groupBoxLogin.Controls.Add(this.linkLabelZapomnialem);
            this.groupBoxLogin.Controls.Add(this.textBoxHaslo1);
            this.groupBoxLogin.Controls.Add(this.labelHaslo1);
            this.groupBoxLogin.Controls.Add(this.textBoxLogin1);
            this.groupBoxLogin.Controls.Add(this.labelLogin1);
            this.groupBoxLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBoxLogin.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLogin.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxLogin.Size = new System.Drawing.Size(254, 220);
            this.groupBoxLogin.TabIndex = 17;
            this.groupBoxLogin.TabStop = false;
            // 
            // lb_ogolny
            // 
            this.lb_ogolny.AutoSize = true;
            this.lb_ogolny.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_ogolny.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_ogolny.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ogolny.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_ogolny.Location = new System.Drawing.Point(21, 159);
            this.lb_ogolny.Name = "lb_ogolny";
            this.lb_ogolny.Size = new System.Drawing.Size(53, 21);
            this.lb_ogolny.TabIndex = 30;
            this.lb_ogolny.Text = "label1";
            this.lb_ogolny.Visible = false;
            // 
            // button_rejestracja
            // 
            this.button_rejestracja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_rejestracja.Location = new System.Drawing.Point(100, 129);
            this.button_rejestracja.Margin = new System.Windows.Forms.Padding(2);
            this.button_rejestracja.Name = "button_rejestracja";
            this.button_rejestracja.Size = new System.Drawing.Size(127, 28);
            this.button_rejestracja.TabIndex = 6;
            this.button_rejestracja.Text = "Rejestracja";
            this.button_rejestracja.UseVisualStyleBackColor = true;
            this.button_rejestracja.Click += new System.EventHandler(this.button_rejestracja_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // bg_logowanie
            // 
            this.bg_logowanie.WorkerReportsProgress = true;
            this.bg_logowanie.WorkerSupportsCancellation = true;
            this.bg_logowanie.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.bg_logowanie.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // bg_wylogowywanie
            // 
            this.bg_wylogowywanie.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_wylogowywanie_DoWork);
            this.bg_wylogowywanie.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_wylogowywanie_RunWorkerCompleted);
            // 
            // UC_logowanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxLogin);
            this.Name = "UC_logowanie";
            this.Size = new System.Drawing.Size(254, 220);
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelLogin1;
        private System.Windows.Forms.TextBox textBoxLogin1;
        private System.Windows.Forms.Label labelHaslo1;
        private System.Windows.Forms.TextBox textBoxHaslo1;
        private System.Windows.Forms.LinkLabel linkLabelZapomnialem;
        private System.Windows.Forms.Button buttonZaloguj;
        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.Button button_rejestracja;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.ComponentModel.BackgroundWorker bg_logowanie;
        private System.Windows.Forms.Label lb_ogolny;
        private System.ComponentModel.BackgroundWorker bg_wylogowywanie;
    }
}
