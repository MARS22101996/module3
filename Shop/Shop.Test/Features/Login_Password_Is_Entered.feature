Feature: Login_Password_Is_Entered
    In order to access my account
    As a user of the website
    I don`t want to log into the website,
	if I did not enter my email

@login
Scenario Outline: Failed Login without email
	Given User enter password <password>
	When Click on the button for log in, when email is not entered
	Then Login was not processed without email
Examples:
| password |
| Test@123 |
| Test@153 |

