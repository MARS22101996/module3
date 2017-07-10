﻿Feature: LogIn_Feature
	In order to access my account
    As a user of the website
   I want to log into the website

@mytag
Scenario Outline: Successful Login with Valid Credentials
	Given User is at the Home Page
	And Navigate to LogIn Page
	When User enter <username> and <password>
	And Click on the LogIn button
	Then Successful LogIN message should display
Examples:
| username   | password |
| testuser_1 | Test@123 |
