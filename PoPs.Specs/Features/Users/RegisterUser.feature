Feature: User should be able to: 
            Register
          

@ResetForEachTest
Scenario: Register without specify data
	Given navigate to '/Home'
	And click in the link 'Register'
    And fill fields with following data
       | id               | value |
       | User             |       |
       | Email            |       |
       | Password         |       |
       | PasswordRepeated |       |
	When click in the button 'Register'
	Then should show the following error messages
       | id               | Value                |
       | User             | User is required     |
       | Email            | Email is required    |
       | Password         | Password is required |
       | PasswordRepeated | Password is required |

@ResetForEachTest
Scenario: Register with different passwords
    Given navigate to '/Home'
    And click in the link 'Register'
    And fill fields with following data
        | id               | value          |
        | User             | user           |
        | Email            | user@gmail.com |
        | Password         | 123            |
        | PasswordRepeated | 1234           |
    When click in the button 'Register'
    Then should show the following error messages
         | id               | Value                |
         | PasswordRepeated | password fields must be equal |

@ResetForEachTest
Scenario: Register with invalid email
    Given navigate to '/Home'
    And click in the link 'Register'
    And fill fields with following data
        | id               | value          |
        | User             | user           |
        | Email            | user           |
        | Password         | 1234           |
        | PasswordRepeated | 1234           |
    When click in the button 'Register'
    Then should show the following error messages
         | id    | Value                        |
         | Email | email is in a invalid format |

@ResetForEachTest
Scenario: Register with valid data
    Given navigate to '/Home'
    And click in the link 'Register'
    And fill fields with following data
        | id               | value          |
        | User             | user           |
        | Email            | user@gmail.com |
        | Password         | 1234           |
        | PasswordRepeated | 1234           |
    When click in the button 'Register'
    Then should be redirected to 'User/Success'
