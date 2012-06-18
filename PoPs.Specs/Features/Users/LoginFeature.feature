Feature: User should be able to login

@ResetForEachTest
Scenario: Login with invalid data
	Given navigate to ''
	And click in the link login
    And fill fields with following data
       | id               | value |
       | Login            |       |
       | Password         |       |
	When click in the button login
	Then should show the following error messages
       | id               | value                                |
       | Login            | 'Login' deve ser preenchido.         |
       | Password         | 'Senha' deve ser preenchido.         |
	   