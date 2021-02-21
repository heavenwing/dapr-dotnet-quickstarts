```sh
dapr run --app-id quickstarts-si --app-port 5000 --dapr-http-port 13501 -- dotnet run
```

provides below methods:

- /weather: get weather info
- /hello: pass "what" parameter, say hello

You can open sample.http file in VS Code(with installed REST Client extension) to try every methods.