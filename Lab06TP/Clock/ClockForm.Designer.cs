namespace Clock
{
    partial class Clock
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.palitrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HourArrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MinuteArrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SecondArrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DigitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DivisionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DigitalClockColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SmalSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MidleSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BigSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.деленияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FirstStyletoolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.SecondStyletoolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.FormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SquareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DigitalClockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutProgramStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.palitrToolStripMenuItem,
            this.SizeToolStripMenuItem,
            this.деленияToolStripMenuItem,
            this.FormToolStripMenuItem,
            this.DigitalClockToolStripMenuItem,
            this.ResetSettingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.AboutProgramStripMenuItem1,
            this.ExitStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(222, 230);
            // 
            // palitrToolStripMenuItem
            // 
            this.palitrToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HourArrowToolStripMenuItem,
            this.MinuteArrowToolStripMenuItem,
            this.SecondArrowToolStripMenuItem,
            this.DigitsToolStripMenuItem,
            this.FormToolStripMenuItem1,
            this.DivisionToolStripMenuItem1,
            this.DigitalClockColorToolStripMenuItem});
            this.palitrToolStripMenuItem.Name = "palitrToolStripMenuItem";
            this.palitrToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.palitrToolStripMenuItem.Text = "Палитра";
            // 
            // HourArrowToolStripMenuItem
            // 
            this.HourArrowToolStripMenuItem.Name = "HourArrowToolStripMenuItem";
            this.HourArrowToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.HourArrowToolStripMenuItem.Text = "Часовая стрелка";
            this.HourArrowToolStripMenuItem.Click += new System.EventHandler(this.HourArrowToolStripMenuItem_Click);
            // 
            // MinuteArrowToolStripMenuItem
            // 
            this.MinuteArrowToolStripMenuItem.Name = "MinuteArrowToolStripMenuItem";
            this.MinuteArrowToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.MinuteArrowToolStripMenuItem.Text = "Минутная стрелка";
            this.MinuteArrowToolStripMenuItem.Click += new System.EventHandler(this.MinuteArrowToolStripMenuItem_Click);
            // 
            // SecondArrowToolStripMenuItem
            // 
            this.SecondArrowToolStripMenuItem.Name = "SecondArrowToolStripMenuItem";
            this.SecondArrowToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.SecondArrowToolStripMenuItem.Text = "Секундная стрелка";
            this.SecondArrowToolStripMenuItem.Click += new System.EventHandler(this.SecondArrowToolStripMenuItem_Click);
            // 
            // DigitsToolStripMenuItem
            // 
            this.DigitsToolStripMenuItem.Name = "DigitsToolStripMenuItem";
            this.DigitsToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.DigitsToolStripMenuItem.Text = "Цифры";
            this.DigitsToolStripMenuItem.Click += new System.EventHandler(this.DigitsToolStripMenuItem_Click);
            // 
            // FormToolStripMenuItem1
            // 
            this.FormToolStripMenuItem1.Name = "FormToolStripMenuItem1";
            this.FormToolStripMenuItem1.Size = new System.Drawing.Size(214, 26);
            this.FormToolStripMenuItem1.Text = "Форма";
            this.FormToolStripMenuItem1.Click += new System.EventHandler(this.FormToolStripMenuItem1_Click);
            // 
            // DivisionToolStripMenuItem1
            // 
            this.DivisionToolStripMenuItem1.Name = "DivisionToolStripMenuItem1";
            this.DivisionToolStripMenuItem1.Size = new System.Drawing.Size(214, 26);
            this.DivisionToolStripMenuItem1.Text = "Деления";
            this.DivisionToolStripMenuItem1.Click += new System.EventHandler(this.DivisionToolStripMenuItem1_Click);
            // 
            // DigitalClockColorToolStripMenuItem
            // 
            this.DigitalClockColorToolStripMenuItem.Name = "DigitalClockColorToolStripMenuItem";
            this.DigitalClockColorToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.DigitalClockColorToolStripMenuItem.Text = "Цифровые часы";
            this.DigitalClockColorToolStripMenuItem.Click += new System.EventHandler(this.DigitalClockColorToolStripMenuItem_Click);
            // 
            // SizeToolStripMenuItem
            // 
            this.SizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SmalSizeToolStripMenuItem,
            this.MidleSizeToolStripMenuItem,
            this.BigSizeToolStripMenuItem});
            this.SizeToolStripMenuItem.Name = "SizeToolStripMenuItem";
            this.SizeToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.SizeToolStripMenuItem.Text = "Размер ";
            // 
            // SmalSizeToolStripMenuItem
            // 
            this.SmalSizeToolStripMenuItem.Name = "SmalSizeToolStripMenuItem";
            this.SmalSizeToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.SmalSizeToolStripMenuItem.Text = "Маленький";
            this.SmalSizeToolStripMenuItem.Click += new System.EventHandler(this.SmalSizeToolStripMenuItem_Click);
            // 
            // MidleSizeToolStripMenuItem
            // 
            this.MidleSizeToolStripMenuItem.Name = "MidleSizeToolStripMenuItem";
            this.MidleSizeToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.MidleSizeToolStripMenuItem.Text = "Средний";
            this.MidleSizeToolStripMenuItem.Click += new System.EventHandler(this.MidleSizeToolStripMenuItem_Click);
            // 
            // BigSizeToolStripMenuItem
            // 
            this.BigSizeToolStripMenuItem.Name = "BigSizeToolStripMenuItem";
            this.BigSizeToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.BigSizeToolStripMenuItem.Text = "Большой";
            this.BigSizeToolStripMenuItem.Click += new System.EventHandler(this.BigSizeToolStripMenuItem_Click);
            // 
            // деленияToolStripMenuItem
            // 
            this.деленияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FirstStyletoolStripMenuItem2,
            this.SecondStyletoolStripMenuItem3});
            this.деленияToolStripMenuItem.Name = "деленияToolStripMenuItem";
            this.деленияToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.деленияToolStripMenuItem.Text = "Деления";
            // 
            // FirstStyletoolStripMenuItem2
            // 
            this.FirstStyletoolStripMenuItem2.Name = "FirstStyletoolStripMenuItem2";
            this.FirstStyletoolStripMenuItem2.Size = new System.Drawing.Size(181, 26);
            this.FirstStyletoolStripMenuItem2.Text = "1 стиль";
            this.FirstStyletoolStripMenuItem2.Click += new System.EventHandler(this.FirstStyletoolStripMenuItem2_Click);
            // 
            // SecondStyletoolStripMenuItem3
            // 
            this.SecondStyletoolStripMenuItem3.Name = "SecondStyletoolStripMenuItem3";
            this.SecondStyletoolStripMenuItem3.Size = new System.Drawing.Size(134, 26);
            this.SecondStyletoolStripMenuItem3.Text = "2 стиль";
            this.SecondStyletoolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // FormToolStripMenuItem
            // 
            this.FormToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CircleToolStripMenuItem,
            this.SquareToolStripMenuItem});
            this.FormToolStripMenuItem.Name = "FormToolStripMenuItem";
            this.FormToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.FormToolStripMenuItem.Text = "Форма";
            // 
            // CircleToolStripMenuItem
            // 
            this.CircleToolStripMenuItem.Name = "CircleToolStripMenuItem";
            this.CircleToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.CircleToolStripMenuItem.Text = "Окружность";
            this.CircleToolStripMenuItem.Click += new System.EventHandler(this.CircleToolStripMenuItem_Click);
            // 
            // SquareToolStripMenuItem
            // 
            this.SquareToolStripMenuItem.Name = "SquareToolStripMenuItem";
            this.SquareToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.SquareToolStripMenuItem.Text = "Квадрат";
            this.SquareToolStripMenuItem.Click += new System.EventHandler(this.SquareToolStripMenuItem_Click);
            // 
            // DigitalClockToolStripMenuItem
            // 
            this.DigitalClockToolStripMenuItem.CheckOnClick = true;
            this.DigitalClockToolStripMenuItem.Name = "DigitalClockToolStripMenuItem";
            this.DigitalClockToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.DigitalClockToolStripMenuItem.Text = "Цифровые часы";
            this.DigitalClockToolStripMenuItem.Click += new System.EventHandler(this.DigitalClockToolStripMenuItem_Click);
            // 
            // ResetSettingsToolStripMenuItem
            // 
            this.ResetSettingsToolStripMenuItem.Name = "ResetSettingsToolStripMenuItem";
            this.ResetSettingsToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.ResetSettingsToolStripMenuItem.Text = "Сбросить настройки";
            this.ResetSettingsToolStripMenuItem.Click += new System.EventHandler(this.ResetSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
            // 
            // AboutProgramStripMenuItem1
            // 
            this.AboutProgramStripMenuItem1.Name = "AboutProgramStripMenuItem1";
            this.AboutProgramStripMenuItem1.Size = new System.Drawing.Size(221, 24);
            this.AboutProgramStripMenuItem1.Text = "О программе";
            this.AboutProgramStripMenuItem1.Click += new System.EventHandler(this.AboutProgramStripMenuItem1_Click);
            // 
            // ExitStripMenuItem1
            // 
            this.ExitStripMenuItem1.Name = "ExitStripMenuItem1";
            this.ExitStripMenuItem1.Size = new System.Drawing.Size(221, 24);
            this.ExitStripMenuItem1.Text = "Выход";
            this.ExitStripMenuItem1.Click += new System.EventHandler(this.ExitStripMenuItem1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Clock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(280, 280);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Clock";
            this.Text = "Clock";
            this.Load += new System.EventHandler(this.Clock_Load);
            this.Shown += new System.EventHandler(this.Clock_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Clock_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Clock_MouseMove);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ExitStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem AboutProgramStripMenuItem1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem palitrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HourArrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MinuteArrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SecondArrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DigitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FormToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SmalSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MidleSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BigSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem деленияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FirstStyletoolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem SecondStyletoolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem FormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResetSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CircleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SquareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DigitalClockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DivisionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem DigitalClockColorToolStripMenuItem;
    }
}

