namespace Clicker
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.nudRepeatTimes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lCursorPosition = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudRepeatInterval = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.lCliksPerformed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepeatTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepeatInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(127, 157);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // nudRepeatTimes
            // 
            this.nudRepeatTimes.Location = new System.Drawing.Point(9, 32);
            this.nudRepeatTimes.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudRepeatTimes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRepeatTimes.Name = "nudRepeatTimes";
            this.nudRepeatTimes.Size = new System.Drawing.Size(70, 20);
            this.nudRepeatTimes.TabIndex = 1;
            this.nudRepeatTimes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Times";
            // 
            // nudX
            // 
            this.nudX.Location = new System.Drawing.Point(28, 19);
            this.nudX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(51, 20);
            this.nudX.TabIndex = 3;
            this.nudX.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nudY
            // 
            this.nudY.Location = new System.Drawing.Point(127, 19);
            this.nudY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(51, 20);
            this.nudY.TabIndex = 4;
            this.nudY.Value = new decimal(new int[] {
            1050,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lCursorPosition);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudX);
            this.groupBox1.Controls.Add(this.nudY);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 71);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cursor Position";
            // 
            // lCursorPosition
            // 
            this.lCursorPosition.AutoSize = true;
            this.lCursorPosition.Location = new System.Drawing.Point(6, 46);
            this.lCursorPosition.Name = "lCursorPosition";
            this.lCursorPosition.Size = new System.Drawing.Size(149, 13);
            this.lCursorPosition.TabIndex = 7;
            this.lCursorPosition.Text = "Current Position: X:100 Y: 100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "X:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudRepeatInterval);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.nudRepeatTimes);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 62);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Repeat";
            // 
            // nudRepeatInterval
            // 
            this.nudRepeatInterval.Location = new System.Drawing.Point(106, 32);
            this.nudRepeatInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRepeatInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRepeatInterval.Name = "nudRepeatInterval";
            this.nudRepeatInterval.Size = new System.Drawing.Size(70, 20);
            this.nudRepeatInterval.TabIndex = 4;
            this.nudRepeatInterval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudRepeatInterval.ValueChanged += new System.EventHandler(this.nudRepeatInterval_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Interval";
            // 
            // lCliksPerformed
            // 
            this.lCliksPerformed.AutoSize = true;
            this.lCliksPerformed.Location = new System.Drawing.Point(9, 162);
            this.lCliksPerformed.Name = "lCliksPerformed";
            this.lCliksPerformed.Size = new System.Drawing.Size(78, 13);
            this.lCliksPerformed.TabIndex = 7;
            this.lCliksPerformed.Text = "Performed: 0/0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Use Win+D to stop";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 210);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lCliksPerformed);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Clicker";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.nudRepeatTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepeatInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown nudRepeatTimes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudX;
        private System.Windows.Forms.NumericUpDown nudY;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lCursorPosition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudRepeatInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lCliksPerformed;
        private System.Windows.Forms.Label label4;
    }
}

