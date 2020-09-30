<template>
	<view class="upload-container">
		<view class="upload-wrap" @click="handleChooseImage" v-if="!mult">
			<image v-show="src" :src="src" mode="aspectFit"></image>
			<view v-show='!src' class="upload-tip">
				<image :src='`/static/img/icon_add.png`' mode="aspectFit"></image>
			</view>
		</view>		
		<view class="mult-upload-wrap" v-else>
			<view 
			class="upload-wrap"
			v-for="(item, index) in src"
			:key='index'
			@click="handleChooseImageMult(index)">
				<image v-show='item' @click.stop="handleDelImage(index)" class="close" :src='`/static/img/close.png`' mode="aspectFit"></image>
				<image v-show="item" :src="item" mode="aspectFit"></image>
				<view v-show='!item' class="upload-tip">
					<image :src='`/static/img/icon_add.png`' mode="aspectFit"></image>
				</view>
			</view>	
		</view>
	</view>
</template>

<script>
export default {
	props: {
		value: {
			type: String,
			default: ''
		},
		mult: { // 多图上传
			type: Boolean,
			default: false
		}
	},
	watch: {
		value(val) {
			this.setSrc(val)
		}
	},
	data() {
		return {
			src: ''
		}
	},
	render() {
		
	},
	mounted() {
		this.setSrc(this.value)
	},
	methods: {
		// 多图
		handleChooseImageMult(index) {
			let src = this.src
			let isReplace = index !== src.length - 1
			uni.chooseImage({
				count: isReplace ? 1 : 9,
				success: res => {
					let tempFilePaths = res.tempFilePaths
					if (isReplace) {
						this.src[index] = tempFilePaths[0]
					} else {
						this.src.splice(index, 1, ...tempFilePaths)
					}
					this.$emit('input', this.src.filter(item => item).join(','))
				}
			})
		},
		handleChooseImage() {
			uni.chooseImage({
				count: 1,
				success: res => {
					this.src = res.tempFilePaths[0]
					this.$emit('input', this.src)
				}
			})
		},
		handleDelImage(index) {
			this.src.splice(index, 1)
			this.$emit('input', this.src.filter(item => item).join(','))
		},
		setSrc(val) {
			if (this.mult) {
				if (!val) {
					this.src = ['']
				} else {
					let src = val.split(',')
					src.push('')
					this.src = src
				}
			} else {
				this.src = val
			}
		}
	}
}
</script>

<style lang="scss" scoped>
.upload-container{
	position: relative;
}
.mult-upload-wrap {
	font-size: 0;
	.upload-wrap {
		display: inline-block;
		vertical-align: top;
		margin-bottom: 30upx;
		margin-left: 30upx;
		&:nth-child(3n + 1) {
			margin-left: 0;
		}
	}
}
.upload-wrap {
	width: 190upx;
	height: 190upx;
	border-radius: 10upx;
	position: relative;
	&>image {
		width: 100%;
		height: 100%;
	}
	.close{
		width: 30upx;
		height: 30upx;
		position: absolute;
		top: -10upx;
		right: -10upx;
	}
// 	&:last-child .close{
// 		display: none;
// 	}
	&>.upload-tip {
		text-align: center;
		width: 100%;
		height: 100%;
		line-height: 180upx;
		box-sizing: border-box;
		border: 1px dashed #CECECE;
		font-size: 80upx;
		color: #ccc;
		border-radius: 10rpx;
		image{
			width: 100%;
			height: 64%;
			display: block;
			margin-top: 34rpx;
		}
	}
}
</style>
