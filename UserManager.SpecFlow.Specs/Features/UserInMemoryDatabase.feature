Feature: UserInMemoryDatabase

In order to set up a new user account 
As a client application
I want to be able to manager user operations with SpecFlow In Memory Tables


@userinmemorytable
Scenario: Get Users
	Given I am a client
	When I get User details with id 14
	Then  following result is returned
	| id | FirstName | LastName | EmailAddress            |
	| 14  | Test  | User      | testUser@mailinator.com |
	