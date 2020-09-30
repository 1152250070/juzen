import {
	GetSysConfig
} from './api'

// 获取配置
function getConfig() {
	return GetSysConfig({})
}

module.exports = {
	getConfig: getConfig
}
