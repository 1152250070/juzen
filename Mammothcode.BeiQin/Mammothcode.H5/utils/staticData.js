function createEnum(list, num = 0) {
  const obj = {}
  const ret = []
  list.forEach((text, i) => {
    const _num = i + num
    obj[_num] = text
    obj[text] = _num
    ret.push({
      value: _num,
      label: text
    })
  })
  return {
    obj,
    list: ret
  }
}

export default {
	install(Vue) {
		// 客户订单状态
		const STATES = ['交易关闭', '已取消', '待付款', '待发货', '待收货', '待评价', '已完成']
		const statesObj = createEnum(STATES, -2)
		Vue.prototype.yStates = statesObj.obj
		Vue.prototype.yStateList = statesObj.list
		
		// 客户订单状态
		const AFTER_STATES = ['用户售后取消', '售后关闭', '审核不通过', '待审核', '审核通过', '用户已退货', '卖家已收到货', '售后完成']
		const afterstatesObj = createEnum(AFTER_STATES, -3)
		Vue.prototype.yAfterStates = afterstatesObj.obj
		Vue.prototype.yAfterStateList = afterstatesObj.list
		
		// 订单类型
		const ORDER_TYPES = ['普通订单', '预售订单', '拼团订单']
		const typesObj = createEnum(ORDER_TYPES)
		Vue.prototype.yOrderTypes = typesObj.obj
		Vue.prototype.yOrderTypeList = typesObj.list
		
		// 物流类型
		const DELIVERY_TYPES = ['快递发货', '同城配送', '自提']
		const deliveryObj = createEnum(DELIVERY_TYPES)
		Vue.prototype.yDeliveryTypes = deliveryObj.obj
		Vue.prototype.yDeliveryTypeList = deliveryObj.list
		
		// 购买类型
		const BUY_TYPES = ['立即购买', '购物车', '发起拼团', '参加拼团']
		Vue.prototype.buyTypes = createEnum(BUY_TYPES).obj
		
		// 支付类型
		const PAY_TYPES = ['余额支付', '微信支付']
		const paysObj = createEnum(PAY_TYPES)
		Vue.prototype.yPayTypes = paysObj.obj
		Vue.prototype.yPayTypeList = paysObj.list
		
		// filters
		Vue.filter('withZero', (val) => {
			if (val == null) {
				return '0.00'
			}
			return (val * 1).toFixed(2)
		})
		Vue.filter('formatTime', val => {
			if (val === null) {
				return ''
			}
			return val.split(' ')[0]
		})
	}
}