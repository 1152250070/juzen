const state = {
	tabBar: [{
			"pagePath": "/pages/index/index",
			"text": "首页",
			"icon": "/static/img/tab/1.png",
			"selectedIcon": "/static/img/tab/1a.png"
		},
		{
			"pagePath": "/pages/consult/index",
			"text": "电话咨询",
			"icon": "/static/img/tab/2.png",
			"selectedIcon": "/static/img/tab/2a.png"
		},
		{
			"pagePath": "/pages/products/index",
			"text": "产品展示",
			"icon": "/static/img/tab/3.png",
			"selectedIcon": "/static/img/tab/3a.png"
		},
		{
			"pagePath": "/pages/contact/contact",
			"text": "联系方式",
			"icon": "/static/img/tab/4.png",
			"selectedIcon": "/static/img/tab/4a.png"
		}
	],
	tabBarIndex: 0
}

const mutations = {
	'changeTabBar'(state, tabBarIndex) {
		state.tabBarIndex = tabBarIndex
	}
}

export default {
	state,
	mutations
}