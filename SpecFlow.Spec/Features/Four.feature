﻿Feature: Problems

A short summary of the feature
@GUI @GeneralUser
Scenario: Using different defs classes 1
	Given new browser is open
	* new login page is displayed
	* the user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
	Then settings page is open

@GeneralUser
Scenario: Using different defs classes 2
	Given new browser is open
	* new login page is displayed
	* the user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
	Then settings page is open
