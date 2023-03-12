Feature: Correios Search
	Search Address


#Etapa II - Automação de Teste Web I 
Scenario: Search Address
	Given I access the CEP Search on the Correios website
	When I enter zip code I get address
		| search      | street							 | neighborhood | state     |
		| 69005-040   | Rua Miranda Leão				 | Centro       | Manaus/AM |
		| Lojas Bemol | Rua Miranda Leão, 41 Lojas Bemol | Centro       | Manaus/AM |