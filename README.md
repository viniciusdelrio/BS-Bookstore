# BS-Bookstore
Projeto simples de uma livraria criado para a intrevista na HBSIS

=======================================================

# O que foi utilizado
- Dapper como ORM;
- WebApi para comunicação entre front e back;
- O front foi inteiro desenvolvido em AngularJs;
- Foi aplicado DDD;
- Autofac como injeção de dependências;
- UnitOfWork para centralização de dependências;
- FluentValidator para realizar validações no back;

=======================================================

# Como rodar o projeto

1- Baixar os fontes;
2- Criar um banco de dados SQLServer e rodar o script "CREATE_DB" da pasta Scripts;
3- Configurar a string de conexão em "appsettings.json" do projeto "BSBookstore.API";
4- Configurar o link da API no arquivo "WebApi.ashx" no WebSite "BSBookstore.View.WebApp.Angular";
5- Rodar ambos os projetos "BSBookstore.View.WebApp.Angular" e "BSBookstore.API";
6- Brincar!

=======================================================
