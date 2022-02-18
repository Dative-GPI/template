import axios from "axios";

const instance: any = axios.create({
  // baseURL: 'https://localhost/',
  timeout: 10000,
  params: {}
});

instance.interceptors.request.use((config: any) => {
  try {
    if (!config.url.endsWith('/') && !config.url.includes("?")) {
      config.url += '/';
    }
  }
  catch (exception) {
    console.log(exception);
  }
  return config;
});

export default instance;