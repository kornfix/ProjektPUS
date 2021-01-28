
namespace WindowsFormsApp2
{
    partial class UC_Lobby
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
            this.btn_dolacz = new System.Windows.Forms.Button();
            this.l_numer = new System.Windows.Forms.Label();
            this.l_gracz1 = new System.Windows.Forms.Label();
            this.l_gracz2 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.l_inf = new System.Windows.Forms.Label();
            this.timer_aktywnosc = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_dolacz
            // 
            this.btn_dolacz.Location = new System.Drawing.Point(205, 61);
            this.btn_dolacz.Name = "btn_dolacz";
            this.btn_dolacz.Size = new System.Drawing.Size(91, 24);
            this.btn_dolacz.TabIndex = 0;
            this.btn_dolacz.Text = "Dołacz";
            this.btn_dolacz.UseVisualStyleBackColor = true;
            this.btn_dolacz.Click += new System.EventHandler(this.btn_dolacz_Click);
            // 
            // l_numer
            // 
            this.l_numer.AutoSize = true;
            this.l_numer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_numer.Location = new System.Drawing.Point(19, 10);
            this.l_numer.Name = "l_numer";
            this.l_numer.Size = new System.Drawing.Size(18, 20);
            this.l_numer.TabIndex = 1;
            this.l_numer.Text = "1";
            // 
            // l_gracz1
            // 
            this.l_gracz1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_gracz1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_gracz1.Location = new System.Drawing.Point(19, 36);
            this.l_gracz1.Name = "l_gracz1";
            this.l_gracz1.Size = new System.Drawing.Size(130, 22);
            this.l_gracz1.TabIndex = 2;
            this.l_gracz1.Text = "Gracz2";
            // 
            // l_gracz2
            // 
            this.l_gracz2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_gracz2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_gracz2.Location = new System.Drawing.Point(166, 36);
            this.l_gracz2.Name = "l_gracz2";
            this.l_gracz2.Size = new System.Drawing.Size(130, 22);
            this.l_gracz2.TabIndex = 3;
            this.l_gracz2.Text = "Gracz1";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(124, 62);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 4;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // l_inf
            // 
            this.l_inf.AutoSize = true;
            this.l_inf.Location = new System.Drawing.Point(82, 15);
            this.l_inf.Name = "l_inf";
            this.l_inf.Size = new System.Drawing.Size(117, 13);
            this.l_inf.TabIndex = 5;
            this.l_inf.Text = "Oczekiwanie na graczy";
            // 
            // timer_aktywnosc
            // 
            this.timer_aktywnosc.Interval = 1000;
            this.timer_aktywnosc.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UC_Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.l_inf);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.l_gracz2);
            this.Controls.Add(this.l_gracz1);
            this.Controls.Add(this.l_numer);
            this.Controls.Add(this.btn_dolacz);
            this.Name = "UC_Lobby";
            this.Size = new System.Drawing.Size(308, 94);
            this.Load += new System.EventHandler(this.UC_Lobby_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_dolacz;
        private System.Windows.Forms.Label l_numer;
        private System.Windows.Forms.Label l_gracz1;
        private System.Windows.Forms.Label l_gracz2;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label l_inf;
        private System.Windows.Forms.Timer timer_aktywnosc;
    }
}
