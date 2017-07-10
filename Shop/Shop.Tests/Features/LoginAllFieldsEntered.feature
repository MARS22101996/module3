Feature: LoginAllFieldsEntered
    In order to access my account
    As a user of the website
    I want to log into the website

Scenario Outline: Successful Login with Valid Credentials
	Given User enters <username> and <password>
	When Click on the LogIn button, when all fields are entered
	Then Successful Log in
Examples:
| username   | password |
| testuser_1 | Test@123 |
| testuser_2 | Test@153 |