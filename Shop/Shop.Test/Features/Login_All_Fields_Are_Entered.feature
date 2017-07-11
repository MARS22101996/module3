Feature: Login_All_Fields_Are_Entered
    In order to access my account
    As a user of the website
    I want to log into the website
	When valid password and email are entered

@login
Scenario Outline: Successful Login with Valid Credentials
	Given User enters username <username> and password  <password>
	When Click on the LogIn button, when all fields are entered
	Then Successful Log in
Examples:
| username   | password |
| testuser_1 | Test@123 |
| testuser_2 | Test@153 |