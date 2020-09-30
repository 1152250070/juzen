import Vue from 'vue'
import App from './App'

import store from './store'

Vue.config.productionTip = false

Vue.prototype.$store = store

// 初始化小程序版本更新代码
import updateManage from '@/lib/init/updateManage'

// 注册loading
import YLoading from '@/components/base/loading'
Vue.component('YLoading', YLoading)

// 注册home
import home from '@/components/base/home'
Vue.component('home', home)

// 注册图片组件
import lazyImg from '@/components/base/lazyImg'
Vue.component('lazyImg', lazyImg)

// 注册列表状态组件
import list from '@/components/base/list'
Vue.component('list', list)

// 小程序Page方法扩展 onShareAppMessage
import pageExtend from '@/lib/extend/pageExtend'
Vue.mixin(pageExtend)

// Vue原型方法扩展
import vueProtoExtend from '@/lib/extend/vueProtoExtend'
Vue.use(vueProtoExtend)
App.mpType = 'app'

const app = new Vue({
    store,
    ...App
})
app.$mount()
