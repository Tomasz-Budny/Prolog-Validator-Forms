
namespace PrologValidatorForms
{
    partial class Main
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

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.cb2 = new PrologValidatorForms.Eksplorator();
            this.cb1 = new PrologValidatorForms.Eksplorator();
            this.btn_export = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(21, 414);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(1023, 31);
            this.btn_confirm.TabIndex = 8;
            this.btn_confirm.Text = "Zatwierdź";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(719, 560);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(133, 13);
            this.labelInfo.TabIndex = 9;
            this.labelInfo.Text = "Jakiś tekst żeby nie zgubić";
            // 
            // cb2
            // 
            this.cb2.Location = new System.Drawing.Point(531, 40);
            this.cb2.Margin = new System.Windows.Forms.Padding(1);
            this.cb2.Name = "cb2";
            this.cb2.Size = new System.Drawing.Size(525, 369);
            this.cb2.TabIndex = 7;
            this.cb2.Load += new System.EventHandler(this.cb2_Load);
            // 
            // cb1
            // 
            this.cb1.Location = new System.Drawing.Point(11, 40);
            this.cb1.Margin = new System.Windows.Forms.Padding(1);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(525, 369);
            this.cb1.TabIndex = 6;
            this.cb1.Load += new System.EventHandler(this.cb1_Load);
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(21, 473);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(75, 23);
            this.btn_export.TabIndex = 10;
            this.btn_export.Text = "Zapisz";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 608);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.cb2);
            this.Controls.Add(this.cb1);
            this.Name = "Main";
            this.Text = "Prolog Validator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private string pathName = "";
        private string finalPath = "";
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private Eksplorator cb1;
        private Eksplorator cb2;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button btn_export;
    }
}

