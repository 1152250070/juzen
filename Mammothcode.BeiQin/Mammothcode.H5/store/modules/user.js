const state = {
	userData: {}, // 用户数据
    userLocation: { address: '宁波 江北区' }, // 用户定位
    expect: null,
    work: null,
    edutcation: null,
    positionMenuIdTwe: null,
    certificate: null,
    topic: null,
    city: {
        cityConfigId: null,
        cityCode: null,
        cityName: '全部'
    },
    sortParams: null,
    sortText: null,
    postContent: null
}

const mutations = {
	updateUserData(state, info) {
		state.userData = info
	},
	'UPDATE_USER_LOCATION'(state, info) {
		state.userLocation = info
	},
    updateExpect(state, info) {
		state.expect = info
    },
    updateWork(state, info) {
		state.work = info
    },
    updateEdutcation(state, info) {
		state.edutcation = info
    },
    updatePositionMenuIdTwe(state, info) {
		state.positionMenuIdTwe = info
    },
    updateCertificate(state, info) {
		state.certificate = info
    },
    updateTopic(state, info) {
		state.topic = info
    },
    updateCity(state, info) {
		state.city = info
    },
    updateSortParams(state, info) {
		state.sortParams = info
    },
    updateSortText(state, info) {
		state.sortText = info
    },
    updatePostContent(state, info) {
		state.postContent = info
    },
}

export default {
	state,
	mutations
}
