import Request from './utils/request.js'

// const ajaxUrl = 'http://localhost:58179/'
// const imgUrl = 'http://localhost:58179/'
const ajaxUrl = 'https://yuekeapi.juzhentech.com/'
const imgUrl = 'https://yuekeapi.juzhentech.com/'

let request = new Request({
	name: 'api',
	baseUrl: ajaxUrl,
	freeUrls: ['api/Member/GetMember','api/Member/GetMemCourseList','api/Course/GetCourseScheduleList','api/Product/GetProductType','api/Product/TakeProductGoods','api/ShoppingCart/MyShoppingCartNew','api/Member/GetMemMemssegeIsReadCount']
})

let token = request.token

// 图片上传
const UploadImgAjax = (path, {
    basePath
} = {
    basePath: 'api/upload/file'
}) => {
    return new Promise((resolve, reject) => {
        uni.uploadFile({
            url: ajaxUrl + basePath,
            name: 'file',
            filePath: path,
            formData: {
                path: 'uploadfile',
                file: path
            },
            success: function (res) {
                // 上传成功 处理数据
                resolve(res.data)
            },
            fail: function (res) {
                reject(res)
            }
        })
    })
}

// === 用户模块 === //

const RegisterAjax = (data, config) => {
	return request.post('api/Member/MemberRegister', data, config)
}

const GetInfoAjax = (data, config) => {
	return request.post('api/Member/GetMember', data, config)
}

const UpdInfoAjax = (data, config) => {
	return request.post('api/Member/UpdMemberInfo', data, config)
}
const GetMemberMobileAjax = (data, config) => {
	return request.post('api/Member/GetMemberMobile', data, config)
}
//发起支付
const RechargeCashAjax = (data, config) => {
	return request.post('api/Member/RechargeCash', data, config)
}

//充值记录
const GetTransferLogAjax = (data, config) => {
	return request.post('api/Member/GetTransferLog', data, config)
}

// 获取登录验证码
const SendMemberVerificationCodeAjax = (data, config) => {
	return request.post('api/Member/SendMobileMessage', data, config)
}
const GetMemberShopInfoAjax = (data, config) => {
	return request.post('api/Member/GetMemberShopInfo', data, config)
}

//用户消息
const GetMemMemssegeList = (data, config) => { //获取用户消息
	return request.post('api/Member/GetMemMemssegeList', data, config)
}
const GetMemMemssegeIsReadCount = (data, config) => { //获取用户未读消息角标
	return request.post('api/Member/GetMemMemssegeIsReadCount', data, config)
}
const GetMemMemssegeReadCount = (data, config) => { //获取用户未读消息角标
	return request.post('api/Member/GetMemMemssegeReadCount', data, config)
}
const GetMemMemssegeSingle = (data, config) => { //获取用户消息详情，把当前消息设置成已读
	return request.post('api/Member/GetMemMemssegeSingle', data, config)
}
const SetAllMemMemssege = (data, config) => { //全部消息设置成已读
	return request.post('api/Member/SetAllMemMemssege', data, config)
}

const GetCourseOrderList = (data, config) => { //获取课程包列表
	return request.post('api/Member/GetCourseOrderList', data, config)
}
const GetMemCourseList = (data, config) => { //获取我的课程
	return request.post('api/Member/GetMemCourseList', data, config)
}
const GetMemCourseDetails = (data, config) => { //获取我的课程
	return request.post('api/Member/GetMemCourseDetails', data, config)
}


//用户意见反馈
const SendSuggestionAjax = (data, config) => {
	return request.post('api/Product/SendSuggestion', data, config)
}
   

// === Common === //

// 广告
const GetAdvertiseListAjax = (data, config) => {
	return request.post('api/Product/GetAdvertiseList', data, config)
}
const GetScrollNoticeListAjax = (data, config) => {
	return request.post('api/AppConfig/GetScrollBar', data, config)
}


// 商品列表
const GetTopGoodsSearchListAjax = (data, config) => {
	return request.post('api/Product/GetTopGoodsSearchList', data, config)
}
const IsShowPriceAreaPartnerAjax = (data, config) => {
	return request.post('api/Partner/IsShowPriceAreaPartner', data, config)
}
const GetProductTypeAjax = (data, config) => {
	return request.post('api/Product/GetFoodMenuList', data, config)
}
const GetFoodGoodListAjax = (data, config) => {
	return request.post('api/Product/GetFoodGoodList', data, config)
}
const GetProductGoodsAjax = (data, config) => {
	return request.post('api/Product/GetProductGoods', data, config)
}
const TakeProductGoodsAjax = (data, config) => {
	return request.post('api/Product/TakeProductGoods', data, config)
}
const TakeRecommandAjax = (data, config) => {
	return request.post('api/Product/TakeRecommand', data, config)
}
const GetProductGoodsDetailAjax = (data, config) => {
	return request.post('api/Product/GetFoodGoodDetail', data, config)
}
const GetGoodsSkuAjax = (data, config) => {
	return request.post('api/Product/GetGoodsSku', data, config)
}
//属性名
const GetAttributeConfigAjax = (data, config) => {
	return request.post('api/Product/GetAttributeConfig', data, config)
}
//属性值
const GetGoodsAttributeAjax = (data, config) => {
	return request.post('api/Product/GetGoodsAttribute', data, config)
}

//课程
const GetCourseTypeList = (data, config) => { //获取课程类别
	return request.post('api/Course/GetCourseTypeList', data, config)
}
const GetCourseScheduleList = (data, config) => { //获取预约课表
	return request.post('api/Course/GetCourseScheduleList', data, config)
}
const AdvanceClass = (data, config) => { //预约课程时间
	return request.post('api/Course/AdvanceClass', data, config)
}
const LineUpAdvanceClass = (data, config) => { //排队预约课程时间
	return request.post('api/Course/LineUpAdvanceClass', data, config)
}
const CancelAdvanceClass = (data, config) => { //取消预约课程时间
	return request.post('api/Course/CancelAdvanceClass', data, config)
}
const AskForLeaveClass = (data, config) => { //请假预约课程时间
	return request.post('api/Course/AskForLeaveClass', data, config)
}

//余额/积分
const GetRechargeConfigAjax = (data, config) => {
	return request.post('api/Member/GetRechargeConfig', data, config)
}


//我的订单
const IsCanOrderAjax = (data, config) => {
	return request.post('api/Order/IsCanOrder', data, config)
}
const MyOrderAjax = (data, config) => {
	return request.post('api/Order/GetMyOrder', data, config)
}
const GetNewMyOrderAjax = (data, config) => {
	return request.post('api/Order/GetNewMyOrder', data, config)
}
const AddGoodsToCartAjax = (data, config) => {
	return request.post('api/Order/AddGoodsToCart', data, config)
}
const UpdateGoodsCartNumAjax = (data, config) => {
	return request.post('api/Order/UpdateGoodsCartNum', data, config)
}
const DeleteGoodsCartAjax = (data, config) => {
	return request.post('api/Order/DeleteGoodsCart', data, config)
}
const GetGoodsCartListAjax = (data, config) => {
	return request.post('api/Order/GetGoodsCartList', data, config)
}
const GetGoodsCartCountAjax = (data, config) => {
	return request.post('api/Order/GetGoodsCartCount', data, config)
}
const CountOrderAjax = (data, config) => {
	return request.post('api/MemberOrder/CountOrder', data, config)
}
const IsOrderCanBuyByPartnerAjax = (data, config) => {
	return request.post('api/MemberOrder/IsOrderCanBuyByPartner', data, config)
}
const ConfirmDeliverAjax = (data, config) => {
	return request.post('api/MemberOrder/ConfirmDeliver', data, config)
}
const CancelOrderAjax = (data, config) => {
	return request.post('api/MemberOrder/CancelOrder', data, config)
}
const GetScoreConfigAjax = (data, config) => {
	return request.post('api/AppConfig/GetScoreConfig', data, config)
}

const GetCreateOrderAllFeeAjax = (data, config) => {
	return request.post('api/Order/GetCreateOrderAllFee', data, config)
}
const CreateOrderAjax = (data, config) => {
	return request.post('api/Order/CreateOrder', data, config)
}
const InitiatePayAjax = (data, config) => {
	return request.post('api/Order/InitiatePayOrder', data, config)
}

const MyShoppingLogAjax = (data, config) => {
	return request.post('api/Member/MyShoppingLog', data, config)
}


// // 系统配置
const GetSystemConfigAjax = (data, config) => {
	return request.post('api/Config/GetCompanySingle', data, config)
}
const GetBaiduMapAkAjax = (data, config) => {
	return request.post('api/AppConfig/GetBaiduMapAk', data, config)
}
// const GetAppConfigAjax = (data, config) => {
// 	return request.post('api/Collect/MyCollect', data, config)
// }

module.exports = {
	// 用户注册
	RegisterAjax,
	GetInfoAjax,
	UpdInfoAjax,
	GetMemberMobileAjax,
	RechargeCashAjax,
	GetTransferLogAjax,
	SendMemberVerificationCodeAjax,
	GetMemberShopInfoAjax,
	SendSuggestionAjax,
	GetMemMemssegeList,
	GetMemMemssegeIsReadCount,
	GetMemMemssegeReadCount,
	GetMemMemssegeSingle,
	SetAllMemMemssege,
	GetCourseOrderList,
	GetMemCourseList,
	GetMemCourseDetails,
	// 轮播
	GetAdvertiseListAjax,
	GetScrollNoticeListAjax,
	GetSystemConfigAjax,
	GetBaiduMapAkAjax,
	
	// 商品列表
	GetTopGoodsSearchListAjax,
	IsShowPriceAreaPartnerAjax,
	GetProductTypeAjax,
	GetFoodGoodListAjax,
	GetProductGoodsAjax,
	TakeProductGoodsAjax,
	TakeRecommandAjax,
	GetProductGoodsDetailAjax,
	GetGoodsSkuAjax,
	GetAttributeConfigAjax,
	GetGoodsAttributeAjax,
	GetRechargeConfigAjax,
	
	//课程
	GetCourseTypeList,
	GetCourseScheduleList,
	AdvanceClass,
	LineUpAdvanceClass,
	CancelAdvanceClass,
	AskForLeaveClass,
	
	// 我的订单
	IsCanOrderAjax,
	MyOrderAjax,
	GetNewMyOrderAjax,
	AddGoodsToCartAjax,
	UpdateGoodsCartNumAjax,
	DeleteGoodsCartAjax,
	GetGoodsCartListAjax,
	GetGoodsCartCountAjax,
	CountOrderAjax,
	IsOrderCanBuyByPartnerAjax,
	ConfirmDeliverAjax,
	CancelOrderAjax,
	GetScoreConfigAjax,
	GetCreateOrderAllFeeAjax,
	CreateOrderAjax,
	MyShoppingLogAjax,
	// 发起支付
	InitiatePayAjax,

	UploadImgAjax,
	ajaxUrl,
	imgUrl,
	token
}
