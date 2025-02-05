import adapter from '@sveltejs/adapter-static';

const config = {
	kit: {
		adapter: adapter({
			pages: '../SvelteApp.Server/wwwroot',
			assets: '../SvelteApp.Server/wwwroot',
			fallback: undefined,
			precompress: false,
			strict: true
		})
	}
};

export default config;
