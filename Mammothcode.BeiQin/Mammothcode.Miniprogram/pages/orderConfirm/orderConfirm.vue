<template>
	<view class="container">
		<view v-if="orderAllFee.noTakeMealsFee > 0" class="alert mb-20">
			由于您上次未取餐，本次下单需再支付{{orderAllFee.noTakeMealsFee || 0}}元。
		</view>
		<view class="order-list">
			<view class="order-top flex c-center">
				<label class="fg1" for="">是否需要米饭</label>
				<switch class='fs0' color="#5EA9FF" :checked="riceType != 0? 'checked' : ''" @change="handleSwitchRice" />
			</view>
			<view class="flex c-center">
				<view :class="['style', 'flex', 'flex-between',riceType === 1? 'active' : '']" @click="handleChangeRiceType(1)">
					{{config.riceSmallName || ''}}
					<view>
						¥{{config.riceSmallFee || 0}}
					</view>
				</view>
				<view class="count-wrap flex">
					<image class="good-avatar fs0" @click="handleUpdateSpecCount(riceNum1,-1,1)" src="../../static/img/icon_minus.png"></image>
					<view style="width: 60rpx;text-align: center;">{{riceNum1 || 1}}</view>
					<image class="good-avatar fs0" @click="handleUpdateSpecCount(riceNum1,1,1)" src="../../static/img/icon_add.png"></image>
				</view>
			</view>
			<view class="flex c-center">
				<view :class="['style', 'flex', 'flex-between',riceType === 2? 'active' : '']" @click="handleChangeRiceType(2)">
					{{config.riceCentreName || ''}}
					<view class="">
						¥{{config.riceCentreFee || 0}}
					</view>
				</view>
				<view class="count-wrap flex">
					<image class="good-avatar fs0" @click="handleUpdateSpecCount(riceNum2,-1,2)" src="../../static/img/icon_minus.png"></image>
					<view style="width: 60rpx;text-align: center;">{{riceNum2 || 1}}</view>
					<image class="good-avatar fs0" @click="handleUpdateSpecCount(riceNum2,1,2)" src="../../static/img/icon_add.png"></image>
				</view>
			</view>
			<view class="flex c-center">
				<view :class="['style', 'flex', 'flex-between',riceType === 3? 'active' : '']" @click="handleChangeRiceType(3)">
					{{config.riceBigName || ''}}
					<view class="">
						¥{{config.riceBigFee || 0}}
					</view>
				</view>
				<view class="count-wrap flex">
					<image class="good-avatar fs0" @click="handleUpdateSpecCount(riceNum3,-1,3)" src="../../static/img/icon_minus.png"></image>
					<view style="width: 60rpx;text-align: center;">{{riceNum3 || 1}}</view>
					<image class="good-avatar fs0" @click="handleUpdateSpecCount(riceNum3,1,3)" src="../../static/img/icon_add.png"></image>
				</view>
			</view>
		</view>
		<view class="order-list">
			<view class="cart-wrap" v-for="(item,index) in orderGoodsList" :key="index">
			    <view class="good-info flex">
			        <image class="good-avatar fs0" :src="item.goodsImg" />
			        <view class="good-name text-hidden fg1">
			            <text>{{item.goodsName || ''}}</text>
			            <!-- <view class="good-specs">规格：{{item.goodsAttrName || ''}}</view> -->
			            <view class="count-num">¥{{item.goodsPrice || ''}}</view>
			            <view class="good-price">x{{item.count || 0}}</view>
			        </view>
			    </view>
			</view>
			
			<!-- <view class="order-top flex c-center" style="border-top: 1px solid #F5F5F5;">
				<label class="fg1" for="">补贴{{orderType == 0? config.breakfastSubsidy:orderType == 1? config.lunchSubsidy:orderType == 2? config.dinnerSubsidy:orderType == 3? config.midnightSubsidy:0}}元</label>
				<switch class='fs0' color="#5EA9FF" @change="handleSwitchCanBu" />
			</view> -->
			<view class="specs-item flex flex-between" style="border-top: 1px solid #F5F5F5;padding-top: 20rpx;">
				<view class="">
					补贴
				</view>
				<view class="">
					-¥{{orderType == 0? config.breakfastSubsidy:orderType == 1? config.lunchSubsidy:orderType == 2? config.dinnerSubsidy:orderType == 3? config.midnightSubsidy:0}}
				</view>
			</view>
			
			<view v-if="!riceType" class="specs-item flex flex-between">
				<view class="">
					不需要米饭
				</view>
			</view>
			<view v-if="riceType" class="specs-item flex flex-between">
				<view class="">
					米饭{{riceType == 1? '小':riceType == 2? '中':riceType == 3? '大':''}}份 x{{riceNum || 0}}
				</view>
				<view class="">
					¥{{orderAllFee.riceFee || 0}}
				</view>
			</view>
			<view v-if="orderAllFee.platePunishFee > 0" class="specs-item flex flex-between">
				<view class="">
					餐盘不干净惩罚
				</view>
				<view class="">
					¥{{orderAllFee.platePunishFee || 0}}
				</view>
			</view>
			<view v-if="orderAllFee.noTakeMealsFee > 0" class="specs-item flex flex-between">
				<view class="">
					未取餐罚款
				</view>
				<view class="">
					¥{{orderAllFee.noTakeMealsFee || 0}}
				</view>
			</view>
			<view class="price-item flex flex-between">
				<view class="">
					总计
				</view>
				<view class="">
					¥{{orderAllFee.payFee || 0}}
				</view>
			</view>
		</view>

		<!-- <view class="order-list flex c-center mb-20" style="padding: 30rpx 20rpx;">
			<label class="fg1" for="">取餐时间</label>
			<picker class="" mode="time" :value="timeValue" @change="bindTimeChange">
				<text class='fs0 mr-20'>{{timeValue || '请选择取餐时间'}}</text>
				<uni-icon class='right-arrow fs0'></uni-icon>
			</picker>
		</view> -->
		
		<view class="order-list pay-wrap">
			<view class="pay-title">
				支付方式
			</view>
			<view class="pay-item flex" @click="orderAllFee.payFee>0? payWay = 0 : ''">
				<image class="item-img" src="../../static/img/icon_wechatpay.png" />
				<view class="fg1">
					微信支付
				</view>
				<uni-icon
				class='ic-radio fs0'
				:class="[payWay === 0 ? 'active' : '']" ></uni-icon>
			</view>
			<view class="pay-item flex" @click="payWay = 1">
				<image class="item-img" src="../../static/img/icon_pay.png" />
				<view class="fg1">
					余额支付（余额¥{{userData.balanceCash}}）
				</view>
				<uni-icon
				class='ic-radio fs0'
				:class="[payWay === 1 ? 'active' : '']"></uni-icon>
			</view>
		</view>
		
		<!-- 结算栏 -->
		<view class="tools-bar flex c-center">
			<view class="total-info flex c-center fg1">
				<view class="total-fee">
					<view class="text2" style="font-size: 40rpx;">¥{{orderAllFee.payFee || 0}}</view>
				</view>
			</view>
			<view class="tools-bar-btn fs0" @click="handleToConfirmOrder">
				结算
			</view> 
		</view>
		
		<view class="h30"></view>
		<YLoading ref='loading'></YLoading>
		<home></home>
	</view>
</template>

<script>
import {
	GetCreateOrderAllFeeAjax,
	CreateOrderAjax,
	InitiatePayAjax,
} from '@/apis/api.js'
import {wxUtils} from '@/lib/utils/util.js'
export default {
	computed: {
		// productCount() {
		// 	return this.orderGoodsList.reduce((start, item) => {
		// 		return start * 1 + item.purchaseQuantity * item.productSinglePrice
		// 	}, 0)
		// },
	},
	data() {
		return {
			userData: {}, // 用户数据
			orderGoodsList: [], // 订单商品信息
			config: {}, // 配置
			payWay: 0,
			// timeValue: '',
			orderType: null,
			isRice: 1,
			riceType: 1,
			riceNum: 1,
			riceNum1: 1,
			riceNum2: 1,
			riceNum3: 1,
			orderAllFee: null,
			orderId: null
		}
	},
	onLoad(options) {
		this.orderType = options.orderType
		this.ySetUserData()
		this.init()
		this.getOrderInfo()
	},
	onShow() {
		this.getUserData()
		this.getConfig()
		this.getCreateOrderAllFee()
	},
	methods: {
		init(){
		},
		// 获取用户数据
		async getUserData() {
			this.userData = await this.$store.dispatch('getUserData')
		},
		async getConfig() {
			this.config = await this.$store.dispatch('getConfig')
		},
		handleChangeRiceType(type){
			this.riceType = type
			if (type == 1) {
				this.riceNum = this.riceNum1
			}
			if (type == 2) {
				this.riceNum = this.riceNum2
			}
			if (type == 3) {
				this.riceNum = this.riceNum3
			}
			this.getCreateOrderAllFee()
		},
		async getCreateOrderAllFee(){
			let orderGoodsList = this.orderGoodsList
			let isRice = this.riceType
			let riceNum = this.riceNum
			this.orderAllFee = await GetCreateOrderAllFeeAjax({
				orderType: this.orderType,
				goodsList: orderGoodsList,
				isRice: isRice,
				riceNum: riceNum,
				token: true
			})
			if(this.orderAllFee.payFee === 0){
				this.payWay = 1
			} else {
				this.payWay = 0
			}
		},
		// 提交订单
		handleToConfirmOrder() {
			// 检查数据
			let orderType = this.orderType
			let orderGoodsList = this.orderGoodsList
			let isRice = this.riceType
			let riceNum = this.riceNum
			let payWay = this.payWay

			uni.showModal({
				title: '是否确定提交订单？',
				success: res => {
					if (!res.confirm) {
						return false
					}
					
					let orderParams = {
						orderType: orderType,
						goodsList: orderGoodsList,
						isRice: isRice,
						riceNum: riceNum,
						token: true,
						payType: payWay,
					}
					this.doCreateOrder(orderParams)
				}
			})
		},
		// 创建订单
		async doCreateOrder(data) {
			this.showPageLoading()
			let payType = this.payWay
			if (payType == 1) {
				// 查询订单金额 余额不足阻止支付
				if (this.userData.balanceCash < this.orderAllFee.payFee) {
					// 余额不足
					uni.showToast({
						title: '余额不足',
						icon: 'none'
					})
					this.hidePageLoading()
					return false
				}
			}
			// 单商品创建订单
				this.orderId = await CreateOrderAjax(data)
			// 生成支付参数
			let payMentData = {
				token: true,
				id: this.orderId.id,
				payType: payType
			}
			// 调用支付
			try{
				let payData = await InitiatePayAjax(payMentData)
				if(payType==0){
					// 微信支付
					let payResult = await wxUtils.doPayMemt(payData)
					this.hidePageLoading()
					if (payResult.isPay) {
						this.doPaySuccess()
					} else {
						uni.redirectTo({
							url: '/pages/myCourseList/myCourseList'
						})
					}
				}else {
					// 不是微信支付
					this.doPaySuccess()
				}
			} catch(e){
			}
		},
		doPaySuccess() {
			this.hidePageLoading()
			// 支付完成
			uni.showToast({
				title: '支付成功',
				mask: true
			})
			setTimeout(() => {
				uni.redirectTo({
					url: '/pages/purchaseSuccess/purchaseSuccess'
				})
				
			}, 1000)
		},
		// 获取订单详情
		getOrderInfo() {
			let tmpOrderInfo = this.$store.state.user.tmpOrderInfo
			this.orderGoodsList = this.cloneObj(tmpOrderInfo)
			console.log(this.orderGoodsList)
		},
		// 是否米饭
		handleSwitchRice(e) {
			this.riceType = e.detail.value ? 1 : 0
			this.getCreateOrderAllFee()
		},
		// 是否补贴
		handleSwitchCanBu(e) {
			this.isCanBu = e.detail.value
			this.getCreateOrderAllFee()
		},
		bindTimeChange: function(e) {
			this.timeValue = e.target.value
		},
		// 修改购买数量
		handleUpdateSpecCount(riceNum,count,type) {
			console.log(riceNum);
			let riceType = this.riceType
			let newCount = riceNum * 1 + count * 1
			if (this.riceType != type || newCount == 0) {
				return false
			}
			if (newCount >=1 && type == 1) {
				this.riceNum1 = newCount
			}
			if (newCount >=1 && type == 2) {
				this.riceNum2 = newCount
			}
			if (newCount >=1 && type == 3) {
				this.riceNum3 = newCount
			}
			this.riceNum = newCount
			this.getCreateOrderAllFee()
		}
	}
}
</script>

<style lang="scss" scoped>
@import "../../style/business/order-confirm.scss";
.ic-radio.active {
	background-color: #5584FF;
}
.alert{
	padding: 0 20upx;
	line-height: 68upx;
	color: #FFFFFF;
	background-color: #FF725F;
	font-size: 24upx;
}
.order-list{
	border-radius:10upx;
	margin: 20upx;
	padding: 0 20upx 10upx;
	.order-top{
		padding: 30upx 0;
		border-bottom: 1px solid #F5F5F5;
		margin-bottom: 10upx;
	}
	.style{
		width:450upx;
		padding: 14upx 30upx;
		background:#ECECEC;
		border-radius:10upx;
		margin: 10upx 20upx 10upx 0;
		font-size: 28upx;
	}
	.style.active{
		background:rgba(94,169,255,1);
		color: #FFFFFF;
	}
	.count-wrap{
		text{
			position: relative;
			top: -10upx;
		}
		image{
			width: 40upx;
			height: 40upx;
		}
	}
	.cart-wrap{
		// margin-bottom:20rpx;
		background: #FFFFFF;
		padding: 20rpx 0 0 0;
		position: relative;
		.good-avatar {
			width: 140rpx;
			height: 140rpx;
			border-radius: 10rpx;
			margin: 0 20rpx 0 0;
			border-radius: 2px;
			border: 1px solid #F5F5F5;
		}
		.good-name {
			font-size: 28upx;
			color: #333333;
		}
		.good-specs {
			font-size: 22upx;
			color: #999999;
		}
		.good-price{
			font-size: 32upx;
			color: #333333;
			margin-top: 28rpx;
		}
		.count-wrap{
			position: absolute;
			right: 0upx;
			bottom: 20upx;
			text{
				position: relative;
				top: -10upx;
			}
			image{
				width: 42upx;
				height: 42upx;
				margin: 0 40upx;
			}
		}
		.count-num{
			position: absolute;
			right: 30rpx;
			bottom: 20rpx;
			font-size: 32upx;
			color: #333333;
			font-weight: 500;
			text{
				position: relative;
				top: -10upx;
			}
		}
	}
	.specs-item{
		color: #999999;
		font-size: 28upx;
		margin: 20upx 0;
	}
	.price-item{
		font-size: 28upx;
		margin-bottom: 14upx;
	}
}
.pay-wrap{
	padding: 20upx 20upx 0;
	.pay-title{
		color: #999999;
	}
	.pay-item{
		padding: 30upx 0;
		border-bottom: 1px solid #F7F7F7;
		.item-img{
			width: 40upx;
			height: 40upx;
			margin-right: 12rpx;
		}
	}
	.pay-item:last-child{
		border-bottom: 0;
	}
}

element.style {
}
.tools-bar{
	z-index: 9;
}
</style>