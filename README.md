## Planejamento

**I. Elaborar base de dados: MongoDB** <br>
**II. Desenvolver Controller e Service** <br>
**III. Integração Backend e Banco de Dados (requisições)** <br>
**IV. Desenvolver Frontend** <br>

### Pensamentos

- A aplicação deve ser disponibilizável para utilização em outras máquinas sem dificuldades.
- Todos os métodos CRUD devem ser implementados.

### Detalhamento

- Para disponibilidade da aplicação, a base de dados será CONTAINERIZADA.

## Guia de utilização do Podman

**I. Para utilização de uma Máquina Virtual:**

% podman machine init <nome_da_maquina>
% podman machine set --active <nome_da_maquina> [Para garantir utilização da máquina especificada]
% podman machine start

**II. Uma vez rodando, a máquina está pronta para criação do Container:**

% podman run --detach --name <nome_do_container> -p <porta_local>:<porta_container> docker.io/mongodb/mongodb-community-server:latest

- <porta_local>: Porta da máquina local que será mapeada para a porta do container (e.g. 3000 ou 27017)
- <porta_container>: Porta do container atribuída à porta local (e.g 27017)
- O último parâmetro consiste na imagem Docker na qual o container gerado se baseará (blueprint)

**III. Container criado, hora da execução da base:**

% podman exec -it <nome_do_container> mongosh

- Este comando causa a execução do mongosh, o que permite a interação com as bases de dados.
- Para segregação, criamos uma nova base onde as collections (no caso deste projeto, apenas uma) serão criadas

## Guia de utilização do Mongosh

**I. Primeiramente, criamos uma nova base de dados:**

/~ use <nome_da_base>

**II. Agora, para interação, é necessária uma Collection**

/~ db.createCollection("Tasks", {})

- O nome da coleção, passado no primeiro parâmetro, costuma ser no plural
- O segundo parâmetro corresponde às validações para as regras de documentos inseridos na coleção
- Os documentos passados na inserção devem ser em formato JSON ({"chave": "valor"})

```
# Exemplo de validação para documentos a serem INSERIDOS

db.createCollection("Tasks", {
validator: {

    $jsonSchema: {
      bsonType: "object",
      required: ["description", "completed"],
      properties: {
        description: {
          bsonType: "string",
          description: "Sentence to describe task."
        },
        completed: {
          bsonType: "bool",
          description: "Determine if task is completed, therefore displayed."
        },
      }
    }

},
validationLevel: "strict"
}
)
```

Para a interação da API com o Banco de Dados, utilizamos o seguinte artigo:
[Create a RESTful API With .NET Core and MongoDB](https://www.mongodb.com/developer/languages/csharp/create-restful-api-dotnet-core-mongodb/?msockid=058229b7cbb46b4c37143cb1ca056a7f)

What's a "singleton"?
