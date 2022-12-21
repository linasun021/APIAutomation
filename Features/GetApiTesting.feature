Feature: GetApiTesting

Verify all get Apis

@tag1
Scenario Outline: List Users verification
	Given I have baseurl
	When I send request to get all users
	Then User "<userQuaried>" should be included

Examples: 
    | userQuaried      |
    | Lindsay Ferguson |
    | Michael Lawson   |


Scenario Outline: Single User verification
	Given I have baseurl
	When I send request to get single user <userId>
	Then User "<userName>" detail info will show
Examples: 
     | userId | userName |
     | 2      | Janet    |
     | 3      | Emma     |

Scenario: Single User not found verification
	Given I have baseurl
	When I send request to get single user 23
	Then The status code should be 404

Scenario: Single resource not found verification
	Given I have baseurl
	When I send request to get resource 23
	Then The status code should be 404
