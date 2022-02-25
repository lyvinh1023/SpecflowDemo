Feature: Project Details feature

@smoke
Scenario Outline: Fill all project details
	Given I am navigated to Login page
	When I enter username and password
	| Username | Password |
	| admin    | 12345    |
	And I click Login button
	Then I should see the Project Details page
	When I enter project details: <country>, <address>, <email>, <phone>
	And I click Save button
	Then The project details info should be saved

Examples: 
	| country | address | email                 | phone     |
	| Angola  | 123 st  | email1@mailinator.com | 123456789 |
	| Belgium | 456 st  | email2@mailinator.com | 333333333 |