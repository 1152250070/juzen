<template>
	<view class="btn-time-out">
		<text v-if="!timeNum" @click="handleStartRun">{{ text }}</text>
		<text v-else>{{timeNum}}s</text>
	</view>
</template>

<script>
	export default {
		props: {
			text: {
				type: String,
				default: '获取验证码'
			},
			time: {
				type: Number,
				default: 180
			}
		},
		data() {
			return {
				timer: null,
				timeNum: 0
			}
		},
		methods: {
			reset() {
				this.clearTimer()
				this.timeNum = 0
			},
			handleStartRun() {
				if (!this.timeNum) {
					this.$emit('click')
				}
			},
			startRun() {
				this.timeNum = this.time
				this.timer = setInterval(() => {
					if (!--this.timeNum) {
						this.clearTimer()
						this.timeNum = 0
					}
				}, 1000)
			},
			clearTimer() {
				clearInterval(this.timer)
				this.timer = null
			}
		}
	}
</script>

<style>
</style>
