import Vue from 'vue'
import App from './App'
import store from './store'
Vue.config.productionTip = false

Vue.prototype.$store = store
// import tabBar from '@/components/business/tui-tabbar/tui-tabbar.vue'
// import consult from '@/components/business/consult/index.vue'
// 组件注册
import globalComponents from '@/lib/extend/global-components.js'
Vue.use(globalComponents)
// Vue.component('tabBar', tabBar)
// Vue.component('consult', consult)
// Vue原型方法扩展
import vueProtoExtend from '@/lib/extend/vueProtoExtend'
Vue.use(vueProtoExtend)

App.mpType = 'app'

import vueStaticData from '@/utils/staticData.js'
Vue.use(vueStaticData)

import checkLogin from '@/mixins/checkLogin.js'
Vue.mixin(checkLogin)

const app = new Vue({
	store,
	...App
})
app.$mount()