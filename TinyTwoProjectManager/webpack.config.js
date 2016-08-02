var pkg = require('./package.json');
var path = require('path');
var webpack = require('webpack');

// bundle dependencies in separate vendor bundle
var vendorPackages = Object.keys(pkg.dependencies).filter(function (el) {
    return el.indexOf('font') === -1; // exclude font packages from vendor bundle
});

/**
 * Default webpack configuration for development
 */
var config = {
    cache: true,
    devtool: 'eval-source-map',
    entry: {
        main: path.join(__dirname, "app", "App.js"),
        vendor: vendorPackages
    },
    externals: {
        // Use external version of React (from CDN for client-side, or bundled with ReactJS.NET for server-side)
        react: 'React'
    },
	module: {
		loaders: [
			{
			    test: /(\.jsx|\.js)$/,
			    loader: 'babel',
			    exclude: /node_modules/,
			    query: {
                    presets: ['es2015', 'react']
			    }
			},
            {
                test: /\.css$/,
                loader: 'style!css'
            }
		],
	},
	output: {
	    path: path.join(__dirname, 'js'),
	    filename: '[name].js',
	    sourceMapFilename: '[file].map'
	},
	plugins: [
        new webpack.OldWatchingPlugin(),  //needed to make watch work. see http://stackoverflow.com/a/29292578/1434764
        new webpack.optimize.CommonsChunkPlugin(/* chunkName= */"vendor", /* filename= */"vendor.js")
	],
	resolve: {
		// Allow require('./blah') to require blah.jsx
	    extensions: ['', '.js', '.jsx'],
        modulesDirectories: ['node_modules']
	},
	resolveLoader: {
	    'fallback': path.join(__dirname, 'node_modules')
	}
};

/**
 * If bundling for production, optimize output
 */
if (process.env.NODE_ENV === 'production') {
    config.devtool = false;
    config.plugins = [
        new webpack.optimize.OccurenceOrderPlugin(),
        new webpack.optimize.UglifyJsPlugin({
            comments: false,
            compress: { warnings: false }
        }),
        new webpack.DefinePlugin({
            'process.env': { NODE_ENV: JSON.stringify('production') }
        })
    ];
};

module.exports = config;