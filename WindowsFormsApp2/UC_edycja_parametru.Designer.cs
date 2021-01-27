
namespace WindowsFormsApp2
{
    partial class UC_edycja_parametru
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
            this.btn_edycja = new System.Windows.Forms.Button();
            this.txt_edytowany = new System.Windows.Forms.TextBox();
            this.l_parametr = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_edycja
            // 
            this.btn_edycja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_edycja.Location = new System.Drawing.Point(254, 11);
            this.btn_edycja.Name = "btn_edycja";
            this.btn_edycja.Size = new System.Drawing.Size(75, 23);
            this.btn_edycja.TabIndex = 0;
            this.btn_edycja.Text = "Edycja";
            this.btn_edycja.UseVisualStyleBackColor = true;
            this.btn_edycja.Click += new System.EventHandler(this.btn_edycja_Click);
            // 
            // txt_edytowany
            // 
            this.txt_edytowany.Enabled = false;
            this.txt_edytowany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_edytowany.Location = new System.Drawing.Point(100, 11);
            this.txt_edytowany.Name = "txt_edytowany";
            this.txt_edytowany.Size = new System.Drawing.Size(123, 22);
            this.txt_edytowany.TabIndex = 1;
            // 
            // l_parametr
            // 
            this.l_parametr.AutoSize = true;
            this.l_parametr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_parametr.Location = new System.Drawing.Point(12, 15);
            this.l_parametr.Name = "l_parametr";
            this.l_parametr.Size = new System.Drawing.Size(45, 16);
            this.l_parametr.TabIndex = 2;
            this.l_parametr.Text = "label1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UC_edycja_parametru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.l_parametr);
            this.Controls.Add(this.txt_edytowany);
            this.Controls.Add(this.btn_edycja);
            this.Name = "UC_edycja_parametru";
            this.Size = new System.Drawing.Size(347, 36);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_edycja;
        private System.Windows.Forms.TextBox txt_edytowany;
        private System.Windows.Forms.Label l_parametr;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
