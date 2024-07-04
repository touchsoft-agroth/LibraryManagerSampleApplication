# Library management application

## Explanation
This is a small sample application written in .NET Core with a small GUI implemented using Windows Forms. It has a simple N-layered architecture
and allows users to borrow and return books that is currently in the library. The books are loaded from mock data in a CSV file.

## Dependencies
* .NET 8.0

## Other information
You are free to use any tools, libraries or other resources for the tasks. There are no limitations or restrictions on technologies, patterns or implementation. After submission, you are expected to
talk about and discuss your code and choices.

FYI: While there are some windows forms that requires visual studio's designer to modify, none of the tasks should require any changes to the GUI.

## Tasks
### Improve the search functionality
* Currently a search on books by their titles is performed each time the search text box changes. Instead, we would like to only perform the search once
the user has not changed the text for more than a configurable amount of milliseconds to avoid searching while the user is actively typing.
* Implement a fuzzy search algorithm to allow partial matching of search results to make the search functionality less strict with spelling. Results should
be ordered by similarity to the search term. This can either be implemented manually or make use of a 3rd party library like [FuzzySharp](https://www.nuget.org/packages/FuzzySharp).

### Introduce a max amount of actively borrowed books per user
* There is currently no restriction on how many books that a single user can borrow at the same time. There should be an easily configurable amount of
books that can be borrowed at the same time, and not allow users to  borrow books if they exceed this limit. You do not have to be concerned with showing any tooltips/labels if a user exceeds this limit,
but the borrow button should not be clickable if the amount is exceeded.
