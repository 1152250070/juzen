<template>
	<view class="container">
		<view class="calendar-wrap flex c-center">
			<view class="month">
				{{ month }}月
			</view>
			<scroll-view scroll-x class="flex calendar-center" :scroll-left='scrollLeft' scroll-with-animation>
				<view class="flex c-center month-wrap">
					<view v-for="(item,index) in monthSelect.dayList" :key="index">
						<view :class="['month-item', 'flex', 'flex-direction', 'j-center', dayIndex == index? 'active' : '', `month-item${index}`]" @click="bindDayChange(item,index)">
							<view class="">
								{{ item == today? '今天' : item.week? item.week : '' }}
							</view>
							<view class="">
								{{ item.day || item }}
							</view>
						</view>
					</view>
				</view>
			</scroll-view>
			<view class="calendar-img flex c-center j-center">
				<image mode="aspectFill" class="item-img fs0" src="../../static/img/icon_calendar.png" @click="handelShowCalendar"></image>
			</view>
		</view>

		<view class="page-top">
			<view class="flex">
				<picker class="flex c-center j-center fg1" style="border-right: 1px solid #FFFFFF;" :range="courseTypeList" :value="typeIndex" @change="bindTypeChange">
					<text class="name">{{courseTypeList[typeIndex] || '全部课程'}}</text><image class="bot-img" src="../../static/img/icon_down.png" mode="aspectFill"></image>
				</picker>
				<view class="flex c-center j-center fg1" @click="onShowDatePicker('rangetime')">
					<text class="name">{{startTime? startTime+ '-' + endTime : '全部时间段'}}</text><image class="bot-img" src="../../static/img/icon_down.png" mode="aspectFill"></image>
				</view>
				<timePicker :show="showPicker" :type="type" :value="value" :show-tips="true" :show-seconds="true" @confirm="onSelected" @cancel="onSelected" />
			</view>
		</view>
		
		<view class="type-wrap flex flex-between">
			<view :class="['type-item',currentTab == 0? 'active' : '']" @click="handleTabChange(0)">
				预约课表({{courseLength || 0}})
			</view>
			<view :class="['type-item',currentTab == 1? 'active' : '']" @click="handleTabChange(1)">
				我的课表
			</view>
		</view>
		
		<view class="course-wrap">
			<view v-for="(item,index) in table.list" :key="index" class="">
				<view class="time flex c-center">
					<view class="dot"></view>
					{{ item.orderTimeLong || '' }}
				</view>
				<view class="course-item">
					<view class="top-wrap flex">
						<view class="course-title fg1">
							{{ item.courseName }}
						</view>
						<view v-if="currentTab == 0">
							<view v-if="item.signUpNum != item.totalSignUp" class="status" style="color: #4A4A4A;">
								待上人数：{{ item.signUpNum }}/{{ item.totalSignUp }}
							</view>
							<view v-if="item.signUpNum == item.totalSignUp" class="status" style="color: #858585;">
								待上人数：{{ item.signUpNum }}/{{ item.totalSignUp }}(已满)
							</view>
						</view>
						<view v-else>
							<view v-if="item.orderStatus == 2" class="status" style="color: #00B46C;">
								已记课
							</view>
							<view v-if="item.orderStatus == 1" class="status" style="color: #858585;">
								待上课
							</view>
							<view v-if="item.orderStatus == -3" class="status" style="color: #858585;">
								未签到
							</view>
							<view v-if="item.orderStatus == -1" class="status" style="color: #858585;">
								已取消
							</view>
							<view v-if="item.orderStatus == -2" class="status" style="color: #858585;">
								已请假
							</view>
							<view v-if="item.orderStatus == 0" class="status" style="color: #FF7617;">
								排队中
							</view>
						</view>
					</view>
					<view class="time">
					</view>
					<view class="course-detail">
						<view class="detail flex">
							<image mode="widthFix" class="detail-img fs0" src="../../static/img/icon_time.png"></image>{{ item.courseTime }}课时
						</view>
						<view class="detail flex">
							<image mode="widthFix" class="detail-img fs0" src="../../static/img/icon_classroom.png"></image>{{ item.className }}
						</view>
						<view class="detail flex">
							<image mode="widthFix" class="detail-img fs0" src="../../static/img/icon_teacher.png"></image>{{ item.teacherName }}
						</view>
						<view v-if="currentTab == 0">
							<view v-if="item.orderStatus" class="detail-btn">
								已预约
							</view>
							<view v-if="!item.orderStatus && item.signUpNum != item.totalSignUp" class="detail-btn" @click="handleShowOrder(item)">
								约课
							</view>
							<view v-if="!item.orderStatus && item.signUpNum == item.totalSignUp" class="detail-btn" style="background:linear-gradient(180deg,rgba(115,138,255,1) 0%,rgba(66,85,179,1) 100%);" @click="handleShowLineUp(item)">
								排队
							</view>
						</view>
						<navigator v-else class="detail-btn"  open-type='navigate' :url="'/pages/orderDetail/orderDetail?id='+item.memOrderCourseId">
							查看详情
						</navigator>
					</view>
				</view>
			</view>
		</view>
		
		<YLoading ref='loading'></YLoading>
		<list
		:status="table.status" 
		noDataImg='/static/img/error.png'
		text='暂无数据'
		@retry='getPageList'></list>
		
		<calendar
		ref='calendar'
		@initMonthData='initMonthData'
		@confirm='handleTimeConfirm'
		>
		</calendar>
		<!-- 预约确认 -->
		<commonDialog
		ref='orderConfirm'
		title='预约确认'
		:showCancel='false'
		confirmTitle='确定约课'
		@confirm='handleOrderConfirm'
		>
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
						课程时间
					</view>
					<view class="info-value">
						{{ courseInfo.orderDate || '' }} {{ courseInfo.orderTimeLong || '' }}
					</view>
				</view>
				<view class="info-item flex flex-between c-center">
					<view class="info-key">
						教师
					</view>
					<view class="info-value">
						{{ courseInfo.teacherName || '' }}
					</view>
				</view>
				<view class="info-item flex flex-between c-center">
					<view class="info-key">
						教室
					</view>
					<view class="info-value">
						{{ courseInfo.className || '' }}
					</view>
				</view>
			</view>
		</commonDialog>
		<!-- 排队确认 -->
		<commonDialog
		ref='lineupConfirm'
		title='排队确认'
		:showCancel='false'
		confirmTitle='确定排队'
		@confirm='handleLineUPConfirm'
		>
			<view class="content-wrap" style="padding: 0;">
				<view class="info-item flex flex-between c-center">
					<view class="info-key">
						课程
					</view>
					<view class="info-value">
						{{ courseInfo.courseName || '' }}
					</view>
				</view>
				<view class="info-item flex flex-between c-center">
					<view class="info-key">
						课程时间
					</view>
					<view class="info-value">
						{{ courseInfo.orderDate || '' }} {{ courseInfo.orderTimeLong || '' }}
					</view>
				</view>
				<view class="info-item flex flex-between c-center">
					<view class="info-key">
						教师
					</view>
					<view class="info-value">
						{{ courseInfo.teacherName || '' }}
					</view>
				</view>
				<view class="info-item flex flex-between c-center">
					<view class="info-key">
						教室
					</view>
					<view class="info-value">
						{{ courseInfo.className || '' }}
					</view>
				</view>
			</view>
		</commonDialog>
		<!-- 再次选择 -->
		<view v-if="isAgainShow && againCourseList.length > 0" class="mask-wrap" @click="isAgainShow = false"></view>
		<view v-if="isAgainShow && againCourseList.length > 0" class="manage-content">
			<image class="bg" src="../../static/img/tab.png" mode="widthFix"></image>
			<view class="text">
				约课提醒
			</view>
			<view class="course-wrap" style="margin-left: 0;">
				<view class="course-item" v-for="(item,index) in againCourseList" :key="index">
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
							<image mode="widthFix" class="detail-img fs0" src="../../static/img/icon_date.png"></image>{{ item.orderDate || '' }} {{ courseInfo.orderTimeLong || '' }}
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
						<view class="detail-btn" @click="handleShowOrder(item)">
							继续约本课程
						</view>
					</view>
				</view>
			</view>
			<view class="btn" @click="isAgainShow = false">选择其他课程</view>
		</view>
		<view v-if="againCourseList.length > 0" class="mask-btn" @click="isAgainShow = true">
			<image mode="aspectFill" class="item-img fs0" src="../../static/img/tab-history@3x.png">
		</view>
		<YLoading ref='loading'></YLoading>
	</view>
</template>

<script>
import {
	GetCourseTypeList,
	GetCourseScheduleList,
	GetMemCourseList,
	AdvanceClass,
	LineUpAdvanceClass,
	CancelAdvanceClass,
	AskForLeaveClass,
	token
} from '@/apis/api.js'
import ListPage from '@/lib/class/createList.js'
import commonDialog from '@/components/base/commonDialog.vue'
import calendar from '@/components/base/mobile-calendar/Calendar.vue'
import timePicker from '@/components/base/timePicker.vue'

let listPage = new ListPage({
	api: null,
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
const year = new Date().getFullYear();
const month = new Date().getMonth()+1;
const day = new Date().getDate();
const week = new Date().getDay();

export default {
	mixins: [listPage],
	components: {
		commonDialog,calendar,timePicker
	},
	data() {
		return {
			userData: {}, // 用户数据
			table: {
				list: []
			},
			typeList: [],
			courseTypeList: [],
			againCourseList: [],
			courseLength: 0,
			currentTab: 0,
			typeIndex: null,
			currentTab: 0,
			isAgainShow: true,
			isShow: false,
			selectMonth: null,
			dayIndex: 0,
			showPicker: false,
			rangetime: ['2019/01/08 14:00','2019/01/16 13:59'],
			type: 'time',
			value: '',
			startTime: null,
			endTime: null,
			time: null,
			id: null,
			courseInfo: {},
			monthSelect: {
				// dayList: 30
				day: null,
				week: null
			},
			selectDayList: [],
			stateWidthList: [], // 状态长度列表
			scrollLeft: 0
		}
	},
	onLoad(options) {
		this.config = this.$store.state.config.config
		this.userData = this.$store.state.user.userData
		this.init()
	},
	computed: {
		year() {
			return parseInt(year)
		},
		month() {
			let m = this.monthSelect.month? this.monthSelect.month : month
			return parseInt(m) > 9 ? parseInt(m) : '0' + parseInt(m)
		},
		today() {
			let d = this.monthSelect.day? this.monthSelect.day : day
			return parseInt(d) > 9 ? parseInt(d) : '0' + parseInt(d)
		},
		weekIndex() {
			let w = this.monthSelect.week? this.monthSelect.week : week
			return w == '周一' ? 1 : w == '周二' ? 2 : w == '周三' ? 3: w == '周四' ? 4 : w == '周五' ? 5 : w == '周六' ? 6 : w == '周日' ? 7 : week
		}
	},
	onShow() {
		this.$store.dispatch('getUserData')
		if (!token.value) {
			uni.navigateTo({
				url: '/pages/login/login'
			})
			return false
		} else {
			this.getMessageNum()
			this.getCourseTypeList()
			this.getAgainCourseList()
			this.changeParams()
		}
	},
	methods: {
		init(){
			this.$refs.calendar.init()
		},
		async doSetActiveMiddle() {
			let scrollLeft = await this.getStateWidth()
			let halfWidth = uni.upx2px(530) / 2
			this.scrollLeft = scrollLeft > halfWidth ? scrollLeft - halfWidth : 0
		},
		// 获取左侧距离
		getStateWidth() {
			function calc(list, index) {
				return list.slice(0, index).reduce((start, item) => {
					return start + item
				}, 0) + list[index] / 2
			}
			return new Promise((resolve) => {
				if (this.stateWidthList.length) {
					resolve(calc(this.stateWidthList, this.dayIndex))
				}
				let count = 0
				let stateWidthList = []
				let length = this.monthSelect.dayList.length
				for (let i = 0; i < length; i++) {
					uni.createSelectorQuery().select(`.month-item${i}`).boundingClientRect(rect => {
						if (!rect) {
							return
						}
						stateWidthList[i] = rect.width
						count++
						if (count === length - 1) {
							resolve(calc(this.stateWidthList = stateWidthList, this.dayIndex))
						}
					}).exec()
				}
			})
		},
		// tab切换
		handleTabChange(index) {
			if (!token.value) {
				uni.navigateTo({
					url: '/pages/login/login'
				})
				return false
			}
			if(this.currentTab == index) {
				return
			}
			this.currentTab = index
			this.changeParams()
		},
		changeParams() {
			this.showLoading
			let currentTab = this.currentTab
			let typeIndex = this.typeIndex
			let date = this.year +'/'+ this.month +'/'+ this.today
			this.changeUrl(currentTab === 0 ? GetCourseScheduleList : GetMemCourseList)
			if(typeIndex) {
				this.addParams({
					courseTypeId: this.typeList[typeIndex].id
				})
			}
			if(this.startTime) {
				this.orderStartTime = new Date(date + ' ' + this.startTime)
				this.orderEndTime = new Date(date + ' ' + this.endTime)
				this.addParams({
					orderStartTime: this.orderStartTime,
					orderEndTime: this.orderEndTime,
					orderDate: new Date(this.year + '-' + this.month + '-' + this.today),
					weekIndex: this.weekIndex
				})
			}else{
				this.addParams({
					orderStartTime: null,
					orderEndTime: null,
					orderDate: new Date(this.year + '-' + this.month + '-' + this.today),
					weekIndex: this.weekIndex
				})
			}
			this.resetList().then(res => {
				if(currentTab == 0) {
					this.courseLength = res.length
				}
				setTimeout(() => {
					this.hidePageLoading()
				}, 500)
			})
		},
		initMonthData(val) {
			this.monthSelect.dayList = val.dayList
			this.dayIndex = val.dayIndex
			this.doSetActiveMiddle()
		},
		async getMessageNum(){
			await this.$store.dispatch('getMemssege')
		},
		async getCourseTypeList() {
			let courseTypeList = [{
				typeName: '全部课程'
			}]
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
		async getAgainCourseList() {
			let result = await GetMemCourseList({
				token: true,
				status: 2,
				pageIndex: 1,
				pageSize: 2
			})
			if(!result){
				this.againCourseList = []
				return false
			}
			this.againCourseList = result.map(item => {
				item.orderDate = item.orderDate?.split(' ')[0]
				return item
			})
		},
		handelShowCalendar(){
			if( this.isShow ) {
				this.isShow = false
				this.$refs.calendar.hide()
			} else {
				this.isShow = true
				this.$refs.calendar.show()
			}
		},
		handleTimeConfirm(v){
			this.isShow = false
			this.monthSelect = v
			this.dayIndex = this.monthSelect.dayIndex
			this.doSetActiveMiddle()
			this.changeParams()
		},
		bindDayChange(item,index){
			let currentTab = this.currentTab
			this.isShow = false
			this.$refs.calendar.hide()
			this.dayIndex = index
			this.doSetActiveMiddle()
			this.monthSelect.day = item.day
			this.monthSelect.week = item.week
			this.changeParams()
		},
		bindTypeChange(e) {
			this.typeIndex = e.target.value
			this.changeParams()
		},
		onShowDatePicker(type){//显示
			let date = this.year +'/'+ this.month +'/'+ this.today
			let startTime = this.startTime? this.startTime : ' 10:00'
			let endTime = this.endTime? this.endTime : ' 11:30'
			this.rangetime = [date +' '+ startTime,date +' '+ endTime]
			this.type = type;
			this.showPicker = true;
			this.value = this[type];
		},
		onSelected(e) {//选择
			this.showPicker = false;
			if(e) {
				this[this.type] = e.value; 
				//选择的值
				this.startTime = e.value[0].split(' ')[1]
				this.endTime = e.value[1].split(' ')[1]
				this.changeParams()
			}
		},
		handleShowOrder(item) {
			this.courseInfo = item
			this.courseInfo.orderDate = this.courseInfo.orderDate?.split(' ')[0]
			this.$refs.orderConfirm.show()
			this.isAgainShow = false
		},
		handleShowLineUp(item) {
			this.courseInfo = item
			this.courseInfo.orderDate = this.courseInfo.orderDate?.split(' ')[0]
			this.$refs.lineupConfirm.show()
		},
		async handleOrderConfirm(){
			await AdvanceClass({
				token: true,
				id: this.courseInfo.id,
				orderDate: new Date(this.year + '-' + this.month + '-' + this.today),
				weekIndex: this.weekIndex
			}).then( res => {
				uni.showToast({
					title: '预约成功',
					icon: 'none'
				})
				this.changeParams()
				this.$refs.orderConfirm.hide()
			})
		},
		async handleLineUPConfirm(){
			await LineUpAdvanceClass({
				token: true,
				id: this.courseInfo.id,
				orderDate: new Date(this.year + '-' + this.month + '-' + this.today),
				weekIndex: this.weekIndex
			}).then( res => {
				uni.showToast({
					title: '排队成功',
					icon: 'none'
				})
				this.changeParams()
				this.$refs.lineupConfirm.hide()
			})
		}
	},
	onPullDownRefresh() {
		if(token.value){
			this.showPageLoading()
			this.getCourseTypeList()
			this.getAgainCourseList()
			this.startTime = null
			this.orderStartTime = null
			this.orderEndTime = null
			this.changeParams()
		}
	}
}
</script>

<style lang="scss" scoped>
@import "../../style/business/order-confirm.scss";
.container{
	padding: 0;
}
.test{
	text-align: center;
	padding: 10px 0;
}
button{
	margin: 20upx;
	font-size: 28upx;
}

.calendar-wrap{
	height: 88upx;
	background-color: #4255B3;
	color: #FFFFFF;
	box-shadow:0px 4upx 8upx 0px rgba(0,0,0,0.15);
	.month{
		width: 120upx;
		line-height: 88upx;
		text-align: center;
		font-size: 28upx;
		box-shadow:0px 4upx 8upx 0px rgba(0,0,0,0.15),4upx 0px 12upx 0px rgba(0,0,0,0.15);
	}
	.calendar-center{
		width: 550upx;
		margin: 0 10upx;
	}
	.month-wrap{
		position: relative;
		padding: 0 10upx;
		.month-item{
			width: 66upx;
			height: 68upx;
			text-align: center;
			font-size: 20upx;
			// margin-right: 10upx;
		}
		.month-item.active {
			background: #FFFFFF;
			color: #4255B3;
			box-shadow:0px 4upx 8upx 0px rgba(0,0,0,0.15);
			border-radius:4upx;
		}
	}
	.calendar-img{
		width: 120upx;
		height: 88upx;
		box-shadow:0px 4px 8px 0px rgba(0,0,0,0.15),-4px 0px 12px 0px rgba(0,0,0,0.15);
		.item-img{
			width: 60upx;
			height: 60upx;
		}
	}
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
.type-wrap{
	padding: 30upx;
	.type-item{
		width:340upx;
		text-align: center;
		line-height:68upx;
		background: #FFFFFF;
		box-shadow:0px 2upx 8upx 0px rgba(0,0,0,0.15);
		border-radius:44upx;
		color: #333333;
		font-weight: 500;
	}
	.type-item.active{
		background: #4255B3;
		color: #FFFFFF;
	}
}
.course-wrap{
	margin: 10upx 0 0 40upx;
	padding-bottom: 1rpx;
	border-left: 4upx solid #FFCCCC;
	.time{
		font-size: 32upx;
		color: #4255B3;
		position: relative;
		left: -11upx;
		top: -10upx;
		font-weight:500;
		.dot{
			width: 20upx;
			height: 20upx;
			border-radius: 50%;
			background: #4255B3;
			margin-right: 20upx;
		}
	}
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
				padding:0 32upx;
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
.content-wrap{
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
	}
}
.mask-wrap{
	position: fixed;
	top: 0;
	left: 0;
	background: #404040;
	z-index: 11;
	opacity: 0.74;
	height: 100%;
	width: 100%;
}
.manage-content{
	margin: auto 35upx;
	height: 830upx;
	background: #FFFFFF;
	border-radius: 40upx;
	position: fixed;
	top: 0;
	left: 0;
	bottom: 0;
	z-index: 11;
	width: 600upx;
	padding: 40upx;
	.bg{
		width: 100%;
		position: absolute;
		top: -28upx;
		left: 0;
		right: 0;
		bottom: 0;
	}
	.course-item{
		border:2upx solid rgba(66,85,179,1);
	}
	.btn{
		// margin: 40upx auto 0;
		border-radius:44upx;
		color: #FFFFFF;
		font-size: 28upx;
		font-weight: 500;
		width:390upx;
		text-align: center;
		line-height:88upx;
		background:linear-gradient(180deg,rgba(115,138,255,1) 0%,rgba(66,85,179,1) 100%);
		z-index: 1;
		position: absolute;
		bottom: -10upx;
		left: 140upx;
	}
	.text{
		font-size: 36upx;
		color: #4255B3;
		font-weight: 500;
		position: relative;
		margin: 100upx 0 30upx;
		text-align: center;
	}
}
.mask-btn{
	position: fixed;
	bototm: 20upx;
	right: 20upx;
	width: 100upx;
	height: 100upx;
	.item-img{
		width: 100%;
		height: 100%;
	}
}
</style>