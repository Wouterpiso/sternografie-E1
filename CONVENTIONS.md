# Tabs for indentation

This is how we are going to do it. it makes it more readable.

# PascalClass for classes, states and singletons, camelCase for variables, functions and properties.

Example:

```
	MyClass = myFunction () {...};
	state = State.Filling_With_Zeros;

	R = pixel.R - pixel.R % 2;
	G = pixel.G - pixel.G % 2;
	B = pixel.B - pixel.B % 2;
```

# Comments above every block of code

This is to make sure that everyone knows what a piece or block of code does, making it clearer and more readable.

# Semicolons

Almost every line should end in a semicolon.

The only exceptions are } that dont ask for them.

# if, else, switch statements

All lines in statements should be indented up once with tab.

Example:

```
	if (secretTextTbx.Text == "Write your secret text here...")
            {
                secretTextTbx.Text = "";
                secretTextTbx.ForeColor = Color.Black;
            }
```

# Keep lines as short as possible (under 80 characters)

Try to keep to 80 characters or less but that is a simple guidline. still, keeping lines short makes it more readable.

# Braces on seperate lines as the thing that started them.

this is ok:
```
	if (secretTextTbx.Text == "Write your secret text here...")
            {
                secretTextTbx.Text = "";
                secretTextTbx.ForeColor = Color.Black;
            }
```

this is not:
```
	if (secretTextTbx.Text == "Write your secret text here...") {
                secretTextTbx.Text = "";
                secretTextTbx.ForeColor = Color.Black;
            }
```

# Keep elses on seperate lines

this is ok:
```
	if (see)
    {
    ...
    }
    else
    {
    ...
    }
```

this is not:
```
	if (see)
    {
    ...
    } else
    {
    ...
    }
```

# Keep properties meaningfull and add the property type at the end

yes: imageLoaderPB, imageUploaderBTN, secretTextTBX

no: pictureBox3, uploadButton, secretTextBox


