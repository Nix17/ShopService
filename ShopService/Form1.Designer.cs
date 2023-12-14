namespace ShopService
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            comboBox1 = new ComboBox();
            tabPage2 = new TabPage();
            button6 = new Button();
            textBox5 = new TextBox();
            label8 = new Label();
            button5 = new Button();
            textBox3 = new TextBox();
            label7 = new Label();
            button4 = new Button();
            dataGridView2 = new DataGridView();
            ExportGoodName = new DataGridViewTextBoxColumn();
            ExportGoodPrice = new DataGridViewTextBoxColumn();
            ExportAmount = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            label6 = new Label();
            comboBox2 = new ComboBox();
            ImportAmount = new DataGridViewTextBoxColumn();
            ImportGoodPrice = new DataGridViewTextBoxColumn();
            ImportGoodName = new DataGridViewTextBoxColumn();
            button1 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            button2 = new Button();
            label3 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(575, 450);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(textBox4);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(567, 422);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Поставщик";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(295, 155);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 7;
            button3.Text = "Завезти";
            button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ImportGoodName, ImportGoodPrice, ImportAmount });
            dataGridView1.Location = new Point(27, 195);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(343, 150);
            dataGridView1.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 159);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 5;
            label5.Text = "Магазин";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(87, 155);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(202, 23);
            comboBox1.TabIndex = 4;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button6);
            tabPage2.Controls.Add(textBox5);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(button5);
            tabPage2.Controls.Add(textBox3);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(button4);
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(comboBox2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(567, 422);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Покупатель";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(15, 240);
            button6.Name = "button6";
            button6.Size = new Size(220, 42);
            button6.TabIndex = 21;
            button6.Text = "Поиск магазина с наименьшей стоимостью покупки";
            button6.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(75, 308);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(73, 23);
            textBox5.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 311);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 15;
            label8.Text = "Сумма";
            // 
            // button5
            // 
            button5.Location = new Point(160, 308);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 14;
            button5.Text = "Поиск";
            button5.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(357, 24);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(73, 23);
            textBox3.TabIndex = 13;
            textBox3.UseWaitCursor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(235, 28);
            label7.Name = "label7";
            label7.Size = new Size(116, 15);
            label7.TabIndex = 12;
            label7.Text = "Стоимость покупки";
            label7.UseWaitCursor = true;
            // 
            // button4
            // 
            button4.Location = new Point(453, 24);
            button4.Name = "button4";
            button4.Size = new Size(95, 23);
            button4.TabIndex = 11;
            button4.Text = "Купить";
            button4.UseVisualStyleBackColor = true;
            button4.UseWaitCursor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { ExportGoodName, ExportGoodPrice, ExportAmount, Total });
            dataGridView2.Location = new Point(15, 62);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(533, 150);
            dataGridView2.TabIndex = 10;
            // 
            // ExportGoodName
            // 
            ExportGoodName.HeaderText = "Товар";
            ExportGoodName.Name = "ExportGoodName";
            ExportGoodName.ReadOnly = true;
            ExportGoodName.Width = 170;
            // 
            // ExportGoodPrice
            // 
            ExportGoodPrice.HeaderText = "Цена";
            ExportGoodPrice.Name = "ExportGoodPrice";
            ExportGoodPrice.ReadOnly = true;
            // 
            // ExportAmount
            // 
            ExportAmount.HeaderText = "Количество";
            ExportAmount.Name = "ExportAmount";
            ExportAmount.Width = 120;
            // 
            // Total
            // 
            Total.HeaderText = "Итого";
            Total.Name = "Total";
            Total.ReadOnly = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 28);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 9;
            label6.Text = "Магазин";
            label6.UseWaitCursor = true;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(75, 24);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(142, 23);
            comboBox2.TabIndex = 8;
            comboBox2.UseWaitCursor = true;
            // 
            // ImportAmount
            // 
            ImportAmount.HeaderText = "Количество";
            ImportAmount.Name = "ImportAmount";
            ImportAmount.Width = 80;
            // 
            // ImportGoodPrice
            // 
            ImportGoodPrice.HeaderText = "Цена";
            ImportGoodPrice.Name = "ImportGoodPrice";
            ImportGoodPrice.Width = 50;
            // 
            // ImportGoodName
            // 
            ImportGoodName.HeaderText = "Товар";
            ImportGoodName.Name = "ImportGoodName";
            ImportGoodName.ReadOnly = true;
            ImportGoodName.Width = 170;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(465, 41);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.UseWaitCursor = true;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(204, 41);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(255, 23);
            textBox2.TabIndex = 11;
            textBox2.UseWaitCursor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(204, 23);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 10;
            label2.Text = "Адрес магазина";
            label2.UseWaitCursor = true;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(27, 42);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(171, 23);
            textBox1.TabIndex = 9;
            textBox1.UseWaitCursor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(27, 24);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 8;
            label1.Text = "Название магазина";
            label1.UseWaitCursor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(204, 98);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 16;
            button2.Text = "Добавить";
            button2.UseVisualStyleBackColor = true;
            button2.UseWaitCursor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(166, 80);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 15;
            label3.UseWaitCursor = true;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(27, 98);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(171, 23);
            textBox4.TabIndex = 14;
            textBox4.UseWaitCursor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(27, 80);
            label4.Name = "label4";
            label4.Size = new Size(130, 15);
            label4.TabIndex = 13;
            label4.Text = "Наименование товара";
            label4.UseWaitCursor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(574, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label5;
        private ComboBox comboBox1;
        private TabPage tabPage2;
        private DataGridView dataGridView1;
        private Button button3;
        private Button button4;
        private DataGridView dataGridView2;
        private Label label6;
        private ComboBox comboBox2;
        private Label label7;
        private TextBox textBox3;
        private TextBox textBox5;
        private Label label8;
        private Button button5;
        private Button button6;
        private DataGridViewTextBoxColumn ExportGoodName;
        private DataGridViewTextBoxColumn ExportGoodPrice;
        private DataGridViewTextBoxColumn ExportAmount;
        private DataGridViewTextBoxColumn Total;
        private Button button2;
        private Label label3;
        private TextBox textBox4;
        private Label label4;
        private Button button1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private DataGridViewTextBoxColumn ImportGoodName;
        private DataGridViewTextBoxColumn ImportGoodPrice;
        private DataGridViewTextBoxColumn ImportAmount;
    }
}