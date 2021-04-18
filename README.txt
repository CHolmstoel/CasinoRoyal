How to use the application:

 ==========================Setup ===================================

1) Use any other browser than Internet Explorer and Edge for the full experience. 

2) Go to the appsetting.json file and change the connection string to match your sql server. Change the "Catalog" to a appropriate name. 

3) Go to the package manager console and enter the command: update-database. (The database will now be setup with the seeded data and the user logins stated above)

==========================Logins with different claims = different views ===================================

- Waiter login: 
 Brugernavn: waiter@waiter.com
 Password:   Sommer25!

 - Receptionist login:
 Brugernavn: reception@reception.com
 Password:   Sommer25!

 - KitchenStaff login:
 Brugernavn: Kitchen@kitchen.com
 Password:   Sommer25!



 ==========================Use case 1 (Kitchen view (IPad)) ===================================

 1) Start the application by ctrl + F5.

 2) Push F12 and change the view size by pushing the "toggle device toolbar". Choose "IPad".

 3) Push the login button. Enter the above stated KitchenStaff login. (You'll now be transfered to the kitchen IPad friendly view.)

 4) KEEP THE WINDOW OPEN. 

 Extra) You may choose register rather than login if you'd like and register yourself as an user. But the rights needed to enter the views, needs to be setup either directly in the database or by the repository API. 


 ==========================Use case 2 (Desktop receptionist view)===================================

 1) Start the application once again by ctrl + F5. 

 2) Push the login button. Enter the above stated Receptionist login. (You'll now be transfered to the Receptionist desktop friendly view)

 3) Push the "Add new guest" button, fill ind the needed information and push the add new guest button.

 4) *Optional: Push the Edit/Remove button to see all guest, their details and perhaps remove the one you just created. 
 5) *Optional: If you didn't remove a guest you can go back to the kitchen view, push the update button and see the numeric changes of the tables. 

 5) Push the book breakfast button to book breakfast for one or more of the rooms. Fill out the date with a date within 5 five days from now. 

 6) Push the book breakfast button after entering the date for either the whole room or single guests. 

 7) Push the Reservation - Next 5 days button. 

 8) *Optional: Push the cancel all reservations button and make some new reservations. 

 9) You may either close this view or keep it open for further changes later on. 

 ==========================Use case 3 ===================================

 1) 

 ==========================Use case 4 ===================================