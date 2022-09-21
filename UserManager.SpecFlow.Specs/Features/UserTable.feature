Feature: UserTable


In order to set up a new user account 
As a client application
I want to be able to manager user operations with SpecFlow Tables


@usertable
Scenario: Create new user
	Given I am a client
	When I make a post request to 'api/Users/Create' with following data
		| FirstName | LastName | EmailAddress            |
		| Test      | User     | testUser@mailinator.com |

	Then the response status code is '200'





Scenario: Update User
	Given I am a client
	When I make a post request to 'api/Users/Update' with following data
		| id | LastName |             
		| 13 | Updated  | 
	Then the response status code is '200'


Scenario: Delete User
	Given I am a client
	When I make a delete request to 'api/Users/{id}' with following data
		| id  |
		|  12 |
	Then the response status code is '204'