/* 小程序页面方法 */

import { imgUrl } from '@/apis/api'
export default {
	/* 基础分享 */
	onShareAppMessage() {
		if (!this.hasShare) {
			let path = ''
			let pages = getCurrentPages()
			let page = pages[pages.length - 1]
			if (this.toIndex) {
				path = 'pages/index/index?'
			} else {
				path =  page.route + '?'
			}
			let params = page.options || {}
			let userData = this.$store.state.user.userData
			if (userData && userData.id) {
				params.pId = userData.id
			}
			for (let k in params) {
				path += `${k}=${encodeURIComponent(params[k])}&`
			}
			path = path.substr(0, path.length - 1)
			
			let config = this.$store.state.config.config
			return {
				path: path,
				imageUrl: config ? config.shareImg : '',
				title: config ? config.shareTitle : ''
			}
		}
	}
}