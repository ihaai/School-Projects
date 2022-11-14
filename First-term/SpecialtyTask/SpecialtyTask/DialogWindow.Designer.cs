namespace SQLTask
{
    partial class DialogWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.dbViewDuplicateGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dbViewDuplicateGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Намерени са два или повече теста с един и същ вариант";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Изберете кой да бъде показан";
            // 
            // exitButton
            // 
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.Red;
            this.exitButton.Location = new System.Drawing.Point(0, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(571, 33);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // dbViewDuplicateGrid
            // 
            this.dbViewDuplicateGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbViewDuplicateGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dbViewDuplicateGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dbViewDuplicateGrid.Location = new System.Drawing.Point(12, 102);
            this.dbViewDuplicateGrid.Name = "dbViewDuplicateGrid";
            this.dbViewDuplicateGrid.Size = new System.Drawing.Size(547, 325);
            this.dbViewDuplicateGrid.TabIndex = 3;
            this.dbViewDuplicateGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DBViewDuplicateGrid_CellDoubleClick);
            // 
            // DialogWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 439);
            this.Controls.Add(this.dbViewDuplicateGrid);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DialogWindow";
            this.Text = "DialogWindow";
            ((System.ComponentModel.ISupportInitialize)(this.dbViewDuplicateGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.DataGridView dbViewDuplicateGrid;
    }
}