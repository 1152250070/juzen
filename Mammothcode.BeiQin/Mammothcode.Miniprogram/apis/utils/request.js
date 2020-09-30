import utils from '@/lib/utils/util.js'
import Token from './token.js'
/* 默认配置 */
const _defaultConfigData = {
	header: {
		'content-type': 'application/json',
	},
	method: 'POST',
	query: null,
	dataType: 'json',
	responseType: 'text',
	noError: false,
	timeout: null // ms
}

/* 请求类 */
export default class Request {
	constructor(configData = {}) {
		this.id = 0
		this.name = configData.name
		this.baseUrl = configData.baseUrl || ''
		this.freeUrls = configData.freeUrls || []
		this.cacheUrls = configData.cacheUrls || []
		this.cache = {}
		this.hasCache = this.cacheUrls.length !== 0
		this.promiseUrl = {}
		this.timers = []
		this.checkFn = configData.checkFn || function(res) {
			return res.data.result
		}
		this.dataRoutes = configData.dataRoutes || ['data', 'data']
		this.errorRoutes = configData.errorRoutes || ['data', 'message']
		if (this.name) {
			this.token = new Token(this.name)
		}
		
		this._addSupport()
	}
	
	/* 添加辅助方法 */
	_addSupport() {
		['get', 'post'].forEach(item => {
			this[item] = function(url, requestData = {}, configData = {}) {
				configData.method = item.toUpperCase()
				return this.request(url, requestData, configData)
			}
		})
	}
	
	/* 设置接口数据缓存 */
	_setCache(isCache, cahceKey, data) {
		if (isCache && !this.cache[cahceKey]) {
			this.cache[cahceKey] = utils.cloneObj(data)
		}
	}
	
	/* 请求函数 */
	request(url, requestData = {}, configData = {}) {
		return new Promise((resolve, reject) => {
			let id = ++this.id
			// 合并配置项
			configData = utils.merge(_defaultConfigData, configData)
			// 设置GET请求参数
			if (configData.method.toUpperCase() === 'GET' && configData.query) {
				requestData = utils.merge(requestData, configData.query)
			}
			// 查看是否连续同时调用接口
			if (!~this.freeUrls.indexOf(url)) {
				this.promiseUrl[url] && this.promiseUrl[url].abort();
			}
			// 检查缓存需求
			let isCache = ~this.cacheUrls.indexOf(url)
			let cahceKey = null
			if (isCache) {
				cahceKey = url
				for (let k in requestData) {
					cahceKey += k + '_'
				}
				if (this.cache[cahceKey]) {
					resolve(utils.cloneObj(this.cache[cahceKey]))
					return false
				}
			}
			// 查看是否需要token
			if (requestData.token) {
				requestData.token = this.token.getValue()
			}
			// 设置定时器
			if (configData.timeout != null) {
				let timer = setTimeout(() => {
					let index = this.timers.findIndex(item => item.id === id)
					if (~index) {
						this.promiseUrl[url] && this.promiseUrl[url].abort()
						this.timers.splice(index, 1)
						reject({
							text: 'timeout',
							isTimeout: true
						})
					}
				}, configData.timeout)
				this.timers.push({
					timer: timer,
					id: id
				})
			}
			// 发请求
			this.promiseUrl[url] = uni.request({
				url: this.baseUrl + url,
				method: configData.method,
				data: requestData,
				dataType: configData.dataType,
				responseType: configData.responseType,
				success: res => {
					if (configData.noError) {
						// 无需检查接口返回数据
						this._setCache(isCache, cahceKey, res)
						resolve(res)
					} else {
						// 检查接口错误
						if (this.checkFn(res)) {
							let resolveData = utils.readObjInfo(res, this.dataRoutes)
							this._setCache(isCache, cahceKey, resolveData)
							resolve(resolveData)
						} else {
							let message = utils.readObjInfo(res, this.errorRoutes) || '出错了!'
							uni.showToast({
								title: message,
								icon: 'none'
							})
							this.hidePageLoading()
							reject({
								isError: true,
								text: message
							})
						}
					}
				},
				fail: res => {
					this.hidePageLoading()
					reject(res)
				},
				complete: res => {
					var index = this.timers.findIndex(item => item.id === id)
					if (~index) {
						clearTimeout(this.timers[index].timer)
						this.timers.splice(index, 1)
					}
					this.promiseUrl[url] = null
				}
			})
		})
	}
	
	/* 隐藏loading */
	hidePageLoading() {
		let pages = getCurrentPages()
		pages && 
		pages[pages.length - 1] && 
		pages[pages.length - 1].$vm && 
		pages[pages.length - 1].$vm.hidePageLoading &&
		pages[pages.length - 1].$vm.hidePageLoading()
	}
	
}