namespace BinaryTree
{
    partial class BinaryTreeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BinaryTreeForm));
            this.label1 = new System.Windows.Forms.Label();
            this.DataInput = new System.Windows.Forms.TextBox();
            this.Operations = new System.Windows.Forms.ComboBox();
            this.Calculate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Realisations = new System.Windows.Forms.ComboBox();
            this.Diagram = new System.Windows.Forms.Button();
            this.Results = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SaveBinaryTree = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MicrosoftGraph = new System.Windows.Forms.TabPage();
            this.gViewer = new Microsoft.Glee.GraphViewerGdi.GViewer();
            this.GraphTab = new System.Windows.Forms.TabControl();
            this.Graphvizbutton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.MicrosoftGraph.SuspendLayout();
            this.GraphTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Доступные операции:";
            // 
            // DataInput
            // 
            this.DataInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DataInput.Location = new System.Drawing.Point(12, 90);
            this.DataInput.Multiline = true;
            this.DataInput.Name = "DataInput";
            this.DataInput.Size = new System.Drawing.Size(284, 32);
            this.DataInput.TabIndex = 2;
            this.DataInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DataInput_KeyPress);
            // 
            // Operations
            // 
            this.Operations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Operations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Operations.FormattingEnabled = true;
            this.Operations.Items.AddRange(new object[] {
            "Вставка",
            "Удаление",
            "Высота",
            "Удаление дерева",
            "Максимальная ширина",
            "Количество узлов",
            "Поиск",
            "Максимальный элемент",
            "Минимальный элемент",
            "Обход в глубину(CLR)",
            "Обход в глубину(LCR)",
            "Обход в глубину(RCL)",
            "Обход в ширину",
            "Зеркальное отображение"});
            this.Operations.Location = new System.Drawing.Point(12, 56);
            this.Operations.Name = "Operations";
            this.Operations.Size = new System.Drawing.Size(284, 28);
            this.Operations.TabIndex = 3;
            // 
            // Calculate
            // 
            this.Calculate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Calculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Calculate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Calculate.Location = new System.Drawing.Point(12, 128);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(284, 28);
            this.Calculate.TabIndex = 4;
            this.Calculate.Text = "Выполнить";
            this.Calculate.UseVisualStyleBackColor = false;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(8, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Реализация класса:";
            // 
            // Realisations
            // 
            this.Realisations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Realisations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Realisations.FormattingEnabled = true;
            this.Realisations.Items.AddRange(new object[] {
            "АВЛ дерево на указателях",
            "Бинарное дерево на указателях",
            "Бинарное дерево на массиве"});
            this.Realisations.Location = new System.Drawing.Point(12, 197);
            this.Realisations.Name = "Realisations";
            this.Realisations.Size = new System.Drawing.Size(284, 28);
            this.Realisations.TabIndex = 6;
            this.Realisations.SelectedIndexChanged += new System.EventHandler(this.Realisations_SelectedIndexChanged);
            // 
            // Diagram
            // 
            this.Diagram.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Diagram.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Diagram.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Diagram.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Diagram.Location = new System.Drawing.Point(12, 231);
            this.Diagram.Name = "Diagram";
            this.Diagram.Size = new System.Drawing.Size(284, 34);
            this.Diagram.TabIndex = 7;
            this.Diagram.Text = "Диаграмма сравнения";
            this.Diagram.UseVisualStyleBackColor = false;
            this.Diagram.Click += new System.EventHandler(this.Diagramm_Click);
            // 
            // Results
            // 
            this.Results.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Results.Location = new System.Drawing.Point(12, 340);
            this.Results.Multiline = true;
            this.Results.Name = "Results";
            this.Results.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Results.Size = new System.Drawing.Size(284, 186);
            this.Results.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(8, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Результаты операции:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1054, 28);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.SaveBinaryTree});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.openToolStripMenuItem.Text = "&Open file";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(195, 6);
            // 
            // SaveBinaryTree
            // 
            this.SaveBinaryTree.Image = ((System.Drawing.Image)(resources.GetObject("SaveBinaryTree.Image")));
            this.SaveBinaryTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveBinaryTree.Name = "SaveBinaryTree";
            this.SaveBinaryTree.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveBinaryTree.Size = new System.Drawing.Size(198, 26);
            this.SaveBinaryTree.Text = "&Save tree";
            this.SaveBinaryTree.Click += new System.EventHandler(this.SaveBinaryTree_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.aboutToolStripMenuItem.Text = "&About program";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MicrosoftGraph
            // 
            this.MicrosoftGraph.Controls.Add(this.gViewer);
            this.MicrosoftGraph.Location = new System.Drawing.Point(4, 27);
            this.MicrosoftGraph.Name = "MicrosoftGraph";
            this.MicrosoftGraph.Padding = new System.Windows.Forms.Padding(3);
            this.MicrosoftGraph.Size = new System.Drawing.Size(717, 464);
            this.MicrosoftGraph.TabIndex = 0;
            this.MicrosoftGraph.Text = "Microsoft Automatic Graph Layout";
            this.MicrosoftGraph.UseVisualStyleBackColor = true;
            // 
            // gViewer
            // 
            this.gViewer.AsyncLayout = false;
            this.gViewer.AutoScroll = true;
            this.gViewer.BackwardEnabled = false;
            this.gViewer.ForwardEnabled = false;
            this.gViewer.Graph = null;
            this.gViewer.Location = new System.Drawing.Point(0, -2);
            this.gViewer.MouseHitDistance = 0.05D;
            this.gViewer.Name = "gViewer";
            this.gViewer.NavigationVisible = true;
            this.gViewer.PanButtonPressed = false;
            this.gViewer.SaveButtonVisible = true;
            this.gViewer.Size = new System.Drawing.Size(721, 470);
            this.gViewer.TabIndex = 17;
            this.gViewer.ZoomF = 1D;
            this.gViewer.ZoomFraction = 0.5D;
            this.gViewer.ZoomWindowThreshold = 0.05D;
            // 
            // GraphTab
            // 
            this.GraphTab.Controls.Add(this.MicrosoftGraph);
            this.GraphTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GraphTab.Location = new System.Drawing.Point(317, 31);
            this.GraphTab.Name = "GraphTab";
            this.GraphTab.SelectedIndex = 0;
            this.GraphTab.Size = new System.Drawing.Size(725, 495);
            this.GraphTab.TabIndex = 16;
            // 
            // Graphvizbutton
            // 
            this.Graphvizbutton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Graphvizbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Graphvizbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Graphvizbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Graphvizbutton.Location = new System.Drawing.Point(12, 271);
            this.Graphvizbutton.Name = "Graphvizbutton";
            this.Graphvizbutton.Size = new System.Drawing.Size(284, 34);
            this.Graphvizbutton.TabIndex = 17;
            this.Graphvizbutton.Text = "Graphviz изображение";
            this.Graphvizbutton.UseVisualStyleBackColor = false;
            this.Graphvizbutton.Click += new System.EventHandler(this.Graphvizbutton_Click);
            // 
            // BinaryTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1054, 536);
            this.Controls.Add(this.Graphvizbutton);
            this.Controls.Add(this.GraphTab);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Results);
            this.Controls.Add(this.Diagram);
            this.Controls.Add(this.Realisations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.Operations);
            this.Controls.Add(this.DataInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BinaryTreeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Binary tree";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MicrosoftGraph.ResumeLayout(false);
            this.GraphTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DataInput;
        private System.Windows.Forms.ComboBox Operations;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Realisations;
        private System.Windows.Forms.Button Diagram;
        private System.Windows.Forms.TextBox Results;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem SaveBinaryTree;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabPage MicrosoftGraph;
        private Microsoft.Glee.GraphViewerGdi.GViewer gViewer;
        private System.Windows.Forms.TabControl GraphTab;
        private System.Windows.Forms.Button Graphvizbutton;
    }
}

