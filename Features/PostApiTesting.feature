Feature: PostApiTesting

Verify all Post Apis

@tag1
Scenario: Create user verification
    Given I have user name "morpheus" and job "leader"
	When I send request to create a user
	Then User "morpheus" is created

Scenario: Register successful verification
    Given I want to register with email "eve.holt@reqres.in" and password "pistol"
	When I send request to register
	Then User with Id 4 and token "QpwL5tke4Pnpja7X4" is registered successfully

Scenario: Register unsuccessful verification
    Given I want to register with email "sydney@fife" and password ""
	When I send request to register
	Then I get status code 400
	And I get error message "Missing password"

Scenario: Login successful verification
    Given I want to login with email "eve.holt@reqres.in" and password "cityslicka"
	When I send request to login
	Then Login successfully with token "QpwL5tke4Pnpja7X4"
