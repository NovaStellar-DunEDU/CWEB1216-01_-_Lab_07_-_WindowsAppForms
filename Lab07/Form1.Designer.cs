namespace Lab07
{
    partial class Form1
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
            this.SearchByBookIDLabel = new System.Windows.Forms.Label();
            this.SearchInput = new System.Windows.Forms.TextBox();
            this.BookInventory = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.Label();
            this.Title2 = new System.Windows.Forms.Label();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.Title3 = new System.Windows.Forms.Label();
            this.BookTitleInput = new System.Windows.Forms.TextBox();
            this.BookTitleLabel = new System.Windows.Forms.Label();
            this.FirstNameInput = new System.Windows.Forms.TextBox();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.StockInput = new System.Windows.Forms.TextBox();
            this.StockLabel = new System.Windows.Forms.Label();
            this.InsertBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.SurnameInput = new System.Windows.Forms.TextBox();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.PublicationYearInput = new System.Windows.Forms.TextBox();
            this.PublicationYearLabel = new System.Windows.Forms.Label();
            this.PageCountInput = new System.Windows.Forms.TextBox();
            this.PageCountLabel = new System.Windows.Forms.Label();
            this.GenreInput = new System.Windows.Forms.TextBox();
            this.GenreLabel = new System.Windows.Forms.Label();
            this.SubGenreInput = new System.Windows.Forms.TextBox();
            this.SubGenreLabel = new System.Windows.Forms.Label();
            this.MSRPLabel = new System.Windows.Forms.Label();
            this.MSRPInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SearchByAuthorID = new System.Windows.Forms.RadioButton();
            this.SearchByMSRP = new System.Windows.Forms.RadioButton();
            this.SearchByPublicationYear = new System.Windows.Forms.RadioButton();
            this.SearchByPage = new System.Windows.Forms.RadioButton();
            this.SearchByStock = new System.Windows.Forms.RadioButton();
            this.SearchByID = new System.Windows.Forms.RadioButton();
            this.BookIDInsert = new System.Windows.Forms.TextBox();
            this.BookIDLabel = new System.Windows.Forms.Label();
            this.EditionInput = new System.Windows.Forms.TextBox();
            this.EditionLabel = new System.Windows.Forms.Label();
            this.PublisherLabel = new System.Windows.Forms.Label();
            this.PublisherInput = new System.Windows.Forms.TextBox();
            this.AuthorIDLabel = new System.Windows.Forms.Label();
            this.AuthorIDInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.BookInventory)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchByBookIDLabel
            // 
            this.SearchByBookIDLabel.AutoSize = true;
            this.SearchByBookIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchByBookIDLabel.Location = new System.Drawing.Point(12, 97);
            this.SearchByBookIDLabel.Name = "SearchByBookIDLabel";
            this.SearchByBookIDLabel.Size = new System.Drawing.Size(262, 16);
            this.SearchByBookIDLabel.TabIndex = 0;
            this.SearchByBookIDLabel.Text = "Search by Book Title, Author, Genres";
            this.SearchByBookIDLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // SearchInput
            // 
            this.SearchInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchInput.Location = new System.Drawing.Point(15, 120);
            this.SearchInput.Name = "SearchInput";
            this.SearchInput.Size = new System.Drawing.Size(205, 22);
            this.SearchInput.TabIndex = 2;
            // 
            // BookInventory
            // 
            this.BookInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.BookInventory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.BookInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BookInventory.Cursor = System.Windows.Forms.Cursors.Default;
            this.BookInventory.Location = new System.Drawing.Point(344, 24);
            this.BookInventory.MaximumSize = new System.Drawing.Size(2000, 1000);
            this.BookInventory.Name = "BookInventory";
            this.BookInventory.ReadOnly = true;
            this.BookInventory.RowHeadersWidth = 51;
            this.BookInventory.RowTemplate.Height = 24;
            this.BookInventory.Size = new System.Drawing.Size(1509, 808);
            this.BookInventory.TabIndex = 8;
            this.BookInventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BookInventoryCellContentClick);
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(7, 24);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(291, 39);
            this.Title.TabIndex = 9;
            this.Title.Text = "BOOKS R\' US";
            this.Title.Click += new System.EventHandler(this.Title_Click);
            // 
            // Title2
            // 
            this.Title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title2.Location = new System.Drawing.Point(9, 56);
            this.Title2.Name = "Title2";
            this.Title2.Size = new System.Drawing.Size(329, 39);
            this.Title2.TabIndex = 10;
            this.Title2.Text = "INVENTORY TRACKER";
            this.Title2.Click += new System.EventHandler(this.label1_Click_3);
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SearchBtn.CausesValidation = false;
            this.SearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBtn.Location = new System.Drawing.Point(226, 119);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchBtn.TabIndex = 11;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // Title3
            // 
            this.Title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.Title3.Location = new System.Drawing.Point(9, 234);
            this.Title3.Name = "Title3";
            this.Title3.Size = new System.Drawing.Size(335, 39);
            this.Title3.TabIndex = 13;
            this.Title3.Text = "ADD/EDIT/DELETE A BOOK";
            // 
            // BookTitleInput
            // 
            this.BookTitleInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BookTitleInput.Location = new System.Drawing.Point(15, 350);
            this.BookTitleInput.Name = "BookTitleInput";
            this.BookTitleInput.Size = new System.Drawing.Size(285, 22);
            this.BookTitleInput.TabIndex = 16;
            // 
            // BookTitleLabel
            // 
            this.BookTitleLabel.AutoSize = true;
            this.BookTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookTitleLabel.Location = new System.Drawing.Point(12, 331);
            this.BookTitleLabel.Name = "BookTitleLabel";
            this.BookTitleLabel.Size = new System.Drawing.Size(97, 16);
            this.BookTitleLabel.TabIndex = 15;
            this.BookTitleLabel.Text = "Title Of Book";
            // 
            // FirstNameInput
            // 
            this.FirstNameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FirstNameInput.Location = new System.Drawing.Point(15, 416);
            this.FirstNameInput.Name = "FirstNameInput";
            this.FirstNameInput.Size = new System.Drawing.Size(121, 22);
            this.FirstNameInput.TabIndex = 18;
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameLabel.Location = new System.Drawing.Point(12, 397);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(130, 16);
            this.FirstNameLabel.TabIndex = 17;
            this.FirstNameLabel.Text = "Author First Name";
            this.FirstNameLabel.Click += new System.EventHandler(this.NameOfAuthorLabel_Click);
            // 
            // StockInput
            // 
            this.StockInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StockInput.Location = new System.Drawing.Point(15, 651);
            this.StockInput.Name = "StockInput";
            this.StockInput.Size = new System.Drawing.Size(121, 22);
            this.StockInput.TabIndex = 20;
            // 
            // StockLabel
            // 
            this.StockLabel.AutoSize = true;
            this.StockLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockLabel.Location = new System.Drawing.Point(12, 632);
            this.StockLabel.Name = "StockLabel";
            this.StockLabel.Size = new System.Drawing.Size(101, 16);
            this.StockLabel.TabIndex = 19;
            this.StockLabel.Text = "Stock Amount";
            this.StockLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // InsertBtn
            // 
            this.InsertBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.InsertBtn.CausesValidation = false;
            this.InsertBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertBtn.Location = new System.Drawing.Point(15, 756);
            this.InsertBtn.Name = "InsertBtn";
            this.InsertBtn.Size = new System.Drawing.Size(75, 23);
            this.InsertBtn.TabIndex = 21;
            this.InsertBtn.Text = "Insert";
            this.InsertBtn.UseVisualStyleBackColor = false;
            this.InsertBtn.Click += new System.EventHandler(this.BookInsert_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.UpdateBtn.CausesValidation = false;
            this.UpdateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateBtn.Location = new System.Drawing.Point(119, 756);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(75, 23);
            this.UpdateBtn.TabIndex = 22;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = false;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateClick);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DeleteBtn.CausesValidation = false;
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.ForeColor = System.Drawing.Color.Red;
            this.DeleteBtn.Location = new System.Drawing.Point(225, 756);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 23;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.Delete_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClearBtn.CausesValidation = false;
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.Location = new System.Drawing.Point(16, 801);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(286, 30);
            this.ClearBtn.TabIndex = 24;
            this.ClearBtn.Text = "Clear All Fields";
            this.ClearBtn.UseVisualStyleBackColor = false;
            this.ClearBtn.Click += new System.EventHandler(this.ClearAllFieldsBtn);
            // 
            // SurnameInput
            // 
            this.SurnameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SurnameInput.Location = new System.Drawing.Point(179, 416);
            this.SurnameInput.Name = "SurnameInput";
            this.SurnameInput.Size = new System.Drawing.Size(121, 22);
            this.SurnameInput.TabIndex = 25;
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameLabel.Location = new System.Drawing.Point(176, 397);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(129, 16);
            this.LastNameLabel.TabIndex = 26;
            this.LastNameLabel.Text = "Author Last Name";
            // 
            // PublicationYearInput
            // 
            this.PublicationYearInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PublicationYearInput.Location = new System.Drawing.Point(15, 593);
            this.PublicationYearInput.Name = "PublicationYearInput";
            this.PublicationYearInput.Size = new System.Drawing.Size(121, 22);
            this.PublicationYearInput.TabIndex = 28;
            // 
            // PublicationYearLabel
            // 
            this.PublicationYearLabel.AutoSize = true;
            this.PublicationYearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PublicationYearLabel.Location = new System.Drawing.Point(12, 573);
            this.PublicationYearLabel.Name = "PublicationYearLabel";
            this.PublicationYearLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PublicationYearLabel.Size = new System.Drawing.Size(121, 16);
            this.PublicationYearLabel.TabIndex = 27;
            this.PublicationYearLabel.Text = "Publication Year";
            // 
            // PageCountInput
            // 
            this.PageCountInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PageCountInput.Location = new System.Drawing.Point(179, 593);
            this.PageCountInput.Name = "PageCountInput";
            this.PageCountInput.Size = new System.Drawing.Size(121, 22);
            this.PageCountInput.TabIndex = 30;
            this.PageCountInput.TextChanged += new System.EventHandler(this.textBox2_TextChanged_1);
            // 
            // PageCountLabel
            // 
            this.PageCountLabel.AutoSize = true;
            this.PageCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PageCountLabel.Location = new System.Drawing.Point(181, 573);
            this.PageCountLabel.Name = "PageCountLabel";
            this.PageCountLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PageCountLabel.Size = new System.Drawing.Size(87, 16);
            this.PageCountLabel.TabIndex = 29;
            this.PageCountLabel.Text = "Page Count";
            this.PageCountLabel.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // GenreInput
            // 
            this.GenreInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GenreInput.Location = new System.Drawing.Point(14, 533);
            this.GenreInput.Name = "GenreInput";
            this.GenreInput.Size = new System.Drawing.Size(122, 22);
            this.GenreInput.TabIndex = 32;
            // 
            // GenreLabel
            // 
            this.GenreLabel.AutoSize = true;
            this.GenreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenreLabel.Location = new System.Drawing.Point(12, 514);
            this.GenreLabel.Name = "GenreLabel";
            this.GenreLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GenreLabel.Size = new System.Drawing.Size(49, 16);
            this.GenreLabel.TabIndex = 31;
            this.GenreLabel.Text = "Genre";
            this.GenreLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // SubGenreInput
            // 
            this.SubGenreInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SubGenreInput.Location = new System.Drawing.Point(179, 533);
            this.SubGenreInput.Name = "SubGenreInput";
            this.SubGenreInput.Size = new System.Drawing.Size(121, 22);
            this.SubGenreInput.TabIndex = 34;
            // 
            // SubGenreLabel
            // 
            this.SubGenreLabel.AutoSize = true;
            this.SubGenreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubGenreLabel.Location = new System.Drawing.Point(179, 514);
            this.SubGenreLabel.Name = "SubGenreLabel";
            this.SubGenreLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SubGenreLabel.Size = new System.Drawing.Size(81, 16);
            this.SubGenreLabel.TabIndex = 33;
            this.SubGenreLabel.Text = "Sub-Genre";
            // 
            // MSRPLabel
            // 
            this.MSRPLabel.AutoSize = true;
            this.MSRPLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MSRPLabel.Location = new System.Drawing.Point(12, 694);
            this.MSRPLabel.Name = "MSRPLabel";
            this.MSRPLabel.Size = new System.Drawing.Size(272, 16);
            this.MSRPLabel.TabIndex = 35;
            this.MSRPLabel.Text = "Manufacturer\'s Suggested Retail Price";
            // 
            // MSRPInput
            // 
            this.MSRPInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MSRPInput.Location = new System.Drawing.Point(15, 713);
            this.MSRPInput.Name = "MSRPInput";
            this.MSRPInput.Size = new System.Drawing.Size(285, 22);
            this.MSRPInput.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "Numerical Filter";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SearchByAuthorID);
            this.groupBox1.Controls.Add(this.SearchByMSRP);
            this.groupBox1.Controls.Add(this.SearchByPublicationYear);
            this.groupBox1.Controls.Add(this.SearchByPage);
            this.groupBox1.Controls.Add(this.SearchByStock);
            this.groupBox1.Controls.Add(this.SearchByID);
            this.groupBox1.Location = new System.Drawing.Point(14, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 61);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            // 
            // SearchByAuthorID
            // 
            this.SearchByAuthorID.AutoSize = true;
            this.SearchByAuthorID.Location = new System.Drawing.Point(97, 6);
            this.SearchByAuthorID.Name = "SearchByAuthorID";
            this.SearchByAuthorID.Size = new System.Drawing.Size(79, 20);
            this.SearchByAuthorID.TabIndex = 54;
            this.SearchByAuthorID.Text = "AuthorID";
            this.SearchByAuthorID.UseVisualStyleBackColor = true;
            this.SearchByAuthorID.Click += new System.EventHandler(this.RadioCheck);
            // 
            // SearchByMSRP
            // 
            this.SearchByMSRP.AutoSize = true;
            this.SearchByMSRP.Location = new System.Drawing.Point(6, 34);
            this.SearchByMSRP.Name = "SearchByMSRP";
            this.SearchByMSRP.Size = new System.Drawing.Size(67, 20);
            this.SearchByMSRP.TabIndex = 53;
            this.SearchByMSRP.Text = "MSRP";
            this.SearchByMSRP.UseVisualStyleBackColor = true;
            this.SearchByMSRP.CheckedChanged += new System.EventHandler(this.SearchByMSRP_CheckedChanged);
            this.SearchByMSRP.Click += new System.EventHandler(this.RadioCheck);
            // 
            // SearchByPublicationYear
            // 
            this.SearchByPublicationYear.AutoSize = true;
            this.SearchByPublicationYear.Location = new System.Drawing.Point(82, 34);
            this.SearchByPublicationYear.Name = "SearchByPublicationYear";
            this.SearchByPublicationYear.Size = new System.Drawing.Size(126, 20);
            this.SearchByPublicationYear.TabIndex = 52;
            this.SearchByPublicationYear.Text = "Publication Year";
            this.SearchByPublicationYear.UseVisualStyleBackColor = true;
            this.SearchByPublicationYear.Click += new System.EventHandler(this.RadioCheck);
            // 
            // SearchByPage
            // 
            this.SearchByPage.AutoSize = true;
            this.SearchByPage.Location = new System.Drawing.Point(220, 34);
            this.SearchByPage.Name = "SearchByPage";
            this.SearchByPage.Size = new System.Drawing.Size(98, 20);
            this.SearchByPage.TabIndex = 51;
            this.SearchByPage.Text = "Page Count";
            this.SearchByPage.UseVisualStyleBackColor = true;
            this.SearchByPage.Click += new System.EventHandler(this.RadioCheck);
            // 
            // SearchByStock
            // 
            this.SearchByStock.AutoSize = true;
            this.SearchByStock.Location = new System.Drawing.Point(201, 6);
            this.SearchByStock.Name = "SearchByStock";
            this.SearchByStock.Size = new System.Drawing.Size(62, 20);
            this.SearchByStock.TabIndex = 50;
            this.SearchByStock.Text = "Stock";
            this.SearchByStock.UseVisualStyleBackColor = true;
            this.SearchByStock.Click += new System.EventHandler(this.RadioCheck);
            // 
            // SearchByID
            // 
            this.SearchByID.AutoSize = true;
            this.SearchByID.Checked = true;
            this.SearchByID.Location = new System.Drawing.Point(6, 6);
            this.SearchByID.Name = "SearchByID";
            this.SearchByID.Size = new System.Drawing.Size(76, 20);
            this.SearchByID.TabIndex = 49;
            this.SearchByID.TabStop = true;
            this.SearchByID.Text = "Book ID";
            this.SearchByID.UseVisualStyleBackColor = true;
            this.SearchByID.CheckedChanged += new System.EventHandler(this.SearchByID_CheckedChanged);
            this.SearchByID.Click += new System.EventHandler(this.RadioCheck);
            // 
            // BookIDInsert
            // 
            this.BookIDInsert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BookIDInsert.Location = new System.Drawing.Point(16, 289);
            this.BookIDInsert.Name = "BookIDInsert";
            this.BookIDInsert.Size = new System.Drawing.Size(120, 22);
            this.BookIDInsert.TabIndex = 41;
            // 
            // BookIDLabel
            // 
            this.BookIDLabel.AutoSize = true;
            this.BookIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookIDLabel.Location = new System.Drawing.Point(13, 270);
            this.BookIDLabel.Name = "BookIDLabel";
            this.BookIDLabel.Size = new System.Drawing.Size(58, 16);
            this.BookIDLabel.TabIndex = 40;
            this.BookIDLabel.Text = "BookID";
            this.BookIDLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // EditionInput
            // 
            this.EditionInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditionInput.Location = new System.Drawing.Point(177, 651);
            this.EditionInput.Name = "EditionInput";
            this.EditionInput.Size = new System.Drawing.Size(123, 22);
            this.EditionInput.TabIndex = 43;
            // 
            // EditionLabel
            // 
            this.EditionLabel.AutoSize = true;
            this.EditionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditionLabel.Location = new System.Drawing.Point(175, 632);
            this.EditionLabel.Name = "EditionLabel";
            this.EditionLabel.Size = new System.Drawing.Size(55, 16);
            this.EditionLabel.TabIndex = 42;
            this.EditionLabel.Text = "Edition";
            // 
            // PublisherLabel
            // 
            this.PublisherLabel.AutoSize = true;
            this.PublisherLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PublisherLabel.Location = new System.Drawing.Point(13, 456);
            this.PublisherLabel.Name = "PublisherLabel";
            this.PublisherLabel.Size = new System.Drawing.Size(72, 16);
            this.PublisherLabel.TabIndex = 44;
            this.PublisherLabel.Text = "Publisher";
            // 
            // PublisherInput
            // 
            this.PublisherInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PublisherInput.Location = new System.Drawing.Point(15, 475);
            this.PublisherInput.Name = "PublisherInput";
            this.PublisherInput.Size = new System.Drawing.Size(287, 22);
            this.PublisherInput.TabIndex = 45;
            // 
            // AuthorIDLabel
            // 
            this.AuthorIDLabel.AutoSize = true;
            this.AuthorIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorIDLabel.Location = new System.Drawing.Point(176, 270);
            this.AuthorIDLabel.Name = "AuthorIDLabel";
            this.AuthorIDLabel.Size = new System.Drawing.Size(66, 16);
            this.AuthorIDLabel.TabIndex = 46;
            this.AuthorIDLabel.Text = "AuthorID";
            // 
            // AuthorIDInput
            // 
            this.AuthorIDInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AuthorIDInput.Location = new System.Drawing.Point(180, 289);
            this.AuthorIDInput.Name = "AuthorIDInput";
            this.AuthorIDInput.Size = new System.Drawing.Size(120, 22);
            this.AuthorIDInput.TabIndex = 47;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1882, 853);
            this.Controls.Add(this.AuthorIDInput);
            this.Controls.Add(this.AuthorIDLabel);
            this.Controls.Add(this.PublisherInput);
            this.Controls.Add(this.PublisherLabel);
            this.Controls.Add(this.EditionInput);
            this.Controls.Add(this.EditionLabel);
            this.Controls.Add(this.BookIDInsert);
            this.Controls.Add(this.BookIDLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MSRPInput);
            this.Controls.Add(this.MSRPLabel);
            this.Controls.Add(this.SubGenreInput);
            this.Controls.Add(this.SubGenreLabel);
            this.Controls.Add(this.GenreInput);
            this.Controls.Add(this.GenreLabel);
            this.Controls.Add(this.PageCountInput);
            this.Controls.Add(this.PageCountLabel);
            this.Controls.Add(this.PublicationYearInput);
            this.Controls.Add(this.PublicationYearLabel);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.SurnameInput);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.InsertBtn);
            this.Controls.Add(this.StockInput);
            this.Controls.Add(this.StockLabel);
            this.Controls.Add(this.FirstNameInput);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.BookTitleInput);
            this.Controls.Add(this.BookTitleLabel);
            this.Controls.Add(this.Title3);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.Title2);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.BookInventory);
            this.Controls.Add(this.SearchInput);
            this.Controls.Add(this.SearchByBookIDLabel);
            this.MaximumSize = new System.Drawing.Size(1900, 900);
            this.MinimumSize = new System.Drawing.Size(1900, 900);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.Text = "BOOKS R\' US / INVENTORY TRACKER";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BookInventory)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SearchByBookIDLabel;
        private System.Windows.Forms.TextBox SearchInput;
        private System.Windows.Forms.DataGridView BookInventory;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Title2;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label Title3;
        private System.Windows.Forms.TextBox BookTitleInput;
        private System.Windows.Forms.Label BookTitleLabel;
        private System.Windows.Forms.TextBox FirstNameInput;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.TextBox StockInput;
        private System.Windows.Forms.Label StockLabel;
        private System.Windows.Forms.Button InsertBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.TextBox SurnameInput;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox PublicationYearInput;
        private System.Windows.Forms.Label PublicationYearLabel;
        private System.Windows.Forms.TextBox PageCountInput;
        private System.Windows.Forms.TextBox GenreInput;
        private System.Windows.Forms.Label GenreLabel;
        private System.Windows.Forms.TextBox SubGenreInput;
        private System.Windows.Forms.Label SubGenreLabel;
        private System.Windows.Forms.Label MSRPLabel;
        private System.Windows.Forms.TextBox MSRPInput;
        private System.Windows.Forms.Label PageCountLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton SearchByMSRP;
        private System.Windows.Forms.RadioButton SearchByPublicationYear;
        private System.Windows.Forms.RadioButton SearchByPage;
        private System.Windows.Forms.RadioButton SearchByStock;
        private System.Windows.Forms.RadioButton SearchByID;
        private System.Windows.Forms.TextBox BookIDInsert;
        private System.Windows.Forms.Label BookIDLabel;
        private System.Windows.Forms.TextBox EditionInput;
        private System.Windows.Forms.Label EditionLabel;
        private System.Windows.Forms.Label PublisherLabel;
        private System.Windows.Forms.TextBox PublisherInput;
        private System.Windows.Forms.Label AuthorIDLabel;
        private System.Windows.Forms.TextBox AuthorIDInput;
        private System.Windows.Forms.RadioButton SearchByAuthorID;
    }
}

