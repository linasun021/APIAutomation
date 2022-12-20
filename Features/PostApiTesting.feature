Feature: PostApiTesting

Verify all Post Apis

@tag1
Scenario: Create user verification
    Given I have user name "morpheus" and job "leader"
	When I send rquest to create a users
	Then User "morpheus" has been created

Scenario: Register successful verification
    Given I want registe with email "eve.holt@reqres.in" and password "pistol"
	When I send rquest to regist
	Then User with Id 4 and token "QpwL5tke4Pnpja7X4" registe successfully

Scenario: Register unsuccessful verification
    Given I want registe with email "sydney@fife" and password ""
	When I send rquest to regist
	Then I got status code 400
	And I got error message "Missing password"

Scenario: Login successful verification
    Given I want login with email "eve.holt@reqres.in" and password "cityslicka"
	When I send rquest to login
	Then Login successful with token "QpwL5tke4Pnpja7X4"
