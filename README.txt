How to use the application:

 ==========================Setup ===================================

1) Use any other browser than Internet Explorer and Edge for the full experience. 

2) Go to the appsetting.json file and change the connection string to match your sql server. Change the "Catalog" to a appropriate name. 

3) Go to the package manager console and enter the command: update-database. (The database will now be setup with the seeded data and the user logins stated above)


====================Logins with different claims = different views ==========================

 - Waiter login: 
 Brugernavn: waiter@waiter.com
 Password:   Sommer25!

 - Receptionist login:
 Brugernavn: reception@reception.com
 Password:   Sommer25!

 - KitchenStaff login:
 Brugernavn: Kitchen@kitchen.com
 Password:   Sommer25!


 ==========================Use case 1 (Kitchen view (IPad)) ==================================

 1) Start the application by ctrl + F5.

 2) Push F12 and change the view size by pushing the "toggle device toolbar". Choose "IPad".

 3) Push the login button. Enter the above stated KitchenStaff login. (You'll now be transfered to the kitchen IPad friendly view.)

 4) KEEP THE WINDOW OPEN. 

 Extra) You may choose register rather than login if you'd like and register yourself as an user. But the rights needed to enter the views, needs to be setup either directly in the database or by the repository API. 


 ==========================Use case 2 (Receptionist view (Desktop))============================

 1) Start the application once again by ctrl + F5. (If you'r still logged in as an kitchen staff user, please choose to logout)

 2) Push the login button. Enter the above stated Receptionist login. (You'll now be transfered to the Receptionist desktop friendly view)

 3) Push the "Add new guest" button, fill ind the needed information and push the add new guest button.

 4) *Optional: Push the Edit/Remove button to see all guest, their details and perhaps remove the one you just created. 
 5) *Optional: If you didn't remove a guest you can go back to the kitchen view, push the update button and see the numeric changes of the tables. 

 6) Push the book breakfast button to book breakfast for one or more of the rooms. Fill out the date with a date within 5 five days from now. 

 7) Push the book breakfast button after entering the date for either the whole room or single guests. 

 8) Push the Reservation - Next 5 days button. 

 9) *Optional: Push the cancel all reservations button and make some new reservations. 

 10) You may either close this view of keep it open for further changes later on. 


 ==========================Use case 3 (Waiter view (Mobile)) ==================================

 1) Start the application once again by ctrl + F5. (If you'r still logged in as an receptionist user, please choose to logout)

 2) Push the login button. Enter the above stated Waiter login. (You'll now be transfered to the waiter mobile device friendly view)

 3) Select a room number from the drop down that contains guests. Example: Room 1. 

 4) Push the Check-in button for one or more of the guests. 

 5) Go back to kitchen window that you've kept open, and press the update button. 

 6) You'll now see that the numeric values of the tables has changed accordingly to the guests checked in by the waiter. 

 7) *Optional: You can push the "Checkout all guests" to checkout all guest from the restaurant.


 =====================================Use case 4 ============================================

 1) Have fun, and try out the solution :-)

 ==========================Funny Corner Cases ===================================
 1) If you try to book a guest for breakfast in the receptionist view, then go to waiter view, to check that guest in for breakfast and then go back 
 to receptionist view to book that same guest for breakfast for today, you will get the message that, that paticular guest has already eaten today.
 It is however possible to book breakfast for the future, like tomorrow. 

 2) If a guest has already eaten today but the rest of the guest i the room has not. You can still use the, book breakfast for all button, but the
 guest who has not eaten, will not be added to the reservation view. Verify this by looking at the bookings for the next 5 days in receptionist view
=======