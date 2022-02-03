namespace WindowsFormsApp2
{
    partial class UC_rejestracja
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelLogin1 = new System.Windows.Forms.Label();
            this.txt_imie = new System.Windows.Forms.TextBox();
            this.labelHaslo1 = new System.Windows.Forms.Label();
            this.txt_nazwisko = new System.Windows.Forms.TextBox();
            this.button_rejestracja = new System.Windows.Forms.Button();
            this.button_anuluj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_haslo1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_haslo2 = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_login = new System.Windows.Forms.TextBox();
            this.groupBoxRejestracja = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBoxRejestracja.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // labelLogin1
            // 
            this.labelLogin1.AutoSize = true;
            this.labelLogin1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLogin1.ForeColor = System.Drawing.SystemColors.Control;
            this.labelLogin1.Location = new System.Drawing.Point(23, 15);
            this.labelLogin1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLogin1.Name = "labelLogin1";
            this.labelLogin1.Size = new System.Drawing.Size(49, 23);
            this.labelLogin1.TabIndex = 0;
            this.labelLogin1.Text = "Imię";
            // 
            // txt_imie
            // 
            this.txt_imie.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_imie.Location = new System.Drawing.Point(23, 41);
            this.txt_imie.Margin = new System.Windows.Forms.Padding(2);
            this.txt_imie.Name = "txt_imie";
            this.txt_imie.Size = new System.Drawing.Size(206, 28);
            this.txt_imie.TabIndex = 1;
            // 
            // labelHaslo1
            // 
            this.labelHaslo1.AutoSize = true;
            this.labelHaslo1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHaslo1.ForeColor = System.Drawing.SystemColors.Control;
            this.labelHaslo1.Location = new System.Drawing.Point(23, 71);
            this.labelHaslo1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHaslo1.Name = "labelHaslo1";
            this.labelHaslo1.Size = new System.Drawing.Size(91, 23);
            this.labelHaslo1.TabIndex = 2;
            this.labelHaslo1.Text = "Nazwisko";
            // 
            // txt_nazwisko
            // 
            this.txt_nazwisko.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_nazwisko.Location = new System.Drawing.Point(23, 97);
            this.txt_nazwisko.Margin = new System.Windows.Forms.Padding(2);
            this.txt_nazwisko.Name = "txt_nazwisko";
            this.txt_nazwisko.Size = new System.Drawing.Size(206, 28);
            this.txt_nazwisko.TabIndex = 2;
            // 
            // button_rejestracja
            // 
            this.button_rejestracja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_rejestracja.Location = new System.Drawing.Point(23, 385);
            this.button_rejestracja.Margin = new System.Windows.Forms.Padding(2);
            this.button_rejestracja.Name = "button_rejestracja";
            this.button_rejestracja.Size = new System.Drawing.Size(112, 28);
            this.button_rejestracja.TabIndex = 7;
            this.button_rejestracja.Text = "Zarejestruj";
            this.button_rejestracja.UseVisualStyleBackColor = true;
            this.button_rejestracja.Click += new System.EventHandler(this.button_rejestracja_Click);
            // 
            // button_anuluj
            // 
            this.button_anuluj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_anuluj.Location = new System.Drawing.Point(139, 385);
            this.button_anuluj.Margin = new System.Windows.Forms.Padding(2);
            this.button_anuluj.Name = "button_anuluj";
            this.button_anuluj.Size = new System.Drawing.Size(90, 28);
            this.button_anuluj.TabIndex = 8;
            this.button_anuluj.Text = "Anuluj";
            this.button_anuluj.UseVisualStyleBackColor = true;
            this.button_anuluj.Click += new System.EventHandler(this.button_anuluj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(23, 131);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(23, 191);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(23, 253);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Hasło";
            // 
            // txt_haslo1
            // 
            this.txt_haslo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_haslo1.Location = new System.Drawing.Point(23, 279);
            this.txt_haslo1.Margin = new System.Windows.Forms.Padding(2);
            this.txt_haslo1.Name = "txt_haslo1";
            this.txt_haslo1.PasswordChar = '*';
            this.txt_haslo1.Size = new System.Drawing.Size(206, 28);
            this.txt_haslo1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(19, 316);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Powtórz hasło";
            // 
            // txt_haslo2
            // 
            this.txt_haslo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_haslo2.Location = new System.Drawing.Point(23, 341);
            this.txt_haslo2.Margin = new System.Windows.Forms.Padding(2);
            this.txt_haslo2.Name = "txt_haslo2";
            this.txt_haslo2.PasswordChar = '*';
            this.txt_haslo2.Size = new System.Drawing.Size(206, 28);
            this.txt_haslo2.TabIndex = 6;
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_email.Location = new System.Drawing.Point(23, 161);
            this.txt_email.Margin = new System.Windows.Forms.Padding(2);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(206, 28);
            this.txt_email.TabIndex = 3;
            // 
            // txt_login
            // 
            this.txt_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_login.Location = new System.Drawing.Point(23, 223);
            this.txt_login.Margin = new System.Windows.Forms.Padding(2);
            this.txt_login.Name = "txt_login";
            this.txt_login.Size = new System.Drawing.Size(206, 28);
            this.txt_login.TabIndex = 4;
            // 
            // groupBoxRejestracja
            // 
            this.groupBoxRejestracja.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBoxRejestracja.Controls.Add(this.txt_login);
            this.groupBoxRejestracja.Controls.Add(this.txt_email);
            this.groupBoxRejestracja.Controls.Add(this.txt_haslo2);
            this.groupBoxRejestracja.Controls.Add(this.label4);
            this.groupBoxRejestracja.Controls.Add(this.txt_haslo1);
            this.groupBoxRejestracja.Controls.Add(this.label3);
            this.groupBoxRejestracja.Controls.Add(this.label2);
            this.groupBoxRejestracja.Controls.Add(this.label1);
            this.groupBoxRejestracja.Controls.Add(this.button_anuluj);
            this.groupBoxRejestracja.Controls.Add(this.button_rejestracja);
            this.groupBoxRejestracja.Controls.Add(this.txt_nazwisko);
            this.groupBoxRejestracja.Controls.Add(this.labelHaslo1);
            this.groupBoxRejestracja.Controls.Add(this.txt_imie);
            this.groupBoxRejestracja.Controls.Add(this.labelLogin1);
            this.groupBoxRejestracja.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBoxRejestracja.Location = new System.Drawing.Point(0, 0);
            this.groupBoxRejestracja.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxRejestracja.Name = "groupBoxRejestracja";
            this.groupBoxRejestracja.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxRejestracja.Size = new System.Drawing.Size(250, 429);
            this.groupBoxRejestracja.TabIndex = 18;
            this.groupBoxRejestracja.TabStop = false;
            // 
            // UC_rejestracja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxRejestracja);
            this.Name = "UC_rejestracja";
            this.Size = new System.Drawing.Size(250, 429);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBoxRejestracja.ResumeLayout(false);
            this.groupBoxRejestracja.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBoxRejestracja;
        private System.Windows.Forms.TextBox txt_login;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_haslo2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_haslo1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_anuluj;
        private System.Windows.Forms.Button button_rejestracja;
        private System.Windows.Forms.TextBox txt_nazwisko;
        private System.Windows.Forms.Label labelHaslo1;
        private System.Windows.Forms.TextBox txt_imie;
        private System.Windows.Forms.Label labelLogin1;
    }
}
