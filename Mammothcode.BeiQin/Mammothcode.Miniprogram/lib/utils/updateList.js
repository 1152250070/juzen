// 获取当前页面名称
export const getCurrentPageName = () => {
	let pages = getCurrentPages()
	let curPage = pages[pages.length - 1]
	return curPage.route
}

// 获取全部更新信息
const _getUpdateInfoList = function() {
	return JSON.parse(JSON.stringify(this.$store.state.user.updateInfoList || []))
}

// 提取当前页面更新信息
export const getUpdateInfo = function() {
	let pageName = getCurrentPageName()
	let updateInfoList = _getUpdateInfoList.call(this)
	let index = updateInfoList.findIndex(item => item.page === pageName)
	if (~index) {
		return updateInfoList[index]
	} else {
		return null
	}
}

// 清除更新信息
export const removeUpdateInfo = function() {
	let pageName = getCurrentPageName()
	let updateInfoList = _getUpdateInfoList.call(this)
	let index = updateInfoList.findIndex(item => item.page === pageName)
	if (~index) {
		updateInfoList.splice(index, 1)
		this.$store.commit('updateInfoList', updateInfoList)
	}
}

// 设置更新信息 请用call调用
export const setUpdateInfo = function(pageName, filterKeyParams, valueParams) {
	let updateInfoList = _getUpdateInfoList.call(this)
	let index = updateInfoList.findIndex(item => item.page === pageName)
	if (~index) {
		updateInfoList.list.push({
			filterKeyParams,
			valueParams
		})
	} else {
		updateInfoList.push({
			page: pageName,
			list: [
				{
					filterKeyParams,
					valueParams
				}
			]
		})
	}
	this.$store.commit('updateInfoList', updateInfoList)
}

// 应用更新信息 用法 applyUpdateInfo.call(this, list)
export const applyUpdateInfo = function(list) {
	let updateInfo = getUpdateInfo.call(this)
	if (updateInfo) {
		updateInfo.list.forEach(infoItem => {
			let { filterKeyParams, valueParams } = infoItem
			let index = list.findIndex(item => item[filterKeyParams.key] === filterKeyParams.value)
			if (~index) {
				for (let k in valueParams) {
					list[index][k] = valueParams[k]
				}
			}
		})
		// 清除
		removeUpdateInfo.call(this)
	}
}

export default {
	setUpdateInfo,
	applyUpdateInfo
}