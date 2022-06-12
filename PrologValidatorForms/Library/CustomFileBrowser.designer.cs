
namespace PrologValidatorForms.Library
{
    partial class Eksplorator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Eksplorator));
            this.listView = new System.Windows.Forms.ListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnChoose = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.btnBackward = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.BackColor = System.Drawing.Color.White;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.dateColumn,
            this.typeColumn,
            this.sizeColumn});
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(9, 37);
            this.listView.Margin = new System.Windows.Forms.Padding(2);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(650, 320);
            this.listView.SmallImageList = this.imageList;
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Nazwa";
            // 
            // dateColumn
            // 
            this.dateColumn.Text = "Data utworzenia";
            this.dateColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // typeColumn
            // 
            this.typeColumn.Text = "Typ";
            this.typeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sizeColumn
            // 
            this.sizeColumn.Text = "Rozmiar";
            this.sizeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Folder-icon.png");
            // 
            // btnChoose
            // 
            this.btnChoose.BackColor = System.Drawing.Color.SlateGray;
            this.btnChoose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChoose.FlatAppearance.BorderSize = 0;
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoose.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnChoose.ForeColor = System.Drawing.Color.Black;
            this.btnChoose.Location = new System.Drawing.Point(515, 10);
            this.btnChoose.Margin = new System.Windows.Forms.Padding(2);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(144, 22);
            this.btnChoose.TabIndex = 1;
            this.btnChoose.Text = "Wybierz";
            this.btnChoose.UseVisualStyleBackColor = false;
            this.btnChoose.Click += new System.EventHandler(this.button_Click);
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBox.Location = new System.Drawing.Point(162, 11);
            this.textBox.Margin = new System.Windows.Forms.Padding(2);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(349, 22);
            this.textBox.TabIndex = 2;
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // btnBackward
            // 
            this.btnBackward.BackColor = System.Drawing.Color.SlateGray;
            this.btnBackward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackward.Font = new System.Drawing.Font("Forte", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackward.Location = new System.Drawing.Point(10, 10);
            this.btnBackward.Margin = new System.Windows.Forms.Padding(2);
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(69, 20);
            this.btnBackward.TabIndex = 3;
            this.btnBackward.Text = "<<";
            this.btnBackward.UseVisualStyleBackColor = false;
            this.btnBackward.Click += new System.EventHandler(this.btnBackward_Click);
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.Color.SlateGray;
            this.btnForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.Font = new System.Drawing.Font("Forte", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForward.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnForward.Location = new System.Drawing.Point(83, 10);
            this.btnForward.Margin = new System.Windows.Forms.Padding(2);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(75, 20);
            this.btnForward.TabIndex = 4;
            this.btnForward.Text = ">>";
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // Eksplorator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnBackward);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.listView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Eksplorator";
            this.Size = new System.Drawing.Size(672, 369);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader dateColumn;
        private System.Windows.Forms.ColumnHeader typeColumn;
        private System.Windows.Forms.ColumnHeader sizeColumn;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btnBackward;
        private System.Windows.Forms.Button btnForward;
    }
}

