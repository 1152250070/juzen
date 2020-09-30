const state = {
	config: { } // 配置信息
}

const mutations = {
	updateConfig(state, newVal) {
		state.config = newVal
	}
}

export default {
	state,
	mutations
}
