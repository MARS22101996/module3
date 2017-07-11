Feature: Login_Email_Is_Entered
    In order to access my account
    As a user of the website
    I don`t want to log into the website,
	if I did not enter my password

@login
Scenario Outline: Failed Login without password
	Given User enter username <username>
	When Click on the LogIn button, when password is not entered
	Then Login was not processed without password
Examples:
| username   |
| testuser_1 |