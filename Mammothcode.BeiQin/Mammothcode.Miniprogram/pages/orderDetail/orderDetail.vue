<template>
	<view class="container">
		<view class="status">
			<view class="flex c-center">
				<image v-if="courseInfo.orderStatus == -3" mode="widthFix" class="status-img fs0" src="../../static/img/icon_close.png"></image>
				<image v-if="courseInfo.orderStatus == -2" mode="widthFix" class="status-img fs0" src="../../static/img/icon_leave.png"></image>
				<image v-if="courseInfo.orderStatus == -1" mode="widthFix" class="status-img fs0" src="../../static/img/icon_close.png"></image>
				<image v-if="courseInfo.orderStatus == 0" mode="widthFix" class="status-img fs0" src="../../static/img/icon_waite.png"></image>
				<image v-if="courseInfo.orderStatus == 1" mode="widthFix" class="status-img fs0" src="../../static/img/icon_ready.png"></image>
				<image v-if="courseInfo.orderStatus == 2" mode="widthFix" class="status-img fs0" src="../../static/img/icon_finish.png"></image>
				<view>
					{{ courseInfo.orderStatus == -3? '未签到' : 
					courseInfo.orderStatus == -2? '已请假' : 
					courseInfo.orderStatus == -1? '已取消' : 
					courseInfo.orderStatus == 0? '排队中' : 
					courseInfo.orderStatus == 1? '待上课' : 
					courseInfo.orderStatus == 2? '已记课' : '' }}
				</view>
			</view>
			<view class="tip">
				{{ courseInfo.orderStatus == -3? '由于您未在24小时之前提出取消课程，本次将扣除课程的课时' :
				courseInfo.orderStatus == -2? '已请假，您还有能请假'+courseInfo.remainingClassTime+'次' : 
				courseInfo.orderStatus == -1? '本节课程已取消' : 
				courseInfo.orderStatus == 0? '如在课程开始前24小时未排进会自动取消，您前面还有'+courseInfo.remainingClassTime+'人。' : 
				courseInfo.orderStatus == 1? '距离您上课还有'+ countdown.day+ '天'+ countdown.hour+ '时'+ countdown.min+ '分'+ countdown.sec+ '秒': 
				courseInfo.orderStatus == 2? '本节课时已完成' : '' }}
			</view>
		</view>
		<view class="content-wrap" style="padding: 0;">
			<view class="info-item flex flex-between c-center">
				<view class="info-key">
					课程
				</view>
				<view class="info-value">
					{{ courseInfo.courseName || ''}}
				</view>
			</view>
			<view class="info-item flex flex-between c-center">
				<view class="info-key">
					上课时间
				</view>
				<view class="info-value">
					{{ courseInfo.orderDate || '' }} {{ courseInfo.orderTimeLong || '' }}
				</view>
			</view>
			<view class="info-item flex flex-between c-center">
				<view class="info-key">
					教师
				</view>
				<view class="info-value flex c-center">
					<image mode="widthFix" class="info-img fs0" src="../../static/img/tab/icon_my-in.png"></image>{{ courseInfo.teacherName || ''}}
				</view>
			</view>
			<view class="info-item flex flex-between c-center" style="border: 0;">
				<view class="info-key">
					教室
				</view>
				<view class="info-value">
					{{ courseInfo.className || ''}}
				</view>
			</view>
		</view>
		<view v-if="courseInfo.orderStatus == 0 || courseInfo.orderStatus == 1" class="address-wrap">
			<!-- <image class="address-img fs0" src="../../static/img/map.jpg"></image> -->
			<map class="address-img fs0" style="width: 100%;" :latitude="config.latitude" :longitude="config.longitude" :markers="covers" />
			<view class="address-info">
				<view class="address text-hidden">
					{{ config.companyName || '-' }}
				</view>
				<view class="addressDetail text-hidden">
					{{ config.address || '' }}
				</view>
				<view class="go-btn flex c-center j-center" @click="goHear">
					<image class="go-img fs0" src="../../static/img/plane.png"></image>去这里
				</view>
			</view>
		</view>
		<view class="tools-bar flex c-center">
			<view class="btn-wrap flex flex-between" style="width: 100%">
				<button class="click_btn_active clearButton" open-type='contact'>联系客服</button>
				<view class="">
					<view v-if="courseInfo.orderStatus == 1" class='click_btn' @click="handleCancelOrder">
						取消预约
					</view>
					<view v-if="courseInfo.orderStatus == 1" class='click_btn' @click="handleLeaveOrder" style="margin-left: 20upx;">
						请假
					</view>
					<view v-if="courseInfo.orderStatus == -2" class='click_btn' @click="handleAginOrder">
						重新预约
					</view>
					<view v-if="courseInfo.orderStatus == 0" class='click_btn' @click="handleCancelLineUp">
						取消排队
					</view>
				</view>
			</view>
			
		</view>
		<view class="h30"></view>
		<YLoading ref='loading'></YLoading>
		<home></home>
	</view>
</template>

<script>
import {
	GetMemCourseDetails,
	AskForLeaveClass,
	CancelAdvanceClass,
} from '@/apis/api.js'
import {wxUtils} from '@/lib/utils/util.js'
import {
	getLeftTime
} from '@/lib/utils/dateFormat.js'
export default {
	data() {
		return {
			userData: {}, // 用户数据
			courseInfo: {},
			orderStartTime: null,
			timer: '',
			countdown:{day:'00',hour:'00',min:'00',sec:'00'},
			config: {
				latitude: 39.909,
				longitude: 116.39742
			}, // 配置
			id: 0,
			title: 'map',
			covers: [{
				latitude: 39.909,
				longitude: 116.39742,
				iconPath: '../../static/img/location.png',
				width: 94,
				height: 60
			}]
		}
	},
	onLoad(options) {
		this.id = options.id
		this.config = this.$store.state.config.config
		this.covers[0].latitude = this.config.latitude
		this.covers[0].longitude = this.config.longitude
	},
	onShow() {
		this.getUserData()
		this.GetOrderDetail()
	},
	methods: {
		// 获取用户数据
		async getUserData() {
			this.userData = await this.$store.dispatch('getUserData')
		},
		async GetOrderDetail() {
			let result = await GetMemCourseDetails({
				token: true,
				queryAll: 1,
				MemOrderCourseId:this.id
			})
			this.courseInfo = result
			this.courseInfo.orderDate = this.courseInfo.orderDate?.split(' ')[0]
			this.countDown()
		},
		countDown() {
			let _this=this
			if(_this.courseInfo.orderStartTime){
				let lefttimer = parseInt((new Date(_this.courseInfo.orderStartTime.replace(/-/g,"/")).getTime() - new Date().getTime()));
				if(lefttimer <= 0){
					_this.countdown = {day: '00',hour: '00',min: '00',sec: '00'}
					clearInterval(_this.timer);
					return false
				}
				_this.timer = setInterval(function(){
					let d = parseInt(lefttimer/1000/3600/24)
					let h = parseInt(lefttimer/1000/3600%24)
					let m = parseInt(lefttimer/1000/60%60)
					let s = parseInt(lefttimer/1000%60)
					d = d < 10?'0' + d : d
					h = h < 10?'0' + h : h
					m = m < 10?'0' + m : m
					s = s < 10?'0' + s : s
					_this.countdown = {day: d,hour: h,min: m,sec: s}
				},1000)
			}
		},
		async handleCancelOrder(){
			uni.showModal({
				title: '提示',
				content: '是否确定取消预约？',
				success: async res => {
					if (!res.confirm) {
						return
					}
					await CancelAdvanceClass({
						token: true,
						id: this.courseInfo.memOrderCourseId,
						CourseOrderId: this.courseInfo.courseOrderId,
						ScheduleId: this.courseInfo.scheduleId
					}).then( res => {
						uni.showToast({
							title: '取消预约成功',
							icon: 'none'
						})
						uni.navigateBack({
							delta: 1
						})
					})
				}
			})
		},
		async handleLeaveOrder(){
			uni.showModal({
				title: '提示',
				content: '是否确认请假？',
				success: async res => {
					if (!res.confirm) {
						return
					}
					await AskForLeaveClass({
						token: true,
						id: this.courseInfo.memOrderCourseId,
						CourseOrderId: this.courseInfo.courseOrderId,
						ScheduleId: this.courseInfo.scheduleId
					}).then( res1 => {
						uni.showToast({
							title: '请假成功',
							icon: 'none'
						})
						uni.navigateBack({
							delta: 1
						})
					})
				}
			})
		},
		handleAginOrder() {
			uni.switchTab({
				url: '../index/index'
			})
			// uni.showModal({
			// 	title: '提示',
			// 	content: '是否确定重新预约？',
			// 	success: async res => {
			// 		if (!res.confirm) {
			// 			return
			// 		}
			// 		await AdvanceClass({
			// 			token: true,
			// 			id: this.courseInfo.memOrderCourseId,
			// 			CourseOrderId: this.courseInfo.courseOrderId,
			// 			ScheduleId: this.courseInfo.scheduleId
			// 		}).then( res1 => {
			// 			uni.showToast({
			// 				title: '预约成功',
			// 				icon: 'none'
			// 			})
			// 			uni.navigateBack({
			// 				delta: 1
			// 			})
			// 		})
			// 	}
			// })
		},
		handleCancelLineUp() {
			uni.showModal({
				title: '提示',
				content: '是否确定取消排队？',
				success: async res => {
					if (!res.confirm) {
						return
					}
					await AskForLeaveClass({
						token: true,
						id: this.courseInfo.memOrderCourseId,
						CourseOrderId: this.courseInfo.courseOrderId,
						ScheduleId: this.courseInfo.scheduleId
					}).then( res1 => {
						uni.showToast({
							title: '取消排队成功',
							icon: 'none'
						})
						uni.navigateBack({
							delta: 1
						})
					})
				}
			})
		},
		goHear() {
			uni.openLocation({
				latitude: this.config.latitude,
				longitude: this.config.longitude,
				success: function () {
					console.log('success');
				}
			});
		}
	}
}
</script>

<style lang="scss" scoped>
@import "../../style/business/order-confirm.scss";
.container{
	padding: 0;
	padding-bottom: 15rpx;
}
.ic-radio.active {
	background-color: #5584FF;
}
.status{
	width: 100%;
	height:200upx;
	background:linear-gradient(180deg,rgba(66,85,179,1) 0%,rgba(37,59,168,1) 100%);
	color: #FFFFFF;
	font-size: 36upx;
	padding: 30upx;
	text-indent: 10px;
	.tip{
		margin-top: 4upx;
		font-size: 24upx;
	}
	.status-img{
		width: 45upx;
		height: 45upx;
		margin-left: 18upx;
	}
}
.content-wrap{
	position: relative;
	top: -115upx;
	border-radius: 20upx;
	background-color: #FFFFFF;
	margin: 0 30upx;
	box-shadow:0px 2upx 8upx 0px rgba(0,0,0,0.15);
	.info-item{
		margin: 0 30upx;
		line-height: 104upx;
		font-size: 32upx;
		border-bottom: 1px solid #EFEFEF;
		.info-key{
			color: #333333;
		}
		.info-value{
			color: #999999;
		}
		.info-img{
			width: 40upx;
			height: 40upx;
			margin-right: 10upx;
			border-radius: 50%;
		}
	}
}
.address-wrap{
	position: relative;
	top: -85upx;
	margin: 0 30upx;
	height: 470upx;
	box-shadow:0px 2upx 8upx 0px rgba(0,0,0,0.15);
	border-radius:20upx;
	font-size: 0;
	.address-img{
		width: 100%;
		height: 352upx;
	}
	.address-info{
		height:78upx;
		background:rgba(255,255,255,1);
		box-shadow:0px 2upx 8upx 0px rgba(0,0,0,0.15);
		border-radius:10upx;
		position: relative;
		.address{
			width: 400upx;
		}
		.addressDetail{
			width: 445upx;
		}
	}
	.go-btn{
		color: #FFFFFF;
		font-size: 28upx;
		font-weight: 500;
		.go-img{
			width: 50upx;
			height: 50upx;
			margin-right: 15upx;
		}
		position: absolute;
		right: 20upx;
		bottom: 20upx;
		width: 200upx;
		text-align: center;
		line-height:72upx;
		background:linear-gradient(180deg,rgba(252,73,77,1) 0%,rgba(191,33,36,1) 100%);
		box-shadow:0px 2upx 8upx 0px rgba(0,0,0,0.15);
		border-radius:36upx;
	}
}
.click_btn{
	display: inline-block;
	width: 152rpx;
	line-height: 58rpx;
	border-radius:20px;
	text-align: center;
	font-size: 24rpx;
	color: #979DA6;
	border: 2rpx solid #979DA6;
}
.good-num {
	.click_btn {
		width: 100upx;
		line-height: 40upx;
		font-size: $font-size-sm;
	}
}
.click_btn_active{
	display: inline-block;
	width: 152rpx;
	margin-left: 20rpx;
	line-height: 58rpx;
	border-radius:20px;
	text-align: center;
	font-size: 24rpx;
	border: 2rpx solid $theme-color;
	color: $theme-color;
}
.btn-wrap{
	padding: 0 30upx;
}
</style>