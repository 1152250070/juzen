import {
	GetInfoAjax,
	token
} from './api'

// token 获取用户模型
function getUserInfoByToken() {
	return new Promise((resolve, reject) => {
		GetInfoAjax({
			token: true
		}, {
			noError: true
		}).then(res => {
			let result = res.data
			if (result.result) {
				token.setValue(result.data.token)
				resolve({
					error: null,
					data: result.data
				})
			} else {
				token.remove()
				resolve({
					error: true,
					data: result.message
				})
			}
		})
	})
}

// jscode 获取用户模型
function getUserInfoByJsCode() {
	return new Promise((resolve, reject) => {
		uni.login({
			success: res => {
				GetInfoAjax({
					jsCode: res.code
				}, {
					noError: true
				}).then(res => {
					let result = res.data
					if (result.result) {
						token.setValue(result.data.token)
						resolve({
							error: null,
							data: result.data
						})
					} else {
						token.remove()
						resolve({
							error: true,
							data: result.message
						})
					}
				})
			}
		})
	})
}

// 获取用户模型
function getUserInfo() {
	return new Promise((resolve, reject) => {
		if (token.value) {
			// token获取
			getUserInfoByToken().then(res => {
				if (!res.error) {
					resolve(res.data)
				} else {
					getUserInfoByJsCode().then(res => {
						!res.error ? resolve(res.data) : reject(res.data)
					})
				}
			})
		} else {
			getUserInfoByJsCode().then(res => {
				!res.error ? resolve(res.data) : reject(res.data)
			})
		}
	})
}


module.exports = {
	getUserInfo: getUserInfo
}
