[![Typing SVG](https://readme-typing-svg.demolab.com?font=Fira+Code&size=18&pause=1000&color=DF62F7&width=435&lines=Projeto+de+Automa%C3%A7%C3%A3o+Cadastro+de+Usu%C3%A1rios)](https://git.io/typing-svg)

Projeto de automação no site http://prova-jgr.com.br/teste/qa/ utilizando a linguagem C# e o framework de automação Selenium WebDriver, explorando a funcionalidade 'Comprar um produto'.

## Feature testada:

Funcionalidade: Cadastrar Usuario
	EU COMO usuário do sistema.
	DESEJO realizar o cadastro de novos usuários.
	PARA QUE seja possível armazenar e gerenciar seus dados.

    Cenário: CT001- Visualizar mensagens de erro
	Dado que eu acesse a página de cadastro
	Quando eu solicitar cadastrar um usuário
	Então eu devo visualizar as mensagens de erro
		| Campo  | Mensagem                      |
		| Nome   | O campo Nome é obrigatório.   |
		| E-mail | O campo E-mail é obrigatório. |
		| Senha  | O campo Senha é obrigatório.  |
		 
    Cenário: CT002- Visualizar mensagens de validação dos campos
	Dado que eu acesse a página de cadastro
	Quando eu preencher o campo nome com "<NomeUsuario>"
	E eu preencher o campo email com "<EmailUsuario>"
	E eu preencher o campo senha com "<SenhaUsuario>"
	E eu solicitar cadastrar um usuário
	Então eu devo visualizar a mensagem "<Mensagem>" abaixo do campo "<Campo>" 

	Exemplos: 
		| NomeUsuario    | EmailUsuario            | SenhaUsuario | Mensagem                                   | Campo  |
		| Gabriela       | gabrielaambos@teste.com | 12345678     | Por favor, insira um nome completo.        | Nome   |
		| Gabriela Ambos | gabrielaambos           | 12345678     | Por favor, insira um e-mail válido.        | E-mail |
		| Gabriela Ambos | gabrielaambos@teste.com | 1234         | A senha deve conter ao menos 8 caracteres. | Senha  |

    Cenário: CT003- Adicionar um usuário com informações válidas
	Dado que eu acesse a página de cadastro
	Quando eu preencher o campo nome com "Gabriela Ambos"
	E eu preencher o campo email com "gabrielaambos@teste.com"
	E eu preencher o campo senha com "12345678"
	E eu solicitar cadastrar um usuário
	Então eu devo visualizar os usuários cadastrados
		| Id | Nome           | E-mail                  |
		|  1 | Gabriela Ambos | gabrielaambos@teste.com |

    Cenário: CT004- Excluir um usuário 
	Dado que eu acesse a página de cadastro
	Quando eu preencher o campo nome com "Gabriela Ambos"
	E eu preencher o campo email com "gabrielaambos@teste.com"
	E eu preencher o campo senha com "12345678"
	E eu solicitar cadastrar um usuário
	Então eu devo visualizar os usuários cadastrados
		| Id | Nome           | E-mail                  |
		|  1 | Gabriela Ambos | gabrielaambos@teste.com |
	Quando eu preencher o campo nome com "Manoel Afonso"
	E eu preencher o campo email com "manoelafonso@teste.com"
	E eu preencher o campo senha com "12345678"
	E eu solicitar cadastrar um usuário
	Então eu devo visualizar os usuários cadastrados
		| Id | Nome           | E-mail                  |
		| 1  | Gabriela Ambos | gabrielaambos@teste.com |
		| 2  | Manoel Afonso  | manoelafonso@teste.com  |
	Quando eu solicito excluir o usuário com o id "1"
	Então eu devo visualizar os usuários cadastrados
		| Id | Nome          | E-mail                 |
		| 2  | Manoel Afonso | manoelafonso@teste.com |





