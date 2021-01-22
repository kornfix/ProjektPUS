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
            this.button_wyloguj = new System.Windows.Forms.Button();
            this.groupBoxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.BackColor = System.Drawing.SystemColors.ActiveBorder;
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
            // UC_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxLogin);
            this.Name = "UC_menu";
            this.Size = new System.Drawing.Size(252, 308);
            this.groupBoxLogin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.Button button_wyloguj;
    }
}
