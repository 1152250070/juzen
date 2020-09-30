// 用户数据
export const userData = state => state.user.userData

export const userLocation = state => state.user.userLocation

export const config = state => state.config.config

// 购物车数量
export const cartCount = state => {
	const cartList = state.cart.cartList
	if (!cartList || cartList.length === 0) {
		return 0
	}
	return state.cart.cartList.reduce((start, good) => {
		return start + good.purchaseQuantity * 1
	}, 0)
}