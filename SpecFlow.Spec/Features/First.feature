Feature: First SpecFlow test

A short summary of the feature

Scenario: Simple test without body

Scenario: Simple test with body
	Given open browser

Scenario: Simple test with Given and When
	Given open browser
	When login page is open

Scenario: Simple test with all key words
	Given open browser
	When login page is open
	Then username field is displayed

Scenario: And Using
	Given open browser
	And login page is open
	Then username field is displayed
	* password field is displayed

Scenario: But Using
	Given open browser
	And login page is open
	Then username field is displayed
	But error is displayed