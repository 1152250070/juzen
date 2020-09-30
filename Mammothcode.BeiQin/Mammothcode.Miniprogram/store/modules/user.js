const state = {
	userData: null, // 用户数据
	parentId: null, // 推荐人id
	tmpOrderInfo: [], // 跳转确认订单信息
	userSelectAddressInfo: null, // 用户订单确认选择地址
	addressFormInfo: null, // 用户地址
	orderInfo: null, // 订单详情跳转存储信息
	newsInfo: null, // 资讯详情
	updateInfoList: [], // 待更新信息
	payMentOrderInfo: null, // 支付尾款订单信息
	messageInfo: null, // 我的消息
	showText: null, // 首页滚动消息
	storeInfo: null, // 门店信息
	couponInfo: null, // 优惠劵信息
	activeCouponInfo: null // 活动优惠劵信息
}

const mutations = {
	updateUserData(state, newVal) {
		state.userData = newVal
	},
	updateParentId(state, newVal) {
		state.parentId = newVal
	},
	updateUserSelectAddressInfo(state, newVal) {
		state.userSelectAddressInfo = newVal
	},
	updateAddressFormInfo(state, newVal) {
		state.addressFormInfo = newVal
	},
	updateOrderInfo(state, newVal) {
		state.orderInfo = newVal
	},
	updateTmpOrderInfo(state, newVal) {
		state.tmpOrderInfo = newVal
	},
	updateNnewsInfo(state, newVal) {
		state.newsInfo = newVal
	},
	updateInfoList(state, newVal) {
		state.updateInfoList = newVal
	},
	updatePayMentOrderInfo(state, newVal) {
		state.payMentOrderInfo = newVal
	},
	updateMessageInfo(state, newVal) {
		state.messageInfo = newVal
	},
	updateShowText(state, newVal) {
		state.showText = newVal
	},
	updateStoreInfo(state, newVal) {
		state.storeInfo = newVal
	},
	updateCouponInfo(state, newVal) {
		state.couponInfo = newVal
	},
	updateActiveCouponInfo(state, newVal) {
		state.activeCouponInfo = newVal
	}
}

export default {
	state,
	mutations
}
