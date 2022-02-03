
namespace WindowsFormsApp2
{
    partial class UC_rejestracja2
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelLogin1 = new System.Windows.Forms.Label();
            this.txt_imie = new System.Windows.Forms.TextBox();
            this.lb_imie = new System.Windows.Forms.Label();
            this.labelHaslo1 = new System.Windows.Forms.Label();
            this.txt_nazwisko = new System.Windows.Forms.TextBox();
            this.lb_nazwisko = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.lb_email = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_login = new System.Windows.Forms.TextBox();
            this.lb_login = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_haslo1 = new System.Windows.Forms.TextBox();
            this.lb_haslo1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_haslo2 = new System.Windows.Forms.TextBox();
            this.lb_haslo2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_anuluj = new System.Windows.Forms.Button();
            this.button_rejestracja = new System.Windows.Forms.Button();
            this.lb_ogolny = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.flowLayoutPanel1.Controls.Add(this.labelLogin1);
            this.flowLayoutPanel1.Controls.Add(this.txt_imie);
            this.flowLayoutPanel1.Controls.Add(this.lb_imie);
            this.flowLayoutPanel1.Controls.Add(this.labelHaslo1);
            this.flowLayoutPanel1.Controls.Add(this.txt_nazwisko);
            this.flowLayoutPanel1.Controls.Add(this.lb_nazwisko);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txt_email);
            this.flowLayoutPanel1.Controls.Add(this.lb_email);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.txt_login);
            this.flowLayoutPanel1.Controls.Add(this.lb_login);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.txt_haslo1);
            this.flowLayoutPanel1.Controls.Add(this.lb_haslo1);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.txt_haslo2);
            this.flowLayoutPanel1.Controls.Add(this.lb_haslo2);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.lb_ogolny);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(15);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(15);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(327, 576);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // labelLogin1
            // 
            this.labelLogin1.AutoSize = true;
            this.labelLogin1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLogin1.ForeColor = System.Drawing.SystemColors.Control;
            this.labelLogin1.Location = new System.Drawing.Point(17, 15);
            this.labelLogin1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLogin1.Name = "labelLogin1";
            this.labelLogin1.Size = new System.Drawing.Size(49, 23);
            this.labelLogin1.TabIndex = 122;
            this.labelLogin1.Text = "Imię";
            // 
            // txt_imie
            // 
            this.txt_imie.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_imie.Location = new System.Drawing.Point(17, 40);
            this.txt_imie.Margin = new System.Windows.Forms.Padding(2);
            this.txt_imie.Name = "txt_imie";
            this.txt_imie.Size = new System.Drawing.Size(293, 28);
            this.txt_imie.TabIndex = 0;
            // 
            // lb_imie
            // 
            this.lb_imie.AutoSize = true;
            this.lb_imie.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_imie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_imie.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_imie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_imie.Location = new System.Drawing.Point(18, 70);
            this.lb_imie.Name = "lb_imie";
            this.lb_imie.Size = new System.Drawing.Size(53, 21);
            this.lb_imie.TabIndex = 20;
            this.lb_imie.Text = "label1";
            this.lb_imie.Visible = false;
            // 
            // labelHaslo1
            // 
            this.labelHaslo1.AutoSize = true;
            this.labelHaslo1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHaslo1.ForeColor = System.Drawing.SystemColors.Control;
            this.labelHaslo1.Location = new System.Drawing.Point(17, 91);
            this.labelHaslo1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHaslo1.Name = "labelHaslo1";
            this.labelHaslo1.Size = new System.Drawing.Size(91, 23);
            this.labelHaslo1.TabIndex = 4;
            this.labelHaslo1.Text = "Nazwisko";
            // 
            // txt_nazwisko
            // 
            this.txt_nazwisko.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_nazwisko.Location = new System.Drawing.Point(17, 116);
            this.txt_nazwisko.Margin = new System.Windows.Forms.Padding(2);
            this.txt_nazwisko.Name = "txt_nazwisko";
            this.txt_nazwisko.Size = new System.Drawing.Size(293, 28);
            this.txt_nazwisko.TabIndex = 1;
            // 
            // lb_nazwisko
            // 
            this.lb_nazwisko.AutoSize = true;
            this.lb_nazwisko.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_nazwisko.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_nazwisko.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nazwisko.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_nazwisko.Location = new System.Drawing.Point(18, 146);
            this.lb_nazwisko.Name = "lb_nazwisko";
            this.lb_nazwisko.Size = new System.Drawing.Size(53, 21);
            this.lb_nazwisko.TabIndex = 21;
            this.lb_nazwisko.Text = "label1";
            this.lb_nazwisko.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(17, 167);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 25;
            this.label1.Text = "Email";
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_email.Location = new System.Drawing.Point(17, 192);
            this.txt_email.Margin = new System.Windows.Forms.Padding(2);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(293, 28);
            this.txt_email.TabIndex = 2;
            // 
            // lb_email
            // 
            this.lb_email.AutoSize = true;
            this.lb_email.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_email.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_email.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_email.Location = new System.Drawing.Point(18, 222);
            this.lb_email.Name = "lb_email";
            this.lb_email.Size = new System.Drawing.Size(53, 21);
            this.lb_email.TabIndex = 27;
            this.lb_email.Text = "label1";
            this.lb_email.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(17, 243);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Login";
            // 
            // txt_login
            // 
            this.txt_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_login.Location = new System.Drawing.Point(17, 268);
            this.txt_login.Margin = new System.Windows.Forms.Padding(2);
            this.txt_login.Name = "txt_login";
            this.txt_login.Size = new System.Drawing.Size(293, 28);
            this.txt_login.TabIndex = 3;
            // 
            // lb_login
            // 
            this.lb_login.AutoSize = true;
            this.lb_login.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_login.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_login.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_login.Location = new System.Drawing.Point(18, 298);
            this.lb_login.Name = "lb_login";
            this.lb_login.Size = new System.Drawing.Size(53, 21);
            this.lb_login.TabIndex = 22;
            this.lb_login.Text = "label1";
            this.lb_login.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(17, 319);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 23);
            this.label3.TabIndex = 17;
            this.label3.Text = "Hasło";
            // 
            // txt_haslo1
            // 
            this.txt_haslo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_haslo1.Location = new System.Drawing.Point(17, 344);
            this.txt_haslo1.Margin = new System.Windows.Forms.Padding(2);
            this.txt_haslo1.Name = "txt_haslo1";
            this.txt_haslo1.PasswordChar = '*';
            this.txt_haslo1.Size = new System.Drawing.Size(293, 28);
            this.txt_haslo1.TabIndex = 5;
            // 
            // lb_haslo1
            // 
            this.lb_haslo1.AutoSize = true;
            this.lb_haslo1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_haslo1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_haslo1.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_haslo1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_haslo1.Location = new System.Drawing.Point(18, 374);
            this.lb_haslo1.Name = "lb_haslo1";
            this.lb_haslo1.Size = new System.Drawing.Size(53, 21);
            this.lb_haslo1.TabIndex = 23;
            this.lb_haslo1.Text = "label1";
            this.lb_haslo1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(17, 395);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "Powtórz hasło";
            // 
            // txt_haslo2
            // 
            this.txt_haslo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_haslo2.Location = new System.Drawing.Point(17, 420);
            this.txt_haslo2.Margin = new System.Windows.Forms.Padding(2);
            this.txt_haslo2.Name = "txt_haslo2";
            this.txt_haslo2.PasswordChar = '*';
            this.txt_haslo2.Size = new System.Drawing.Size(293, 28);
            this.txt_haslo2.TabIndex = 6;
            // 
            // lb_haslo2
            // 
            this.lb_haslo2.AutoSize = true;
            this.lb_haslo2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_haslo2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_haslo2.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_haslo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_haslo2.Location = new System.Drawing.Point(18, 450);
            this.lb_haslo2.Name = "lb_haslo2";
            this.lb_haslo2.Size = new System.Drawing.Size(53, 21);
            this.lb_haslo2.TabIndex = 24;
            this.lb_haslo2.Text = "label1";
            this.lb_haslo2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.button_anuluj);
            this.panel1.Controls.Add(this.button_rejestracja);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(18, 474);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 63);
            this.panel1.TabIndex = 28;
            // 
            // button_anuluj
            // 
            this.button_anuluj.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_anuluj.Location = new System.Drawing.Point(166, 14);
            this.button_anuluj.Margin = new System.Windows.Forms.Padding(2);
            this.button_anuluj.Name = "button_anuluj";
            this.button_anuluj.Size = new System.Drawing.Size(121, 47);
            this.button_anuluj.TabIndex = 8;
            this.button_anuluj.Text = "Anuluj";
            this.button_anuluj.UseVisualStyleBackColor = true;
            this.button_anuluj.Click += new System.EventHandler(this.button_anuluj_Click);
            // 
            // button_rejestracja
            // 
            this.button_rejestracja.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_rejestracja.Location = new System.Drawing.Point(4, 14);
            this.button_rejestracja.Margin = new System.Windows.Forms.Padding(2);
            this.button_rejestracja.Name = "button_rejestracja";
            this.button_rejestracja.Padding = new System.Windows.Forms.Padding(5);
            this.button_rejestracja.Size = new System.Drawing.Size(150, 47);
            this.button_rejestracja.TabIndex = 7;
            this.button_rejestracja.Text = "Zarejestruj";
            this.button_rejestracja.UseVisualStyleBackColor = true;
            this.button_rejestracja.Click += new System.EventHandler(this.button_rejestracja_Click);
            // 
            // lb_ogolny
            // 
            this.lb_ogolny.AutoSize = true;
            this.lb_ogolny.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_ogolny.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_ogolny.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ogolny.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_ogolny.Location = new System.Drawing.Point(18, 540);
            this.lb_ogolny.Name = "lb_ogolny";
            this.lb_ogolny.Size = new System.Drawing.Size(53, 21);
            this.lb_ogolny.TabIndex = 29;
            this.lb_ogolny.Text = "label1";
            this.lb_ogolny.Visible = false;
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
            // UC_rejestracja2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UC_rejestracja2";
            this.Size = new System.Drawing.Size(342, 591);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelLogin1;
        private System.Windows.Forms.TextBox txt_imie;
        private System.Windows.Forms.Label labelHaslo1;
        private System.Windows.Forms.TextBox txt_nazwisko;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_login;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_haslo1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_imie;
        private System.Windows.Forms.Label lb_nazwisko;
        private System.Windows.Forms.Label lb_login;
        private System.Windows.Forms.Label lb_haslo1;
        private System.Windows.Forms.TextBox txt_haslo2;
        private System.Windows.Forms.Label lb_haslo2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label lb_email;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_anuluj;
        private System.Windows.Forms.Button button_rejestracja;
        private System.Windows.Forms.Label lb_ogolny;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
