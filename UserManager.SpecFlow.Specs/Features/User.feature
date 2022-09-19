Feature: User

In order to set up a new user account 
As a client application
I want to be able to create a user 

@user
Scenario: Create new user
	Given I am a client
	When I make a post request to 'api/Users/Create' with the following data '{ "firstName" : "Rashid","lastName":"Ali","emailAddress":"rashid.ali@iqiglobal.com" }'
	Then the response status code is '200'



	
Scenario: Update User
	Given I am a client
	When I make a post request to 'api/Users/Update' with the following data '{"id" :1, "firstName" : "Rashid"}'
	Then the response status code is '200'



Scenario: Delete User
	Given I am a client
	When I make a delete request to 'api/Users/2'
	Then the response status code is '204'




Scenario: Get User
	Given I am a client
	When I make a get request to 'api/Users/1'
	Then the response status code is '200'

