Feature: GUI and API tests

A short summary of the feature

@GUI @GeneralUser
Scenario: Login to the app
	Given chrome browser is open
	* loginpage is displayed
	When a user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
	Then dashboard page is open

@GUI @GeneralUser
Scenario: Create new project
	Given chrome browser is open
	* loginpage is displayed
	* a user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
	* dashboard page is open
	When new project "Test Project" added
	Then the project "Test Project" is displayed

@API
Scenario Outline: Add a test case
	Given init api client
	When new case "<title>" with "<sectionId>" and "<typeId>" and "<priorityId>" is added
	Then the case is added

	Examples: 
	| title           | sectionId | typeId | priorityId | createdBy | createdOn | suiteId |
	| Test Case June  | 1         | 2      | 3          | 15        | 4         | 1       |

@API
Scenario Outline: Get a test case
	Given init api client
	When new case "<title>" with "<sectionId>" and "<typeId>" and "<priorityId>" is added
	Then the case is requested to get

	Examples: 
	| title           | sectionId | typeId | priorityId | createdBy | createdOn | suiteId |
	| Test Case Test  | 2         | 3      | 4          | 16        | 8         | 9       |

@API
Scenario Outline: Update a test case
	Given init api client
	When new case "<title>" with "<sectionId>" and "<typeId>" and "<priorityId>" is added
	* the case is updated
	Then the title is updated

	Examples: 
	| title             | sectionId | typeId | priorityId | createdBy | createdOn | suiteId |
	| Test Case Update  | 8         | 7      | 15         | 20        | 8         | 9       |

@API
Scenario: Delete a test case
	Given init api client
	When new case "<title>" with "<sectionId>" and "<typeId>" and "<priorityId>" is added
	Then the case is deleted
	* there is no deleted case

	Examples: 
	| title        | sectionId | typeId | priorityId | createdBy | createdOn | suiteId |
	| Deleted Case | 8         | 7      | 15         | 20        | 8         | 9       |