##Book Outlet Website
#Project Overview
This project is an outlet-like website for selling books at lower prices from various publishing houses. The platform features time-limited sales and future book promotions. Users can view current and upcoming book deals through the status section of each book post.

##Technology Stack
Frontend: ASP.NET Core, CSS, Bootstrap
Backend: ASP.NET Core, JavaScript (for functionality like filtering), Bootbox (for deleting records)
Database: SQL
##User Roles
Visitors: Can browse books, view details, and see the status of book sales.
Users: Can create an account, log in, and purchase books.
Admins: Have full control to add, edit, and delete books, authors, and publishing houses.
Features
##Navigation Bar: Home, Search, Register, and Login.
#Search Functionality: Search by book title, author, and category.
#Book Listing: Displays category, author, status (on sale, upcoming, ended).
#Book Details: Detailed view includes book description and publishing house info.
#Purchase System: Buy button visible but inactive until user logs in.
#Authorization: Managed at both View and Controller levels using Authorize.
##User Registration & Login
#Registration: Requires first name, last name, address, and password with validation.
#Login: Provides access to purchase books.
##Purchasing Process
#Basket: Add books to basket, adjust quantity, view price updates.
#Payment: Integrated with PayPal Sandbox for testing transactions in USD (due to limitations with MKD).
##Admin Capabilities
#Manage Content: Add, edit, and delete books, authors, and publishing houses.
#Orders Management: View all executed orders.
##Usage Instructions
#Visitor: Browse books, view details, and register/login for purchasing.
#User: After logging in, add books to the basket and proceed to checkout using PayPal.
#Admin: Manage books, authors, publishing houses, and view all orders.
