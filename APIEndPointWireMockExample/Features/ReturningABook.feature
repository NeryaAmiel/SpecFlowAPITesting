Feature: ReturningABook

testing the return action of borrowed books

@happyFlow @return
Scenario: Returning A Book HF
       Given a borrowed book id 2 and userId 1
       When a user Returns the book
       Then the message should be "Book returned successfully"
