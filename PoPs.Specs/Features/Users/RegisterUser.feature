Feature: User should be able to: 
            Register
          

@ResetForEachTest
Scenario: Register without specify data
	Given navigate to ''
	And click in the link registrar
    And fill fields with following data
       | id               | value |
       | Login            |       |
       | Email            |       |
       | Password         |       |
       | PasswordRepeated |       |
	When click in the button registrar
	Then should show the following error messages
       | id               | value                                |
       | Login            | 'Login' deve ser preenchido.         |
       | Email            | 'Email' deve ser preenchido.         |
       | Password         | 'Senha' deve ser preenchido.         |
       | PasswordRepeated | 'Repetir Senha' deve ser preenchido. |

@ResetForEachTest
Scenario: Register with different passwords
    Given navigate to ''
    And click in the link registrar
    And fill fields with following data
        | id               | value          |
        | Login            | login          |
        | Email            | user@gmail.com |
        | Password         | 123            |
        | PasswordRepeated | 1234           |
    When click in the button registrar
    Then should show the following error messages
         | id               | value                                  |
         | Password         | As senhas informadas devem ser iguais. |
         | PasswordRepeated | As senhas informadas devem ser iguais. |

@ResetForEachTest
Scenario: Register with invalid email
    Given navigate to ''
    And click in the link registrar
    And fill fields with following data
        | id               | value |
        | Login            | login |
        | Email            | user  |
        | Password         | 1234  |
        | PasswordRepeated | 1234  |
    When click in the button registrar
    Then should show the following error messages
         | id    | value                                         |
         | Email | 'Email' deve ser um endereço de email válido. |

@ResetForEachTest
Scenario: Register with email/login already used
    Given navigate to ''
    And click in the link registrar
    And fill fields with following data
        | id               | value |
        | Login            | abcd |
        | Email            | abcd@gmail.com  |
        | Password         | 1234  |
        | PasswordRepeated | 1234  |
    When click in the button registrar
    Then should show the following error messages
         | id    | value                 |
         | Login | 'Login' já existente. |
         | Email | 'Email' já existente. |

@ResetForEachTest
Scenario: Register with valid data
    Given navigate to ''
    And click in the link registrar
    And fill fields with following data
        | id               | value          |
        | Login            | login          |
        | Email            | user@gmail.com |
        | Password         | 1234           |
        | PasswordRepeated | 1234           |
    When click in the button registrar
    Then should show text 'Cadastro efetuado com sucesso!' at 'h2'
