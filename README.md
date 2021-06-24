[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]


<br />
<p align="center">
  <a href="https://github.com/ahcantarim/xpinc-xamarin-forms">
    <img src=".github/logo.png" alt="xpinc-xamarin-forms" width="80" height="80">
  </a>

  <h3 align="center">Desafio Técnico | XP Inc.</h3>

  <p align="center">
    Desafio técnico proposto pela XP Inc. (Tribo Bull) onde é simulada uma tela de histórico de ordens na bolsa de valores, renderizada para UWP e WPF utilizando Xamarin.Forms.
    <br />
    <br />
    <a href="https://github.com/ahcantarim/xpinc-xamarin-forms/issues">Ver problemas abertos</a>
    ·
    <a href="https://github.com/ahcantarim/xpinc-xamarin-forms/issues/new">Reportar um problema</a>
  </p>
</p>


## Sumário

<ol>
    <li>
        <a href="#sobre-este-projeto">Sobre este projeto</a>
        <ul>
            <li><a href="#tecnologias-utilizadas">Tecnologias utilizadas</a></li>
        </ul>
    </li>
    <li>
        <a href="#configurações-do-ambiente-de-desenvolvimento">Configurações do ambiente de desenvolvimento</a>
        <ul>
            <li><a href="#pré-requisitos">Pré-requisitos</a></li>
            <li><a href="#clonando-o-repositório">Clonando o repositório</a></li>
        </ul>
    </li>
    <li><a href="#estrutura-da-aplicação">Estrutura da aplicação</a></li>
    <li><a href="#execução-da-aplicação">Execução da aplicação</a></li>
    <li><a href="#teste-de-aumento-de-carga">Teste de aumento de carga</a></li>
    <li><a href="#testes-unitários">Testes unitários</a></li>
    <li><a href="#análise-de-cobertura-de-código">Análise de cobertura de código</a></li>
    <li><a href="#análise-de-performance">Análise de performance</a></li>
    <li><a href="#licença">Licença</a></li>
    <li><a href="#contato">Contato</a></li>
</ol>


## Sobre este projeto

Desafio composto pelas etapas abaixo:

###### 1. Layout

- Criação da tela de histórico.
- A tela deve ser renderizada tanto em `UWP (Universal Windows Platform)` quanto em `WPF (Windows Presentation Foundation)`, utilizando `Xamarin.Forms`.


###### 2. Criação do Mock

- A tela deve sofrer alterações constantes semelhante a execução de ordens na bolsa de valores.
- A cada `50 milissegundos`, incluir um item novo na lista e/ou modificar os itens existentes.
- A tela deve refletir essa alteração.

###### 3. Desafio extra #1

- Simular momentos de aumento de carga, onde múltiplos itens da lista são alterados.

###### 4. Testes unitários

- A aplicação deve conter ao menos `80%` de cobertura de testes unitários.

###### 5. Desafio extra #2

- Gerar os relatórios de cobertura de código utilizando o `Coverlet`.

###### 6. Análise de performance

- Realizar uma análise de performance da aplicação, fazendo um comparativo entre `UWP` e `WPF`, principalmente ao uso de processamento e memória.


### Tecnologias utilizadas

* [Xamarin.Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/)
* [UWP](https://docs.microsoft.com/en-us/archive/msdn-magazine/2016/connect/xamarin-xamarin-and-the-universal-windows-platform)
* [WPF](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/platform/other/wpf)
* [Coverlet](https://github.com/coverlet-coverage/coverlet)


## Configurações do ambiente de desenvolvimento

Para obter uma cópia local atualizada e que possa ser executada corretamente, siga os passos abaixo.

### Pré-requisitos

- Visual Studio com os seguintes componentes inclusos na instalação:
  - Desenvolvimento móvel com .NET
  - Desenvolvimento com a Plataforma Universal do Windows


### Clonando o repositório

```bash
git clone https://github.com/ahcantarim/xpinc-xamarin-forms.git
```


## Estrutura da aplicação

A solução está dividida em quatro projetos, conforme imagem:

[![Solution Explorer][screenshot-solution-explorer]][screenshot-solution-explorer]

- `XPInc.Cantarim.UI.Mobile.CrossPlatform`: projeto cross-platform com alto nível de compartilhamento de código entre as plataformas alvo.

- `XPInc.Cantarim.UI.Mobile.CrossPlatform.UWP`: projeto alvo para UWP (Universal Windows Platform).

- `XPInc.Cantarim.UI.Mobile.CrossPlatform.WPF`: projeto alvo para WPF (Windows Presentation Foundation).

- `XPInc.Cantarim.UI.Mobile.CrossPlatform.Test`: projeto para testes de unidade do código cross-platform.

## Execução da aplicação

Independente da plataforma alvo escolhida para execução, a aplicação terá o mesmo comportamento.

A cada 50 milissegundos é simulada uma alteração no histórico de ordens.

Nessa simulação, sorteia-se uma ação a ser realizada:

- **Incluir nova ordem**: uma nova ordem aleatória é adicionada à listagem, com `Quantidade Executada` zerada.

- **Alterar ordem existente**: sorteia-se um número de ordens que serão alteradas e, para cada ordem sorteada, a `Quantidade Executada` é incrementada de forma aleatória. Ordens totalmente executadas (`Quantidade Executada = Quantidade`) são removidas da listagem, enquanto ordens parcialmente executadas (`Quantidade Executada < Quantidade`) continuam sendo exibidas, mas com valores atualizados em tela.

- **Ambos**: as ações anteriores são executadas mais vezes do que seriam comumente.


#### Exemplo da execução do projeto alvo UWP

[![Universal Windows Platform][screenshot-sample-uwp]][screenshot-sample-uwp]


#### Exemplo da execução do projeto alvo WPF

[![Windows Presentation Foundation][screenshot-sample-wpf]][screenshot-sample-wpf]


## Teste de aumento de carga

O método responsável por simular alterações no histórico de ordens, sorteia a quantidade de ordens que deverão ser modificadas na listagem.

Essa quantidade pode ser grande ou pequena e, para facilitar a análise, um `log` foi escrito neste momento para exibir:

- A quantidade atual de ordens no histórico;

- A quantidade de ordens que deverão ser alteradas, com base no sorteio prévio;

- A quantidade atualizada de ordens no histórico, desconsiderando ordens que após a alteração podem ter sido totalmente executadas;

Conforme imagem, nota-se que existem momentos em que a quantidade de ordens alteradas é relativamente grande quando comparada com a quantidade de ordens existentes, simulando assim um aumento na carga de processamento e na atualização da tela:


[![Output Window][screenshot-output-window]][screenshot-output-window]


## Testes unitários

O projeto conta com testes unitários do `MSTest` para garantir seu funcionamento em diversas situações.

Atualmente, todos os testes estão sendo executados com êxito, confirmando o resultado esperado:

[![Test Explorer][screenshot-test-explorer]][screenshot-test-explorer]


## Análise de cobertura de código

Com base nos testes unitários escritos para validação do código, foi gerado o relatório de cobertura com o `Coverlet`.

Atualmente, o projeto conta com uma cobertura de código de +92%:

[![BLA][screenshot-code-coverage]][screenshot-code-coverage]


## Análise de performance

`TODO: Imagens e análise`


## Licença

Distribuído através da licença MIT. Veja `LICENSE` para mais informações.


## Contato

André Cantarim

[![LinkedIn][linkedin-shield]][linkedin-url]


<a href="#sumário">🔝 Voltar ao topo</a>


[contributors-shield]: https://img.shields.io/github/contributors/ahcantarim/xpinc-xamarin-forms.svg?style=for-the-badge
[contributors-url]: https://github.com/ahcantarim/xpinc-xamarin-forms/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/ahcantarim/xpinc-xamarin-forms.svg?style=for-the-badge
[forks-url]: https://github.com/ahcantarim/xpinc-xamarin-forms/network/members
[stars-shield]: https://img.shields.io/github/stars/ahcantarim/xpinc-xamarin-forms.svg?style=for-the-badge
[stars-url]: https://github.com/ahcantarim/xpinc-xamarin-forms/stargazers
[issues-shield]: https://img.shields.io/github/issues/ahcantarim/xpinc-xamarin-forms.svg?style=for-the-badge
[issues-url]: https://github.com/ahcantarim/xpinc-xamarin-forms/issues
[license-shield]: https://img.shields.io/github/license/ahcantarim/xpinc-xamarin-forms.svg?style=for-the-badge
[license-url]: https://github.com/ahcantarim/xpinc-xamarin-forms/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/ahcantarim

[screenshot-code-coverage]: .github/code-coverage.png
[screenshot-output-window]: .github/output-window.png
[screenshot-sample-uwp]: .github/sample-uwp.png
[screenshot-sample-wpf]: .github/sample-wpf.png
[screenshot-solution-explorer]: .github/solution-explorer.png
[screenshot-test-explorer]: .github/test-explorer.png