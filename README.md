# static-svelte-on-asp-minimal-aot

닷넷을 백엔드로 스벨트를 프론트로 웹UI 스탠드얼론 데스크톱 애플리케이션을 만듭니다.

아래 명령을 복붙해주세요

```bash
node -v # v23.7.0
npm -v # 10.9.2
dotnet --version # 9.0.200-preview.0.25057.12

git clone https://github.com/naratteu/staticsvelteonaspminimalaot
cd staticsvelteonaspminimalaot

curl -L "https://github.com/webui-dev/webui/releases/download/2.5.0-beta.2/webui-windows-msvc-x64.zip" | tar -x # 윈도우용 명령
curl -LO "https://github.com/webui-dev/webui/releases/download/2.5.0-beta.2/webui-linux-gcc-x64.zip" && unzip *.zip # wsl 명령

dotnet build ./SvelteApp.Client/SvelteApp.Client.esproj
dotnet publish ./SvelteApp.Server/SvelteApp.Server.csproj -o ./pub
./pub/SvelteApp.Server
```

## Done

- win11-x64
- linux-x64 (ChromeOS Flex)

## Todo

- Debug용 구성
- macOS Test
- webui 라이브러리 분리
- 빌드 플로우 간소화
- golang 백엔드로도 구현해보고싶음

## See alse

- https://github.com/MichalStrehovsky/PublishAotCompressed (upx)
