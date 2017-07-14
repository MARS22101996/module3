Feature: UserLogin
    In order to access my account
    As a user of the website
    I want to log into the website

@login
Scenario Outline: Successful Login with Valid Credentials when all fields are entered
	Given User enters peronal username <username> and password  <password>
	When Click on the LogIn button, when all fields are entered
	Then Successful Log in
Examples:
| username   | password |
| testuser_1 | Test@123 |
| testuser_2 | Test@153 |

@login
Scenario Outline: Failed Login without password
	Given User enter personal username <username>
	When Click on the LogIn button, when one field is not entered
	Then Login was not processed and user stay at the Login page
Examples:
| username   |
| testuser_1 |


@login
Scenario Outline: Failed Login without email
	Given User enter personal password <password>
	When Click on the LogIn button, when one field is not entered
	Then Login was not processed and user stay at the Login page
Examples:
| password |
| Test@123 |
| Test@153 |
