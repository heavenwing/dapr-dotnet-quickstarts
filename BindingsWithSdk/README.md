```sh
dapr run --app-id quickstarts-bindingsdk --app-port 5277 --dapr-http-port 13505 -- dotnet run

dapr run --app-id quickstarts-bindingsdk --app-port 5277 --dapr-http-port 13505 --components-path ../components -- dotnet run
```

Demostrates secrets management sdk usage:

- get secret