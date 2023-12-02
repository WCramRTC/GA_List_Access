# GA_List_Access

## Explanation

A list is an object that is used to hold multiple objects of the same type, like an array. A list has easy to use functionality that allows you to easily add, remove, and insert items into it. 

The key functionality is

**Creating A List**
```csharp
	List<type> listName = new List<type>();

	Example:
	List<string> names = new List<string>();
```

**Adding to the list**
```csharp
	listName.Add(item); // This adds the item to the end of our list
```

**Accessing a value**
```csharp
	listName[index]; // Just like an array, we use square brackets and an index to access the value of a single element
```

**Removing an item**
```csharp
	listName.Remove(item); // Removes the first instance of a specific item that matches the argument

	listName.RemoveAt(index); // Removes the item at the specific index
```

**Inserting an Item**
```csharp
	name.Insert(index, item); // This inserts an item at a specific index
```

**Count of Elements**
```csharp
	int index = listName.Count; // listName.Count will return the number of items inserted into the list. So if there are 5 names, the count will be 5.
```

---

## Quick Assignment

1. Add a label to display the counts of elements in a list
2. Add a editor that is read only to display information
3. Add a label that says "Enter a name"
4. Add a entry for a user to input information
5. Add a label that says "Enter Index"
6. Add an entry that will take an index the user passes in 
7. Add a button that says Add Information that, when pressed, will add the information to a global list in our c#. The information will now update on the editor.
8. Add a button that will take the users name input and index input and UPDATES the information ( changes or reassigns the value )
9. Add a button that will take the users name input and index input and adds the name to the list at that location.
10. Add a button that clears the list

---

## Step By Step

### Step 1 - Create A New Project

Create a new Maui project.
    - Give it a name of ***GA\_Editor\_YourName***
    - Remove provided template code

### Step 2 - Add the Controls to our .Xaml

Add the following controls to your project.

`MainPage.xaml`
```XML
    
    <!-- Label to display the count of elements in the list -->
    <Label
        x:Name="labelCount"
        Text="Count: 0" />

    <!-- Editor to display information, set as read-only -->
    <!-- Height request will let the editor resize so you can scroll it -->
    <Editor
        x:Name="editorInfo"
        IsReadOnly="True"
        HeightRequest="100" />

    <!-- Label indicating where to enter a name -->
    <Label
        Text="Enter a name" />

    <!-- Entry field for user to input a name -->
    <Entry
        x:Name="entryName"
        Placeholder="Name" />

    <!-- Label indicating where to enter an index -->
    <Label
        Text="Enter Index" />

    <!-- Entry field for user to input an index, numeric keyboard for ease of input -->
    <Entry
        x:Name="entryIndex"
        Placeholder="Index"
        Keyboard="Numeric" />

    <!-- Buttons for various actions, each with an event handler -->
    <!-- Button we will use to Add an item to our list -->
    <Button
        x:Name="buttonAdd"
        Text="Add Information"
        Clicked="buttonAdd_Clicked"
            />
    <!-- Button we will use to Update our list -->
    <Button
        x:Name="buttonUpdate"
        Text="Update Information"
        Clicked="buttonUpdate_Clicked"
            />

    <!-- Button used to insert an item into our list -->
    <Button
        x:Name="buttonInsert"
        Text="Insert at Index"
        Clicked="buttonInsert_Clicked"
            />

    <!-- Button used to remove an item from our list -->
    <Button
        x:Name="buttonRemove"
        Text="Remove at Index"
        Clicked="buttonRemove_Clicked"
            />

    <!-- Button used to clear our list of all items -->
    <Button
        x:Name="buttonClear"
        Text="Clear List"
        Clicked="buttonClear_Clicked"
            />     
```

### Step 3 - Add a List object to our code

`MainPage.xaml.cs`

We are going to add a global List that will hold a handful of names. To declare a list you will add the following name above your MainPage() method.

```csharp
    List<string> names = new List<string>();
```

The first part, `List<string>`, is how we declare our list. We can replace the word string with any type. int, double, bool, etc...

This is followed by the name of our list. Our list will store multiple names, so we call it names. Standing naming convention means list names tend to be plural.

After that we do =, and the `new` keyword. The `new` keyword tells C# to make place in memory for our object.

Then we repeat our declaration, `List<string>` followed by ();.

Again our full syntax is `List<string> names = new List<string>();`


### Step 4 - .Add() - Adding items to our list.

Inside of our `MainPage()` method, we are going to add items to our list. Put the following code.

```csharp
    names.Add("Kristyn");
```

Here with start off with the name of our list, `names`. This is followed by dot Add. This is a method that lets us add items to our list. We place the item we want to add, here a string, to our list. `names.Add("Kristyn");` will add the name Kristyn to our list. Do this 4 more times with different names.

Example

```csharp
    names.Add("Manjula");
    names.Add("Desmond");
    names.Add("Jonathan");
    names.Add("Christie");
```

You should have added 5 names. They are added in order, so Kristyn would be the first name, and Christie would be the last in this example. An item stored in a list is reffered to as an Element.

### Step 5 - Displaying Elements

We are going to create a method to display our names to our Editor.

Create a NEW method with the following code. This should be written outside of MainPage().

```csharp
    private void UpdateInfoEditor()
    {
        editorInfo.Text = ""; // Clear the current text
        foreach (var name in names)
        {
            editorInfo.Text += name + "\m"; // Append each name with a newline
        }
    }
```

The first line, `editorInfo.Text = ""`, is used to erase information from our editorInfo display.

Then for ease of use we are going to use a foreach to loop through our list, just like we can with an array.

Inside you notice we use a `var` keyword. This is like in javascript where it will guess the type were working with. You could have typed `string` and it would work the same.

Then we do the word name, which is our variable placeholder name, followed by in, and then the name of our list, which is names.

And finally inside of our foreach we do `editorInfo.Text += name + "\n";`. Which is just looping through our list, adding the current name, and then going next line.

After this method is created, call it in `MainPage()` by typing

```csharp
    UpdateInfoEditor();
```

Result: When you run your code, the names should appear in your editor.

### Step 6 - Displaying the Count

Create another method with the following code

```csharp
    private void UpdateCountLabel()
    {
        // Refresh the labelCount with the current numbers of elements in the list
        labelCount.Text = $"Count: {names.Count}";
    }
```

This method will be used to display how many items our in our list. 

The labelCount.Text is just assigning a value to our label. But the important part is `names.Count`.

Every list has a `.Count` property. This returns the number of elements in our list. Right now we have 5 names, so it will display 5.

Call this method inside of our `MainPage()` with

```csharp
    UpdateCountLabel();
```

Your `MainPage()` should currently look like

```csharp
    public MainPage()
        {
            InitializeComponent();

            // Add names to the list
            names.Add("Kristyn");      
            names.Add("Manjula");
            names.Add("Desmond");
            names.Add("Christie");
            names.Add("Will");

            // Call the UpdateInfoEditor() to update the display with names
            UpdateInfoEditor();
            // Call UpdateCountLabel() to update the count of elements on the top label
            UpdateCountLabel();
        }
```

### Step 7 - Add Button

After making your xaml code, including events, you should have 5 methods to work with. The first event is `buttonAdd_Clicked`. 

Enter the following code inside that method.

```csharp
    names.Add(entryName.Text); // Add the entered name to the list
    UpdateInfoEditor(); // Update the editor to display the new list
    UpdateCountLabel(); // Update the count label
```

The first line of code should be familiar. We are adding to our names list. We are passing the value of our `entryName.Text`.

The following lines `UpdateInfoEditor()` and `UpdateCountLabel()` are called afterward so the information is redisplayed.

When we run our code, when we type in a name, and click Add Name, the name should now appear in the editor, and the Count should now be updated.

### Step 7 - Button Update

This next block of code is for our `buttonUpdate_Clicked` event. Inside of there add the following code.

```csharp
    if (int.TryParse(entryIndex.Text, out int index) && index >= 0 && index < names.Count)
    {
        names[index] = entryName.Text; // Update the name at the specified index
        UpdateInfoEditor(); // Update the editor to display the new list
    }
```

We have a few things happening here. First we are validating the information coming in.

We have a statement `if (int.TryParse(entryIndex.Text, out int index) && index >= 0 && index < names.Count)`.

If we pay attention we can see this is checking for 2 different things. 

Part 1.

`int.TryParse(entryIndex.Text, out int index) `

This is checking to see if the string entered into our entryIndex.Text is a number, and outputting as the variable if it is.

Part 2.

`index >= 0 && index < names.Count`

This is checking to make sure that the number entered is between 0 and the last index in our list.

Without these validations, if the wrong number was entered our application would crash.

Now inside of our validation is

```csharp
names[index] = entryName.Text; // Update the name at the specified index
UpdateInfoEditor(); // Update the editor to display the new list
```

Just like working with arrays, you use square brackets, [], and pass in an index to work with a specific value. So

`names[index] = entryName.Text;` Is letting us change the name of whoever is at the entered index.

Example: `names[4] = "Josh";` would switch Wills name to Josh.

The last line is just to update the list to redisplay the names.

### Step 8 - Insert

Using `.Add()` always adds to the bottom of our list. The `.Insert()` method lets you add a name at a specific index. Type the following code into our `buttonInsert_Clicked` event.

```csharp
if (int.TryParse(entryIndex.Text, out int index) && index >= 0 && index <= names.Count)
{
    names.Insert(index, entryName.Text); // Insert the name at the specified index
    UpdateInfoEditor(); // Update the editor to display the new list
    UpdateCountLabel(); // Update the count label
}
```

Most of this code should be familiar by now. The if statement is to validate that the index is a number, and within range.

The UpdateInfoEditor and UpdateCountLabel redisplay information.

Our new code is `names.Insert(index, entryName.Text)`. This is calling the `.Insert` method on our names list. It then takes 2 arguments. The first is the index you would like to add our name at, the second is the name.

If you called `names.Insert(0, "Jonathan");` then Jonathan name would be added to the front of the List.

### Step 9 - Remove At

The `.RemoveAt()` method lets you remove an element at a specific index.

Enter the following code into our `buttonRemove_Clicked` event.

```csharp
    if (int.TryParse(entryIndex.Text, out int index) && index >= 0 && index < names.Count)
    {
        names.RemoveAt(index); // Remove the name at the specified index
        UpdateInfoEditor(); // Update the editor to display the new list
        UpdateCountLabel(); // Update the count label
    }
```

The new method is `names.RemoveAt(index)`. Called this method and passing in a specific index removes the item at that index from the list. The following elements on the list now have then index subtracted by 1. 

You may notice our method is `.RemoveAt()`. There are other removes that let you search for an object, and even remove a range of objects.

### Step 10 - Clear List

This last event will clear the entire list, removing all items from it.

Inside the `buttonClear_Clicked`, type the following code.

```csharp
    names.Clear();
    UpdateInfoEditor();
    UpdateCountLabel();
```

The `.Clear()` method will clear ALL items from the list. So be careful with this one.

When you run the code and click this button, the nothing should display, and the Count will be 0.

### Finale

This is a introduction to the most commonly used Methods with our list.

---




## Full Code

`Xaml Code`
```xml
<ScrollView>
        <!-- Vertical layout to stack elements vertically -->
        <VerticalStackLayout
            Spacing="15"
            Padding="15">

            <!-- Label to display the count of elements in the list -->
            <Label
                x:Name="labelCount"
                Text="Count: 0" />

            <!-- Editor to display information, set as read-only -->
            <Editor
                x:Name="editorInfo"
                IsReadOnly="True"
                HeightRequest="100" />

            <!-- Label indicating where to enter a name -->
            <Label
                Text="Enter a name" />

            <!-- Entry field for user to input a name -->
            <Entry
                x:Name="entryName"
                Placeholder="Name" />

            <!-- Label indicating where to enter an index -->
            <Label
                Text="Enter Index" />

            <!-- Entry field for user to input an index, numeric keyboard for ease of input -->
            <Entry
                x:Name="entryIndex"
                Placeholder="Index"
                Keyboard="Numeric" />

            <!-- Buttons for various actions, each with an event handler -->
            <Button
                x:Name="buttonAdd"
                Text="Add Information"
                Clicked="buttonAdd_Clicked"
                 />
            <Button
                x:Name="buttonUpdate"
                Text="Update Information"
                Clicked="buttonUpdate_Clicked"
                 />
            <Button
                x:Name="buttonInsert"
                Text="Insert at Index"
                Clicked="buttonInsert_Clicked"
                 />
            <Button
                x:Name="buttonRemove"
                Text="Remove at Index"
                Clicked="buttonRemove_Clicked"
                 />
            <Button
                x:Name="buttonClear"
                Text="Clear List"
                Clicked="buttonClear_Clicked"
                 />     

        </VerticalStackLayout>
    </ScrollView>
```

`C# Code`
```csharp
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
```