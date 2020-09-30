const axios = window.axios
import { MessageBox, Message, Loading } from 'element-ui'
import store from '@/store'
import { getToken } from '@/utils/auth'
import config from '@/config'

let loadingInstance = null

// create an axios instance
const service = axios.create({
  baseURL: config.baseUrl // url = base url + request url
  // withCredentials: true, // send cookies when cross-domain requests
  // timeout: 20000 // request timeout
})

// request interceptor
service.interceptors.request.use(
  config => {
    // do something before request is sent
    const configData = config.headers.configData
    if (configData && configData.hasLoading) {
      loadingInstance = Loading.service({
        fullscreen: true,
        lock: true,
        text: 'Loading',
        spinner: 'el-icon-loading',
        background: 'rgba(0, 0, 0, 0.7)'
      })
    }
    if (store.getters.token) {
      // let each request carry token
      // ['X-Token'] is a custom headers key
      // please modify it according to the actual situation
      config.headers['X-Token'] = getToken()
      if (config.data) {
        config.data.token = store.getters.token
      }
    }
    return config
  },
  error => {
    // do something with request error
    console.log(error) // for debug
    return Promise.reject(error)
  }
)

// response interceptor
service.interceptors.response.use(
  /**
   * If you want to get http information such as headers or status
   * Please return  response => response
  */

  /**
   * Determine the request status by custom code
   * Here is just an example
   * You can also judge the status by HTTP Status Code
   */
  response => {
    loadingInstance && loadingInstance.close()
    const res = response.data
    const configData = response.config.headers.configData
    if (configData && configData.return) {
      return response
    }
    if (configData && configData.noError) {
      return res
    }
    // if the custom code is not 20000, it is judged as an error.
    if (res.status !== 200) {
      Message({
        message: res.message || 'Error',
        type: 'error',
        duration: 5 * 1000
      })

      // 50008: Illegal token; 50012: Other clients logged in; 50014: Token expired;
      if (res.status === 50008 || res.status === 50012 || res.status === 50014) {
        // to re-login
        MessageBox.confirm('You have been logged out, you can cancel to stay on this page, or log in again', 'Confirm logout', {
          confirmButtonText: 'Re-Login',
          cancelButtonText: 'Cancel',
          type: 'warning'
        }).then(() => {
          store.dispatch('user/resetToken').then(() => {
            location.reload()
          })
        })
      }
      return Promise.reject(new Error(res.message || 'Error'))
    } else {
      return res.data
    }
  },
  error => {
    loadingInstance && loadingInstance.close()
    const configData = error.response.config.headers.configData
    if (configData && (configData.noError || configData.return)) {
      return Promise.reject(error)
    } else {
      let message = ''
      try {
        message = error.response && error.response.data
          ? error.response.data.message
          : error.message
      } catch (error) {
        message = error.message
      }
      Message({
        message,
        type: 'error',
        duration: 5 * 1000
      })
      return Promise.reject(error)
    }
  }
)

export default service
