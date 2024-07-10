
# Book Outlet Website

## Project Overview
This project is an outlet-like website designed to sell books at lower prices from various publishing houses. The platform features time-limited sales and showcases future book promotions. Users can view current and upcoming book deals through the status section of each book post.

## Technology Stack
- **Frontend**: ASP.NET Core, CSS, Bootstrap
- **Backend**: ASP.NET Core, JavaScript (for functionality like filtering), Bootbox (for deleting records)
- **Database**: SQL

## User Roles
1. **Visitors**: Can browse books, view details, and see the status of book sales.
2. **Users**: Can create an account, log in, and purchase books.
3. **Admins**: Have full control to add, edit, and delete books, authors, and publishing houses.

## Features
- **Navigation Bar**: Includes links to Home, Search, Register, and Login pages.
- **Search Functionality**: Users can search for books by title, author, and category.
- **Book Listing**: Displays information about each book, including category, author, and sale status (on sale, upcoming, or ended).
- **Book Details**: Detailed view includes the book description and publishing house information.
- **Purchase System**: The buy button is visible but inactive until the user logs in.
- **Authorization**: Managed at both the View and Controller levels using `Authorize`.

## User Registration & Login
- **Registration**: Requires first name, last name, address, and password with validation.
- **Login**: Allows users to access purchase functionalities.

## Purchasing Process
- **Basket**: Users can add books to the basket, adjust quantities, and view updated prices.
- **Payment**: Integrated with PayPal Sandbox for testing transactions in USD (due to limitations with MKD).

## Admin Capabilities
- **Manage Content**: Add, edit, and delete books, authors, and publishing houses.
- **Orders Management**: View all executed orders.

## Usage Instructions
1. **Visitor**: Browse books, view details, and register/login for purchasing.
2. **User**: After logging in, add books to the basket and proceed to checkout using PayPal.
3. **Admin**: Manage books, authors, publishing houses, and view all orders.

