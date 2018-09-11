const path = require('path');
const HtmlWebPackPlugin = require('html-webpack-plugin');

module.exports = {
    entry: './src/main.jsx',
    output: {
        path: path.resolve('wwwroot'),
    },
    module: {
        rules: [
            {
                test: /\.css$/,
                use: ['style-loader', 'css-loader'],
            },
            {
                test: /\.jsx?$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                },
            },
            { test: /\.flow$/, loader: 'ignore-loader' },
        ],
    },
    plugins: [
        new HtmlWebPackPlugin({
            template: './src/index.html',
            filename: './index.html',
        }),
    ],
};
