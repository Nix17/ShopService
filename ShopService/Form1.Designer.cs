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
            btnAddProviderProduct = new Button();
            label3 = new Label();
            txtBoxProviderProductName = new TextBox();
            label4 = new Label();
            btnAddProviderStore = new Button();
            txtBoxProviderStoreAddress = new TextBox();
            label2 = new Label();
            txtBoxProviderStoreName = new TextBox();
            label1 = new Label();
            btnProviderDelivery = new Button();
            dtGridProviderProducts = new DataGridView();
            ImportGoodId = new DataGridViewTextBoxColumn();
            ImportGoodName = new DataGridViewTextBoxColumn();
            ImportGoodPrice = new DataGridViewTextBoxColumn();
            ImportAmount = new DataGridViewTextBoxColumn();
            label5 = new Label();
            cmbBoxProviderStores = new ComboBox();
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
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtGridProviderProducts).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1, 0);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(657, 600);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnAddProviderProduct);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(txtBoxProviderProductName);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(btnAddProviderStore);
            tabPage1.Controls.Add(txtBoxProviderStoreAddress);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(txtBoxProviderStoreName);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(btnProviderDelivery);
            tabPage1.Controls.Add(dtGridProviderProducts);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(cmbBoxProviderStores);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(649, 567);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Поставщик";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddProviderProduct
            // 
            btnAddProviderProduct.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddProviderProduct.Location = new Point(233, 131);
            btnAddProviderProduct.Margin = new Padding(3, 4, 3, 4);
            btnAddProviderProduct.Name = "btnAddProviderProduct";
            btnAddProviderProduct.Size = new Size(86, 31);
            btnAddProviderProduct.TabIndex = 16;
            btnAddProviderProduct.Text = "Добавить";
            btnAddProviderProduct.UseVisualStyleBackColor = true;
            btnAddProviderProduct.UseWaitCursor = true;
            btnAddProviderProduct.Click += btnAddProviderProduct_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(190, 107);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 15;
            label3.UseWaitCursor = true;
            // 
            // txtBoxProviderProductName
            // 
            txtBoxProviderProductName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxProviderProductName.Location = new Point(31, 131);
            txtBoxProviderProductName.Margin = new Padding(3, 4, 3, 4);
            txtBoxProviderProductName.Name = "txtBoxProviderProductName";
            txtBoxProviderProductName.Size = new Size(195, 27);
            txtBoxProviderProductName.TabIndex = 14;
            txtBoxProviderProductName.UseWaitCursor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(31, 107);
            label4.Name = "label4";
            label4.Size = new Size(168, 20);
            label4.TabIndex = 13;
            label4.Text = "Наименование товара";
            label4.UseWaitCursor = true;
            // 
            // btnAddProviderStore
            // 
            btnAddProviderStore.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddProviderStore.Location = new Point(531, 55);
            btnAddProviderStore.Margin = new Padding(3, 4, 3, 4);
            btnAddProviderStore.Name = "btnAddProviderStore";
            btnAddProviderStore.Size = new Size(86, 31);
            btnAddProviderStore.TabIndex = 12;
            btnAddProviderStore.Text = "Добавить";
            btnAddProviderStore.UseVisualStyleBackColor = true;
            btnAddProviderStore.UseWaitCursor = true;
            btnAddProviderStore.Click += btnAddProviderStore_Click;
            // 
            // txtBoxProviderStoreAddress
            // 
            txtBoxProviderStoreAddress.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxProviderStoreAddress.Location = new Point(233, 55);
            txtBoxProviderStoreAddress.Margin = new Padding(3, 4, 3, 4);
            txtBoxProviderStoreAddress.Name = "txtBoxProviderStoreAddress";
            txtBoxProviderStoreAddress.Size = new Size(291, 27);
            txtBoxProviderStoreAddress.TabIndex = 11;
            txtBoxProviderStoreAddress.UseWaitCursor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(233, 31);
            label2.Name = "label2";
            label2.Size = new Size(121, 20);
            label2.TabIndex = 10;
            label2.Text = "Адрес магазина";
            label2.UseWaitCursor = true;
            // 
            // txtBoxProviderStoreName
            // 
            txtBoxProviderStoreName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxProviderStoreName.Location = new Point(31, 56);
            txtBoxProviderStoreName.Margin = new Padding(3, 4, 3, 4);
            txtBoxProviderStoreName.Name = "txtBoxProviderStoreName";
            txtBoxProviderStoreName.Size = new Size(195, 27);
            txtBoxProviderStoreName.TabIndex = 9;
            txtBoxProviderStoreName.UseWaitCursor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(31, 32);
            label1.Name = "label1";
            label1.Size = new Size(147, 20);
            label1.TabIndex = 8;
            label1.Text = "Название магазина";
            label1.UseWaitCursor = true;
            // 
            // btnProviderDelivery
            // 
            btnProviderDelivery.Location = new Point(337, 207);
            btnProviderDelivery.Margin = new Padding(3, 4, 3, 4);
            btnProviderDelivery.Name = "btnProviderDelivery";
            btnProviderDelivery.Size = new Size(86, 31);
            btnProviderDelivery.TabIndex = 7;
            btnProviderDelivery.Text = "Завезти";
            btnProviderDelivery.UseVisualStyleBackColor = true;
            btnProviderDelivery.Click += btnProviderDelivery_Click;
            // 
            // dtGridProviderProducts
            // 
            dtGridProviderProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGridProviderProducts.Columns.AddRange(new DataGridViewColumn[] { ImportGoodId, ImportGoodName, ImportGoodPrice, ImportAmount });
            dtGridProviderProducts.Location = new Point(31, 260);
            dtGridProviderProducts.Margin = new Padding(3, 4, 3, 4);
            dtGridProviderProducts.Name = "dtGridProviderProducts";
            dtGridProviderProducts.RowHeadersWidth = 51;
            dtGridProviderProducts.RowTemplate.Height = 25;
            dtGridProviderProducts.Size = new Size(392, 200);
            dtGridProviderProducts.TabIndex = 6;
            // 
            // ImportGoodId
            // 
            ImportGoodId.HeaderText = "Id";
            ImportGoodId.MinimumWidth = 6;
            ImportGoodId.Name = "ImportGoodId";
            ImportGoodId.ReadOnly = true;
            ImportGoodId.Visible = false;
            ImportGoodId.Width = 125;
            // 
            // ImportGoodName
            // 
            ImportGoodName.HeaderText = "Товар";
            ImportGoodName.MinimumWidth = 6;
            ImportGoodName.Name = "ImportGoodName";
            ImportGoodName.ReadOnly = true;
            ImportGoodName.Width = 170;
            // 
            // ImportGoodPrice
            // 
            ImportGoodPrice.HeaderText = "Цена";
            ImportGoodPrice.MinimumWidth = 6;
            ImportGoodPrice.Name = "ImportGoodPrice";
            ImportGoodPrice.Width = 50;
            // 
            // ImportAmount
            // 
            ImportAmount.HeaderText = "Количество";
            ImportAmount.MinimumWidth = 6;
            ImportAmount.Name = "ImportAmount";
            ImportAmount.Width = 80;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 212);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 5;
            label5.Text = "Магазин";
            // 
            // cmbBoxProviderStores
            // 
            cmbBoxProviderStores.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBoxProviderStores.FormattingEnabled = true;
            cmbBoxProviderStores.Location = new Point(99, 207);
            cmbBoxProviderStores.Margin = new Padding(3, 4, 3, 4);
            cmbBoxProviderStores.Name = "cmbBoxProviderStores";
            cmbBoxProviderStores.Size = new Size(230, 28);
            cmbBoxProviderStores.TabIndex = 4;
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
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(649, 567);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Покупатель";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(17, 320);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(251, 56);
            button6.TabIndex = 21;
            button6.Text = "Поиск магазина с наименьшей стоимостью покупки";
            button6.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(86, 411);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(83, 27);
            textBox5.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 415);
            label8.Name = "label8";
            label8.Size = new Size(55, 20);
            label8.TabIndex = 15;
            label8.Text = "Сумма";
            // 
            // button5
            // 
            button5.Location = new Point(183, 411);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(86, 31);
            button5.TabIndex = 14;
            button5.Text = "Поиск";
            button5.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(408, 32);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(83, 27);
            textBox3.TabIndex = 13;
            textBox3.UseWaitCursor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(269, 37);
            label7.Name = "label7";
            label7.Size = new Size(144, 20);
            label7.TabIndex = 12;
            label7.Text = "Стоимость покупки";
            label7.UseWaitCursor = true;
            // 
            // button4
            // 
            button4.Location = new Point(518, 32);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(109, 31);
            button4.TabIndex = 11;
            button4.Text = "Купить";
            button4.UseVisualStyleBackColor = true;
            button4.UseWaitCursor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { ExportGoodName, ExportGoodPrice, ExportAmount, Total });
            dataGridView2.Location = new Point(17, 83);
            dataGridView2.Margin = new Padding(3, 4, 3, 4);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(609, 200);
            dataGridView2.TabIndex = 10;
            // 
            // ExportGoodName
            // 
            ExportGoodName.HeaderText = "Товар";
            ExportGoodName.MinimumWidth = 6;
            ExportGoodName.Name = "ExportGoodName";
            ExportGoodName.ReadOnly = true;
            ExportGoodName.Width = 170;
            // 
            // ExportGoodPrice
            // 
            ExportGoodPrice.HeaderText = "Цена";
            ExportGoodPrice.MinimumWidth = 6;
            ExportGoodPrice.Name = "ExportGoodPrice";
            ExportGoodPrice.ReadOnly = true;
            ExportGoodPrice.Width = 125;
            // 
            // ExportAmount
            // 
            ExportAmount.HeaderText = "Количество";
            ExportAmount.MinimumWidth = 6;
            ExportAmount.Name = "ExportAmount";
            ExportAmount.Width = 120;
            // 
            // Total
            // 
            Total.HeaderText = "Итого";
            Total.MinimumWidth = 6;
            Total.Name = "Total";
            Total.ReadOnly = true;
            Total.Width = 125;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 37);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 9;
            label6.Text = "Магазин";
            label6.UseWaitCursor = true;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(86, 32);
            comboBox2.Margin = new Padding(3, 4, 3, 4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(162, 28);
            comboBox2.TabIndex = 8;
            comboBox2.UseWaitCursor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(656, 600);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtGridProviderProducts).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label5;
        private ComboBox cmbBoxProviderStores;
        private TabPage tabPage2;
        private DataGridView dtGridProviderProducts;
        private Button btnProviderDelivery;
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
        private Button btnAddProviderProduct;
        private Label label3;
        private TextBox txtBoxProviderProductName;
        private Label label4;
        private Button btnAddProviderStore;
        private TextBox txtBoxProviderStoreAddress;
        private Label label2;
        private TextBox txtBoxProviderStoreName;
        private Label label1;
        private DataGridViewTextBoxColumn ImportGoodId;
        private DataGridViewTextBoxColumn ImportGoodName;
        private DataGridViewTextBoxColumn ImportGoodPrice;
        private DataGridViewTextBoxColumn ImportAmount;
    }
}