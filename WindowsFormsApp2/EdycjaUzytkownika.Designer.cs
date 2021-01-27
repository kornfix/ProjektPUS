
namespace WindowsFormsApp2
{
    partial class EdycjaUzytkownika
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flp_edycja_uzytkownika = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_anuluj = new System.Windows.Forms.Button();
            this.button_rejestracja = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flp_edycja_uzytkownika, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.033183F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.96682F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(389, 663);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flp_edycja_uzytkownika
            // 
            this.flp_edycja_uzytkownika.AutoScroll = true;
            this.flp_edycja_uzytkownika.AutoSize = true;
            this.flp_edycja_uzytkownika.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_edycja_uzytkownika.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_edycja_uzytkownika.Location = new System.Drawing.Point(3, 39);
            this.flp_edycja_uzytkownika.Name = "flp_edycja_uzytkownika";
            this.flp_edycja_uzytkownika.Size = new System.Drawing.Size(383, 567);
            this.flp_edycja_uzytkownika.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 30);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edycja użytkowniika";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_anuluj);
            this.panel2.Controls.Add(this.button_rejestracja);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 612);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(383, 48);
            this.panel2.TabIndex = 2;
            // 
            // button_anuluj
            // 
            this.button_anuluj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_anuluj.Location = new System.Drawing.Point(245, 12);
            this.button_anuluj.Margin = new System.Windows.Forms.Padding(2);
            this.button_anuluj.Name = "button_anuluj";
            this.button_anuluj.Size = new System.Drawing.Size(90, 28);
            this.button_anuluj.TabIndex = 10;
            this.button_anuluj.Text = "Anuluj";
            this.button_anuluj.UseVisualStyleBackColor = true;
            this.button_anuluj.Click += new System.EventHandler(this.button_anuluj_Click);
            // 
            // button_rejestracja
            // 
            this.button_rejestracja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_rejestracja.Location = new System.Drawing.Point(26, 12);
            this.button_rejestracja.Margin = new System.Windows.Forms.Padding(2);
            this.button_rejestracja.Name = "button_rejestracja";
            this.button_rejestracja.Size = new System.Drawing.Size(160, 28);
            this.button_rejestracja.TabIndex = 9;
            this.button_rejestracja.Text = "Zatwierdź zmianny";
            this.button_rejestracja.UseVisualStyleBackColor = true;
            this.button_rejestracja.Click += new System.EventHandler(this.button_rejestracja_Click);
            // 
            // EdycjaUzytkownika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 663);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EdycjaUzytkownika";
            this.Text = "EdycjaUzytkownika";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flp_edycja_uzytkownika;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_anuluj;
        private System.Windows.Forms.Button button_rejestracja;
    }
}