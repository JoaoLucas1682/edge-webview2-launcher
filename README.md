# edge-webview2-launcher

Um programa simples que invoca o WebView2 do Microsoft Edge com argumentos personalizados.

## Disclaimer
Este projeto usa o componente 'WebView2' fornecido e mantido pela Microsoft. No entanto:

- Este software __não é afiliado, patrocinado, endossado ou oficialmente associado à Microsoft Corporation (ou Microsoft Corp.)__.
- Todas as __marcas registradas, nomes comerciais e logotipos__ mencionados pertencem aos seus respectivos proprietários.
- O uso do WebView2 está sujeito às __licenças e termos definidos pela Microsoft__.
- O conteúdo carregado no WebView é de __responsabilidade do desenvolvedor__. 


## Requisitos

### .NET:
Este aplicativo requre o .NET Runtime 6.0 (recomendo o 6.0.36). Clique em alguma dessas opções: [Opção 1](https://builds.dotnet.microsoft.com/dotnet/WindowsDesktop/6.0.36/windowsdesktop-runtime-6.0.36-win-x64.exe) | [Opção 2](https://dotnet.microsoft.com/pt-br/download/dotnet/thank-you/runtime-desktop-6.0.36-windows-x64-installer?cid=getdotnetcore)
<br>
O WebView2Launcher também inclui os arquivos nativos do WebView2 (`WebView2Loader.dll`) para suportar o modo "fixed version".  
__MAS note que:__
- Ele usa o modo de distribuição __Evergreen__, que precisa do __WebView2 Runtime__ (acho que o Microsoft Edge já vem com isto) ou o WebView2 Runtime nos argumentos (--runtime ...).


Nenhuma instalação adicional do .NET é necessária.

### Espaço:
2 MB sem incluir o WebView2.

### Memória RAM:
Depende de vários aspectos como:
- A página que está tentando renderizar
- O motor de renderização

No meu caso, deu ~65 MB.
Recomendo pelo menos uns 512 MB para páginas simples e 2 GB para páginas complexas.

## Como compilar?
Se deseja compilar você mesmo, aqui vai um passo a passo:
1. Você precisa do .NET SDK. Mesmo que seja para 6.0 eu usei o 9.0.303 e funciona. [Baixar NET 9.0 SDK](https://builds.dotnet.microsoft.com/dotnet/Sdk/9.0.303/dotnet-sdk-9.0.303-win-x64.exe)
2. Quando baixar, clique no instalador e siga as etapas nele.
3. Para ter certeza que instalou, abra uma nova janela e digite dotnet --info. Se aparecer .NET SDK, então está instalado.
4. Assim que instalado, baixe o repositorio (Code > Download ZIP)
5. Extraia o ZIP que baixou em uma pasta e navegue em src > WebView2Launcher-Clean e clique no build.cmd
6. Se aparecer "Concluido com êxito (ignore os alertas; eles não afetam o WebView)
7. Vá em  bin\Release\net6.0-windows\ e você encontra todos os arquivos necessários para rodar.
8. Pronto! Agora você tem o seu próprio WebView2

   
## Como usar

Se executar sem argumentos, ele abrirá a página assets/default.html.

- ### --url


  ```WebView2Launcher --url=[URL que deseja abrir]```
  Abrirá a URL que colocar no argumento. Se não definido abrirá a página assets/default.html.

- ### --userdata
  
  ```WebView2Launcher --userdata=[pasta para ser a UserData]```
  Define aonde vai ser a UserData. Se não definido irá usar a pasta em WebView2Launcher.exe.WebView2\EBWebView ou algo semelhante.

- ### --runtime
  
  ```WebView2Launcher --runtime=[Runtime do WebView ou navegador]```
  Define aonde está o executável (ou runtime) do WebView2. Se não definido irá usar o WebView2 padrão do Microsoft Edge.

- ### --icon
  
  ```WebView2Launcher --userdata=[pasta para ser a UserData]```
  Define o ícone que aparecerá na Windows Taskbar e na janela. Se não definido usará o ícone em assets/favicon.ico.

- ### --width

  ```WebView2Launcher --width=[largura em pixels]```
  Define a largura da janela. Se não definido define 512px.

- ### --height
  
  ```WebView2Launcher --height=[altura em pixels]```
  Define a altura da janela. Se não definido define 512px.


## Fim

No WebView2, da para colocar tudo da Web. Desde receitas, explicações e até jogos complexos.
Eu criei isto porque queria colocar jogos num WebView2 sem pywebview. Então decidi criar isto.
