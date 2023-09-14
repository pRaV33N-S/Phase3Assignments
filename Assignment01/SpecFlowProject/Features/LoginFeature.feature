Feature: LoginFeature

@Valid
Scenario: Valid Login
	Given the username is "Praveen"
	And the password is "NotJustARandomPassword"
	When I try to login
	Then the message should be "Login Successful" 

@ProvideUserName
Scenario: Provide Username
	Given the username is "null"
	And the password is "NotJustARandomPassword"
	When I try to login
	Then the message should be "Provide Username" 

@ProvidePassword
Scenario: Provide Password
	Given the username is "Praveen"
	And the password is "null"
	When I try to login
	Then the message should be "Provide Password"
	
@InvalidLogin
Scenario: InValid Login
	Given the username is "InvalidUsername"
	And the password is "InvalidPassword"
	When I try to login
	Then the message should be "Login Failed" 

@ProvideBoth
Scenario: Provide Username and Password
	Given the username is "null"
	And the password is "null"
	When I try to login
	Then the message should be "Provide Username and Password" 