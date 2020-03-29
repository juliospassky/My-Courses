# Criando Apps Web com Angular e UiKit
## Instalação
- [Node](https://nodejs.org/en/)
- [Yarn](https://classic.yarnpkg.com/pt-BR/)
- [UiKit](https://getuikit.com/)

  - Instalação do angular globalmente
  ```sh
  npm install -g @angular/cli
  ```
  - Instalação do yarn
  ```sh
  yarn install
  ```
  - Compilar o projeto após o clone
  ```sh
  npm install --save-dev @angular-devkit/build-angular
  ``` 
  - Instala dependencias do yarn (Na pasta do projeto)
  ```sh  
  yarn
  ```
  - Compilar o uikit modificado
  ```sh  
  yarn compile
  ```
  
  
## Comandos
 - Gera um novo componente Navbar
  ```sh
  ng generate component Navbar
  ``` 
 - Gera uma nova página
 ```sh
 ng generate component LoginPage
 ```
 - Instala o Toaster (Popup de mensagem) 
 ```sh
  npm install --save toastr
  ```
## Dicas Uikit
Modificar variaveis no arquivo (uikit\src\less\theme\variables.less)


## Dicas Angular
No verbo Get evita-se o subscribe que mantem a requisição bloqueada durante o seu processamento. Recomenda-se então o uso do Observable que trabalha de forma assincrona, por convenção usa-se $ no final da declaração da variável. Verificar arquivo products-page.component.ts para exemplo.

O armazenamento do Token, pode ser feito de três formas: variável global; session storage e local storage. A forma mais recomendada é com local storage, pois o browse armazena esse token internamente. Verificar arquivo login.page.components.ts
