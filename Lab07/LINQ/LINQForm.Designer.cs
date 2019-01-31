namespace LINQ
{
    partial class LINQForm
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.first_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.second_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronymic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.average_point = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scholarship = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OperationsCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OperationsMCB = new System.Windows.Forms.ComboBox();
            this.A = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.resultsTB = new System.Windows.Forms.TextBox();
            this.execute = new System.Windows.Forms.Button();
            this.comparation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.first_name,
            this.second_name,
            this.patronymic,
            this.group,
            this.average_point,
            this.scholarship,
            this.DOB});
            this.DGV.Location = new System.Drawing.Point(12, 37);
            this.DGV.Name = "DGV";
            this.DGV.RowTemplate.Height = 24;
            this.DGV.Size = new System.Drawing.Size(860, 435);
            this.DGV.TabIndex = 0;
            this.DGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_EditingControlShowing);
            this.DGV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DGV_KeyPress);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 50;
            // 
            // first_name
            // 
            this.first_name.HeaderText = "Имя";
            this.first_name.Name = "first_name";
            this.first_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // second_name
            // 
            this.second_name.HeaderText = "Фамилия";
            this.second_name.Name = "second_name";
            this.second_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // patronymic
            // 
            this.patronymic.HeaderText = "Отчество";
            this.patronymic.Name = "patronymic";
            this.patronymic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // group
            // 
            this.group.HeaderText = "Группа";
            this.group.Name = "group";
            this.group.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // average_point
            // 
            this.average_point.HeaderText = "Средний балл";
            this.average_point.Name = "average_point";
            // 
            // scholarship
            // 
            this.scholarship.HeaderText = "Стипендия";
            this.scholarship.Name = "scholarship";
            // 
            // DOB
            // 
            this.DOB.HeaderText = "Дата рождения";
            this.DOB.Name = "DOB";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1196, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // OperationsCB
            // 
            this.OperationsCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OperationsCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OperationsCB.FormattingEnabled = true;
            this.OperationsCB.Items.AddRange(new object[] {
            "Сортировка",
            "Фильтрация",
            "Группировка",
            "Вычисления"});
            this.OperationsCB.Location = new System.Drawing.Point(878, 57);
            this.OperationsCB.Name = "OperationsCB";
            this.OperationsCB.Size = new System.Drawing.Size(306, 28);
            this.OperationsCB.TabIndex = 2;
            this.OperationsCB.DropDownClosed += new System.EventHandler(this.OperationsCB_DropDownClosed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(878, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Операции:";
            // 
            // OperationsMCB
            // 
            this.OperationsMCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OperationsMCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OperationsMCB.FormattingEnabled = true;
            this.OperationsMCB.Location = new System.Drawing.Point(878, 91);
            this.OperationsMCB.Name = "OperationsMCB";
            this.OperationsMCB.Size = new System.Drawing.Size(306, 28);
            this.OperationsMCB.TabIndex = 4;
            // 
            // A
            // 
            this.A.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.A.Location = new System.Drawing.Point(924, 176);
            this.A.Multiline = true;
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(260, 28);
            this.A.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(878, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "A = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(878, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Результат:";
            // 
            // resultsTB
            // 
            this.resultsTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultsTB.Location = new System.Drawing.Point(878, 322);
            this.resultsTB.Multiline = true;
            this.resultsTB.Name = "resultsTB";
            this.resultsTB.ReadOnly = true;
            this.resultsTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resultsTB.Size = new System.Drawing.Size(306, 150);
            this.resultsTB.TabIndex = 8;
            this.resultsTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.resultsTB_KeyPress);
            // 
            // execute
            // 
            this.execute.BackColor = System.Drawing.SystemColors.Window;
            this.execute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.execute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.execute.Location = new System.Drawing.Point(878, 219);
            this.execute.Name = "execute";
            this.execute.Size = new System.Drawing.Size(142, 33);
            this.execute.TabIndex = 9;
            this.execute.Text = "Выполнить";
            this.execute.UseVisualStyleBackColor = false;
            this.execute.Click += new System.EventHandler(this.execute_Click);
            // 
            // comparation
            // 
            this.comparation.BackColor = System.Drawing.SystemColors.Window;
            this.comparation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comparation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comparation.Location = new System.Drawing.Point(1039, 219);
            this.comparation.Name = "comparation";
            this.comparation.Size = new System.Drawing.Size(142, 33);
            this.comparation.TabIndex = 10;
            this.comparation.Text = "Сравнение";
            this.comparation.UseVisualStyleBackColor = false;
            this.comparation.Click += new System.EventHandler(this.comparation_Click);
            // 
            // LINQForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1196, 484);
            this.Controls.Add(this.comparation);
            this.Controls.Add(this.execute);
            this.Controls.Add(this.resultsTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.A);
            this.Controls.Add(this.OperationsMCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OperationsCB);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LINQForm";
            this.Text = "LINQ to Objects";
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ComboBox OperationsCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox OperationsMCB;
        private System.Windows.Forms.TextBox A;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox resultsTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn first_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn second_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronymic;
        private System.Windows.Forms.DataGridViewTextBoxColumn group;
        private System.Windows.Forms.DataGridViewTextBoxColumn average_point;
        private System.Windows.Forms.DataGridViewTextBoxColumn scholarship;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOB;
        private System.Windows.Forms.Button execute;
        private System.Windows.Forms.Button comparation;
    }
}

