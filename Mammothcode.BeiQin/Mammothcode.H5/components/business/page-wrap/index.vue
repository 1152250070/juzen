<template>
	<view class="pages-wrap">
		<myheader ref="myheader" />
		<view class="main-render-view">
			<slot />
		</view>
		<myfoot ref="myfoot" />
	</view>
</template>

<script>
	import myheader from './components/head/index.vue'
	import myfoot from './components/foot/index.vue'
	export default {
		components: {
			myheader,
			myfoot
		},
		data() {
			return {
			}
		},
		mounted() {
		},
		methods: {
		}
	}
</script>

<style lang="scss" scoped>
	.pages-wrap {
		height: 100%;
	}
	.main-render-view {
		padding-top: 100upx;
	}
</style>
