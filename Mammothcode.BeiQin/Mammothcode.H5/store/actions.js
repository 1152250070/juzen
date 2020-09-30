import user from '@/apis/user'
import config from '@/apis/config'
import cart from '@/apis/cart.js'
import store from '@/store'
import {
    token,
    CheckLogin
} from '@/apis/api.js'
// 获取用户模型
export const getUserData = ({
	commit
}) => {
	return new Promise((resolve, reject) => {
		user.getUserInfo()
			.then(res => {
				commit('updateUserData', res)
				resolve(Object.assign({}, res))
			})
			.catch(e => {
				console.warn(e)
				resolve()
			})
	})
}

// 获取用户模型
export const checkLogin = ({
	commit
}, _auth) => {
	return new Promise((resolve, reject) => {
        if (_auth) {
            if (!token.value) {
                resolve(true)
                uni.switchTab({
                    url: '/pages/index/index'
                })
                return
            }
            CheckLogin({
                token: true
            })
                .then(res => {
                    result.member.ages = result.ages
                    commit('updateUserData', res.member)
                    resolve(Object.assign({}, res))
                })
                .catch(e => {
                    console.warn(e)
                    resolve()
                })
        }
	})
}

// === ** 项目 action ** === //

export const getConfig = ({
	commit
}) => {
	return new Promise((resolve, reject) => {
		config.getConfig()
		.then(res =>{
			commit('updateConfig', res)
			resolve(Object.assign({}, res))
		})
	})
}

// 购物车相关
export const getGoodsCartList = ({ commit, getters }) => {
	return new Promise(async resolve => {
		if (!token.value) {
			resolve(true)
		}
		let carts = []
		try {
			carts = await cart.getGoodsCartList({
				queryAll: 1,
				token: true
			})			
		} catch(e) {
			console.log(e)
		}
		commit('UPDATE_CART_LIST', carts)
		store.dispatch('updateCartCount')
		resolve(true)
	})
}

export const updateCartCount = ({ commit, getters }) => {
	return new Promise(async resolve => {
		commit('UPDATE_CART_COUNT', getters.cartCount)
		resolve(true)
	})
}


export const deleteGoodsCart = ({ commit }, payload) => {
	return new Promise(async (resolve, reject) => {
		try{
			await cart.deleteGoodsCart(payload)
			await store.dispatch('getGoodsCartList')			
		}catch(e){
			//TODO handle the exception
		}
		resolve(true)
	})
}

// 更新购物车数量
export const updateGoodsCartNum = ({ commit }, payload) => {
	return new Promise(async resolve => {
		try {
			await cart.updateGoodsCartNum(payload)
			await store.dispatch('getGoodsCartList')
		} catch(e) {
			//
		}
		resolve(true)
	})
}

// 更新购物车sku
export const updateGoodsCart = ({ commit }, payload) => {
	return new Promise(async (resolve, reject) => {
		try{
			await cart.updateGoodsCart(payload)
			await store.dispatch('getGoodsCartList')
			resolve(true)
		}catch(e){
			reject()
		}
	})
}

export const addGoodsToCart = ({ commit }, payload) => {
	return new Promise(async resolve => {
		try {
			await cart.addGoodsToCart(payload)
			await store.dispatch('getGoodsCartList')
		} catch(e) {
			//
		}
		resolve(true)
	})
}