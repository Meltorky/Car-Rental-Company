# 🚗 Hexina Car Rental Booking System

Hexina is a modern web application built with **ASP.NET 8 MVC** for managing car rentals. Users can register, log in, and book available cars. Admins can manage car brands, features, and inventory through a secure panel. The system features dynamic filtering and date-aware booking to prevent double reservations.

---

## 🌟 Features

### 👤 User Features
- Register & login using Microsoft Identity
- Browse and filter cars by brand, features, or availability
- Book a car for specific dates
- Cancel bookings (only if the start date hasn't passed)
- Only available cars for the selected date range are shown

### 🛠️ Admin Features
- Secure admin dashboard
- CRUD operations for:
  - Brands
  - Features
  - Cars
- View and manage all bookings

---

## ⚙️ Tech Stack

- ✅ ASP.NET 8 MVC
- ✅ Entity Framework Core
- ✅ LINQ
- ✅ SQL Server
- ✅ Bootstrap 5
- ✅ Microsoft Identity
- ✅ Clean Architecture (4-Tiered)
- ✅ Repository Pattern (with Base Repository)
- ✅ DTOs, ViewModels, Services
- ✅ OOP Principles (Interface Segregation, DRY, YAGNI)
- ✅ Identity Seeder for roles and default admin

---

## 🚀 Getting Started

You can run this project like any standard .NET 8 MVC application. 😉

### 🧩 Steps

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/your-repo-name.git
2. Open the solution in Visual Studio 2022 or later

3. Update appsettings.json

   Add your SQL Server connection string.

4. Apply migrations
   ```bash
   Update-Database

5. Run the application

   Hit F5 or press "Run".

## 🧠 Architecture Notes

- This project was built using best practices in real-world software development:
- Clean separation of layers: Presentation, Application, Infrastructure, and Domain
- Reusable base repository for all entities
- Asynchronous methods for better performance
- Booking logic ensures no car is double-booked, by preventing selection if already reserved for the selected date range.
