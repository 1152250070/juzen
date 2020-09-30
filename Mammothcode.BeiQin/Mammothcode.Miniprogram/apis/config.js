import {
	GetSystemConfigAjax
} from './api'

// 获取配置
function getConfig() {
	return GetSystemConfigAjax()
}

module.exports = {
	getConfig: getConfig
}
