import request from '@/utils/request'
import { dateFormat, getType } from '@/utils'

export const commonAjax = function(hasLoading, url = '', requestData = {}, configData = {}) {
  configData.hasLoading = hasLoading
  configData.method = (configData.method ? configData.method : 'POST').toUpperCase()
  const data = configData.method === 'POST'
    ? { data: requestData }
    : configData.method === 'GET'
      ? { params: requestData }
      : {}
  return request({
    url,
    method: configData.method,
    ...data,
    headers: {
      configData
    }
  })
}

export const commonTableDateFetch = (option) => function(pageIndex) {
  const _this = this
  const url = typeof option.url === 'function' ? option.url.call(_this) : option.url
  if (!url) {
    return
  }
  this.table.isLoading = true
  const requestData = Object.assign({
    pageIndex: pageIndex || 1,
    pageSize: this.table.pageSize
  }, (this.table.ajaxData || {}), option.data && option.data.call(_this))
  const configData = {
    noError: true,
    method: option.method || 'post'
  }
  return commonAjax.call(_this, false, url, requestData, configData)
    .then(result => {
      if (result.result) {
        _this.table.data = typeof option.success === 'function'
          ? option.success.call(_this, result.data)
          : result.data
        _this.table.currentPage = pageIndex
        _this.table.pageTotal = result.total
      } else {
        option.fail && option.fail.call(_this, result)
      }
      _this.table.isLoading = false
      return result
    })
    .catch(e => {
      _this.table.isLoading = false
    })
}

export const combineReqData = function(formData) {
  const data = {}
  for (const key in formData) {
    const keys = key.split(',')
    const values = keys.length > 1 ? formData[key] : [formData[key]]
    keys.forEach((k, index) => {
      const value = values[index]
      const type = getType(value)
      switch (type) {
        case 'date':
          data[k] = dateFormat(value, 'yyyy-MM-dd hh:mm:ss')
          break
        case 'string':
          data[k] = value.trim()
          break
        default:
          data[k] = value
          break
      }
    })
  }
  return data
}
