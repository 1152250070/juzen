import {
	GetMemberInfo,
	token
} from './api'

// token 获取用户模型
function getUserInfoByToken() {
	return new Promise((resolve, reject) => {
		GetMemberInfo({
			token: true
		}, {
			noError: true
		}).then(res => {
			let result = res.data
			if (result.result) {
                result.data.member.ages = result.data.ages
				token.setValue(result.data.token)
				resolve({
					error: null,
					data: result.data.member
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
				GetMemberInfo({
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
					reject(res.data)
				}
            })
        } else {
            resolve({})
        }
		// } else {
		// 	getUserInfoByJsCode().then(res => {
		// 		if (!res.error) {
		// 			resolve(res.data)
		// 		} else {
		// 			reject(res.data)
		// 		}
		// 	})
		// }
	})
}


module.exports = {
	getUserInfo: getUserInfo
}
