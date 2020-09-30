<template>
	<view class="container flex flex-direction">
		<view class="course-wrap flex">
			<view class="fg1">
				当前课包
			</view>
			<picker :range="courseNameList" :value="courseIndex" @change="bindCourseChange">
				<text>{{courseNameList[courseIndex] || '课包类别'}}</text><image class="bot-img" src="../../static/img/icon_down.png" mode="aspectFill"></image>
			</picker>
		</view>
		<view class="page-top fs0">
			<view class="flex count-wrap">
				<view class="flex flex-direction fg1" style="border-right: 1px solid #FFFFFF;">
					<text class="count">{{ courseInfo.totalClassTime || 0}}</text>
					<text class="name">总课时</text>
				</view>
				<view class="flex flex-direction fg1" style="border-right: 1px solid #FFFFFF;">
					<text class="count">{{ courseInfo.remainingClassTime || 0}}</text>
					<text class="name">剩余课时</text>
				</view>
				<view class="flex flex-direction fg1">
					<text class="count">{{ courseInfo.totalLeaveNum || 0}}<text style="font-size: 24rpx;">({{ courseInfo.leaveNum || 0}})</text></text>
					<text class="name">请假次数(已使用)</text>
				</view>
			</view>
			<view class="contract-info flex c-center">
				<view class="fg1">
					查看合同信息（有效期至{{ courseInfo.effectiveTiem || '-'}}）
				</view>
				<image class="right fs0" src="../../static/img/go.png" mode="aspectFill"></image>
			</view>
		</view>
		<!-- <view class="time_wrap flex">
			<view class="info-title Cnname">
				<view class="">收益明细</view>
			</view>
			<picker class="time_btn fs0" mode="date" :value="startDatetime" :start="startDate" :end="endDate" @change="bindDateChange">
				<view class="uni-input">{{startDatetime || '2020年2月'}}</view>
			</picker>
		</view> -->
		<view class="content-wrap fg1">
			<view class="list-item flex c-center" style="padding: 30rpx 0 20rpx;">
				<view class="fg1">
					<view class="title flex">
						<text class="fg1 class-record">耗课记录</text>
						<picker class="flex c-center class-type" style="border-right: 1px solid #FFFFFF;" :range="courseTypeNameList" :value="typeIndex" @change="bindTypeChange">
							<text class="name">{{courseTypeNameList[typeIndex] || '全部课程'}}</text><image class="bot-type" src="../../static/img/bot-type.png" mode="aspectFill"></image>
						</picker>
						<picker mode="date" class="flex c-center j-center fg1" :value="time" @change="bindTimeChange">
							<text class="name">{{time || '开课日期'}}</text><image class="bot-type" src="../../static/img/bot-type.png" mode="aspectFill"></image>
						</picker>
						<!-- <view class="flex c-center">2020年4月 <image class="bot-type" src="../../static/img/bot-type.png" mode="aspectFill"></image></view> -->
					</view>
					<view class="time flex">
						<text class="fg1"></text>
						<view class="class-time"><text style="margin-right: 20rpx;">本月上课：10次</text> 使用课时：10课时</view>
					</view>
				</view>
			</view>
			<scroll-view class="scroll-view" scroll-y @scrolltolower="scrollToBottom">
				<view class="list-item flex c-center" v-for="(item,index) in table.list" :key="index">
					<view class="fg1">
						<view class="title flex">
							<text class="fg1">{{ item.courseName || ''}}</text>
							<view class="use-time">使用{{ item.useClassTime || ''}}课时</view>
						</view>
						<view class="time flex">
							<text class="fg1">{{ item.orderDate || '' }} {{ item.orderTimeLong || '' }}</text>
							<view>剩余：{{ item.remainingClassTime || ''}}课时</view>
						</view>
					</view>
				</view>
				<list
				 :status="table.status"
				 noDataImg='/static/img/error.png'
				 text='未查询到数据'
				 @retry='getPageList'></list>
			</scroll-view>
		</view>
		<view class="h30"></view>

		<YLoading ref='loading'></YLoading>

		<home></home>

	</view>
</template>

<script>
	import {
		GetCourseOrderList,//课包列表
		GetCourseTypeList,//课程类型
		GetMemCourseList
	} from '@/apis/api.js'
	import tab from '@/components/base/tab.vue'
	import ListPage from '@/lib/class/createList.js'
	let listPage = new ListPage({
		api: GetMemCourseList,
		data: {
			token: true,
			queryAll:1,
			status: 2
		},
		callback: (list) => {
			return list.map(item => {
		        item.orderDate = item.orderDate?.split(' ')[0]
				return item
			})
		}
	})
	export default {
		mixins: [listPage],
		data() {
			return {
				userData: {},
				sumInfo:'',//头部信息
				table: {
					list: []
				},
				courseList:[],
				courseInfo: {},
				courseIndex: 0,
				courseTypeList: [{
					typeName: '全部课程',
					id: null
				}],
				courseNameList: [],
				courseTypeNameList: [],
				typeIndex: 0,
				config: {},
				startDatetime: '2020.02.01 0:00:00',
				time: null
			}
		},
		onShow() {
			this.getUserInfo()
			this.resetList()
			this.getCourseOrderList()
			this.getCourseTypeList()
		},
		methods: {
			async getsumInfo() {
				this.sumInfo = await GetCreaterFeeSum({
					token:true,
					queryAll:1
				})
			},
			bindCourseChange(e) {
				this.courseIndex = e.target.value
				this.courseInfo = this.courseList[this.courseIndex]
				this.addParams({
					courseOrderId: this.courseList[this.courseIndex].id
				})
				this.resetList().then(res => {
					res.map(item => {
						item.orderDate = item.orderDate?.split(' ')[0]
							return item
					})
				})
			},
			bindTypeChange(e) {
				this.typeIndex = e.target.value
				this.addParams({
					courseTypeId: this.courseTypeList[this.typeIndex].id
				})
				this.resetList().then(res => {
					res.map(item => {
						item.orderDate = item.orderDate?.split(' ')[0]
							return item
					})
				})
			},
			bindTimeChange(e) {
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
			async getCourseOrderList() {
				await GetCourseOrderList({
					token:true,
					queryAll:1
				}).then(res => {
					this.courseList = res
					this.courseInfo = res[this.courseIndex]
					this.courseNameList = res.map(item =>{
						return item.courseOrderName
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
				this.courseTypeList = courseTypeList
				this.courseTypeNameList = courseTypeList.map(item => {
					return item.typeName
				})
			},
			async getUserInfo() {
				this.ySetUserData()
				this.userData = await this.$store.dispatch('getUserData')
			},
			bindDateChange(e) {
				this.startDatetime = e.target.value
				// this.addParams({
				// 	startDatetime: this.startDatetime
				// })
				// this.resetList()
			}
		}
	}
</script>

<style lang="scss" scoped>
	.container {
		background: $bg-color-grey;
		height: 100%;
		position: relative;
	}
	.course-wrap{
		padding: 24upx 30upx;
		background: $theme-color;
		color: #FFFFFF;
		.bot-img{
			width: 16upx;
			height: 12upx;
			margin-left: 6upx;
		}
	}
	.page-top {
		background-color: $theme-color;
		text-align: center;
		color: #FFFFFF;
		height:284upx;
		background:linear-gradient(180deg,rgba(66,85,179,1) 0%,rgba(37,59,168,1) 100%);
		position: relative;
		padding-top: 30upx;

		.countAll {
			font-size: 48upx;
			margin-bottom: 10upx;
		}
		.count {
			font-size: 44upx;
			margin-bottom: 8upx;
		}

		.name {
			font-size: 24upx;
		}
		.contract-info{
			text-align: left;
			margin: 40upx 30upx 0;
			.right{
				width: 15upx;
				height: 26upx;
			}
		}
	}

	.time_wrap {
		padding: 36upx 30upx;
		position: relative;

		.info-title {
			padding-left: 18rpx;
			font-size: 32upx;
			font-weight: bold;
			border-left: 1px solid #FFC000;
		}

		.time_btn {
			position: absolute;
			overflow: hidden;
			width: 180upx;
			text-align: center;
			height: 68upx;
			line-height: 68upx;
			background: #FFFFFF;
			border-radius: 34upx;
			top: 20upx;
			right: 30upx;
			font-size: 24upx;
		}
	}

	.content-wrap {
		overflow: hidden;
		background: #FFFFFF;
		border-radius:40upx 40upx 0px 0px;
		z-index: 1;
		margin: -66upx 0 -30upx;
		padding-bottom: 60upx;
		.content-title {
			height: 94upx;
			padding: 30upx 20upx 20upx;
			box-sizing: border-box;
			border-bottom: 1px solid $border-color;
			font-weight: bold;
		}

		.scroll-view {
			height: calc(100% - 94upx);
		}

		.list-item {
			padding: 30upx 0;
			margin: 0 30upx;
			border-bottom: 1px solid $border-color;

			.title {
				font-size: $font-size-base;
				.class-record{
					font-size: 32upx;
					font-weight:500;
				}
				.use-time{
					color: #F14246;
				}
				.class-type{
					margin-right: 20upx;
				}
				.bot-type{
					width: 20upx;
					height: 12upx;
					margin-left: 10upx;
				}
			}

			.time {
				color: #999;
				font-size: $font-size-sm;
				padding-top: 10upx;
				.class-time{
					font-size: 28upx;
				}
			}

			.amount {
				font-size: $font-size-lg;
				margin-left: 20upx;
			}
		}
	}
</style>
