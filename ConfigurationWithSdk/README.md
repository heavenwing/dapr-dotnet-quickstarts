```sh
dapr run --app-id quickstarts-configsdk --dapr-http-port 13504 --components-path ../components -- dotnet run
```

add initial value for configuration

```bash
docker exec dapr_redis redis-cli SET withdrawVersion "v1||1"
docker exec dapr_redis redis-cli SET source "local"
```

Demostrates configuration sdk and asp.net core extensions usage:

- load configuration from dapr redis store
- auto refresh configuration from dapr redis store