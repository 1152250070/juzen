<template>
	<view class="head flex-between c-center">
		<image src="/static/img/logo.png" mode="aspectFill" />
	</view>
</template>

<script>
	export default {
		data() {
			return {
			}
		},
		methods: {

		}
	}
</script>

<style lang="scss" scoped>
	.head {
		@include fixed-top-area;
		background-color: $theme-color;
		height: 100upx;
		color: #fff;
		padding: 0 20upx;
		z-index: 9999;
		image {
			width: 188upx;
			height: 42upx;
		}
		.iconfont {
			font-size: 48upx;
		}
	}
	
</style>
