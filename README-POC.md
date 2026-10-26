# PoC — Laboratório de Codificação Segura
ASP.NET Core MVC / C# / .NET 10

## Instalação
Na pasta do projeto, execute:
1. `dotnet add package Microsoft.Data.Sqlite`
2. `dotnet restore`
3. `dotnet run`
Abra o endereço local informado.

## Demonstrações
- SQL Injection: usuário fictício `joao`, senha `demo123`. Teste `' OR 1=1 --` com senha `qualquercoisa`.
- XSS: compare a interpretação HTML do exemplo benigno com `textContent`.
- CSRF: envie o formulário com token; depois use a simulação sem token (HTTP 400).

## Segurança e limitações
Laboratório local, educativo, sem persistência de conta. A consulta SQL vulnerável é intencional, jamais a use em produção. O painel XSS inseguro interpreta HTML: não cole scripts nem dados não confiáveis e não exponha o laboratório à internet. O endpoint CSRF de simulação rejeita e não altera dados. Senhas reais exigem hash apropriado, e sistemas reais também precisam de autorização, validação e HTTPS.
