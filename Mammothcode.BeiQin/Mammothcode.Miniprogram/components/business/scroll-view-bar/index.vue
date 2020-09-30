<template>
	<view class="scroll-view-bar-wrap">
		<view class="scroll-view-bar">
			<text class="scroll-bar" :style="{ left }"></text>
		</view>
	</view>
</template>

<script>
	export default {
		props: {
			width: {
				type: Number,
				default: 100
			},
			gap: {
				type: Number,
				default: 0
			},
			total: {
				type: Number,
				default: 0
			},
			initWidth: {
				type: Number,
				default: 0
			},
			scrollLeft: {
				type: Number,
				default: 0
			}
		},
		data() {
			return {
				leftScrollBar: uni.upx2px(120 - 40)
			}
		},
		computed: {
			totalWidth() {
				return this.total * (this.width + this.gap) - this.gap
			},
			leftScrollWidth() {
				return uni.upx2px(this.totalWidth - this.initWidth)
			},
			left() {
				return this.scrollLeft / this.leftScrollWidth * this.leftScrollBar + 'px'
			}
		}
	}
</script>

<style lang="scss" scoped>
	.scroll-view-bar-wrap {
		text-align: center;
	}
	.scroll-view-bar {
		display: inline-block;
		background-color: #EAEAEA;
		height: 10upx;
		border-radius: 10upx;
		position: relative;
		width: 120upx;
		overflow: hidden;
	}
	.scroll-bar {
		position: absolute;
		left: 0;
		top: 0;
		height: 100%;
		background-color: $theme-color;
		width: 40upx;
		border-radius: 10upx;
	}
</style>
