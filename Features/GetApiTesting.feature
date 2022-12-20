Feature: GetApiTesting

Verify all get Apis

@tag1
Scenario Outline: List Users verification
	Given I have baseurl
	When I send rquest to get all users
	Then User "<UserQuaried>" should be included

Examples: 
    | UserQuaried      |
    | Lindsay Ferguson |
    | Michael Lawson   |


Scenario: Single User verification
	Given I have baseurl
	When I send rquest to get single user
	Then User "Janet" detail info will show

Scenario: Single User not found verification
	Given I have baseurl
	When I send rquest to get not exist single user
	Then The status code should be 404

Scenario: Single resource not found verification
	Given I have baseurl
	When I send rquest to get not exist resource
	Then The status code should be 404
