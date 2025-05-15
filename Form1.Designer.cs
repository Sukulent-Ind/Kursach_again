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
            choose_scale = new ComboBox();
            label2 = new Label();
            test_group = new GroupBox();
            show_matrix = new Button();
            label4 = new Label();
            button3 = new Button();
            test_number = new NumericUpDown();
            button2 = new Button();
            label6 = new Label();
            label5 = new Label();
            field_width = new NumericUpDown();
            number_of_squares = new NumericUpDown();
            groupBox1 = new GroupBox();
            test_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)test_number).BeginInit();
            ((System.ComponentModel.ISupportInitialize)field_width).BeginInit();
            ((System.ComponentModel.ISupportInitialize)number_of_squares).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(16, 170);
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
            label1.Location = new Point(17, 32);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 1;
            label1.Text = "Ширина поля";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 76);
            label3.Name = "label3";
            label3.Size = new Size(130, 15);
            label3.TabIndex = 5;
            label3.Text = "Количество квадартов";
            // 
            // choose_scale
            // 
            choose_scale.FormattingEnabled = true;
            choose_scale.Location = new Point(86, 123);
            choose_scale.Name = "choose_scale";
            choose_scale.Size = new Size(121, 23);
            choose_scale.TabIndex = 1;
            choose_scale.TextChanged += choose_scale_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 126);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 0;
            label2.Text = "Масштаб";
            // 
            // test_group
            // 
            test_group.Controls.Add(show_matrix);
            test_group.Controls.Add(label4);
            test_group.Controls.Add(button3);
            test_group.Controls.Add(test_number);
            test_group.Controls.Add(button2);
            test_group.Controls.Add(label6);
            test_group.Controls.Add(label5);
            test_group.Location = new Point(261, 12);
            test_group.Name = "test_group";
            test_group.Size = new Size(231, 207);
            test_group.TabIndex = 9;
            test_group.TabStop = false;
            test_group.Text = "Тестирование";
            test_group.Visible = false;
            // 
            // show_matrix
            // 
            show_matrix.Enabled = false;
            show_matrix.Location = new Point(118, 123);
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
            label4.Location = new Point(6, 123);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 2;
            label4.Text = "Матрица";
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(50, 170);
            button3.Name = "button3";
            button3.Size = new Size(140, 23);
            button3.TabIndex = 4;
            button3.Text = "Тест";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // test_number
            // 
            test_number.Enabled = false;
            test_number.Location = new Point(118, 78);
            test_number.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            test_number.Name = "test_number";
            test_number.Size = new Size(58, 23);
            test_number.TabIndex = 3;
            test_number.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // button2
            // 
            button2.Location = new Point(118, 31);
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
            label6.Location = new Point(6, 78);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 1;
            label6.Text = "Номер теста";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 31);
            label5.Name = "label5";
            label5.Size = new Size(100, 15);
            label5.TabIndex = 0;
            label5.Text = "Тестовый режим";
            // 
            // field_width
            // 
            field_width.Location = new Point(149, 32);
            field_width.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            field_width.Name = "field_width";
            field_width.Size = new Size(58, 23);
            field_width.TabIndex = 4;
            field_width.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // number_of_squares
            // 
            number_of_squares.Location = new Point(149, 76);
            number_of_squares.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            number_of_squares.Name = "number_of_squares";
            number_of_squares.Size = new Size(58, 23);
            number_of_squares.TabIndex = 10;
            number_of_squares.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(number_of_squares);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(field_width);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(choose_scale);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(238, 207);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(503, 229);
            Controls.Add(groupBox1);
            Controls.Add(test_group);
            KeyPreview = true;
            Name = "Form1";
            Text = "Расстановка квадратов";
            KeyDown += Form1_KeyDown;
            test_group.ResumeLayout(false);
            test_group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)test_number).EndInit();
            ((System.ComponentModel.ISupportInitialize)field_width).EndInit();
            ((System.ComponentModel.ISupportInitialize)number_of_squares).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label3;
        private Label label2;
        private ComboBox choose_scale;
        private GroupBox test_group;
        private NumericUpDown test_number;
        private Button button2;
        private Label label6;
        private Label label5;
        private NumericUpDown field_width;
        private NumericUpDown number_of_squares;
        private Button button3;
        private Label label4;
        private Button show_matrix;
        private GroupBox groupBox1;
    }
}
