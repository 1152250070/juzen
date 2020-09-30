<template>
	<view class='tabs flex c-center' :style="{backgroundColor: background}">
		<view class="tabs-item fg1"
		:class="{'active' : currentTab === index}"
		v-for="(item, index) in tabs"
		:key="index"
		@click="onSetTab(index)">
			<text :id="'tab' + index">{{ item.text }}</text>
			<image v-if="item.isRank&&item.isTop" class="rankImg" mode='aspectFill' src='../../static/img/detail/icon_rankt.png'></image>
			<image v-if="item.isRank&&!item.isTop" class="rankImg" mode='aspectFill' src='../../static/img/detail/icon_rankb.png'></image>
		</view>
		<view v-if="isShow"
		class="active-bar"
		:style="{left: activeBar.left, right: activeBar.right, backgroundColor: barColor}"></view>
	</view>
</template>

<script>
	export default {
		props: {
			tabs: {
			  type: Array,
			  default: () => []
			},
			current: {
			  type: Number,
			  default: 0
			},
			background: {
				type: String,
				default: '#fff'
			},
			color: {
				type: String,
				default: '#fff'
			},
			barColor: {
				type: String,
				default: '#fff'
			},
			left: {
				type: Number,
				default: 0
			},
			right: {
				type: Number,
				default: 0
			}
		},
		computed: {

		},
		data() {
			return {
				isShow: false,
				currentTab: 0,
				activeBar: {
				  left: 0,
				  right: 0
				}
			}
		},
		watch: {
			current(val) {
				this.currentTab = val
				this.setActiveBar()
			}
		},
		onReady() {
			this.currentTab = this.current
			this.setActiveBar()
		},
		methods: {
			onSetTab(index) {
			  index = index * 1
			  let currentTab = this.currentTab
			  if (index === currentTab) {
				  if(this.tabs[index].isRank){
					  let tabs = this.tabs
					  tabs[index].isTop = !tabs[index].isTop
					  this.$emit('update:tabs', tabs)
				  }else{
					  return false
				  }
			  }
			  this.currentTab = index
			  this.setActiveBar(index < currentTab ? "left" : "right")
			  this.$emit('change', index)
			},
			setActiveBar: function (direction) {
				const query = uni.createSelectorQuery()
				query.select(`#tab >>> #tab${this.currentTab}`).boundingClientRect(rect => {
					if (!rect) {
						return
					}
					let left = rect.left - uni.upx2px(this.left) + 'px'
					let right = this.$store.state.system.systemInfo.windowWidth - uni.upx2px(this.right) - rect.right + 'px'
					if (direction) {
					  if (direction === 'left') {
						this.activeBar.left = left
						setTimeout(() => {
							this.activeBar.right = right
						}, 75)
					  } else {
						this.activeBar.right = right
						setTimeout(() => {
						  this.activeBar.left = left
						}, 75)
					  }
					} else {
					  this.activeBar.left = left
					  this.activeBar.right = right
					}
					this.isShow = true
				}).exec()
			}
		}
	}
</script>

<style lang="scss">
.tabs {
  height: 90upx;
  line-height: 90upx;
  left: 0;
  right: 0;
  background-color: #fff;
  font-size: 26upx;
  text-align: center;
  position: relative;
  z-index: 2;
  border-bottom: 1rpx solid #F5F5F5;
  .tabs-item {
	height: 100%;
	color: #FFFFFF;
	.rankImg{
		width: 16rpx;
		height: 22rpx;
		margin-left: 10rpx;
	}
  }
}
.tabs .tabs-item text {
	opacity: 0.7;
	font-size: 30upx;
}
.tabs .tabs-item.active {
  font-size: 33upx;
  font-weight: bold;
  color: #FFFFFF;
}
.tabs .tabs-item.active text {	
  opacity: 1;
  font-size: 33upx;
}

.active-bar {
  position: absolute;
  bottom: 0;
  height: 6upx;
  left: 0;
  right: 10upx;
  transition: left .15s, right .15s;
}
</style>
