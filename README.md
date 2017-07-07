# LI Watermellon Coding TEst

## ASP.NET Developer Exam
### Objectives
The objective of this exercise is to implement a single ASP.NET page which allows users to enter a
watermelon themed competition. Users will be able to access this page without logging in and will be able to
submit a form on the page to enter the competition with their details. Upon completing the form the
information should be stored in a database and an email should be sent to the user confirming that they’ve
entered the competition.
### Delivery
When you are finished with the task please zip the website folder and make sure any related/required files
are enclosed. Please also use the Entity Framework Code First method to build your database and do not
submit a SQL script to create the database.
### Requirements
- This application must be a compiled ASP.NET MVC 3, 4, or 5 website. DO NOT USE ASP.NET
WEB FORMS.
- Maximum time for this task is 4 hours. It is not expected that you will finish everything; just enough
that we can get a feel for the direction that you take to find a solution and get as far as you can with
development within the timeframe.
- The language must be C#
- The database must be either a SQL Server 2008 or 2012 database
- All forms must have validation associated to the input controls
- Entity Framework Code First must be used for the database layer
- It is expected you will follow the original design as closely as possible.
- Note that all fonts used in the design are Google Web Fonts.
- Please ensure that your name is placed somewhere prominent in the code.
### Functional Requirements
Please ensure that you follow modern coding best practices when you create this page. Whilst it is important
that you try and implement as much of the design as possible, we will mainly be examining the code of the
solution so remember to treat the functionality of the page as the most important element of the task. Design
files have been provided for you to export and use in the site however you see fit. 
### FORM FIELDS
The form must contain all the following fields which must be validated accordingly and show meaningful
feedback to the user upon not validating.
Field Input Validation
Full name Textbox Required
Email Textbox Required, valid email, email autocomplete (see autocomplete)
Male / Female Radio button Required
Where is your favourite
place to eat
watermelon?
Multiline
textbox
Required, 100 words maximum. One word is any string of
characters separated by a space (eg: ‘Here’s my test entry’ –
4 words)
Terms and conditions Checkbox Required
### Autocomplete
The email field of the form should not allow users who have already entered the database to enter a second
time. When the user fills in their email address it should make a web service call to the database to check if
the email address already exists in the system and notify the user if their entry has already been received
previously. The user should not have to submit the form to see this validation.
Database
When the user submits the form a record should be created in a SQL database with their entries. This
database must not allow the user to enter the competition if their address is already in the system.
Email Send
When the user successfully submits the form an email should be sent to the account which they registered
with informing them that they’ve successfully entered. This email should contain all the details they entered
on the form. While it is up to you how you implement email, Liquid would recommend using a temporary
Gmail account as this approach should work on your local machine and on the Liquid server without much
configuration.
###Bonus Functionality
This functionality is not required to complete the exam, but any items you can implement within the given
timeframe would be beneficial to your application.
- The site should display well in all modern browsers as well as at any screen width.
- When the form submits the user should be shown a thank you message on the page.
- There user should be able to see instantly how many words are in the multiline textbox while typing
- The submit buttons should be disabled until the T&Cs is checked.
