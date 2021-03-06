# Todo List Api Rest with ASP .NET core 2.2 with MongoDB & Swagger

_Basic Api rest example in ASP .NET Core 2.2 with MongoDB & Swagger_

### Prerequisites

- [Visual Studio 2017+](https://visualstudio.microsoft.com)

- [MongoDB](https://www.mongodb.com/)

### Installing

Cloning the repository

```

git clone https://github.com/ghouljd/TodoListApiRest.git

```

Execute file _TodoApiRest.sln_ located in cloned folder.

Create database _TodoListDB_ in your MongoDB instance.

Compile and run project. Visit _https://localhost:your-port/swagger/_

```

https://localhost:<your-port>/swagger/

```

## Using

The available routes are:

| Route          | Method | Body                                   | Description                            |
| -------------- | ------ | -------------------------------------- | -------------------------------------- |
| /api/Todo      | GET    |                                        | Returns a list of existing Todo items. |
| /api/Todo/{id} | GET    |                                        | Returns a specific Todo item.          |
| /api/Todo/     | POST   | { name: 'string' }                     | Create a Todo item.                    |
| /api/Todo/{id} | PUT    | { name: 'string', isComplete: 'bool' } | Edit a Todo item.                      |
| /api/Todo/{id} | DELETE |                                        | Delete a Todo item.                    |

## Built tools

- [Visual Studio 2017+](https://visualstudio.microsoft.com) - IDE for .NET Apps.
- [MongoDB](https://www.mongodb.com/) - Database NoSQL.

## Made by

[**Jesús Escalante**](https://github.com/ghouljd)
