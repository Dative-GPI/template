module.exports = {
  "transpileDependencies": [
    "vuetify"
  ],
  devServer: {
    host: "0.0.0.0",
    port: "8080",
    public: "extension.localhost",
    disableHostCheck: true
  },
  configureWebpack: {
    resolve: {
      symlinks: false
    }
  },
  assetsDir: "dist"
}