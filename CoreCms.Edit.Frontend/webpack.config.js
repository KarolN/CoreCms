const path = require("path");
const webpack = require("webpack");

module.exports = {
    entry: {
        app: "./app/index.js",
        styles: "./app/styles.js"
    },
    output: {
        filename: "[name].bundle.js",
        path: path.resolve(__dirname, "./assets/")
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /(node_modules|bower_components)/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ['env']
                    }
                }
            },
            {
                test: /\.scss$/,
                exclude: /(node_modules)/,
                use: [
                    {
                        loader: "style-loader"
                    }, {
                        loader: "css-loader",
                        options: {sourceMap: true}
                    }, {
                        loader: "sass-loader",
                        options: {sourceMap: true}
                    }
                ]
            },
            {
                test: /\.css$/,
                use: [
                    {
                        loader: "style-loader"
                    }, {
                        loader: "css-loader",
                        options: {sourceMap: true}
                    }
                ]
            },
            {
                test: /\.vue$/,
                loader: 'vue-loader',
                options: {
                    scss: 'vue-style-loader!css-loader!sass-loader',
                    sass: 'vue-style-loader!css-loader!sass-loader?indentedSyntax',
                    css: 'vue-style-loader!css-loader'
                }
            }
        ]
    },
    resolve: {
        alias: {
            vue: 'vue/dist/vue.js',
            ["~"]: path.resolve(__dirname, "app")
        }
    },
    devtool:"#source-map",
    plugins: [
        new webpack.optimize.CommonsChunkPlugin(
            {name: 'common'})
    ]
};

