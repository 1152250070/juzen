<template>
	<view class="user-comment-imgs">
		<view 
		class="comment-img-item"
		v-for="(item, index) in imgsShowList"
		@click="handlePreview(index)"
		:key='index'>
			<image
			class="comment-img"
			:src="item"
			mode="aspectFit"></image>
			<view class="img-mask" v-if="leftL && index === 2">
				<text>还剩{{leftL}}张</text>
			</view>
		</view>
	</view>
</template>

<script>
	export default {
		props: {
			imgs: {
				type: String,
				default: ''
			}
		},
		computed: {
			imgsList() {
				return this.imgs ? this.imgs.split(',') : []
			},
			imgsShowList() {
				return this.imgsList.slice(0, 3)
			},
			leftL() {
				return this.imgsList.length - this.imgsShowList.length
			}
		},
		methods: {
			handlePreview(index) {
				uni.previewImage({
					current: index,
					urls: this.imgsList
				})
			}
		}
	}
</script>

<style lang="scss">
.user-comment-imgs {
	font-size: 0;
	.comment-img-item {
		display: inline-block;
		vertical-align: top;
		position: relative;
		width: 210upx;
		height: 210upx;
		.comment-img {
			width: 100%;
			height: 100%;
		}
		.img-mask {
			background-color: rgba(0, 0, 0, .5);
			position: absolute;
			top: 0;
			left: 0;
			right: 0;
			bottom: 0;
			text-align: center;
			color: #fff;
			font-size: $font-size-base;
			line-height: 210upx;
		}
		&+.comment-img-item {
			margin-left: 30upx;
		}
	}
}
</style>
