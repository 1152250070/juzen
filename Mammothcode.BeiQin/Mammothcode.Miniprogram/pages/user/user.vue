<template>
	<view class="container">
		<view v-if="!userData" class="user-info-wrap flex c-center" style="background-image: url('../../static/img/bg.png')" @click="handleUserInfoClick">
			<image mode="widthFix" class="user-avatar fs0" :src="userData.stuImg"></image>
			<view>
				<view class="user-nickname">
					{{ userData.stuName || '点击授权登录' }}
				</view>
			</view>
		</view>
		<view v-else class="user-info-wrap flex c-center">
			<image mode="aspectFill" class="user-avatar fs0" :src="userData.stuImg"></image>
			<image mode="widthFix" class="authen fs0" src="../../static/img/icon_vip.png"></image>
			<view>
				<view class="user-nickname flex">
					{{ userData.stuName || '' }}
					<view v-if="userData.stuSex" class="feedback flex j-center c-center">
						<image v-if="userData.stuSex == '男'" mode="widthFix" class="feed-img fs0" src="../../static/img/icon_male.png"></image>
						<image v-if="userData.stuSex == '女'" mode="widthFix" class="feed-img fs0" src="../../static/img/icon_female.png"></image>
						{{ userData.stuBirthday || '' }}岁
					</view>
				</view>
				<view class="user-phone">
					手机号：{{ userData.mobile || ''}}
				</view>
			</view>
		</view>
		
		<view v-if="config.isExamine" class="" style="margin: 0 20rpx;">
			<image src="../../static/img/index.png" mode="widthFix" style="width: 100%;"/>
		</view>
		
		<view class="function-list">
			<view @click="handleRouter('/pages/myContract/myContract')" class="function-item flex c-center" >
				<image mode="widthFix" class="item-img fs0" src="../../static/img/icon_contract.png"></image>
				<view class="fg1 value">
					<text>我的合同</text>
				</view>
				<uni-icon class='right-arrow fs0'></uni-icon>
			</view>
			<view @click="handleRouter('/pages/myCourseList/myCourseList')" class="function-item flex c-center" style="border: 0;" >
				<image mode="widthFix" class="item-img fs0" src="../../static/img/icon_myclass.png"></image>
				<view class="fg1 value">
					<text>我的课程</text>
				</view>
				<uni-icon class='right-arrow fs0'></uni-icon>
			</view>
		</view>
			
		<view class="new-course flex">
			最近课程
			<view class="course-tip">
				（仅显示最近3次待上课的课程）
			</view>
		</view>
		<view class="course-wrap">
			<view class="course-item" v-for="(item,index) in newCourseList" :key="index">
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
<!-- 		<view class="course-wrap" v-if="!newOrderDetail">
			<view class="noorder-wrap">
				<image mode="widthFix" class="fs0" src="../../static/img/noorder.png"></image>
			</view>
		</view> -->
		<YLoading ref='loading'></YLoading>
	</view>
</template>

<script>
import {
	token as memberToken,
	GetMemberMobileAjax,
	GetSystemConfigAjax,
	GetMemCourseList,
	token
} from '@/apis/api.js'
export default {
	data() {
		return {
			userData: null,
			newCourseList: null,
			config: null,
			timer: null
		}
	},
	onLoad() {
		this.config = this.$store.state.config.config
		// this.userData = this.$store.state.user.userData
		this.showPageLoading()
		this.init()
	},
	onPullDownRefresh() {
		this.getUserData()
		if(token.value){
			this.getNewOrder()
		}
		setTimeout(() => {
			uni.stopPullDownRefresh()
		}, 1000)
	},
	mounted() {
		
	},
	onShow() {
		this.getUserData()
		if(token.value){
			this.$store.dispatch('getMemssege')
			this.getNewCourse()
		}
	},
	methods: {
		init(){
			this.hidePageLoading()
		},
		// async getConfig() {
		// 	this.config = await this.$store.dispatch('getConfig')
		// },
		// 点击授权
		handleUserInfoClick() {
			// if(this.config.isExamine){
			// 	return false
			// }
			// this.yCheckLogin()
			uni.navigateTo({
				url: '/pages/login/login'
			})
		},
		handleRouter(url) {
			if (!token.value) {
				uni.navigateTo({
					url: '/pages/login/login'
				})
				return false
			}
			uni.navigateTo({
				url
			})
		},
		// 获取用户信息
		getUserData() {
		    this.$store.dispatch('getUserData').then(res => {
		    	this.userData = res
				this.userData.stuBirthday = this.userData.stuBirthday? this.getAge(this.userData.stuBirthday) : ''
		    })
		},
		async GetSystemConfig() {
			this.config = await GetSystemConfigAjax({})
		},
		async getNewCourse() {
			let result = await GetMemCourseList({
				token: true,
				status: 1,
				pageIndex: 1,
				pageSize: 3
			})
			if(!result){
				return false
			}
			this.newCourseList = result.map(item => {
				item.orderDate = item.orderDate?.split(' ')[0]
				return item
			})
			setTimeout(() => {
				this.hidePageLoading()
			}, 1000)
		},
		getAge(strAge) {
			var birArr = strAge.split("-");
			var birYear = birArr[0];
			var birMonth = birArr[1];
			var birDay = birArr[2];

			d = new Date();
			var nowYear = d.getFullYear();
			var nowMonth = d.getMonth() + 1; //记得加1
			var nowDay = d.getDate();
			var returnAge;

			if (birArr == null) {
				return false
			};
			var d = new Date(birYear, birMonth - 1, birDay);
			if (d.getFullYear() == birYear && (d.getMonth() + 1) == birMonth && d.getDate() == birDay) {
				if (nowYear == birYear) {
					returnAge = 0; // 
				} else {
					var ageDiff = nowYear - birYear; // 
					if (ageDiff > 0) {
						if (nowMonth == birMonth) {
							var dayDiff = nowDay - birDay; // 
							if (dayDiff < 0) {
								returnAge = ageDiff - 1;
							} else {
								returnAge = ageDiff;
							}
						} else {
							var monthDiff = nowMonth - birMonth; // 
							if (monthDiff < 0) {
								returnAge = ageDiff - 1;
							} else {
								returnAge = ageDiff;
							}
						}
					} else {
						return  "出生日期晚于今天，数据有误"; //返回-1 表示出生日期输入错误 晚于今天
					}
				}
				return returnAge;
			} else {
				return ("输入的日期格式错误！");
			}
		}
	},
	onPullDownRefresh() {
		if(token.value){
			this.showPageLoading()
			this.getNewCourse()
		}
		setTimeout(() => {
			uni.stopPullDownRefresh()
		}, 1000)
	}
}
</script>

<style lang="scss" scoped>
.clearButton{
	font-size: 28rpx;
	color: #333333;
}
.container {
	background: $bg-color-grey;
	min-height: 100%;
	position: relative;
}
.feedback{
	padding: 0 18upx;
	text-align: center;
	height:48upx;
	line-height:48upx;
	background: #FF777A;
	color: #FFFFFF;
	border-radius:28upx;
	font-size: 28upx;
	font-weight: 500;
	margin-left: 20upx;
	.feed-img {
		width: 32upx;
		height: 32upx;
		margin-right: 4upx;
	}
}
.base-count {
	position: absolute;
	background-color: #FF3939;
	width: 30upx;
	line-height: 30upx;
	text-align: center;
	font-size: 18upx;
	z-index: 1;
	border-radius: $border-radius-circle;
}
.user-info-wrap {
	color: #FFFFFF;
	padding: 30upx 30upx 54upx;
	margin-bottom: 20rpx;
	position: relative;
	background-image: url('../../static/img/bg.png');
	background-size: 100% 100%;
	.user-avatar {
		width: 100upx;
		height: 100upx;
		border-radius: $border-radius-circle;
		margin-right: 20upx;
		background: #EFEFEF;
	}
	.authen{
		position: absolute;
		width: 30upx;
		height: 30upx;
		top: 100upx;
		left: 100upx;
	}
	.user-nickname {
		font-size: 36upx;
		color: #FFFFFF;
		margin-bottom: 10upx;
	}
	.user-phone {
		font-size: 28upx;
		color: #FFFFFF;
	}
	.viewAll{
		font-size: 24upx;
	}
}
.function-list {
	border-radius:20upx;
	box-shadow:0px 2upx 8upx 0px rgba(0,0,0,0.1);
	background: #ffffff;
	margin: 30upx;
	.function-item {
		border-bottom: 1px solid #EFEFEF;
		padding: 30upx 0;
		margin: 0 20upx;
		.item-img{
			width: 40upx;
			height: 40upx;
			margin-right: 20upx;
		}
	}
}
.new-course{
	font-size: 28upx;
	padding: 20upx 20upx 0;
	font-weight: 660;
	padding:0 30upx 30upx;
	color: #333333;
	.course-tip{
		font-size: 24upx;
		color: #999999;
		margin-left: 10upx;
	}
}
.course-wrap{
	// height:552upx;
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
.content-wrap{
	padding: 0 30rpx 10rpx;
	// height: 465rpx;
}
.operate-bar {
	height: 100upx!important;
	line-height: 100upx!important;
}
</style>