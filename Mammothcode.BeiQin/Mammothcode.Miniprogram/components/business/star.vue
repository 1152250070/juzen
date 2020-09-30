<template>
	<view class="star-box">
		<view class="star-item" v-for="(item, index) in starList" :key='index' @click="handleSetStar(index)">
			<image :src="item" mode="widthFix"></image>
		</view>
	</view>
</template>

<script>
	export default {
		props: {
			total: {
				type: Number,
				default: 10
			},
			min: {
				type: Number,
				default: 1
			},
			value: {
				type: Number,
				default: 0
			},
			clickable: {
				type: Boolean,
				default: false
			}
		},
		computed: {
			starList() {
				let list = []
				for (let i=0;i<this.total;i++) {
					list.push(i <= this.value - 1 ? '/static/img/collected.png' : '/static/img/collection.png')
				}
				return list
			}
		},
		methods: {
			handleSetStar(index) {
				if (this.clickable && (index + 1) >= this.min) {
					this.$emit('input', index + 1)
				}
			}
		}
	}
</script>

<style lang="scss">
.star-box {
	font-size: 0;
	.star-item {
		display: inline-block;
		vertical-align: top;
		width: 50upx;
		height: 50upx;
		margin: 0 2upx;
		image {
			width: 100%;
			height: 100%;
		}
	}
}
</style>
