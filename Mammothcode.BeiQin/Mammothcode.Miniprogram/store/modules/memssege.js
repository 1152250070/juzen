const state = {
	memssegeInfo: null //消息信息
}
const mutations = {
	updateMemssegeInfo(state, newVal) {
		if( newVal > 0 ){
			uni.showTabBarRedDot({index: 1})
			uni.setTabBarBadge({
				index: 1,
				text: newVal.toString()
			})
		}else{
			uni.hideTabBarRedDot({index: 1})
		}
		state.memssegeInfo = newVal
	}
}

export default {
	state,
	mutations
}
