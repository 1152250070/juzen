<template>
	<view class="footer">
		<!-- <tabBar /> -->
		<!-- <view class="img-wrap">
			<image src="/static/img/logo.png" mode="aspectFill"></image>
		</view>
		<view class="footer-text">
			波尔管道源自德国，专业从事塑料管道系统的研发和制造。公司始创于1996年，将PP-R管道生产技术引入中国，并开始在国内设立生产基地，是中国最早生产PP-R管道的企业之一，填补了浙江省空白。
		</view>
		<view class="copyrights">
			Copyright©1996-2020 All Rights Reserved. 宁波波尔管业开发有限公司 版权所有 浙ICP备11065979号-1
		</view> -->
	</view>
</template>

<script>
	import { mapGetters } from 'vuex'
	export default {
		computed: {
			...mapGetters([
				'config'
			])
		}
	}
</script>

<style lang="scss" scoped>
	.footer {
		background-color: $theme-color;
		padding: 0 20upx;
		color: #fff;
		margin-bottom: 50px;
		.img-wrap {
			font-size: 0;
			text-align: center;
			padding-top: 40upx;
		}
		image {
			width: 284upx;
			height: 64upx;
		}
		.footer-text {
			margin-top: 30upx;
			font-size: $font-size-sm;
			line-height: 40upx;
			letter-spacing: 1upx;
		}
		.copyrights {
			margin-top: 30upx;
			padding: 30upx 0;
			text-align: center;
			border-top: 2upx solid rgba(255, 255, 255, .25);
			font-size: $font-size-xsm;
		}
	}
</style>
