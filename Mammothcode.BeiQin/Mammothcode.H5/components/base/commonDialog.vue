<!-- 这是一个弹对话框的组件 -->
<template>
	<view class="detail-wrap" :style="{ fontSize: globalData.fontSize,color:globalData.fontColor }">
		<!--@touchmove.stop.prevent蒙版不会点击穿透-->
		<view class="mask" :class="{'show': isShow}" @click="hide" @touchmove.stop.prevent></view>
		<view class="dialog"
        @touchmove.stop.prevent
        :style="{height: dialogHeight + 'px'}"
        :class="{'show': isShow, 'hide': isToHide}">
			<view id="conten-box">
				<image class="ic-close" @click="hide" src="/static/h5img/icon_del2@3x.png" mode="widthFix" />
				<view class="title">
					<text>{{ title }}</text>
				</view>
				<slot></slot>
				<view class="operate-bar flex c-center">
					<view class="fg1" @click="hide">
						<text>{{ cancelTitle }}</text>
					</view>
					<view class="fg1" @click="handleConfirm" v-if="showConfirm">
						<text :style="{ color:globalData.barColor }">{{ confirmTitle }}</text>
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
                globalData: null
			}
        },
        created() {
            this.globalData = getApp().globalData
        },
		methods: {
			handleConfirm() {
				this.$emit('confirm')
			},
			show() {
				this.isShow = true
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
		transition: all .3s; //过渡效果
		visibility: hidden;
		opacity: 0;
		z-index: 8;

		&.show {
			visibility: visible;
			opacity: 1; //灰色一般不可见,动态属性show===true时可见
		}
	}
	.dialog {
		background-color: #fff;
		position: fixed;
		top: 45%;
		right: 30upx;
		left: 30upx;
		opacity: 0;
		transform: translateY(-50%) scale(1.1);
		transition: all .3s;
		visibility: hidden;
		border-radius: $border-radius-xlg;
		z-index: 100;
		overflow: hidden;
        display: none;
		&.show {
            display: block;
			visibility: visible;
			opacity: 1;
			transform: translateY(-50%) scale(1);
		}

		&.hide {
			visibility: visible;
			opacity: 0;
			transform: translateY(-50%) scale(.8);
		}

		.ic-close {
			position: absolute !important;
			z-index: 1;
			width: 40upx;
			height: 40upx;
			right: 30upx;
			top: 30upx;
		}
	}

	.title {
		font-size: 115%;
		text-align: center;
		padding: 30upx 44upx;
		font-weight: bold;
	}

	.operate-bar {
		height: 104upx;
		line-height: 104upx;
		border-top: 1px solid $border-color;
		color: $theme-color;
		text-align: center;
		font-size: 115%;

		.fg1 {
			height: 100%;

			&+.fg1 {
				border-left: 1px solid $border-color;
			}
		}
	}
</style>
