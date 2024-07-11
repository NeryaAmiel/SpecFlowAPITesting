@borrow
Feature: BorrowingABook

A short summary of the feature

@happyFlow
Scenario: Borrowing A Book HF
       Given a book is available
       When a user borrows the book
       Then the book status should be "Book borrowed successfully"
