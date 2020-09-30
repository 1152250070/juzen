<template>
	<view class="detail-wrap">
		<view class="mask" :class="{'show': isShow}" @click="hide" @touchmove.stop.prevent></view>
		<view class="dialog"
		@touchmove.stop.prevent
		:style="{height: dialogHeight + 'px'}"
		:class="{'show': isShow, 'hide': isToHide, 'centerdialog': isCenter}">
			<view id="conten-box">
				<image class="ic-close" @click="hide" src="/static/img/ic-close.png" mode="widthFix"></image>
				<view class="title">
					<text>{{ title }}</text>
				</view>
				<slot></slot>
				<view class="operate-bar flex c-center" v-if="showConfirm">
					<view class="fg1" @click="hide" v-if="showCancel" style="background: #FFFFFF;color: #999999;">
						<text>{{ cancelTitle }}</text>
					</view>
					<view class="fg1" @click="handleConfirm" v-if="showConfirm">
						<text>{{ confirmTitle }}</text>
					</view>
				</view>
			</view>
		</view>
	</view>
</template>

<script>
	export default {
		props: {
			title: {
				type: String,
				default: '提示'
			},
			confirmTitle: {
				type: String,
				default: '确定'
			},
			cancelTitle: {
				type: String,
				default: '取消'
			},
			showCancel: {
				type: Boolean,
				default: false
			},
			showConfirm: {
				type: Boolean,
				default: true
			}
		},
		data() {
			return {
				isShow: false,
				isToHide: false,
				dialogHeight: 0, // 窗体高度
				isCenter: false
			}
		},
		methods: {
			handleConfirm() {
				this.$emit('confirm')
			},
			show() {
				this.isShow = true
				this.setDialogHeight()
			},
			showCenter() {
				this.isShow = true
				this.isCenter = true
				this.setDialogHeight()
			},
			hide() {
				this.isToHide = true
				this.isShow = false
				setTimeout(() => {
					this.isToHide = false
					this.dialogHeight = 0
				}, 200)
			},
			// 设置高度
			setDialogHeight(delay = 300) {
				setTimeout(() => {
					const query = uni.createSelectorQuery().in(this)
					query.select(`#conten-box`).boundingClientRect(data => {
						this.dialogHeight = data.height
					}).exec()
				}, delay)
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
.centerdialog {
	// transform: translateY(-50%) scale(1.1);
	bottom: 40%!important;
	margin: 0 30rpx!important;
	border-radius: 16rpx!important;
}
.dialog {
	background-color: #fff;
	position: fixed;
	// top: 65%;
	bottom: 0;
	right: 0;
	left: 0;
	opacity: 0;
	// transform: translateY(-50%) scale(1.1);
	transition: all .3s;
	visibility: hidden;
	border-radius: $border-radius-xlg $border-radius-xlg 0 0;
	z-index: 9;
	overflow: hidden;
	padding-bottom: 30upx;
	&.show {
		visibility: visible;
		opacity: 1;
		// transform: translateY(-50%) scale(1);
	}
	&.hide {
		visibility: visible;
		opacity: 0;
		// transform: translateY(-50%) scale(.8);
	}
	.ic-close {
		position: absolute;
		z-index: 1;
		width: 40upx;
		height: 40upx;
		right: 30upx;
		top: 30upx;
	}
}
.title {
	font-size: $font-size-lg;
	text-align: center;
	padding: 30upx 44upx;
	font-weight: bold;
}
.operate-bar {
	height: 86upx;
	line-height: 86upx;
	border-top: 1px solid $border-color;
	background:rgba(94,169,255,1);
	border-radius:50upx;
	margin: 30rpx;
	color: #FFFFFF;
	text-align: center;
	font-size: $font-size-base;
	.fg1 {
		height: 100%;
		&+.fg1 {
			border-left: 1px solid $border-color;
		}
	}
}
</style>