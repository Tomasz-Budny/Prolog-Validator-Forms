namespace FolderBrowser
{
    partial class Form1
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
            this.Okno_Wyszukiwań_Źródła_Pobrania = new System.Windows.Forms.FolderBrowserDialog();
            this.button_explore_source_code = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.button_do_tyłu_export_code = new System.Windows.Forms.Button();
            this.button_do_przodu_export_code = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_explore_export_code = new System.Windows.Forms.Button();
            this.Okno_Wuszukiwań_Docelowego_Źródła = new System.Windows.Forms.FolderBrowserDialog();
            this.button_LOCK_export_results_location = new System.Windows.Forms.Button();
            this.button_LOCK_source_code_location = new System.Windows.Forms.Button();
            this.text_Path_soruce_code = new System.Windows.Forms.TextBox();
            this.text_Path_export_location = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.process_button = new System.Windows.Forms.Button();
            this.button_do_tyłu_source_code = new System.Windows.Forms.Button();
            this.button_do_przodu_source_code = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_explore_source_code
            // 
            this.button_explore_source_code.Location = new System.Drawing.Point(540, 42);
            this.button_explore_source_code.Name = "button_explore_source_code";
            this.button_explore_source_code.Size = new System.Drawing.Size(75, 23);
            this.button_explore_source_code.TabIndex = 2;
            this.button_explore_source_code.Text = "Explore";
            this.button_explore_source_code.UseVisualStyleBackColor = true;
            this.button_explore_source_code.Click += new System.EventHandler(this.button_explore_source_code_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Path:";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 74);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(603, 271);
            this.webBrowser1.TabIndex = 5;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Location = new System.Drawing.Point(631, 74);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(603, 271);
            this.webBrowser2.TabIndex = 6;
            // 
            // button_do_tyłu_export_code
            // 
            this.button_do_tyłu_export_code.Location = new System.Drawing.Point(631, 42);
            this.button_do_tyłu_export_code.Name = "button_do_tyłu_export_code";
            this.button_do_tyłu_export_code.Size = new System.Drawing.Size(40, 23);
            this.button_do_tyłu_export_code.TabIndex = 7;
            this.button_do_tyłu_export_code.Text = "<<<";
            this.button_do_tyłu_export_code.UseVisualStyleBackColor = true;
            this.button_do_tyłu_export_code.Click += new System.EventHandler(this.button_do_tyłu_export_code_Click);
            // 
            // button_do_przodu_export_code
            // 
            this.button_do_przodu_export_code.Location = new System.Drawing.Point(677, 42);
            this.button_do_przodu_export_code.Name = "button_do_przodu_export_code";
            this.button_do_przodu_export_code.Size = new System.Drawing.Size(40, 23);
            this.button_do_przodu_export_code.TabIndex = 8;
            this.button_do_przodu_export_code.Text = ">>>";
            this.button_do_przodu_export_code.UseVisualStyleBackColor = true;
            this.button_do_przodu_export_code.Click += new System.EventHandler(this.button_do_przodu_export_code_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(723, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Path:";
            // 
            // button_explore_export_code
            // 
            this.button_explore_export_code.Location = new System.Drawing.Point(1159, 43);
            this.button_explore_export_code.Name = "button_explore_export_code";
            this.button_explore_export_code.Size = new System.Drawing.Size(75, 23);
            this.button_explore_export_code.TabIndex = 11;
            this.button_explore_export_code.Text = "Explore";
            this.button_explore_export_code.UseVisualStyleBackColor = true;
            this.button_explore_export_code.Click += new System.EventHandler(this.button_explore_export_code_Click);
            // 
            // button_LOCK_export_results_location
            // 
            this.button_LOCK_export_results_location.Location = new System.Drawing.Point(920, 351);
            this.button_LOCK_export_results_location.Name = "button_LOCK_export_results_location";
            this.button_LOCK_export_results_location.Size = new System.Drawing.Size(75, 23);
            this.button_LOCK_export_results_location.TabIndex = 12;
            this.button_LOCK_export_results_location.Text = "Lock";
            this.button_LOCK_export_results_location.UseVisualStyleBackColor = true;
            // 
            // button_LOCK_source_code_location
            // 
            this.button_LOCK_source_code_location.Location = new System.Drawing.Point(266, 351);
            this.button_LOCK_source_code_location.Name = "button_LOCK_source_code_location";
            this.button_LOCK_source_code_location.Size = new System.Drawing.Size(75, 23);
            this.button_LOCK_source_code_location.TabIndex = 13;
            this.button_LOCK_source_code_location.Text = "Lock";
            this.button_LOCK_source_code_location.UseVisualStyleBackColor = true;
            // 
            // text_Path_soruce_code
            // 
            this.text_Path_soruce_code.Location = new System.Drawing.Point(142, 43);
            this.text_Path_soruce_code.Name = "text_Path_soruce_code";
            this.text_Path_soruce_code.Size = new System.Drawing.Size(392, 20);
            this.text_Path_soruce_code.TabIndex = 14;
            // 
            // text_Path_export_location
            // 
            this.text_Path_export_location.Location = new System.Drawing.Point(761, 45);
            this.text_Path_export_location.Name = "text_Path_export_location";
            this.text_Path_export_location.ReadOnly = true;
            this.text_Path_export_location.Size = new System.Drawing.Size(392, 20);
            this.text_Path_export_location.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Source Code Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(627, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Export Results Location";
            // 
            // process_button
            // 
            this.process_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.process_button.Location = new System.Drawing.Point(568, 392);
            this.process_button.Name = "process_button";
            this.process_button.Size = new System.Drawing.Size(114, 30);
            this.process_button.TabIndex = 18;
            this.process_button.Text = "Process";
            this.process_button.UseVisualStyleBackColor = true;
            // 
            // button_do_tyłu_source_code
            // 
            this.button_do_tyłu_source_code.Location = new System.Drawing.Point(12, 42);
            this.button_do_tyłu_source_code.Name = "button_do_tyłu_source_code";
            this.button_do_tyłu_source_code.Size = new System.Drawing.Size(40, 23);
            this.button_do_tyłu_source_code.TabIndex = 19;
            this.button_do_tyłu_source_code.Text = "<<<";
            this.button_do_tyłu_source_code.UseVisualStyleBackColor = true;
            this.button_do_tyłu_source_code.Click += new System.EventHandler(this.button_do_tyłu_source_code_Click);
            // 
            // button_do_przodu_source_code
            // 
            this.button_do_przodu_source_code.Location = new System.Drawing.Point(58, 42);
            this.button_do_przodu_source_code.Name = "button_do_przodu_source_code";
            this.button_do_przodu_source_code.Size = new System.Drawing.Size(40, 23);
            this.button_do_przodu_source_code.TabIndex = 20;
            this.button_do_przodu_source_code.Text = ">>>";
            this.button_do_przodu_source_code.UseVisualStyleBackColor = true;
            this.button_do_przodu_source_code.Click += new System.EventHandler(this.button_do_przodu_source_code_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 450);
            this.Controls.Add(this.button_do_przodu_source_code);
            this.Controls.Add(this.button_do_tyłu_source_code);
            this.Controls.Add(this.process_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_Path_export_location);
            this.Controls.Add(this.text_Path_soruce_code);
            this.Controls.Add(this.button_LOCK_source_code_location);
            this.Controls.Add(this.button_LOCK_export_results_location);
            this.Controls.Add(this.button_explore_export_code);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_do_przodu_export_code);
            this.Controls.Add(this.button_do_tyłu_export_code);
            this.Controls.Add(this.webBrowser2);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_explore_source_code);
            this.Name = "Form1";
            this.Text = "Prolog RunCode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog Okno_Wyszukiwań_Źródła_Pobrania;
        private System.Windows.Forms.Button button_explore_source_code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.Button button_do_tyłu_export_code;
        private System.Windows.Forms.Button button_do_przodu_export_code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_explore_export_code;
        private System.Windows.Forms.FolderBrowserDialog Okno_Wuszukiwań_Docelowego_Źródła;
        private System.Windows.Forms.Button button_LOCK_export_results_location;
        private System.Windows.Forms.Button button_LOCK_source_code_location;
        private System.Windows.Forms.TextBox text_Path_soruce_code;
        private System.Windows.Forms.TextBox text_Path_export_location;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button process_button;
        private System.Windows.Forms.Button button_do_tyłu_source_code;
        private System.Windows.Forms.Button button_do_przodu_source_code;
    }
}

