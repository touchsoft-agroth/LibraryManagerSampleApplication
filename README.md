# Library management application

## Explanation
This is a small sample application written in .NET Core with a small GUI implemented using Windows Forms. It has a simple N-layered architecture
and allows users to borrow and return books that is currently in the library. The books are loaded from mock data in a CSV file.

## Dependencies
* .NET 8.0

## Other information
You are free to use any tools, libraries or other resources for the tasks. There are no limitations or restrictions on technologies, patterns or implementation. After submission, you are expected to
talk about and discuss your code and choices.

FYI: While there are some windows forms that requires visual studio's designer to modify, none of the tasks should require any changes to the GUI via the winforms designer.

## Tasks
### Improve the search functionality
Implement a fuzzy search algorithm to allow partial matching of search results to make the search functionality less strict with spelling. Results should
be ordered by similarity to the search term. This can either be implemented manually or make use of a 3rd party library like [FuzzySharp](https://www.nuget.org/packages/FuzzySharp).

### Introduce a max amount of actively borrowed books per user
Users are currently allowed to borrow any amount of books without restrictions. You should implement an easily configurable amount of concurrent books the user is able to borrow at any time.
The "Borrow" button in the borrowing dialog GUI should be disabled if the selected user has reached this limitation, and only enable it again once the user has less concurrent borrowed books. Other users should
still be able to borrow books.

### Logging of borrowing to output file
Whenever a user either borrows or returns a book, we want to log this event into a local log text file on the client's machine. The log file should be located inside of the AppData/Roaming/LibraryManager directory on the machine.
New events should be appended to the end of the file without overriding existing logged events. If the directory, or the log file does not exist, it should automatically be created.

The logged events should include:
* Current time
* What type of event it was? Borrowed? Returned?
* The related book
* The user doing the operation
