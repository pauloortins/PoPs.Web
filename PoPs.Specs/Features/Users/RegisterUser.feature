Feature: User should be able to: 
            Register
          

@ResetForEachTest
Scenario: Register without specify data
	Given navigate to '/Home'
	And click in the link 'Register'
    And fill fields with following data
       | id               | value |
       | user             |       |
       | email            |       |
       | password         |       |
       | passwordRepeated |       |
	When click in the button 'Register'
	Then should show the following error messages
       | id               | Value                |
       | user             | user is required     |
       | email            | email is required    |
       | password         | password is required |
       | passwordRepeated | password is required |

@ResetForEachTest
Scenario: Register with different passwords
    Given navigate to '/Home'
    And click in the link 'Register'
    And fill fields with following data
        | id               | value          |
        | user             | user           |
        | email            | user@gmail.com |
        | password         | 123            |
        | passwordRepeated | 1234           |
    When click in the button 'Register'
    Then should show the following error messages
         | id               | Value                |
         | passwordRepeated | password fields must be equal |

@ResetForEachTest
Scenario: Register with invalid email
    Given navigate to '/Home'
    And click in the link 'Register'
    And fill fields with following data
        | id               | value          |
        | user             | user           |
        | email            | user           |
        | password         | 1234           |
        | passwordRepeated | 1234           |
    When click in the button 'Register'
    Then should show the following error messages
         | id    | Value                        |
         | email | email is in a invalid format |

@ResetForEachTest
Scenario: Register with valid data
    Given navigate to '/Home'
    And click in the link 'Register'
    And fill fields with following data
        | id               | value          |
        | user             | user           |
        | email            | user@gmail.com |
        | password         | 1234           |
        | passwordRepeated | 1234           |
    When click in the button 'Register'
    Then should be redirected to 'User/Success'
