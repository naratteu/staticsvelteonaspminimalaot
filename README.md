# static-svelte-on-asp-minimal-aot

![image](https://github.com/user-attachments/assets/5307e783-1eae-4bdc-928a-cc663c921aa5)
> 실행파일 하나로 웹앱 뚝딱!

닷넷을 백엔드로 스벨트를 프론트로 웹UI 스탠드얼론 데스크톱 애플리케이션을 만듭니다.

아래 명령을 복붙해주세요

```bash
node -v # v23.7.0
npm -v # 10.9.2
dotnet --version # 9.0.200-preview.0.25057.12

git clone https://github.com/naratteu/staticsvelteonaspminimalaot --branch webui
cd staticsvelteonaspminimalaot

curl -L "https://github.com/webui-dev/webui/releases/download/2.5.0-beta.2/webui-windows-msvc-x64.zip" | tar -x # 윈도우용 명령
curl -LO "https://github.com/webui-dev/webui/releases/download/2.5.0-beta.2/webui-linux-gcc-x64.zip" && unzip *.zip # wsl 명령

dotnet build ./SvelteApp.Client/SvelteApp.Client.esproj
dotnet publish ./SvelteApp.Server/SvelteApp.Server.csproj -o ./pub
./pub/SvelteApp.Server
```

## Done

- `win11-x64`: 14MB -upx-> 5.6MB
- `linux-x64`: 16MB -upx-> 6.2MB (ChromeOS Flex)

## Todo

- Debug용 구성
- macOS Test
- webui 라이브러리 분리
- 빌드 플로우 간소화
- golang 백엔드로도 구현해보고싶음
- https://github.com/MichalStrehovsky/PublishAotCompressed (upx)

## Thanks

- https://github.com/Quickz/svelte-dotnet-template
- https://github.com/webui-dev/webui
- https://github.com/sneusse/aot-static-example
