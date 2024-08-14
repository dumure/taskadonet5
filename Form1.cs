using static System.Reflection.Metadata.BlobBuilder;

namespace taskadonet5
{
    public partial class Form1 : Form
    {
        private LibraryContext libraryContext;
        public Form1()
        {
            InitializeComponent();
            libraryContext = new LibraryContext();
            comboBox1.DataSource = new List<string>() { "Themes", "Categories", "Authors" };
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void UpdateListView()
        {
            List<Book> books = new List<Book>();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        foreach (Book book in libraryContext.Books.ToList())
                        {
                            if ((comboBox2.SelectedItem as Theme).Id == book.Id_Themes) books.Add(book);
                        }
                        break;
                    }
                case 1:
                    {
                        foreach (Book book in libraryContext.Books.ToList())
                        {
                            if ((comboBox2.SelectedItem as Category).Id == book.Id_Category) books.Add(book);
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (Book book in libraryContext.Books.ToList())
                        {
                            if ((comboBox2.SelectedItem as Author).Id == book.Id_Author) books.Add(book);
                        }
                        break;
                    }
            }
            listBox1.DataSource = null;
            listBox1.DataSource = books;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        comboBox2.DataSource = libraryContext.Themes.ToList();
                        break;
                    }
                case 1:
                    {
                        comboBox2.DataSource = libraryContext.Categories.ToList();
                        break;
                    }
                case 2:
                    {
                        comboBox2.DataSource = libraryContext.Authors.ToList();
                        break;
                    }
            }
            UpdateListView();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            libraryContext.Dispose();
        }
    }
}
