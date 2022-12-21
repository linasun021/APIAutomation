Feature: DeleteApiTesting

Verify all delete Apis


Scenario: Delete user verification
    Given I have a user
	When I send rquest to delete user 2
	Then Response status code should be 204
