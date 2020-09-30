<template>
	<view class='loading-page-cover' v-show='isShow'>
		<view class="loader" :class="{'show': isShowLoader}">
			<view class="loader-inner">
				<view class="loader-line-wrap">
					<view class="loader-line"></view>
				</view>
				<view class="loader-line-wrap">
					<view class="loader-line"></view>
				</view>
				<view class="loader-line-wrap">
					<view class="loader-line"></view>
				</view>
				<view class="loader-line-wrap">
					<view class="loader-line"></view>
				</view>
				<view class="loader-line-wrap">
					<view class="loader-line"></view>
				</view>
			</view>
		</view>
	</view>
</template>

<script>
	export default {
		name: 'loading',
		data() {
			return {
				isShow: false,
				isShowLoader: false
			}
		},
		methods: {
			showLoading(isPreventTap) {
				this.isShow = true
				setTimeout(() => {
					this.isShowLoader = true
				}, 20)
			},
			hideLoading() {
				this.isShowLoader = false
				setTimeout(() => {
					this.isShow = false
				}, 200)
			}
		}
	}
</script>

<style lang="scss" scoped>
	.loader {
		opacity: 0;
		transition: opacity .3s;
		&.show {
			opacity: 1;
		}
	}
	.loader-inner {
		position: fixed;
		left: 50%;
		top: 50%;
		height: 60upx;
		width: 100upx;
		transform: translateX(-50%) translateY(-50%);
		margin-top: -60upx;
		z-index: 8;
	}

	.loader-line-wrap {
		-webkit-animation:
			spin 2000ms cubic-bezier(.175, .885, .32, 1.275) infinite;
		animation:
			spin 2000ms cubic-bezier(.175, .885, .32, 1.275) infinite;
		box-sizing: border-box;
		height: 50upx;
		left: 0;
		overflow: hidden;
		position: absolute;
		top: 0;
		-webkit-transform-origin: 50% 100%;
		transform-origin: 50% 100%;
		width: 100upx;
	}

	.loader-line {
		border: 4upx solid transparent;
		border-radius: 100%;
		box-sizing: border-box;
		height: 100upx;
		left: 0;
		margin: 0 auto;
		position: absolute;
		right: 0;
		top: 0;
		width: 100upx;
	}

	.loader-line-wrap:nth-child(1) {
		-webkit-animation-delay: -50ms;
		animation-delay: -50ms;
	}

	.loader-line-wrap:nth-child(2) {
		-webkit-animation-delay: -100ms;
		animation-delay: -100ms;
	}

	.loader-line-wrap:nth-child(3) {
		-webkit-animation-delay: -150ms;
		animation-delay: -150ms;
	}

	.loader-line-wrap:nth-child(4) {
		-webkit-animation-delay: -200ms;
		animation-delay: -200ms;
	}

	.loader-line-wrap:nth-child(5) {
		-webkit-animation-delay: -250ms;
		animation-delay: -250ms;
	}

	.loader-line-wrap:nth-child(1) .loader-line {
		border-color: hsl(0, 80%, 60%);
		height: 90upx;
		width: 90upx;
		top: 7upx;
	}

	.loader-line-wrap:nth-child(2) .loader-line {
		border-color: hsl(60, 80%, 60%);
		height: 76upx;
		width: 76upx;
		top: 14upx;
	}

	.loader-line-wrap:nth-child(3) .loader-line {
		border-color: hsl(120, 80%, 60%);
		height: 62upx;
		width: 62upx;
		top: 21upx;
	}

	.loader-line-wrap:nth-child(4) .loader-line {
		border-color: hsl(180, 80%, 60%);
		height: 48upx;
		width: 48upx;
		top: 28upx;
	}

	.loader-line-wrap:nth-child(5) .loader-line {
		border-color: hsl(240, 80%, 60%);
		height: 34upx;
		width: 34upx;
		top: 35upx;
	}

	@-webkit-keyframes spin {

		0%,
		15% {
			-webkit-transform: rotate(0);
			transform: rotate(0);
		}

		100% {
			-webkit-transform: rotate(360deg);
			transform: rotate(360deg);
		}
	}

	@keyframes spin {

		0%,
		15% {
			-webkit-transform: rotate(0);
			transform: rotate(0);
		}

		100% {
			-webkit-transform: rotate(360deg);
			transform: rotate(360deg);
		}
	}
</style>
