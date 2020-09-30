import YLoading from '@/components/base/page-loading/index.vue'
import ListStatus from '@/components/base/list-status/index.vue'
import BgImg from '@/components/base/BgImg/index.vue'
import safeBottom from '@/components/base/safe-bottom/index.vue'
import CommonHead from '@/components/business/common-head/index.vue'
import CommonInput from '@/components/business/common-input/index.vue'
import VueAMap from 'vue-amap'
import VueLazyload from 'vue-lazyload'

export default {
	install(Vue) {
		// 注册loading
		Vue.component('y-loading', YLoading)
		Vue.component('list-status', ListStatus)
		Vue.component('BgImg', BgImg)
		// 注册列表状态组件
        Vue.component('safe-bottom', safeBottom)
        // 通用头部
        Vue.component('CommonHead', CommonHead)
        // 通用输入框
        Vue.component('CommonInput', CommonInput)
		// map
		Vue.use(VueAMap)
		VueAMap.initAMapApiLoader({
			key: '25eba91c9a274cfd7c767aabb1f4715d',
			plugin: [
				'AMap.Geolocation' // 定位控件，用来获取和展示用户主机所在的经纬度位置
			],
			v: '1.4.4'
		})
		Vue.use(VueLazyload)
	}
}