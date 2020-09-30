<template>
	<view class="container">
		<view class="page-top">
			<view class="flex">
				<picker mode="date" class="flex c-center j-center fg1" style="border-right: 1px solid #FFFFFF;" :value="time" @change="bindTimeChange">
					<text class="name">{{time || '选择时间'}}</text><image class="bot-img" src="../../static/img/icon_down.png" mode="aspectFill"></image>
				</picker>
				<!-- <view class="flex c-center j-center fg1" style="border-right: 1px solid #FFFFFF;">
					<text class="name">选择时间</text><image class="bot-img" src="../../static/img/icon_down.png" mode="aspectFill"></image>
				</view> -->
				<picker class="flex c-center j-center fg1" style="border-right: 1px solid #FFFFFF;" :range="courseTypeList" :value="typeIndex" @change="bindTypeChange">
					<text class="name">{{courseTypeList[typeIndex] || '课程类型'}}</text><image class="bot-img" src="../../static/img/icon_down.png" mode="aspectFill"></image>
				</picker>
				<picker class="flex c-center j-center fg1" :range="courseStatusList" :value="statusIndex" @change="bindStatusChange">
					<text class="name">{{courseStatusList[statusIndex] || '课程状态'}}</text><image class="bot-img" src="../../static/img/icon_down.png" mode="aspectFill"></image>
				</picker>
			</view>
		</view>
		<view class="course-wrap">
			<view class="course-item" v-for="(item,index) in table.list" :key="index">
				<view class="top-wrap flex">
					<view class="course-title fg1">
						{{ item.courseName || ''}}
					</view>
					<view class="status">
						{{ item.orderStatus == -3? '未签到' :
						item.orderStatus == -2? '已请假' : 
						item.orderStatus == -1? '已取消' : 
						item.orderStatus == 0? '排队中' : 
						item.orderStatus == 1? '待上课' : 
						item.orderStatus == 2? '已记课' : '' }}
					</view>
				</view>
				<view class="time">
				</view>
				<view class="course-detail">
					<view class="detail flex">
						<image mode="widthFix" class="detail-img fs0" src="../../static/img/icon_date.png"></image>{{ item.orderDate || '' }} {{ item.orderTimeLong || '' }}
					</view>
					<view class="detail flex">
						<image mode="widthFix" class="detail-img fs0" src="../../static/img/icon_time.png"></image>{{ item.courseTime || ''}}课时
					</view>
					<view class="detail flex">
						<image mode="widthFix" class="detail-img fs0" src="../../static/img/icon_classroom.png"></image>{{ item.className || ''}}
					</view>
					<view class="detail flex">
						<image mode="widthFix" class="detail-img fs0" src="../../static/img/icon_teacher.png"></image>{{ item.teacherName || ''}}
					</view>
					<navigator class="detail-btn"  open-type='navigate' :url="'/pages/orderDetail/orderDetail?id='+item.memOrderCourseId">
						查看详情
					</navigator>
				</view>
			</view>
		</view>
		<YLoading ref='loading'></YLoading>
		<list
		:status="table.status" 
		noDataImg='/static/img/error.png'
		text='暂无数据'
		@retry='getPageList'></list>
	</view>
</template>

<script>
import {
	GetMemCourseList,
	GetCourseTypeList
} from '@/apis/api.js'
import ListPage from '@/lib/class/createList.js'
let listPage = new ListPage({
	api: GetMemCourseList,
	data: {
		token: true,
		queryAll:1
	},
	callback: (list) => {
		return list.map(item => {
	        return item
		})
	}
})
export default {
	mixins: [listPage],
	data() {
		return {
			userData: {}, // 用户数据
			table: {
				list: []
			},
			tabs: [
				{text: '选择时间'},
				{text: '课程类型'},
				{text: '课程状态'}
			],
			typeList: [],
			courseTypeList: [{
				typeName: '课程类别'
			}],
			typeIndex: 0,
			courseStatusList: [
				'课程状态',
				'排队中',
				'待上课',
				'已记课',
				'已取消',
				'请假'
			],
			statusIndex: null,
			currentTab: 0,
			time: null
		}
	},
	onLoad(options) {
		this.init()
		this.config = this.$store.state.config.config
	},
	onShow() {
		this.getUserData()
		// this.addParams({
		// 	orderType: this.currentTab
		// })
		// this.resetList().then(res => {
		// 	res.map(item => {
		// 		item.orderDate = item.orderDate?.split(' ')[0]
		// 		return item
		// 	})
		// })
	},
	methods: {
		init() {
			this.getCourseTypeList()
			this.resetList().then(res => {
				res.map(item => {
					item.orderDate = item.orderDate?.split(' ')[0]
					return item
				})
			})
		},
		async getCourseTypeList() {
			let courseTypeList = this.courseTypeList
			let result = await GetCourseTypeList({
				token: true,
				queryAll: 1
			})
			courseTypeList.push(...result)
			this.typeList = courseTypeList
			this.courseTypeList = courseTypeList.map(item => {
				return item.typeName
			})
		},
		bindTypeChange(e) {
			this.typeIndex = e.target.value
			this.addParams({
				courseTypeId: this.typeList[this.typeIndex].id
			})
			this.resetList().then(res => {
			res.map(item => {
				item.orderDate = item.orderDate?.split(' ')[0]
				return item
			})
		})
		},
		bindStatusChange(e) {
			let statusIndex = e.target.value
			this.statusIndex = statusIndex
			if(statusIndex == 0){
				statusIndex = ''
			}
			if(statusIndex == 1){
				statusIndex = 0
			}
			if(statusIndex == 2){
				statusIndex = 1
			}
			if(statusIndex == 3){
				statusIndex = 2
			}
			if(statusIndex == 4){
				statusIndex = -1
			}
			if(statusIndex == 5){
				statusIndex = -2
			}
			this.addParams({
				Status: statusIndex
			})
			this.resetList().then(res => {
			res.map(item => {
				item.orderDate = item.orderDate?.split(' ')[0]
				return item
			})
		})
		},
		bindTimeChange: function(e) {
			this.time = e.target.value
			this.addParams({
				orderDate: new Date(this.time)
			})
			this.resetList().then(res => {
			res.map(item => {
				item.orderDate = item.orderDate?.split(' ')[0]
				return item
			})
		})
		},
		// 获取用户数据
		async getUserData() {
			this.userData = await this.$store.dispatch('getUserData')
		}
	}
}
</script>

<style lang="scss" scoped>
@import "../../style/business/order-confirm.scss";
.container{
	padding: 0;
}
.page-top {
	background-color: $theme-color;
	text-align: center;
	color: #FFFFFF;
	padding: 24upx 0;
	background:linear-gradient(180deg,rgba(66,85,179,1) 0%,rgba(37,59,168,1) 100%);
	position: relative;
	.name {
		font-size: 28upx;
	}
	.bot-img{
		width: 16upx;
		height: 12upx;
		margin-left: 6upx;
	}
}
.course-wrap{
	padding-top: 30upx;
	.course-item{
		background:rgba(255,255,255,1);
		border-radius:10px;
		padding: 20upx;
		margin: 0 30upx 20upx;
		position: relative;
		box-shadow:0px 2upx 8upx 0px rgba(0,0,0,0.15);
		.top-wrap{
			font-size: 28upx;
			.course-title{
				color: #000000;
				font-weight: 500;
			}
			.status{
				color: #858585;
				font-weight: 400;
			}
		}
		.img-wrap{
			width: 300upx;
			height: 300upx;
			margin: 0 auto;
			padding: 10upx;
			image{
				width: 100%;
				height: 100%;
			}
		}
		.noorder-wrap{
			width: 300upx;
			height: 300upx;
			margin: 60rpx auto;
			image{
				width: 100%;
				height: 100%;
			}
		}
		.time{
			border-bottom: 2upx solid #F5F5F5;
			color: #999999;
			text-align: center;
			padding: 0 0 20upx 0;
		}
		.course-detail{
			font-size: 24upx;
			.detail{
				margin-top: 10upx;
				color: #999999;
				.detail-img{
					width: 30upx;
					height: 30upx;
					margin-right: 10upx;
				}
			}
			.detail-btn{
				width:174upx;
				text-align: center;
				line-height:56upx;
				background:linear-gradient(180deg,rgba(252,73,77,1) 0%,rgba(191,33,36,1) 100%);
				color: #FFFFFF;
				border-radius:28upx;
				font-size: 24upx;
				position: absolute;
				right: 20upx;
				bottom: 20upx;
			}
		}
	}
}
</style>