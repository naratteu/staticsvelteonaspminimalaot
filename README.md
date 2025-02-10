# staticsvelteonaspminimalaot

닷넷을 백엔드로 스벨트를 프론트로 웹UI 스탠드얼론 데스크톱 애플리케이션을 만듭니다.

코드스페이스에서 아래 명령을 복붙해주세요

```bash
curl -L "https://github.com/webui-dev/webui/releases/download/2.5.0-beta.2/webui-windows-msvc-x64.zip" | tar -x # 윈도우용 명령
curl -LO "https://github.com/webui-dev/webui/releases/download/2.5.0-beta.2/webui-linux-gcc-x64.zip" && unzip *.zip # wsl 명령

dotnet build ./SvelteApp.Client/SvelteApp.Client.esproj
dotnet publish ./SvelteApp.Server/SvelteApp.Server.csproj -o ./pub
./pub/SvelteApp.Server
```