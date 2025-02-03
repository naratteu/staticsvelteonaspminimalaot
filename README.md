# staticsvelteonaspminimalaot

닷넷을 백엔드로 스벨트를 프론트로 구성해봅니다.

코드스페이스에서 아래 명령을 복붙해주세요

```bash
dotnet new webapiaot -o ./Server
npx sv create --template minimal --types ts --no-add-ons --no-install ./Client

# https://svelte.dev/docs/kit/adapter-static
pushd Client

cat <<EOF > svelte.config.js
import adapter from '@sveltejs/adapter-static';

export default {
	kit: {
		adapter: adapter({
			// default options are shown. On some platforms
			// these options are set automatically — see below
			pages: '../Server/wwwroot',
			assets: '../Server/wwwroot',
			fallback: undefined,
			precompress: false,
			strict: true
		})
	}
};
EOF

cat <<EOF > src/routes/+layout.js
// This can be false if you're using a fallback (i.e. SPA mode)
export const prerender = true;
EOF

npm i -D @sveltejs/adapter-static
npm run build

popd

cd Server

patch Program.cs <<EOF
26a27,28
> app.UseDefaultFiles();
> app.UseStaticFiles();
EOF

dotnet run
```