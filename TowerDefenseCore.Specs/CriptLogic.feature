Feature: CripLogic
	Crip alive, take damage and dead.

@crip
Scenario: Check crip is dead
	Given Crip is alive 	
	When Crip HP - 100 
	Then Crip is dead
