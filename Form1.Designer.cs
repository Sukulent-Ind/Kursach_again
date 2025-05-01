namespace Kursach_again
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            label3 = new Label();
            make_random = new CheckBox();
            groupBox1 = new GroupBox();
            show_matrix = new Button();
            label4 = new Label();
            choose_scale = new ComboBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            button3 = new Button();
            test_number = new NumericUpDown();
            button2 = new Button();
            label6 = new Label();
            label5 = new Label();
            field_width = new NumericUpDown();
            number_of_squares = new NumericUpDown();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)test_number).BeginInit();
            ((System.ComponentModel.ISupportInitialize)field_width).BeginInit();
            ((System.ComponentModel.ISupportInitialize)number_of_squares).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(32, 163);
            button1.Name = "button1";
            button1.Size = new Size(191, 23);
            button1.TabIndex = 0;
            button1.Text = "Начать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 25);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 1;
            label1.Text = "Ширина поля";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 69);
            label3.Name = "label3";
            label3.Size = new Size(130, 15);
            label3.TabIndex = 5;
            label3.Text = "Количество квадартов";
            // 
            // make_random
            // 
            make_random.AutoSize = true;
            make_random.Location = new Point(32, 107);
            make_random.Name = "make_random";
            make_random.Size = new Size(191, 19);
            make_random.TabIndex = 7;
            make_random.Text = "Случайный размер квадратов";
            make_random.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(show_matrix);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(choose_scale);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(248, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(155, 183);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Доп. опции";
            // 
            // show_matrix
            // 
            show_matrix.Enabled = false;
            show_matrix.Location = new Point(11, 99);
            show_matrix.Name = "show_matrix";
            show_matrix.Size = new Size(87, 23);
            show_matrix.TabIndex = 3;
            show_matrix.Text = "Показать";
            show_matrix.UseVisualStyleBackColor = true;
            show_matrix.Click += show_matrix_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 81);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 2;
            label4.Text = "Матрица";
            // 
            // choose_scale
            // 
            choose_scale.FormattingEnabled = true;
            choose_scale.Location = new Point(11, 42);
            choose_scale.Name = "choose_scale";
            choose_scale.Size = new Size(121, 23);
            choose_scale.TabIndex = 1;
            choose_scale.TextChanged += choose_scale_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 24);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 0;
            label2.Text = "Масштаб";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(test_number);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(426, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(115, 183);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Тестирование";
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(7, 151);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 4;
            button3.Text = "Тест";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // test_number
            // 
            test_number.Enabled = false;
            test_number.Location = new Point(6, 101);
            test_number.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            test_number.Name = "test_number";
            test_number.Size = new Size(58, 23);
            test_number.TabIndex = 3;
            test_number.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // button2
            // 
            button2.Location = new Point(6, 41);
            button2.Name = "button2";
            button2.Size = new Size(92, 23);
            button2.TabIndex = 2;
            button2.Text = "Активировать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 81);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 1;
            label6.Text = "Номер теста";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 24);
            label5.Name = "label5";
            label5.Size = new Size(100, 15);
            label5.TabIndex = 0;
            label5.Text = "Тестовый режим";
            // 
            // field_width
            // 
            field_width.Location = new Point(165, 25);
            field_width.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            field_width.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            field_width.Name = "field_width";
            field_width.Size = new Size(58, 23);
            field_width.TabIndex = 4;
            field_width.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // number_of_squares
            // 
            number_of_squares.Location = new Point(165, 69);
            number_of_squares.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            number_of_squares.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            number_of_squares.Name = "number_of_squares";
            number_of_squares.Size = new Size(58, 23);
            number_of_squares.TabIndex = 10;
            number_of_squares.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 207);
            Controls.Add(number_of_squares);
            Controls.Add(field_width);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(make_random);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Расстановка квадратов";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)test_number).EndInit();
            ((System.ComponentModel.ISupportInitialize)field_width).EndInit();
            ((System.ComponentModel.ISupportInitialize)number_of_squares).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label3;
        private CheckBox make_random;
        private GroupBox groupBox1;
        private Label label2;
        private Button show_matrix;
        private Label label4;
        private ComboBox choose_scale;
        private GroupBox groupBox2;
        private NumericUpDown test_number;
        private Button button2;
        private Label label6;
        private Label label5;
        private NumericUpDown field_width;
        private NumericUpDown number_of_squares;
        private Button button3;
    }
}
