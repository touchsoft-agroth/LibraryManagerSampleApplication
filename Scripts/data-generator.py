import random
import csv

# Read words from files
def read_words_from_file(filename):
    with open(filename, 'r') as file:
        return [line.strip() for line in file.readlines()]

# Generate random names
def generate_names(first_names, last_names, count):
    return [f"{random.choice(first_names)} {random.choice(last_names)}" for _ in range(count)]

# Generate random book titles
def generate_book_titles(subjects, adjectives, binding_words, count, adj_prob=0.5, bind_prob=0.5):
    titles = []
    for _ in range(count):
        title = ""
        if random.random() < adj_prob:
            title += random.choice(adjectives) + " "
        title += random.choice(subjects)
        if random.random() < bind_prob:
            title += " " + random.choice(binding_words) + " " + random.choice(subjects)
        titles.append(title.strip())
    return titles

# Match books to authors and generate output CSV
def match_books_to_authors(book_titles, authors):
    data = []
    for idx, title in enumerate(book_titles):
        author = random.choice(authors)
        data.append([idx, title, author])
    return data

# Write data to CSV file
def write_to_csv(filename, data, headers):
    with open(filename, 'w', newline='') as file:
        writer = csv.writer(file)
        writer.writerow(headers)
        writer.writerows(data)

# Main function
def main():
    # Read data from files
    first_names = read_words_from_file('first-names.txt')
    last_names = read_words_from_file('last-names.txt')
    subjects = read_words_from_file('subjects.txt')
    adjectives = read_words_from_file('adjectives.txt')
    binding_words = read_words_from_file('binding-words.txt')

    # Configuration
    num_authors = 5000
    num_books = 50000

    # Generate authors and book titles
    authors = generate_names(first_names, last_names, num_authors)
    book_titles = generate_book_titles(subjects, adjectives, binding_words, num_books)

    # Match books to authors and prepare data for CSV
    books_data = match_books_to_authors(book_titles, authors)

    # Write books data to CSV
    write_to_csv('books.csv', books_data, ['Id', 'Title', 'Author'])

    # Generate user data for CSV
    user_data = [[i, name] for i, name in enumerate(authors)]
    write_to_csv('users.csv', user_data, ['Id', 'Name'])

if __name__ == "__main__":
    main()
