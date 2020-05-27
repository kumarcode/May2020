Feature: TimeAndMaterial
	As a TurnUp portal admin
	I would like to manage time and material record effectively

@mytag
Scenario: Create a new time and material record
	Given I have logged in to the Turnup portal successfully
	And I create a time and material 
	Then the record should be created successfully

Scenario: Edit an existing time and material record
	Given I have logged in to the Turnup portal successfully
	And I edit an existing time and material record 
	Then the record should be edited successfully

Scenario Outline: Create multiple time and material records
	Given I have logged in to the Turnup portal successfully
	And I create a time and material with below <codes>, <description>
	Then the record should be created successfully
	Examples: 
	| code | description    |
	| test | testDescription |
	| IC   | testIC |
