const state = {
	worker: null // worker
}

const mutations = {
	updateWorker(state, newVal) {
		state.worker = newVal
	}
}

export default {
	state,
	mutations
}
