Feature: LoginPasswordEntered
    In order to access my account
    As a user of the website
    I don`t want to log into the website,
	if I did not entered my email

@mytag
Scenario Outline: Failed Login without email
	Given User enter password <password>
	When Click on the button for log in
	Then Login was not processed without password
Examples:
| password |
| Test@123 |
| Test@153 |
