using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Lab07
{
    public partial class Form1 : Form
    {
        // MySQL Connection
        MySqlConnection conn = new MySqlConnection("Server=localhost;Port=3306;Database=bookstore;Uid=root;Password=Th1sMySQLS3rv3r;");
        public Form1()
        {
            InitializeComponent();
        }
        public void display_data()
        {
            // Giving the user a way to put in books
            // Preventing user deleting or updating non-existant items
            InsertBtn.Enabled = true;
            DeleteBtn.Enabled = false;
            UpdateBtn.Enabled = false;

            // Setting the book data source to none to clear previous data view
            BookInventory.DataSource = null;
            // Create a new data view with updated information
            BookInventory.Refresh();
            conn.Open();
            
            // Overview of this first query:
            // Creates OR replaces the view of the database every time this method is called
            // Basically forcing an update if there was any information added

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = CreateReplaceTables(); // Check LINES 819 and onward
            cmd.ExecuteNonQuery();

            // Overview of this second query:
            // Selects the author's name and ID
            // Selects the book's ID, and information

            MySqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = SelectALL(); // Check LINES 795 and onward

            DataTable dta = new DataTable(); // Creates a new table
            MySqlDataReader reader = cmd2.ExecuteReader(); // Reads the command
            dta.Load(reader); // Loads the results

            BookInventory.DataSource = dta; // Gives the result to the DisplayGridView
            conn.Close();
        }

        // Same thing here for lines 105-162
        private void Form1_Load(object sender, EventArgs e)
        {
            InsertBtn.Enabled = true;
            DeleteBtn.Enabled = false;
            UpdateBtn.Enabled = false;

            BookInventory.DataSource = null;
            BookInventory.Refresh();
            conn.Open();

            BookInventory.AutoGenerateColumns = true;

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = CreateReplaceTables(); // CHECK Lines 819 and onward
            cmd.ExecuteNonQuery();

            MySqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = SelectALL(); // Check LINES 795 and onward

            MySqlDataReader reader = cmd2.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            BookInventory.DataSource = dt;
            conn.Close();
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            GetSearchBtn();
            // If the search button is clicked, the search method will occur
        }
        private void GetSearchBtn()
        {
            conn.Open();
            MySqlCommand cmd2 = conn.CreateCommand(); // Create a new command
            cmd2.CommandType = CommandType.Text;

            string newQuery = ""; // Set new query to none
            string input = SearchInput.Text; // Set input to Search Box

            // This empty new query will be filled conditionally

            // There are radio buttons used on this app
            // They are for searching for specific numeric values
            // If I didn't do this
            // the program wouldn't know what to look for
            // and it would search up any matching input

            // TLDR: The semantics would get VERY lost in the sauce

            // The BookID Radio Button is enabled by Default

            if (SearchByMSRP.Checked == true) // Checks if the MSRP Radio Button was clicked
            {
                newQuery = QueryByMSRP(); // CHECK LINE 613 FOR MORE INFO
                // Replaces the old empty query with the new string query
                // Inputted NUMERICAL value will be checked as MSRP
            }
            else if (SearchByPage.Checked == true)
            {
                int pages;
                if (int.TryParse(SearchInput.Text, out pages))
                {
                    int maxpages = pages + 100; // Looks for 0-100 page long books

                    cmd2.Parameters.AddWithValue("@minPages", pages);
                    cmd2.Parameters.AddWithValue("@maxPages", maxpages);

                    MessageBox.Show("Searched for books within " + pages + " to " + maxpages + " pages. \n\nClick 'OK' to view these results.\n", "Searching...");
                }
                // If TryParse failed, then continue query as normal

                newQuery = QueryByPage(); // CHECK LINE 644 FOR MORE INFO
                // Replaces the old empty query with the new string query, the rest of the other new queries
                // Your inputted NUMERICAL value will now be checked as Pages
            }
            else if (SearchByPublicationYear.Checked == true)
            {
                newQuery = QueryByPublicationYear(); // CHECK LINE 675 FOR MORE INFO
                // Your inputted NUMERICAL value will now be checked as Publication Year
            }
            else if (SearchByStock.Checked == true)
            {
                newQuery = QueryByStock(); // CHECK LINE 705 FOR MORE INFO
                // Your inputted numerical value will now be checked as Stock
            }
            else if (SearchByAuthorID.Checked == true)
            {
                newQuery = QueryByAuthorID(); // CHECK LINE 735 FOR MORE INFO
                // Your inputted numerical value will now be checked as AuthorID
            }
            else // If none of the other radio buttons were clicked, then by default, search for BookID
            {
                if (SearchByID.Checked == true)
                {
                    newQuery = QueryByBookID(); // CHECK LINE 765 FOR MORE INFO
                    // Your inputted numerical value will now be checked as BookID
                }
            }

            // TLDR, all the stuff above is for streamlining filtering
            // All of the queries are very similar, but sorting numerics
            // like bookID, MSRP, authorID, and Stock
            // change according to what radio button is clicked
            // Each radio button has its own little varient that is catered to them ONLY

            cmd2.CommandText = newQuery;

            // Putting your input into the Searching Query
            cmd2.Parameters.AddWithValue("@input", "%" + input + "%");
            cmd2.Parameters.AddWithValue("@input1", input);

            MySqlDataReader reader = cmd2.ExecuteReader(); // Executes the query
            DataTable dt = new DataTable(); // Creates a new and blank view
            dt.Load(reader); //  Gives the new view your searched data

            if (dt.Rows.Count > 0)
            {
                BookInventory.DataSource = dt; // Refreshes your table so you can now see the newly made data
                conn.Close();
            }
            else
            {
                MessageBox.Show("Using your criteria, no entries were found.\n\nCreate a book entry, or enter in a different value when searching.\n\nPress 'OK' to proceed.", "oh no...!  :(");
                // No information found feedback message
                conn.Close();
            }
        }
        private void RadioCheck(object sender, EventArgs e)
        {
            // Looks for which radio button was selected
            RadioButton rb = sender as RadioButton;
            if (rb == null) // If not clicked, keep this information
                return;

            if (!rb.Checked)
                return; // If clicked, keep this information
        }

        private void BookInsert_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to create " + BookTitleInput.Text + "?", "Confirmation", MessageBoxButtons.YesNo);
            // Are you sure prompt

            if (result == DialogResult.Yes)
            {
                DialogResult result2 = MessageBox.Show("Creating" + BookTitleInput.Text + "details with the new details you just gave us. \n\nClick 'OK' to proceed.", "Creating. . .", MessageBoxButtons.OKCancel);
                // Another "are you sure" prompt
                if (result2 == DialogResult.OK) // IF user clicks "OK"
                {
                    BookInsert_Complete(); // Creates the new book
                }
                else // Otherwise if it is "CANCEL" then cancel the creation
                {
                    MessageBox.Show("Cancelled creating " + BookTitleInput.Text + ". \n\nClick 'OK' to proceed.", "Cancelled.");
                    display_data();
                }
            }
            else // Same thing here
            {
                MessageBox.Show("Cancelled creating " + BookTitleInput.Text + ". \n\nClick 'OK' to proceed.", "Cancelled.");
                display_data();
            }
        }

        private void BookInsert_Complete() // CREATE
        {
            conn.Open(); // The command below checks for your book's ID before inserting a new book
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Book WHERE BookID='" + BookIDInsert.Text + "'", conn);

            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            try
            {
                if (CheckForEmptyString()) // Checks for empty fields, basically my own homebrew exception
                {
                    MessageBox.Show("Some of your input was left empty. \n\nCheck your inputs, then try again. \n\nInputs: \n\nBookID:" + BookIDInsert.Text + "\nAuthorID:"
                                        + AuthorIDInput.Text + "\nAuthor First Name:" + FirstNameInput.Text + "\nAuthor Last Name:" + SurnameInput.Text
                                        + "\nBook Title:" + BookTitleInput.Text + "\nPublication Year:"
                                       + PublicationYearInput.Text + "\nPublisher:" + PublisherInput.Text + "\nPage Count:" + PageCountInput.Text + "\nGenre:"
                                       + GenreInput.Text + "\nSub-genre:" + SubGenreInput.Text + "\nMSRP:"
                                       + MSRPInput.Text, "oh no..!  :(");

                    conn.Close(); // It also gives the user insight on their inputs and which input was left empty
                }
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("This BookID already exists. Please edit your BookID to be distinct from another.", "oh no..!  :(");
                    conn.Close();
                }
                else
                {
                    MySqlCommand cmd2 = conn.CreateCommand();
                    cmd2.CommandType = CommandType.Text; // General book information
                    cmd2.CommandText = "INSERT INTO Book" +
                                       "(Title, PublicationYear, Publisher, CountOfPages, Genre, Subgenre, MSRP) VALUES ('"
                                       + BookTitleInput.Text + "', '"
                                       + PublicationYearInput.Text + "', '" + PublisherInput.Text + "', '" + PageCountInput.Text + "', '"
                                       + GenreInput.Text + "', '" + SubGenreInput.Text + "', '"
                                       + MSRPInput.Text + "')"; // Your filled out Input form goes into here
                    cmd2.ExecuteNonQuery();

                    MySqlCommand cmd3 = conn.CreateCommand();
                    cmd3.CommandType = CommandType.Text; // Author first name and last name
                    cmd3.CommandText = "INSERT INTO Author" +
                                       "(FirstName, LastName) VALUES ('"
                                       + FirstNameInput.Text + "', '" + SurnameInput.Text + "')"; // and here
                    cmd3.ExecuteNonQuery();

                    MySqlCommand cmd4 = conn.CreateCommand();
                    cmd4.CommandType = CommandType.Text; // Relational Table ID
                    cmd4.CommandText = "INSERT INTO BookAuthor(BookID, AuthorID) VALUES ('"
                                        + BookIDInsert.Text + "', '" + AuthorIDInput.Text + "');"; // and here
                    cmd4.ExecuteNonQuery();

                    conn.Close();

                    ClearAllFields();

                    MessageBox.Show("Your new book was added successfully! \n\nPress 'OK' to Proceed.", "Added New Book! :)");

                    display_data();
                }
            }
            catch (MySqlException ex) // If the input type variable does not match, then throw this exception
            {
                {
                    MessageBox.Show("Your inputs were invalid. \n\nCheck your inputs, then try again. \n\nInputs: \n\nBookID:" + BookIDInsert.Text + "\nAuthorID:" 
                                        + AuthorIDInput.Text + "\nAuthor First Name:" + FirstNameInput.Text + "\nAuthor Last Name:" + SurnameInput.Text 
                                        + "\nBook Title:" + BookTitleInput.Text + "\nPublication Year:"
                                       + PublicationYearInput.Text + "\nPublisher:" + PublisherInput.Text + "\nPage Count:" + PageCountInput.Text + "\nGenre:"
                                       + GenreInput.Text + "\nSub-genre:" + SubGenreInput.Text + "\nMSRP:"
                                       + MSRPInput.Text, "oh no..!  :(");

                    conn.Close(); // Gives the user insight on their inputs and which input was left empty
                }
            }
        }
        private void BookInventoryCellContentClick(object sender, DataGridViewCellEventArgs e) // Accessible Updating of Database
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;

            DataGridViewRow row = BookInventory.Rows[rowIndex]; // How many Rows there are

            string realBookID = row.Cells["BookID"].Value?.ToString() ?? ""; // If there is a Book ID, use it, if the book ID is null, use empty string
            string realAuthorID = row.Cells["AuthorID"].Value?.ToString() ?? "No Author"; // If there is an Author ID, use it, if the Author ID is null, replace with "No Author"

            // Clear AuthorID if there is no numeric
            if (!int.TryParse(realAuthorID, out _))
            {
                realAuthorID = "";
            }

            BookIDInsert.Text = realBookID;
            AuthorIDInput.Text = realAuthorID;

            // Data Type conversion to string of the information from selected row

            BookTitleInput.Text = row.Cells["Title"].Value.ToString();
            PublisherInput.Text = row.Cells["Publisher"].Value.ToString();
            GenreInput.Text = row.Cells["Genre"].Value.ToString();
            SubGenreInput.Text = row.Cells["Subgenre"].Value.ToString();
            PublicationYearInput.Text = row.Cells["YearPublished"].Value.ToString();
            PageCountInput.Text = row.Cells["Pages"].Value.ToString();
            EditionInput.Text = row.Cells["Edition"].Value.ToString();
            MSRPInput.Text = row.Cells["MSRP"].Value.ToString();
            StockInput.Text = row.Cells["Stock"].Value.ToString();

            string authorName = row.Cells["AuthorName"].Value.ToString(); // Seperates the first name and last name into their respective input fields
            string[] nameParts = authorName.Split(' ');
            

            FirstNameInput.Text = nameParts[0]; // nameParts[0] is the First Name

            if (nameParts.Length > 1)
            {
                SurnameInput.Text = string.Join(" ", nameParts.Skip(1)); //nameParts[1] is a space
            }
            else
            {
                SurnameInput.Text = ""; //nameParts[2] is the Surname
            }

            BookIDInsert.Enabled = false; // Won't let you edit the BookID

            InsertBtn.Enabled = false; // Inserting a pre-existing book isn't allowed
            UpdateBtn.Enabled = true; // Updating is ok
            DeleteBtn.Enabled = true; // Deleting is ok
        }


        private void UpdateClick(object sender, EventArgs e) // Prompt to make sure the user means to update a book
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to update this book?", "Confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                DialogResult result2 = MessageBox.Show("Editing" + BookTitleInput.Text + "details with the new details you just gave us. \n\nClick 'OK' to proceed.", "Updating. . .", MessageBoxButtons.OKCancel);
                if (result2 == DialogResult.OK) 
                {
                    UpdateComplete();
                }
                else
                {
                    MessageBox.Show("Cancelled updating " + BookTitleInput.Text + ". \n\nClick 'OK' to proceed.", "Cancelled.");
                    display_data();
                }
            }
            else
            {
                MessageBox.Show("Cancelled updating " + BookTitleInput.Text + ". \n\nClick 'OK' to proceed.", "Cancelled.");
                display_data();
            }
        }

        private void UpdateComplete() // UPDATE
        {
            string BookTitle = BookTitleInput.Text;
            string FirstName = FirstNameInput.Text;
            string Surname = SurnameInput.Text;
            string Genre = GenreInput.Text;
            string SubGenre = SubGenreInput.Text;
            string PageCount = PageCountInput.Text;
            string PublishedYear = PublicationYearInput.Text;
            string Publisher = PublisherInput.Text;
            string Edition = EditionInput.Text;
            string MSRP = MSRPInput.Text;
            string Stock = StockInput.Text;

            conn.Open();
            try
            {
                if (CheckForEmptyString()) // Looks for empty information
                {
                    MessageBox.Show("Some of your input was left empty. \n\nCheck your inputs, then try again. \n\nInputs: \n\nBookID:" + BookIDInsert.Text + "\nAuthorID:"
                                        + AuthorIDInput.Text + "\nAuthor First Name:" + FirstNameInput.Text + "\nAuthor Last Name:" + SurnameInput.Text
                                        + "\nBook Title:" + BookTitleInput.Text + "\nPublication Year:"
                                       + PublicationYearInput.Text + "\nPublisher:" + PublisherInput.Text + "\nPage Count:" + PageCountInput.Text + "\nGenre:"
                                       + GenreInput.Text + "\nSub-genre:" + SubGenreInput.Text + "\nMSRP:"
                                       + MSRPInput.Text, "oh no..!  :(");

                    conn.Close(); // Gives the user insight on their inputs and which input was left empty
                }
                else
                {
                    MySqlCommand cmd3 = new MySqlCommand();
                    cmd3.Connection = conn;
                    cmd3.CommandType = CommandType.Text;

                    cmd3.CommandText = // Updates a book's general information in Book Table
                    "UPDATE Book SET " +
                    "Title=@title, Genre=@genre, Subgenre=@subgenre, PublicationYear=@year, " +
                    "Publisher=@publisher, CountOfPages=@pages, Edition=@edition, MSRP=@msrp, Stock=@stock " +
                    "WHERE BookID=@bookID;";

                    cmd3.Parameters.AddWithValue("@title", BookTitle);
                    cmd3.Parameters.AddWithValue("@genre", Genre);
                    cmd3.Parameters.AddWithValue("@subgenre", SubGenre);
                    cmd3.Parameters.AddWithValue("@year", PublishedYear);
                    cmd3.Parameters.AddWithValue("@publisher", Publisher);
                    cmd3.Parameters.AddWithValue("@pages", PageCount);
                    cmd3.Parameters.AddWithValue("@edition", Edition);
                    cmd3.Parameters.AddWithValue("@msrp", MSRP);
                    cmd3.Parameters.AddWithValue("@stock", Stock);
                    cmd3.Parameters.AddWithValue("@bookID", BookIDInsert.Text);

                    cmd3.ExecuteNonQuery();

                    MySqlCommand cmd4 = new MySqlCommand();
                    cmd4.Connection = conn;
                    cmd4.CommandType = CommandType.Text; // Updates an author's name and last name, and ID in Author Table
                    cmd4.CommandText = "UPDATE Author SET " + "FirstName=@first, LastName=@last " + "WHERE AuthorID=@authID;";

                    cmd4.Parameters.AddWithValue("@first", FirstName);
                    cmd4.Parameters.AddWithValue("@last", Surname);
                    cmd4.Parameters.AddWithValue("@authID", AuthorIDInput.Text);

                    cmd4.ExecuteNonQuery();

                    MySqlCommand cmd5 = new MySqlCommand();
                    cmd5.Connection = conn;
                    cmd5.CommandType = CommandType.Text; // Updates an author's ID and a book's ID in relational table

                    cmd5.CommandText =
                        "UPDATE BookAuthor SET AuthorID=@authID WHERE BookID=@bookID;";

                    cmd5.Parameters.AddWithValue("@authID", AuthorIDInput.Text);
                    cmd5.Parameters.AddWithValue("@bookID", BookIDInsert.Text);

                    cmd5.ExecuteNonQuery();

                    conn.Close();

                    display_data();

                    InsertBtn.Enabled = true;
                    DeleteBtn.Enabled = false;
                    UpdateBtn.Enabled = false;

                    MessageBox.Show("Your book has been updated successfully!", "Update successful  :)");
                }

            }
            catch (MySqlException ex)
            {
                {
                    MessageBox.Show("Your inputs were invalid. \n\nCheck your inputs, then try again. \n\nInputs: \n\nBookID:" + BookIDInsert.Text + "\nAuthorID:"
                                        + AuthorIDInput.Text + "\nAuthor First Name:" + FirstNameInput.Text + "\nAuthor Last Name:" + SurnameInput.Text
                                        + "\nBook Title:" + BookTitleInput.Text + "\nPublication Year:"
                                       + PublicationYearInput.Text + "\nPublisher:" + PublisherInput.Text + "\nPage Count:" + PageCountInput.Text + "\nGenre:"
                                       + GenreInput.Text + "\nSub-genre:" + SubGenreInput.Text + "\nMSRP:"
                                       + MSRPInput.Text, "oh no..!  :(");

                    conn.Close(); // If the input type variable does not match, then throw this exception
                }
            }
        }
        private void Delete_Click(object sender, EventArgs e) // Prompt the user to make sure they don't accidently delete a book that was really important
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to delete this book?", "Confirmation", MessageBoxButtons.YesNo);
            bool deleteAuthor = false;

            if (result == DialogResult.Yes)
            {
                DialogResult result2 = MessageBox.Show("This book will be gone forever unless you inserted it again.", "ARE YOU REALLY SURE?", MessageBoxButtons.YesNo);

                conn.Open();
                string query = "SELECT COUNT(*) FROM BookAuthor WHERE AuthorID=@authID AND BookID=@bookID";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@authID", AuthorIDInput.Text);
                cmd.Parameters.AddWithValue("@bookID", BookIDInsert.Text);

                int booksRemaining = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();

                if (booksRemaining == 1 && result2 == DialogResult.Yes)
                {
                    DialogResult result3 = MessageBox.Show("The author, "+ FirstNameInput.Text + " " + SurnameInput.Text + ", will have no more books left. \nThey will be deleted automatically, and be gone forever.", "ARE YOU ABSOLUTELY AND POSITIVELY SURE?", MessageBoxButtons.OKCancel);
                    if (result3 == DialogResult.Yes)
                    {
                        {
                            deleteAuthor = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cancelled deleting " + BookTitleInput.Text + ", and it's author, " + FirstNameInput.Text + " " + SurnameInput.Text + ". \n\nClick 'OK' to proceed.", "Cancelled.");
                        display_data();
                        return;
                    }
                }

                else if (booksRemaining > 1 && result2 == DialogResult.Yes)
                {
                    MessageBox.Show("Deleting " + BookTitleInput.Text + "'s details. \n\nClick 'OK' to proceed.", "Deleting. . .");
                }
                else
                {
                    MessageBox.Show("Cancelled deleting " + BookTitleInput.Text + ". \n\nClick 'OK' to proceed.", "Cancelled.");
                    display_data();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Cancelled deleting " + BookTitleInput.Text + ". \n\nClick 'OK' to proceed.", "Cancelled.");
                display_data();
                return;
            }

            DeleteComplete(deleteAuthor);
        }

        private void DeleteComplete(bool deleteAuthor) // DELETE
        {
            conn.Open();

            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = conn;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "DELETE FROM BookAuthor WHERE BookID=@bookID;"; // Delete the row from Relational Table using BookID
            cmd1.Parameters.AddWithValue("@bookID", BookIDInsert.Text);
            cmd1.ExecuteNonQuery();

            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = conn;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "DELETE FROM Book WHERE BookID=@bookID"; // Delete the row from Book Table using BookID
            cmd2.Parameters.AddWithValue("@bookID", BookIDInsert.Text);
            cmd2.ExecuteNonQuery();

            if (deleteAuthor == true)
            {
                MySqlCommand cmd3 = new MySqlCommand();
                cmd3.Connection = conn;
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "DELETE FROM BookAuthor WHERE AuthorID=@authID";
                cmd3.Parameters.AddWithValue("@bookID", BookIDInsert.Text);
                cmd3.ExecuteNonQuery();

                MySqlCommand cmd4 = new MySqlCommand();
                cmd4.Connection = conn;
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "DELETE FROM Author WHERE AuthorID=@authID"; // Delete the row from Book Table using BookID
                cmd4.Parameters.AddWithValue("@bookID", BookIDInsert.Text);
                cmd4.ExecuteNonQuery();
            }

            conn.Close();
            display_data(); // Show all data

            ClearAllFields(); // Clear all input fields

            InsertBtn.Enabled = true;
            DeleteBtn.Enabled = false;
            UpdateBtn.Enabled = false;

            BookIDInsert.Enabled = true;

            MessageBox.Show("The deletion was successful.");
        }
        private void ClearAllFields() // Clear all input fields
        {
            BookIDInsert.Text = "";
            AuthorIDInput.Text = "";
            BookTitleInput.Text = "";
            FirstNameInput.Text = "";
            SurnameInput.Text = "";
            GenreInput.Text = "";
            SubGenreInput.Text = "";
            PublisherInput.Text = "";
            PublicationYearInput.Text = "";
            PageCountInput.Text = "";
            EditionInput.Text = "";
            MSRPInput.Text = "";
            StockInput.Text = "";

            InsertBtn.Enabled = true;
            DeleteBtn.Enabled = false;
            UpdateBtn.Enabled = false;
            BookIDInsert.Enabled = true;
        }
        private void ClearAllFieldsBtn(object sender, EventArgs e)
        {
            ClearAllFields(); // Clear all input fields
        }

        private string QueryByMSRP() // On Radio Button Click, Select every non-numerical value except for MSRP
        {
            string newQuery =
                "SELECT DISTINCT \n" +
                "B.BookID, " +
                "GROUP_CONCAT(DISTINCT IFNULL(BA.AuthorID, 'No Author')) AS AuthorID, " + // BA.AuthorID doesn't exist anymore due to joins, it's now AuthorID
                "GROUP_CONCAT(DISTINCT CONCAT(IFNULL(A.FirstName, ''), ' ', IFNULL(A.LastName, '')) SEPARATOR ', ') AS AuthorName, " + // Takes FirstName and LastName, and puts them together as AuthorName
                "B.Title, " +
                "B.Publisher, " +
                "B.PublicationYear AS YearPublished, " +
                "B.Genre, " +
                "B.Subgenre, " +
                "B.CountOfPages AS Pages, " +
                "B.Edition, " +
                "B.MSRP, " +
                "B.Stock " +
                "FROM Book B " +
                "LEFT JOIN BookAuthor BA ON B.BookID = BA.BookID " +
                "LEFT JOIN Author A ON A.AuthorID = BA.AuthorID " +
                "GROUP BY " +
                "B.BookID, B.Title, B.Publisher, B.Genre, B.Subgenre, " +
                "B.PublicationYear, B.CountOfPages, B.Edition, B.MSRP, B.Stock " +
                "HAVING Title LIKE @input " +
                "OR FirstName LIKE @input " +
                "OR LastName LIKE @input " +
                "OR Genre LIKE @input " +
                "OR Subgenre LIKE @input " +
                "OR Publisher LIKE @input " +
                "OR MSRP LIKE @input;";
            return newQuery;
        }

        private string QueryByPage() // On Radio Button Click, Select every non-numerical value except for Page Count
        {
            string newQuery =
                "SELECT DISTINCT \n" +
                "B.BookID, " +
                "GROUP_CONCAT(DISTINCT IFNULL(BA.AuthorID, 'No Author')) AS AuthorID, " + // BA.AuthorID doesn't exist anymore due to joins, it's now AuthorID
                "GROUP_CONCAT(DISTINCT CONCAT(IFNULL(A.FirstName, ''), ' ', IFNULL(A.LastName, '')) SEPARATOR ', ') AS AuthorName, " + // Takes FirstName and LastName, and puts them together as AuthorName
                "B.Publisher, " +
                "B.PublicationYear AS YearPublished, " +
                "B.Title, " +
                "B.Genre, " +
                "B.Subgenre, " +
                "B.CountOfPages AS Pages, " +
                "B.Edition, " +
                "B.MSRP, " +
                "B.Stock " +
                "FROM Book B " +
                "LEFT JOIN BookAuthor BA ON B.BookID = BA.BookID " +
                "LEFT JOIN Author A ON A.AuthorID = BA.AuthorID " +
                "GROUP BY " +
                "B.BookID, B.Title, B.Publisher, B.Genre, B.Subgenre, " +
                "B.PublicationYear, B.CountOfPages, B.Edition, B.MSRP, B.Stock " +
                "HAVING Title LIKE @input " +
                "OR AuthorName LIKE @input " +
                "OR Genre LIKE @input " +
                "OR Subgenre LIKE @input " +
                "OR Publisher LIKE @input " +
                "OR (CountOfPages >= @minPages AND CountOfPages <= @maxPages) " +
                "OR CAST(CountOfPages AS CHAR) LIKE @minPages";
            return newQuery;
        }

        private string QueryByPublicationYear() // On Radio Button Click, Select every non-numerical value except for Publication Year
        {
            string newQuery =
                "SELECT DISTINCT \n" +
                "B.BookID, " +
                "GROUP_CONCAT(DISTINCT IFNULL(BA.AuthorID, 'No Author')) AS AuthorID, " + // BA.AuthorID doesn't exist anymore due to joins, it's now AuthorID
                "GROUP_CONCAT(DISTINCT CONCAT(IFNULL(A.FirstName, ''), ' ', IFNULL(A.LastName, '')) SEPARATOR ', ') AS AuthorName, " + // Takes FirstName and LastName, and puts them together as AuthorName
                "B.Title, " +
                "B.Publisher, " +
                "B.PublicationYear AS YearPublished, " +
                "B.Genre, " +
                "B.Subgenre, " +
                "B.CountOfPages AS Pages, " +
                "B.Edition, " +
                "B.MSRP, " +
                "B.Stock " +
                "FROM Book B " +
                "LEFT JOIN BookAuthor BA ON B.BookID = BA.BookID " +
                "LEFT JOIN Author A ON A.AuthorID = BA.AuthorID " +
                "GROUP BY " +
                "B.BookID, B.Title, B.Publisher, B.Genre, B.Subgenre, " +
                "B.PublicationYear, B.CountOfPages, B.Edition, B.MSRP, B.Stock " +
                "HAVING Title LIKE @input " +
                "OR AuthorName LIKE @input " +
                "OR Genre LIKE @input " +
                "OR Subgenre LIKE @input " +
                "OR Publisher LIKE @input " +
                "OR PublicationYear LIKE @input;";
            return newQuery;
        }

        private string QueryByStock() // On Radio Button Click, Select every non-numerical value except for Stock
        {
            string newQuery =
                "SELECT DISTINCT \n" +
                "B.BookID, " +
                "GROUP_CONCAT(DISTINCT IFNULL(BA.AuthorID, 'No Author')) AS AuthorID, " + // BA.AuthorID doesn't exist anymore due to joins, it's now AuthorID
                "GROUP_CONCAT(DISTINCT CONCAT(IFNULL(A.FirstName, ''), ' ', IFNULL(A.LastName, '')) SEPARATOR ', ') AS AuthorName, " + // Takes FirstName and LastName, and puts them together as AuthorName
                "B.Title, " +
                "B.Publisher, " +
                "B.PublicationYear AS YearPublished, " +
                "B.Genre, " +
                "B.Subgenre, " +
                "B.CountOfPages AS Pages, " +
                "B.Edition, " +
                "B.MSRP, " +
                "B.Stock " +
                "FROM Book B " +
                "LEFT JOIN BookAuthor BA ON B.BookID = BA.BookID " +
                "LEFT JOIN Author A ON A.AuthorID = BA.AuthorID " +
                "GROUP BY " +
                "B.BookID, B.Title, B.Publisher, B.Genre, B.Subgenre, " +
                "B.PublicationYear, B.CountOfPages, B.Edition, B.MSRP, B.Stock " +
                "HAVING Title LIKE @input " +
                "OR AuthorName LIKE @input " +
                "OR Genre LIKE @input " +
                "OR Subgenre LIKE @input " +
                "OR Publisher LIKE @input " +
                "OR Stock LIKE @input;";
            return newQuery;
        }

        private string QueryByAuthorID() // On Radio Button Click, Select every non-numerical value except for AuthorID
        {
            string newQuery =
                "SELECT DISTINCT \n" +
                "B.BookID, " +
                "GROUP_CONCAT(DISTINCT IFNULL(BA.AuthorID, 'No Author')) AS AuthorID, " + // BA.AuthorID doesn't exist anymore due to joins, it's now AuthorID
                "GROUP_CONCAT(DISTINCT CONCAT(IFNULL(A.FirstName, ''), ' ', IFNULL(A.LastName, '')) SEPARATOR ', ') AS AuthorName, " + // Takes FirstName and LastName, and puts them together as AuthorName
                "B.Title, " +
                "B.Publisher, " +
                "B.PublicationYear AS YearPublished, " +
                "B.Genre, " +
                "B.Subgenre, " +
                "B.CountOfPages AS Pages, " +
                "B.Edition, " +
                "B.MSRP, " +
                "B.Stock " +
                "FROM Book B " +
                "LEFT JOIN BookAuthor BA ON B.BookID = BA.BookID " +
                "LEFT JOIN Author A ON A.AuthorID = BA.AuthorID " +
                "GROUP BY " +
                "B.BookID, B.Title, B.Publisher, B.Genre, B.Subgenre, " +
                "B.PublicationYear, B.CountOfPages, B.Edition, B.MSRP, B.Stock " +
                "HAVING AuthorIDs LIKE @input1 " +
                "OR Title LIKE @input " +
                "OR AuthorName LIKE @input " +
                "OR Genre LIKE @input " +
                "OR Subgenre LIKE @input " +
                "OR Publisher LIKE @input;";
            return newQuery;
        }

        private string QueryByBookID() // On Radio Button Click, Select every non-numerical value except for BookID
        {
            string newQuery =
                    "SELECT \n" +
                    "B.BookID, " +
                    "GROUP_CONCAT(DISTINCT IFNULL(BA.AuthorID, 'No Author')) AS AuthorID, " + // BA.AuthorID doesn't exist anymore due to joins, it's now AuthorID
                    "GROUP_CONCAT(DISTINCT CONCAT(IFNULL(A.FirstName, ''), ' ', IFNULL(A.LastName, '')) SEPARATOR ', ') AS AuthorName, " + // Takes FirstName and LastName, and puts them together as AuthorName
                    "B.Title, " +
                    "B.Publisher, " +
                    "B.PublicationYear AS YearPublished, " +
                    "B.Genre, " +
                    "B.Subgenre, " +
                    "B.CountOfPages AS Pages, " +
                    "B.Edition, " +
                    "B.MSRP, " +
                    "B.Stock " +
                    "FROM Book B " +
                    "LEFT JOIN BookAuthor BA ON B.BookID = BA.BookID " +
                    "LEFT JOIN Author A ON A.AuthorID = BA.AuthorID " +
                    "GROUP BY " +
                    "B.BookID, B.Title, B.Publisher, B.Genre, B.Subgenre, " +
                    "B.PublicationYear, B.CountOfPages, B.Edition, B.MSRP, B.Stock " +
                    "HAVING BookID LIKE @input1 " +
                    "OR Title LIKE @input " +
                    "OR AuthorName LIKE @input " +
                    "OR Genre LIKE @input " +
                    "OR Subgenre LIKE @input " +
                    "OR Publisher LIKE @input;";
            return newQuery;
        }

        private string SelectALL() // Selects Book Information and Author's First Name and Last Name
        {
            string cmd2 = "SELECT \n" +
            " B.BookID, " +
            "GROUP_CONCAT(DISTINCT IFNULL(BA.AuthorID, 'No Author')) AS AuthorID," + // BA.AuthorID doesn't exist anymore due to joins, it's now AuthorID
            "GROUP_CONCAT(DISTINCT CONCAT(IFNULL(A.FirstName, ''), ' ', IFNULL(A.LastName, '')) SEPARATOR ', ') AS AuthorName, " + // Takes FirstName and LastName, and puts them together as AuthorName
            " B.Title, " +
            " B.Publisher, " +
            " B.PublicationYear AS YearPublished, " +
            " B.Genre, " +
            " B.Subgenre, " +
            " B.CountOfPages AS Pages, " +
            " B.Edition, " +
            " B.MSRP, " +
            " B.Stock " +
            "FROM Book B " +
            "LEFT JOIN BookAuthor BA ON B.BookID = BA.BookID " +
            "LEFT JOIN Author A ON A.AuthorID = BA.AuthorID " +
            "GROUP BY " +
            " B.BookID, B.Title, B.Publisher, B.Genre, B.Subgenre, " +
            " B.PublicationYear, B.CountOfPages, B.Edition, B.MSRP, B.Stock;";
            return cmd2;
        }

        private string CreateReplaceTables() // Forcing an update if there was any information added if called
        {
            string cmd1 = "CREATE OR REPLACE VIEW vw_FormDisplay AS " +
            "SELECT \n" +
            " B.BookID, " +
            " CONCAT(IFNULL(BA.AuthorID, 'No Author')) AS AuthorID, " + // BA.AuthorID doesn't exist anymore due to joins, it's now AuthorID
            " CONCAT(IFNULL(A.FirstName, ''), ' ', IFNULL(A.LastName, '')) AS AuthorName, " + // Takes FirstName and LastName, and puts them together as AuthorName
            " B.Title, " +
            " B.Publisher, " +
            " B.PublicationYear AS YearPublished, " +
            " B.Genre, " +
            " B.Subgenre, " +
            " B.CountOfPages, " +
            " B.Edition, " +
            " B.MSRP, " +
            " B.Stock " +
            "FROM Book B " +
            "LEFT JOIN BookAuthor BA ON B.BookID = BA.BookID " +
            "LEFT JOIN Author A ON A.AuthorID = BA.AuthorID;"; ;
            return cmd1;
        }

        private bool CheckForEmptyString() // Check for empty inputs
        {
            return new[] {
            BookTitleInput.Text,
            FirstNameInput.Text,
            GenreInput.Text,
            SubGenreInput.Text,
            PageCountInput.Text,
            PublicationYearInput.Text,
            PublisherInput.Text,
            EditionInput.Text,
            MSRPInput.Text,
            StockInput.Text
            }.Any(string.IsNullOrWhiteSpace);
        }

        // Below is just all of the labels being initalized, nothing really happens below this point

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchByBookTitleLabel_Click(object sender, EventArgs e)
        {

        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void label1_Click_4(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void NameOfAuthorLabel_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void SearchByID_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SearchByMSRP_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
