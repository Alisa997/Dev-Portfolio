# Final Assignment
### Course: Object-Oriented Programming Using C++

Using STL, develop three console applications with a menu to solve the following tasks.

---

## Task 1 (mandatory, max 8 points)

In a vector consisting of **n integer elements**, implement the following menu commands:

- Count the number of vector elements equal to **0**
- Find the **sum of elements located after the minimum element**
- Remove elements that appear **less than twice**
- Sort the vector in **ascending order of absolute values**
- **Duplicate negative elements**
- Save the vector to a **binary file** using an output stream
- Read the vector from a **binary file** using an input stream

---

## Task 2 (for candidates for 10 points)

Using **classes, STL algorithms, and lambda expressions**, write an application to solve the following problem:

### Library Book Accounting System

Each **book** includes:
- Identifier (inventory number)
- Author surname and initials
- Book title
- Year of publication
- Number of copies

The **library** includes:
- Address
- Director surname and initials
- Book collection

Store data in a **CSV text file** using `;` as a separator.

### File Format
- First line → library data
- Each following line → one book
- On first launch: initialize **at least 12 books**
- Application must use a menu

### Required Features
- Output library and book data to console
- Add a book from keyboard input and save to file
- Remove books by identifier and save to file
- Modify number of books by author and save to file
- Filter by year → output sorted by year (without modifying original or file)
- Filter by author → output sorted by author (without modifying original or file)
- Sort books by:
  - Number of copies (descending)
  - Identifier
  - Title  
  Output results to console without modifying the file

> Minimize loops — maximize use of STL algorithms.

---

## Task 3 (for candidates for 12 points) – Option 2

Develop an application for a **fitness club**, which conducts trainings in its halls, with trainers or independently by clients. The club can also rent halls to external trainers.

### System Entities & Rules
- **User categories:** clients, trainers, administration
- **Halls:** gym, aerobics hall, martial arts hall

### Clients
- Can view:
  - Group class schedules
  - Hall occupancy
  - Individual training availability
- Can register for:
  - Group sessions
  - Personal sessions
- If **fewer than 2 clients register**, the session is canceled and notifications are sent.

### Trainers
- Submit preferred schedules:
  - Preferred time
  - Suitable hall

### Administration Responsibilities
- Hire and fire trainers
- Sell memberships
- Schedule trainer sessions
- Manage operations
- Generate reports (e.g., number of trainer sessions per month)

### Users
Clients & Staff include:
- First name
- Surname
- Patronymic
- Passport number

Staff additionally:
- Position
- Salary  
There is **one administrator** supervising multiple trainers.

### Training Session Description
- Place
- Time
- Trainer
- List of participants  
(For individual sessions → list contains one person)

### Required Demonstration Scenario
For **7 clients, 3 trainers, and 1 administrator**, implement and test:
- Assignment of trainers to:
  - Two group sessions
  - One individual session
- All occur:
  - Same time
  - Same day
  - Different halls
- One group session must have **only one client registered** to demonstrate cancellation

### Technical Requirement
- Use **STL**
- Use **lambda expressions**
- Initial data → from fixed set
