namespace TestDbManager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.buttonFillDb = new System.Windows.Forms.Button();
            this.buttonShowDb = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonClearDb = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(321, 337);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // buttonFillDb
            // 
            this.buttonFillDb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonFillDb.Location = new System.Drawing.Point(27, 12);
            this.buttonFillDb.Name = "buttonFillDb";
            this.buttonFillDb.Size = new System.Drawing.Size(75, 23);
            this.buttonFillDb.TabIndex = 1;
            this.buttonFillDb.Text = "Заполнить";
            this.buttonFillDb.UseVisualStyleBackColor = true;
            this.buttonFillDb.Click += new System.EventHandler(this.buttonFillDb_Click);
            // 
            // buttonShowDb
            // 
            this.buttonShowDb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonShowDb.Location = new System.Drawing.Point(27, 41);
            this.buttonShowDb.Name = "buttonShowDb";
            this.buttonShowDb.Size = new System.Drawing.Size(75, 23);
            this.buttonShowDb.TabIndex = 2;
            this.buttonShowDb.Text = "Показать";
            this.buttonShowDb.UseVisualStyleBackColor = true;
            this.buttonShowDb.Click += new System.EventHandler(this.buttonShowDb_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.ValueColumn});
            this.dataGridView1.Location = new System.Drawing.Point(467, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(305, 337);
            this.dataGridView1.TabIndex = 3;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Название";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.Width = 130;
            // 
            // ValueColumn
            // 
            this.ValueColumn.HeaderText = "Значение";
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.Width = 130;
            // 
            // buttonClearDb
            // 
            this.buttonClearDb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonClearDb.Location = new System.Drawing.Point(27, 70);
            this.buttonClearDb.Name = "buttonClearDb";
            this.buttonClearDb.Size = new System.Drawing.Size(75, 23);
            this.buttonClearDb.TabIndex = 4;
            this.buttonClearDb.Text = "Очистить";
            this.buttonClearDb.UseVisualStyleBackColor = true;
            this.buttonClearDb.Click += new System.EventHandler(this.buttonClearDb_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonDelete.Location = new System.Drawing.Point(27, 99);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonAdd.Location = new System.Drawing.Point(27, 129);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.Controls.Add(this.buttonExport);
            this.panel1.Controls.Add(this.buttonFillDb);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Controls.Add(this.buttonShowDb);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.buttonClearDb);
            this.panel1.Location = new System.Drawing.Point(336, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(129, 337);
            this.panel1.TabIndex = 7;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(27, 159);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 7;
            this.buttonExport.Text = "Экспорт";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.treeView1);
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button buttonFillDb;
        private System.Windows.Forms.Button buttonShowDb;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonClearDb;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonExport;
    }
}

