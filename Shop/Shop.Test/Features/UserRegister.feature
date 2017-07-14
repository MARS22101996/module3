Feature: UserRegister
    In order to access my account
    As a user of the website
    I want to register on the website

@Register
Scenario Outline: Successful registration when phone number has a valid format
	Given User enter phone number <phone>
	When Click on the Registration button, when phone number has a valid format
	Then Successful Registration
Examples:
| phone           |
| (555) 555-5555  |

@Register
Scenario Outline:Failed registration when phone number does not have a valid format
	Given  User enter phone number <phone>
	When Click on the Registration button, when phone number does not have a valid format
	Then Failed Registration
Examples:
| phone     |
|555-5555   |