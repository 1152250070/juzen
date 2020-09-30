import {
	GetMemMemssegeIsReadCount,
	token
} from './api'

// 获取配置
function getMemssege() {
	return GetMemMemssegeIsReadCount({
		token:true,
        IsRead: false
	})
}

module.exports = {
	getMemssege: getMemssege
}
