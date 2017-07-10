Feature: LoginEmailEntered
    In order to access my account
    As a user of the website
    I don`t want to log into the website,
	if I did not entered my password

@mytag
Scenario Outline: Failed Login without password
	Given User enter <username>
	When Click on the LogIn button
	Then Login was not processed
Examples:
| username   |
| testuser_2 |