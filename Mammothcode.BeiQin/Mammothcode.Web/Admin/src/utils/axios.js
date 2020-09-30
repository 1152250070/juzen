const request = require('@/utils/request')

function appendRoute(url, routeData) {
  const appendKeys = []
  for (const k in routeData) {
    if (routeData.hasOwnProperty(k) && new RegExp(`/:${k}(/|$)`).test(url)) {
      appendKeys.push(k)
      url = url.replace(`:${k}`, routeData[k])
    }
  }
  return {
    url,
    appendKeys
  }
}

const METHODS = ['get', 'post', 'delete', 'put'];

export const $axios = function(options) {
  return beforeRequest(options)
}

function beforeRequest(options) {
  options.method = options.method.toUpperCase();

  // 合并路由数据
  const routeData = Object.assign({}, options.data, options.params, options.config?.routeData);

  // 拼接路由链接
  if (Object.keys(routeData).length) {
    const { url, appendKeys } = appendRoute(options.url, routeData)
    options.url = url
    // 清除路由添加数据
    if (appendKeys.length) {
      appendKeys.forEach(key => {
        if (options.data && options.data.hasOwnProperty(key)) {
          delete options.data[key]
        }
        if (options.params && options.params.hasOwnProperty(key)) {
          delete options.params[key]
        }
      })
    }
  }

  return request(options);

}

// 添加方法
METHODS.forEach(m => {
  $axios[m] = function(url, requestData = {}, configData = { routeData: {} }) {
    const method = m.toUpperCase()
    return beforeRequest({
      url,
      method,
      config: configData,
      data: method !== 'GET' ? requestData : {},
      params: method === 'GET' ? requestData : {}
    })
  }
})

export default $axios
