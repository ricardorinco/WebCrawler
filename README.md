# WebCrawler ConsoleApp

Repositório do aplicativo WebCrawler.

## Configurações

Este projeto contém um arquivo de configuração na pasta `src\WebCrawler.ConsoleApp\app.config`.

As propriedades desse arquivo são:

| Propriedade      | Descrição                                       | Valor                              |
| ---------------- | ----------------------------------------------- | ---------------------------------- |
| ChromiumHeadless | Define o modo de execução do Chromium           | `true` ou `false`                  |
| SentenceFile*    | Arquivo Json para seleção offline das sentenças | `D:\resources\bttf-sentences.json` |

###### * Será necessário realizar ajustes para a localização do arquivo .json.

> Observação: É fornecido um arquivo .json de exemplo, este arquivo está localizado na raiz do projeto: `resources\sentences\bttf-sentences.json`.

Caso deseje criar seu próprio arquivo de sentenças o formato aceito é:

```json
    [
        { "sentence": "Yes, definitely, god-dammit George, swear. Okay, so now, you come up, you punch me in the stomach, I'm out for the count, right? And you and Lorraine live happily ever after." },
        { "sentence": "One point twenty-one gigawatts. One point twenty-one gigawatts. Great Scott." },
        { "sentence": "Hey, hey, keep rolling, keep rolling there. No, no, no, no, this sucker's electrical. But I need a nuclear reaction to generate the one point twenty-one gigawatts of electricity that I need." },
        { "sentence": "Hey, McFly, I thought I told you never to come in here. Well it's gonna cost you. How much money you got on you?" }
    ]
```

## Console Arguments (flags)

Para execução customizada da aplicação, foi configurado a passagem de argumentos (flags) por linha de comando, Abaixo segue os comandos disponívies:

| Argumento      | Descrição                              | Exemplos                 | Valor Padrão  |
| -------------- | -------------------------------------- | ------------------------ | ------------- |
| FileSavePath*  | Diretório para salvar os arquivos .txt | `-fsp D:\\CrawlerReport` | Obrigatório   |
| FileSize       | Tamanho máximo do arquivo a ser gerado | `-fs 2500` (250MB)       | 100MB         |
| Interactions   | Interações realizadas pelo console     | `-i 7` (7 execuções)     | 1 execução    |
| BufferSize     | Tamanho máximo do buffer de string     | `-bs 15` (15MB)          | 10MB          |
| SentenceModo** | Modo da sentença gerada pelo LeroLero  | `-m 2` (Programador)     | 2-Programador | 

###### * Argumento obrigatório.
###### ** Opções disponíveis: 0-Original, 1-Psicanalítico e 2-Programador.

## Dependências 

WebCrawler usa os seguintes frameworks.

| Framework      | Version | Documentation                                                                                        |
| -------------- | ------- | ---------------------------------------------------------------------------------------------------- |
| ConsoleTables  | 2.4.2   | [https://github.com/khalidabuhakmeh/ConsoleTables](https://github.com/khalidabuhakmeh/ConsoleTables) |
| PuppeteerSharp | 2.0.4   | [https://github.com/hardkoded/puppeteer-sharp](https://github.com/hardkoded/puppeteer-sharp)         |
