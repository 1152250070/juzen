<template>
	<view class="detail-wrap">
		<view class="mask" :class="{'show': isShow}" @click="hide" @touchmove.stop.prevent></view>
		<view class="dialog"
		@touchmove.stop.prevent
		:style="{height: dialogHeight + 'px'}"
		:class="{'show': isShow, 'hide': isToHide}">
			<view id="conten-box">
				<view class="title">
					<text>支付方式</text>
				</view>
				<view class="content-wrap">
					<!-- 支付方式 -->
					<view class="payway-box">
						<view 
						class="pay-item flex c-center"
						@click="handleSelectPayWay(index)"
						v-for="(item, index) in paywayList"
						:key='index'>
							<uni-icon
							class='ic-radio fs0'
							:class="[payType === index ? 'active' : '']"></uni-icon>
							<text>{{ item.text }}</text>
							<text v-if="item.extraText" class="fg1 extra-text">{{ item.extraText }}</text>
						</view>
					</view>
					<!-- 账户信息 -->
					<view class="account-info" v-show="payType === 3">
						<view class="form-item flex c-center">
							<label class="label fs0">账号名称</label>
							<view class="fg1">
								<text>{{ config.bankCompany }}</text>
							</view>
						</view>
						<view class="form-item flex c-center">
							<label class="label fs0">账号</label>
							<view class="fg1">
								<text>{{ config.bankAccount }}</text>
							</view>
						</view>
						<view class="form-item flex c-center">
							<label class="label fs0">开户行</label>
							<view class="fg1">
								<text>{{ config.bankName }}</text>
							</view>
						</view>
					</view>
					<!-- 对公打款 -->
					<view class="form" v-show="payType === 3">
						<view class="form-item">
							<input type="text" v-model='accountInfo.companyName' placeholder="请输入公司名称" />
						</view>
					</view>
				</view>
				<view class="btn-wrap flex c-center">
					<view class="btn-cancel fg1" @click="cancel">
						<text>取消</text>
					</view>
					<view class="btn-cancel fg1" @click="confirm">
						<text>支付</text>
					</view>
				</view>
			</view>
		</view>
	</view>
</template>

<script>
	import {
		GetCompanyAccountAjax
	} from '@/apis/api.js'
	export default {
		data() {
			return {
				isShow: false,
				isToHide: false,
				dialogHeight: 0, // 窗体高度
				accountInfo: {}, // 对公账号信息
				payType: 0,
				paywayList: [{
					text: '微信支付'
				},{
					text:  '余额支付',
					extraText: '（可用余额0元）'
				}],
				config: {}
			}
		},
		watch: {
			payType() {
				this.setDialogHeight(100)
			}
		},
		methods: {
			show() {
				this.isShow = true
				this.setDialogHeight()
				this.setUserBalance()
				this.setConfig()
			},
			hide() {
				this.isToHide = true
				this.isShow = false
				setTimeout(() => {
					this.isToHide = false
				}, 300)
			},
			setUserBalance() {
				this.paywayList[1].extraText = `（可用余额${this.$store.state.user.userData.balanceCash || 0}元）`
			},
			setConfig() {
				this.config = this.$store.state.config.config
			},
			confirm() {
// 				if (this.payType === this.payTypes['对公打款']) {
// 					if (!this.accountInfo.companyName) {
// 						uni.showToast({
// 							title: '请填写公司名称'
// 						})
// 						return false
// 					}
// 				}
				this.$emit('confirm', {
					payWay: this.payType,
					accountInfo: this.accountInfo
				})
			},
			cancel() {
				this.hide()
			},
			// 设置高度
			setDialogHeight(delay = 300) {
				setTimeout(() => {
					const query = uni.createSelectorQuery().in(this)
					query.select(`#conten-box`).boundingClientRect(data => {
						this.dialogHeight = data.height
					}).exec()
				}, delay)
			},
			// 支付方式
			handleSelectPayWay(index) {
				this.payType = index * 1
				if (this.payType === 3) {
					this.getCompanyAccountInfo()
				}
			},
			// 获取对公信息
			async getCompanyAccountInfo() {
				if (this.accountInfo.id) {
					return false
				}
				let accountInfo = await GetCompanyAccountAjax({
					token: true
				})
				this.accountInfo = accountInfo || {}
			}
		}
	}
</script>

<style lang="scss" scoped>
.mask {
	position: fixed;
	top: 0;
	left: 0;
	right: 0;
	bottom: 0;
	background-color: $bg-color-mask;
	transition: all .3s;
	visibility: hidden;
	opacity: 0;
	z-index: 8;
	&.show {
		visibility: visible;
		opacity: 1;
	}
}
.dialog {
	background-color: #fff;
	position: fixed;
	top: 46%;
	right: 30upx;
	left: 30upx;
	opacity: 0;
	transform: translateY(-50%) scale(1.1);
	transition: all .3s;
	visibility: hidden;
	border-radius: $border-radius-xlg;
	z-index: 9;
	overflow: hidden;
	&.show {
		visibility: visible;
		opacity: 1;
		transform: translateY(-50%) scale(1);
	}
	&.hide {
		visibility: visible;
		opacity: 0;
		transform: translateY(-50%) scale(.8);
	}
}
.title {
	font-size: $font-size-lg;
	padding: 30upx 0 20upx;
	text-align: center;
	font-weight: bold;
}
// 支付方式
.payway-box {
	.pay-item {
		padding: 0 40upx 30upx;
	}
	.ic-radio {
		margin-right: 20upx;
	}
	.extra-text {
		color: #999999;
	}
}

// 对公打款
.form {
	.form-item {
		font-size: $font-size-base;
		background-color: #ECECEC;
		color: #999999;
		padding: 24upx 20upx;
		border-radius: $border-radius-base;
		margin: 0 40upx 30upx;
	}
}
.account-info {
	.form-item {
		margin: 0 40upx 30upx;
		label {
			width: 186upx;
			text-indent: 50upx;
		}
	}
}
.btn-wrap {
	border-top: 1px solid #E5E5E5;
	line-height: 100upx;
}
.btn-cancel {
	font-size: $font-size-lg;
	color: $color-theme-bg;
	text-align: center;
	&+.btn-cancel {
		border-left: 1px solid #E5E5E5;
	}
}
</style>