Feature: Trivago Search
	Search Travel


#Etapa III - Automação de Teste Web II 
Scenario: Search Travel
	Given that I access the Trivago website
	When I look for <Manaus>
	Then I check the information of the first item