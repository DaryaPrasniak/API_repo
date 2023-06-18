Feature: Parameterized tests

A short summary of the feature

Scenario: Steps parameterization
	Given browser is open
	* login page is opened
	When user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
	Then the title is "All Projects - TestRail"
	And project ID is 123

Scenario Outline: Parameterization with value tables
    Given browser is open
	* login page is opened
	When user "<username>" with password "<passsword>" logged in
	Then the title is "All Projects - TestRail"
	And project ID is <id>

	Examples: 
	| username           | password | id  |
	| atrostyanko@gmail.com | Qwertyu_1 | 123 |
	| atrostyanko@gmail.com | Qwertyu_1 | 456 |

Scenario Template: Parameterization with value tables 1
    Given browser is open
	* login page is opened
	When user "<username>" with password "<passsword>" logged in
	Then the title is "All Projects - TestRail"
	And project ID is <id>

	Examples:
	| username           | password | id  |
	| atrostyanko@gmail.com | Qwertyu_1 | 123 |
	| atrostyanko@gmail.com | Qwertyu_1 | 456 |