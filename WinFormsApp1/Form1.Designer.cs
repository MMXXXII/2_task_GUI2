﻿namespace WinFormsApp1
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 9);
            label1.Name = "label1";
            label1.Size = new Size(705, 20);
            label1.TabIndex = 0;
            label1.Text = "Дано предложение. Определить, сколько в нем одинаковых соседних букв. Пробелы не учитывать.";

            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 57);
            label2.Name = "label2";
            label2.Size = new Size(172, 20);
            label2.TabIndex = 1;
            label2.Text = "Введите предложение: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(219, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(555, 27);
            textBox1.TabIndex = 2;

            // 
            // button1
            // 
            button1.Location = new Point(232, 102);
            button1.Name = "button1";
            button1.Size = new Size(367, 29);
            button1.TabIndex = 3;
            button1.Text = "Подсчитать количество соседних букв";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
    }
}
