const state = {
	cartList: null // 购物车数据
}

const mutations = {
	'UPDATE_CART_LIST'(state, cartList) {
		state.cartList = cartList
	},
	'UPDATE_CART_COUNT'(state, cartCount) {
		const index = 2
		if (cartCount) {
			uni.showTabBarRedDot({
				index
			})
			uni.setTabBarBadge({
				index,
				text: cartCount > 999 ? '999+' : cartCount.toString()
			})
		} else {
			uni.removeTabBarBadge({
				index
			})
			uni.hideTabBarRedDot({
				index
			})
		}
	}
}

export default {
	state,
	mutations
}
