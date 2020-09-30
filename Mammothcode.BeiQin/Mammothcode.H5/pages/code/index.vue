<template>
    <view class="page-wrap">
        <image class="code" src="" />
        <view class="btn flex-center">扫码关注公众号</view>
    </view>
</template>

<script>
    import {

    } from '@/apis/api.js'

	export default {
		data() {
			return {

			}
		},
		onLoad() {
            
        },
        computed: {

        },
        watch: {

        },
		methods: {
            
        }
	}
</script>

<style lang="scss" scoped>
.code {
    display: block;
    width: 410upx;
    height: 410upx;
    background: #D8D8D8;
    margin: 234upx auto 72upx;
}
.btn {
    width: 410upx;
    height: 88upx;
    box-shadow: 0px 4upx 16upx 0px rgba(0, 0, 0, 0.1);
    border-radius: 44upx;
    border: 2upx solid #D6544F;
    font-size: 28upx;
    font-weight: 500;
    color: #D6544F;
    margin: 0 auto;
}
</style>
