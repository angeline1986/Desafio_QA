Feature: Virtual Store


Scenario: 01_ Create User
	Given I use user API to register a new user
	| nome        | email            | password | administrador |
	| Celine Dion | celine@gmail.com | titanic  | true          |
	Then I check created user
	And generate a token



Scenario: 02_ Create Product
	Given I use product API to register a new product
	| nome             | preco | descricao | quantidade |
	| Dell Vostro 5170 | 5405  | Notebook  | 5          |
	Then I check created product
	And I delete this product
	And I delete this user