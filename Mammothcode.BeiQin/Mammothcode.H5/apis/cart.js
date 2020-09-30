import {
	AddGoodsToCartAjax,
	UpdateGoodsCartNumAjax,
	UpdateGoodsCartAjax,
	DeleteGoodsCartAjax,
	GetGoodsCartListAjax
} from '@/apis/api.js'

const addGoodsToCart = (data) => {
	return AddGoodsToCartAjax(data)
}

const updateGoodsCart = (data) => {
	return UpdateGoodsCartAjax(data)
}

const updateGoodsCartNum = (data) => {
	return UpdateGoodsCartNumAjax(data)
}

const deleteGoodsCart = (data) => {
	return DeleteGoodsCartAjax(data)
}

const getGoodsCartList = (data) => {
	return new Promise(async resolve => {
		const result = await GetGoodsCartListAjax(data, {
			noError: true
		})
		if (result.data.result) {
			resolve(result.data.data)
		} else {
			resolve([])
		}
	})
}

module.exports = {
	addGoodsToCart,
	updateGoodsCartNum,
	updateGoodsCart,
	deleteGoodsCart,
	getGoodsCartList
}