Feature: CheckingBookStatus

Checking Book Status (e.g., {"status": "available"} or {"status": "borrowed"})

@happyFlow
Scenario: Check book status of borrowed book
        Given a book 2 has been borrowed
        When the status is checked
        Then the status should be "borrowed"

@happyFlow @status
Scenario: Check book status of available book
        Given a book 1 has been available
        When the status is checked
        Then the status should be "available"
