import Vue from 'vue'

import Cookies from 'js-cookie'

import Element from 'element-ui'
import '@/styles/element-variables.scss'
import '@/styles/index.scss' // global css

// Vue 地图
import VueAMap from 'vue-amap'
Vue.use(VueAMap)

VueAMap.initAMapApiLoader({
  key: '25eba91c9a274cfd7c767aabb1f4715d',
  plugin: [
    'AMap.Geolocation' // 定位控件，用来获取和展示用户主机所在的经纬度位置
  ],
  v: '1.4.4'
})

// swiper
import VueAwesomeSwiper from 'vue-awesome-swiper'
import 'swiper/dist/css/swiper.css'

Vue.use(VueAwesomeSwiper)

import App from './App'
import store from './store'
import router from './router'

import '@/frame/icons' // icon
import './permission' // permission control
import './utils/error-log' // error log

import { install as extend } from '@/frame/extend'
extend(Vue)

Vue.use(Element, {
  size: Cookies.get('size') || 'medium' // set element-ui default size
})

Vue.config.productionTip = false

new Vue({
  el: '#app',
  router,
  store,
  render: h => h(App)
})
