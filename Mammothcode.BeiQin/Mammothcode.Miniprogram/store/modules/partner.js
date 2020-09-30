const state = {
	userData: null, // 合伙人数据
	orderInfo: null, // 订单详情跳转存储信息
	servicerInfo: null // 服务人员信息
}

const mutations = {
	updatePartnerOrderInfo(state, newVal) {
		state.orderInfo = newVal
	},
	updateServicerInfo(state, newVal) {
		state.servicerInfo = newVal
	},
	updatePartnerData(state, newVal) {
		state.userData = newVal
	}
}

export default {
	state,
	mutations
}