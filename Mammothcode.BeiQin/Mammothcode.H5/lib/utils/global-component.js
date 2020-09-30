import YLoading from '@/components/base/loading'
import home from '@/components/base/home'
import lazyImg from '@/components/base/lazyImg'
import list from '@/components/base/list'

export default {
	install(Vue) {
		// 注册loading
		Vue.component('y-loading', YLoading)
		// 注册home
		Vue.component('home', home)
		// 注册图片组件
		Vue.component('lazyImg', lazyImg)
		// 注册列表状态组件
		Vue.component('list', list)
	}
}