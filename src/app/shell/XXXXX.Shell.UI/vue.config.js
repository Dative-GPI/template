module.exports = {
  "transpileDependencies": [
    "vuetify"
  ],
  devServer: {
    host: "0.0.0.0",
    port: "8080",
    disableHostCheck: true
  },
  configureWebpack: {
    resolve: {
      symlinks: false
    }
  },
  assetsDir: "dist"
}