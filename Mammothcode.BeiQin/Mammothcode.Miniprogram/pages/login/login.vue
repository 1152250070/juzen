<template>
	<view class="container">
		<view class="flex flex-direction">
			<image mode="widthFix" class="top-img fs0" src="../../static/img/top-img.png"></image>
			<view class="login-title">
				欢迎来到蒙特梭利
			</view>
		</view>
		<view v-if="type == 1" class="form">
			<view class="form-item flex c-center">
				<view class="icon-img">
					手机号
				</view>
				<input class="fg1" type="number" v-model="formData.mobile" placeholder="请输入购买课程时预留的手机号码" />
			</view>
			<view class="form-item flex c-center" style="padding: 20rpx;">
				<view class="icon-img">
					验证码
				</view>
				<input class="fg1" type="text" v-model="formData.vCode" placeholder="请输入验证码" />
				<timebtn @click='handleClickTime' class='btn-time fs0' ref='timebtn'></timebtn>
			</view>
		</view>

		<button v-if="type == 0" class="clearButton btn-login" open-type="getUserInfo" @getuserinfo="getuserinfo">
			微信授权登录
		</button>
		<view v-if="type == 1" class="clearButton btn-login" @click="handleClickLogin">
			会员登录
		</view>
		<view class="flex flex-direction">
			<image mode="widthFix" class="bot-img fs0" src="../../static/img/bot-img.png"></image>
		</view>
		<YLoading ref='loading'></YLoading>
	</view>
</template>

<script>
	import {
		token,
		RegisterAjax,
		SendMemberVerificationCodeAjax
	} from '@/apis/api.js'
	import timebtn from '@/components/base/timebtn.vue'
	export default {
		components: {
			timebtn
		},
		data() {
			return {
				formData: {
					mobile: '',
					vCode: null
				},
				userData: {
					nickName: null,
					headImg: null,
					jsCode: null
				},
				type: 0
			}
		},
		onLoad() {

		},
 		methods: {
			async handleClickTime() {
				let formData = this.formData
				if (!this.validForm(formData, [
					{
						key: 'mobile',
						text: '请输入手机号',
					},
					{
						key: 'mobile',
						text: '请输入正确的手机号',
						verify: 'mobile'
					}
				])) {
					return
				}
				await SendMemberVerificationCodeAjax({
					// token: true,
					mobile: formData.mobile
				})
				this.$refs.timebtn.startRun()
				uni.showToast({
					title: '请注意查收',
					icon: 'none'
				})
			},
			getuserinfo(res) {
				let _this =  this
				this.showPageLoading()
				//拿到用户基本信息
				uni.login({
					//拿到code
					provider: 'weixin'
				}).then(res1 => {
					this.hidePageLoading()
					uni.showToast({
						title: '微信授权成功',
						icon: 'none'
					})
					this.$store.dispatch('getUserData').then(res2 => {
						if(res2){
							setTimeout(() => {
								uni.switchTab({
									url: '/pages/user/user'
								})
							}, 1000)
						} else {
							this.userData = {
								nickName: res.detail.userInfo.nickName,
								headImg: res.detail.userInfo.avatarUrl,
								jsCode: res1[1].code
							}
							setTimeout(() => {
								this.type = 1
							}, 500)
						}
					})
					
				})
				
				
			},
			async handleClickLogin() {
				let formData =  this.formData
				if (!this.validForm(formData, [
					{
						key: 'mobile',
						text: '请输入手机号'
					},
					{
						key: 'mobile',
						text: '请输入正确的手机号',
						verify: 'mobile'
					},
					{
						key: 'vCode',
						text: '请输入验证码'
					}
				])) {
					return
				}
				this.showPageLoading()
				let result = await RegisterAjax({
					...this.formData,
					...this.userData
				}).then(async res2 => {
					token.setValue(res2.token)
					this.hidePageLoading()
					uni.showToast({
						title: '登录成功',
						icon: 'none'
					})
					setTimeout(() => {
						uni.switchTab({
							url: '/pages/user/user'
						})
					}, 1000)
				})
			}
		}
	}
</script>

<style lang="scss" scoped>
.container {
	background: #FFFFFF;
	min-height: 100%;
}
@import "@/style/business/login.scss";
.top-img{
	margin: 60upx auto 0;
	width:390upx;
	height:428upx;
}
.login-title{
	font-weight: 600;
	font-size: 40upx;
	color: #091B37;
	margin: 40upx 0;
	text-align: center;
}
.type_switch{
	color: #999999;
}
.register{
	float: right;
	margin-top: 20rpx;
	color: #999999;
}
.icon-img{
	width: 150upx;
	height: 32upx;
	margin-right: 16upx;
	image{
		width: 100%;
		height: 100%;
	}
}
.btn-time {
	display: block;
	width: 190upx;
	line-height: 60upx;
	margin-left: 20upx;
	border-radius: $border-radius-base;
	text-align: center;
	// background-color: $theme-color;
	color: #4255B3;
	border:2upx solid #4255B3;
	font-size: $font-size-base;
}
.bot-img{
	width:372upx;
	height:80upx;
	margin: 40upx auto;
}
</style>
