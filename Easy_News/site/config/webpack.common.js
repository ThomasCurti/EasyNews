// node modules
const path = require('path');
const merge = require('webpack-merge');

// webpack plugins
const ManifestPlugin = require('webpack-manifest-plugin');
const WebpackNotifierPlugin = require('webpack-notifier');
const HtmlWebpackPlugin = require('html-webpack-plugin');

// config files
const pkg = require('../package.json');
const settings = require('./webpack.settings.js');

// Configure Babel loader
const configureBabelLoader = () => {
    return {
        test: /\.js$/,
        exclude: [/(node_modules)/],
        use: [
            {
                loader: 'babel-loader',
                options: {
                    cacheDirectory: true,
                    sourceType: 'unambiguous',
                    presets: [
                        '@babel/preset-react',
                        '@babel/preset-env',
                    ],
                    plugins: ['@babel/plugin-transform-runtime'],
                },
            },
        ],
    };
};

// Configure Entries
const configureEntries = () => {
    let entries = {};
    for (const [key, value] of Object.entries(settings.entries)) {
        entries[key] = path.resolve(__dirname, settings.paths.src.base + value);
    }

    return entries;
};

// Configure Manifest
const configureManifest = (fileName) => {
    return {
        fileName: fileName,
        basePath: settings.manifestConfig.basePath,
        map: (file) => {
            file.name = file.name.replace(/(\.[a-f0-9]{32})(\..*)$/, '$2');
            return file;
        },
    };
};

// Configure Html webpack
const configureIndexHtml = () => {
    return {
        template: './public/index.html',
        filename: 'index.html',
        inject: true,
    };
};

const configure200Html = () => {
    return {
        template: './public/index.html',
        filename: '200.html',
        inject: true,
    };
};

// The base webpack config
const baseConfig = {
    name: pkg.name,
    entry: configureEntries(),
    output: {
        path: path.resolve(__dirname, settings.paths.dist.base),
        publicPath: settings.urls.publicPath(),
    },
    module: {
        rules: [configureBabelLoader()],
    },
    plugins: [
        new WebpackNotifierPlugin({
            title: 'Webpack',
            excludeWarnings: true,
            alwaysNotify: true,
        }),
        new ManifestPlugin(configureManifest('manifest-legacy.json')),
        new HtmlWebpackPlugin(configureIndexHtml()),
        new HtmlWebpackPlugin(configure200Html()),
    ],
};

// Common module exports
// noinspection WebpackConfigHighlighting
module.exports = {
    legacyConfig: merge.strategy({
        module: 'prepend',
        plugins: 'prepend',
    })(baseConfig),
};
