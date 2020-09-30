import Request from './utils/request.js'
// 请求地址
// const ajaxUrl = 'http://47.94.59.37:7478/'
const ajaxUrl = 'https://ezhangouapi.juzhentech.com/'
// const imgUrl = 'http://47.94.59.37:6059/'

let request = new Request({
	name: 'api-partner',
	baseUrl: ajaxUrl,
	freeUrls: ['api/Member/GetInfo', 'api/Product/GetGeneralGoodsList']
})

let token = request.token
const GetOwnOrdersAjax = (data, config) => {
	return request.post('api/Partner/GetOwnOrders', data, config)
}

const GetOwnClientAjax = (data, config) => {
	return request.post('api/Partner/GetOwnClient', data, config)
}
const ConfirmOrderAjax = (data, config) => {
	return request.post('api/MemberOrder/ConfirmOrder', data, config)
}
const CancelOrderByPartnersAjax = (data, config) => {
	return request.post('api/MemberOrder/CancelOrderByPartners', data, config)
}
const DeliverOrderByPartnersAjax = (data, config) => {
	return request.post('api/MemberOrder/DeliverOrderByPartners', data, config)
}

const GetOwnCountOrdersAjax = (data, config) => {
	return request.post('api/Partner/GetOwnCountOrders', data, config)
}
const GetOwnDataStatisticsAjax = (data, config) => {
	return request.post('api/Partner/GetOwnDataStatistics', data, config)
}
const GetTransferLogPartnerAjax = (data, config) => {
	return request.post('api/Member/GetTransferLogPartner', data, config)
}
const CountTransferLogPartnerAjax = (data, config) => {
	return request.post('api/Member/CountTransferLogPartner', data, config)
}

const DeliverOrderAjax = (data, config) => {
	return request.post('api/Partner/DeliverOrder', data, config)
}

const ConfirmPayAjax = (data, config) => {
	return request.post('api/Partner/ConfirmPay', data, config)
}

export {
	GetOwnOrdersAjax,
	GetOwnClientAjax,
	ConfirmOrderAjax,
	CancelOrderByPartnersAjax,
	DeliverOrderByPartnersAjax,
	
	GetOwnCountOrdersAjax,
	GetOwnDataStatisticsAjax,
	GetTransferLogPartnerAjax,
	CountTransferLogPartnerAjax,
// 	GetOrderCountByDayAjax,
// 	GetOrderCountByMonthAjax,
// 	GetOrderCountByYearAjax,
	DeliverOrderAjax,
	ConfirmPayAjax,
	
	ajaxUrl,
	token
}
