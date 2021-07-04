# thread-in-motion-library-web-application
thread-in-motion-library-web-application

We want you to develop a basic library web application. Library members can borrow books whenever they want, provided that they come back.
For this application we offer you to use MsSQL Express or MySQL as database server. All tables must be designed by developer.
Scenario:
The member comes to helpdesk and asks for the book with its name, author or ISBN. Librarian enters this information into a form for searching. This information can be multiple or single, with just name or just ISBN it is possible to search. Most important thing in here is to search with LIKE operator. All possibilities will be listed when Librarian clicked to search button. If the book is available and not entrusted, Librarian enters the member id of the person who wants the book and enters the return date. Normally, return date is 30 working days after retrieve. These working days must be excluded from public holidays. The holidays must be defined for TURKEY.

At that point we need minimum 3 tables.
Books
Members,
BookTransactions

For the BookTransactions table you must use ISBN number and MemberId as FK. This table will be used when a member requested a book.
We also need minimum 5 different screen for this application.
Book Save
Member Save
Book Transaction
Book Search
Daily Report 
Daily report will be used by Librarian to follow upcoming or late due dates of books.
If the book has penalty for a late due date, must be also shown on this report screen. Upcoming due dates will be listed for last two days.

Penalty Calculation:
To calculate penalty, you must use Fibonacci series. Each calculation is total sum of previous days.
There is a coefficient to multiply the values. Calculation summery is below.
This calculation must be converted to a formula with a method.
Coefficient: 0.20 
1.Day Penalty = (0)*(0.20)
2.Day Penalty = (1)*(0.20)+(1.Day Penalty)
3.Day Penalty = (1)*(0.20)+ (2.Day Penalty)
4. Day Penalty = (2)*(0.20)+ (2.Day Penalty)
NOTE: This web application must be developed on ASP.NET MVC or ASP.NET CORE
In computer science there is not just a correct way, there are always different solutions, our aim is to understand your perspective and technic.
