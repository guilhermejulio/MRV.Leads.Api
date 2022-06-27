
<h1 align="center">REST API - Controle de Leads</h1>
<p align="center">API De exemplo para uma aplicação de controle de Leads</p>
<p align="center">
  <a href="https://github.com/guilhermejulio/MRV.Leads.Api/commits/main">
    <img alt="Azure Deploy" src="https://github.com/guilhermejulio/MRV.Leads.Api/actions/workflows/main_mrv-leads-api.yml/badge.svg">
    <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/guilhermejulio/MRV.Leads.Api">
  </a>
	
</p>
<br/>

## Sobre a API

<br/>
Trata-se de uma .Net Core Web API com Entity Framework, utilizando banco de dados SQL Server. 

## Frontend Web

<br/>
O front-end também está hospedado para execução (https://leads-spa.netlify.app/), além disso o repositório do front-end é: https://github.com/guilhermejulio/mrvleads-frontend

## Swagger

<br/>
Acesse aqui a definição da API no Swagger: https://mrv-leads-api.azurewebsites.net/swagger/


## Hospedagem

<br/>
A aplicação está hospedada na Azure (https://mrv-leads-api.azurewebsites.net), logo para uma demonstração não é necessário rodar a aplicação de modo local.

Rotas: 
- /api/leads/Create
- /api/leads/GetById/{id}
- /api/leads/GetStatistics
- /api/leads/ListAllAccepted
- /api/leads/ListAllCreated
- /api/leads/UpdateStatus/accept/{id}
- /api/leads/UpdateStatus/decline/{id}

## Execução local

<br/>
Caso queira rodar a aplicação local utilize os comandos:

- dotnet build
- dotnet run

## Banco de dados

<br/>
O banco de dados usado é o SQL Server, também está hospedado na Azure.

