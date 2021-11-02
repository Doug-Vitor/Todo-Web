<h1 align="center">Sistema Todo (cliente)</h1>
<h4 align="center">Aplicação responsável por gerenciar sua lista de à fazeres de forma rápida e fácil. Projeto cliente da API do sistema Todo (confira <a href="https://github.com/Doug-Vitor/Todo-Api/">aqui</a>).</h3>

<br/>
<p>:warning: É obrigatório/indispensável/imprescindível a utilização da <a href="https://github.com/Doug-Vitor/Todo-Api/">API do Sistema Todo</a> antes da utilização deste projeto. Certifique-se de ler os requisitos deste projeto e do projeto citado antes de testar.<p>

<br/>
<h3>:computer: Tecnologias utilizadas:</h3>
<h4>
 <ul>
  <li>DotNET 5.0</li>
  </ul>
</h4>

<br/>
<h3>:wrench: Quer rodar o projeto? Siga os passos:</h3>
<h4>
 <ul><li>É necessário instalar o Visual Studio 2019.</li></ul>
 
 <br/>
 <ol>
  <li>Faça o download ou clone o projeto.</li>
  <li>Faça o download e siga os passos do projeto da <a href="https://github.com/Doug-Vitor/Todo-Api">API do sistema Todo</a>.</li>
  <li>Abra o arquivo de solução chamado TodoWeb.sln</li>
  <li>No arquivo appsettings.json (projeto TodoWeb.Application), no objeto "ApiRoutingConfiguration", altere a porta (números presentes no valor de BasePath) para o seu localhost. É necessário executar a <a href="https://github.com/Doug-Vitor/Todo-Api">API do Sistema Todo</a> para descobrir o endereço que aponta para seu localhost.</li>
  <li>Restaure os pacotes NuGet da solução:
   <ul>
    <p>Pelo CLI: <blockquote>dotnet restore</blockquote></p>
    <p>Pelo CLI do NuGet: <blockquote>nuget restore TodoApi.sln</blockquote></p>
   </ul>
  </li>
</h4>

<br/>
<h3>O que aprendi neste projeto:</h3>
<h4>
 <ul>
  <li>Consumo de uma API RESTful utilizando a arquitetura MVC.</li>
 </ul>
</h4>

<br/>
<h3>Referências:</h3>
<ul>
  <li>Projeto referência: <a href="https://github.com/dotnet-architecture/eShopOnWeb">Clique aqui</a></li>
</ul>

<br>
<h3>Falhas conhecidas:</h3>
<ul>
  <li>Os métodos do repositório deste sistema sempre retornam o supertipo object, o que pode afetar a aplicação em termos de desempenho, leitura de código e facilita a sua quebra. Além disso, isso gerou duplicidade de código: existe a necessidade de se verificar o que foi retornado por duas vezes (no repositório, no controlador e, por vezes, em camadas de serviços). Isso fere conceitos do padrão SOLID e da programação orientada a objetos. O autor deste projeto reconhece essa falha, no entanto, não haverão mais alterações neste projeto visando a correção desse problema. Em projetos futuros, não ocorrerá mais esse deslize.</li>
</ul>

<br/>
<h3>Outros:</h3>
<ul>
  <li>O autor deste projeto iniciou recentemente os estudos sobre a abordagem DDD. É válido ressaltar que tal abordagem deve ser utilizada para resolver problemas da aplicação e não deve ser usada em qualquer aplicação como arquitetura. Deve-se analisar o contexto para tomar tal decisão. O Sistema Todo foi projetado visando atender o domínio apenas para fins didáticos.</li>
  <li>É válido ressaltar que o autor deste projeto foca seu aprendizado em desenvolvimento back-end. Portanto, diversos elementos do sistema Todo que estejam atrelados ao desenvolvimento front-end podem estar desalinhados, mal formatados ou mal posicionados.</li>
</ul>
