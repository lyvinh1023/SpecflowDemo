Feature: Login feature
	Verify the login feature works properly

@smoke
Scenario: Login with valid account
	Given I am navigated to Login page
	When I enter username and password
	| Username | Password |
	| user1    | 12345    |
	And I click Login button
	Then I should see the Project Details page

@regression
Scenario: Login with invalid password
	Given I am navigated to Login page
	When I enter username and password
	| Username | Password |
	| user1    | 123    |
	And I click Login button
	Then I should see the password error message
