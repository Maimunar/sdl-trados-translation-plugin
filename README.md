# SDL Trados Plugin

## By Aleksandar Ivanov, Martin Georgiev, Angel Angelov, Mirela Cristiana Gherlan, Alexandra Gomoyurova, Yash Jagwani, Galin Savov

### Goal of project

The project is given as a task from Amplexor (https://www.amplexor.com/). 
The goal is to create a service that automatically translates a document in a selected language. The restrictions consist of a few things, most notably:
    The software needs to run as a plugin for SDL Trados Studio 2019
    The translation needs to be done using the EUR-LEX Database

During the process of translation, the following steps are done:
    1. The software runs through the source document, finding any fitting reference numbers
    2. Upon found references, they are send to the EUR-LEX API in order to receive a CELEX_ID number
    3. When a CELEX number is received, it is sent to the EUR-LEX Database to receive the documents in source and target language as HTML
    4. The texts are stripped of HTML, aligned on a paragraph level and put in a translation memory using the SDL Trados Studio
    5. The translation memory is then exported to a .tmx format

### How to use

In order to create the plugin from the source code, you need to run build. You will receive a Debug folder with an .sdlpugin installer
NOTE: In some cases, you might not be able to directly build the project. That might be because of a signing issue. To fix that, follow these steps:
1. Right-click on the project itself 
2. Properties 
3. Signing 
4. Check Sign with Assembly
5. The key is in the repository itself (gcs.snk). Select it.
