Feature: User should be able to login

@ResetForEachTest
Scenario: Login with empty data
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

@ResetForEachTest
Scenario: Login with invalid data
	Given navigate to ''
	And click in the link login
    And fill fields with following data
       | id               | value |
       | Login            | abcd      |
       | Password         | 123456      |
	When click in the button login
	Then should show the following error messages
       | id    | value                           |
       | Login | 'Login' ou 'Senha' inválido(a). |

@ResetForEachTest
Scenario: Login with valid data
	Given navigate to ''
	And click in the link login
    And fill fields with following data
       | id               | value	  |
       | Login            | abcd      |
       | Password         | 1234      |
	When click in the button login
	Then should be redirected to ''
    And should show account area

@ResetForEachTest
Scenario: User has to be able to logout
	Given user is logged
	When click in the link logout
	Then should be logged out