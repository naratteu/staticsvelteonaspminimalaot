# staticsvelteonaspminimalaot

닷넷을 백엔드로 스벨트를 프론트로 구성해봅니다.

코드스페이스에서 아래 명령을 복붙해주세요

```bash
dotnet build ./SvelteApp.Client/SvelteApp.Client.esproj
dotnet publish ./SvelteApp.Server/SvelteApp.Server.csproj -o ./pub
./pub/SvelteApp.Server
```