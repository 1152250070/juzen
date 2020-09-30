<template>
	<view class="btn-home" @click="handleSwitchTab" v-if="isShow">
		<text>首页</text>
	</view>
</template>

<script>
	export default {
		data() {
			return {
				isShow: false
			}
		},
		created() {
			this.isShow = getCurrentPages().length === 1
		},
		methods: {
			handleSwitchTab() {
				uni.switchTab({
					url: '/pages/index/index'
				})
			}
		}
	}
</script>

<style lang="scss">
	.btn-home {
		position: fixed;
		bottom: 200upx;
		right: 40upx;
		background-color: $theme-color;
		width: 100upx;
		line-height: 100upx;
		border-radius: $border-radius-circle;
		text-align: center;
		color: #fff;
		font-size: $font-size-base;
	}
</style>
