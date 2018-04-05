# BS-Bookstore
Projeto simples de uma livraria criado para a entrevista na HBSIS

=======================================================

# O que foi utilizado
- Dapper como ORM;
- WebApi para comunicação entre front e back;
- O front foi inteiro desenvolvido em AngularJs;
- Foi aplicado DDD;
- Autofac como injeção de dependências;
- UnitOfWork para centralização de dependências;
- FluentValidator para realizar validações no back;
- .NET Core 2.0

=======================================================

# Como rodar o projeto

- Baixar os fontes;
- Criar um banco de dados SQLServer e rodar o script "CREATE_DB" da pasta Scripts;
- Configurar a string de conexão em "appsettings.json" do projeto "BSBookstore.API";
- Configurar o link da API no arquivo "WebApi.ashx" no WebSite "BSBookstore.View.WebApp.Angular";
- Rodar ambos os projetos "BSBookstore.View.WebApp.Angular" e "BSBookstore.API";
- Brincar!

=======================================================
