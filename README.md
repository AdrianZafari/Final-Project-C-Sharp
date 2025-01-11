# Contact Manager in C# 

This is a simple solution that consists of two seperate aplications that cover basic CRUD functionality with local data storage (json file in a local directory).
All the main methods used for CRUD were mocked where needed and tested to make sure that they behave as desired.  

## Console Application 

This is a simple application that is capable of creating a contact, adding the contact to a json file, then reading that json file upon launch and displaying the contacts. 
It also features a quit prompt. 

## MAUI Blazor Hybrid Application

To get the highest grade, we were tasked with creating an application with a GUI that could carry out full CRUD functionality. We were asked to have a page for displaying all contacts, a page to view all contacts, and a page to edit a selected contact. 
The latter point was achieved using query parameters particular using the .NET `NavigationManager` library. 

### How to use

1. Create a contact by pressing the `Add New Contact` menu option
2. Fill in the contact information and follow the instructions on the page, after 1.5s you shall be returned to the Contacts page 
3. You may use the search bar to find a particular contact based on their contact information
4. Click on a contact to open the dropdown showing their contact information. 
5. Should you want to Edit them, press the yellow notepad button at the bottom of the drop-down panel, this takes you to the edit page.
6. After you made your changes, press the `Update Contact` button. After 1.5s you shall be returned to the Contacts page. If you did not intend on making any changes, then pressing `Update Contact` will not overwrite any of your pre-existing information
7. If you want to Delete a contact press the red trash button next to the edit button, this bring up a modal that will ask you to confirm your choice.
8. Simply close the application window to exit.
\
\
NOTE: The application was designed particularly with the Windows OS in mind. Running it on other operating systems may cause the applcation to behave unpredictably.
