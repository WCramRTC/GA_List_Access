namespace GA_List_Access
{
    public partial class MainPage : ContentPage
    {

        // Declare a global variable list to hold a list of strings, names
        List<string> names = new List<string>();

        public MainPage()
        {
            InitializeComponent();

            // Add names to the list
            names.Add("Desmond");
            names.Add("Manjula");
            names.Add("Kristyn");
            names.Add("Josh");
            names.Add("Will");

            // Call the UpdateInfoEditor() to update the display with names
            UpdateInfoEditor();
            // Call UpdateCountLabel() to update the count of elements on the top label
            UpdateCountLabel();
        }

        private void UpdateInfoEditor()
        {
            editorInfo.Text = ""; // Clear the current text
            foreach (var name in names)
            {
                editorInfo.Text += name + Environment.NewLine; // Append each name with a newline
            }
        }

        private void UpdateCountLabel()
        {
            // Refresh the labelCount with the current numbers of elements in the list
            labelCount.Text = $"Count: {names.Count}";
        }

        private void buttonAdd_Clicked(object sender, EventArgs e)
        {
            names.Add(entryName.Text); // Add the entered name to the list
            UpdateInfoEditor(); // Update the editor to display the new list
            UpdateCountLabel(); // Update the count label
        }

        private void buttonUpdate_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(entryIndex.Text, out int index) && index >= 0 && index < names.Count)
            {
                names[index] = entryName.Text; // Update the name at the specified index
                UpdateInfoEditor(); // Update the editor to display the new list
            }
        }

        private void buttonInsert_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(entryIndex.Text, out int index) && index >= 0 && index <= names.Count)
            {
                names.Insert(index, entryName.Text); // Insert the name at the specified index
                UpdateInfoEditor(); // Update the editor to display the new list
                UpdateCountLabel(); // Update the count label
            }
        }

        private void buttonRemove_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(entryIndex.Text, out int index) && index >= 0 && index < names.Count)
            {
                names.RemoveAt(index); // Remove the name at the specified index
                UpdateInfoEditor(); // Update the editor to display the new list
                UpdateCountLabel(); // Update the count label
            }
        }

        private void buttonClear_Clicked(object sender, EventArgs e)
        {
            names.Clear();
            UpdateInfoEditor();
            UpdateCountLabel();
        }
    }
}