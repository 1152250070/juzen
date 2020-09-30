// 获取当前页面名称
export const getCurrentPageName = () => {
	let pages = getCurrentPages()
	let curPage = pages[pages.length - 1]
	return curPage.route
}

// 获取全部更新信息
const _getNavigateInfoList = function() {
	return JSON.parse(JSON.stringify(this.$store.state.user.navigateInfoList || []))
}

// 提取当前页面更新信息
export const getNavigateInfo = function() {
	let pageName = getCurrentPageName()
	let navigateInfoList = _getNavigateInfoList.call(this)
	let index = navigateInfoList.findIndex(item => item.page === pageName)
	if (~index) {
		return navigateInfoList[index]
	} else {
		return null
	}
}

// 清除更新信息
export const removeNavigateInfo = function() {
	let pageName = getCurrentPageName()
	let navigateInfoList = _getNavigateInfoList.call(this)
	let index = navigateInfoList.findIndex(item => item.page === pageName)
	if (~index) {
		navigateInfoList.splice(index, 1)
		this.$store.commit('updateNavigateList', navigateInfoList)
	}
}

// 设置更新信息 请用call调用
export const setNavigateInfo = function(pageName, options) {
	let navigateInfoList = _getNavigateInfoList.call(this)
	navigateInfoList.push({
		page: pageName,
		options
	})
	this.$store.commit('updateNavigateList', navigateInfoList)
}

export const applyNavigateInfo = function() {
	let navigateInfo = getNavigateInfo.call(this)
	if (navigateInfo) {
		removeNavigateInfo.call(this)
		let url = navigateInfo.options.url + '?'
		const query = navigateInfo.options.query || {}
		for (const k in query) {
			url += `${k}=${query[k]}&`
		}
		setTimeout(() => {
			uni.navigateTo({
				url
			})
		}, 200)
	}
}

function navBack() {
	if (getCurrentPages().length > 1) {
		uni.navigateBack({
			delta: 1
		})
	} else {
		uni.navigateTo({
			url: '/pages/index/index'
		})
	}
}

module.exports = {
	setNavigateInfo,
	applyNavigateInfo,
	navBack
}