Feature: User should be able to get a new password

@ResetForEachTest
Scenario: Try to reset password with empty email
	Given navigate to ''
	And click in the link login
	And click in the link esqueci minha senha
    And fill fields with following data
       | id    | value |
       | Email |       |
	When click in the button resetar senha
	Then should show the following error messages
       | id    | value                   |
       | Email | 'Email' deve ser preenchido. |

@ResetForEachTest
Scenario: Try to reset password with invalid email
	Given navigate to ''
	And click in the link login
	And click in the link esqueci minha senha
    And fill fields with following data
       | id    | value          |
       | Email | notfound@gmail.com |
	When click in the button resetar senha
	Then should show the following error messages
       | id    | value                   |
       | Email | 'Email' não cadastrado. |

@ResetForEachTest
Scenario: Try to reset password with valid email
	Given navigate to ''
	And click in the link login
	And click in the link esqueci minha senha
    And fill fields with following data
       | id    | value          |
       | Email | abcd@gmail.com |
	When click in the button resetar senha
	Then should show text 'Uma nova senha foi enviada para o email indicado.' at 'h2'
