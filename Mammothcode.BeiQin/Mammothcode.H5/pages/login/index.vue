<template>
    <view class="page-wrap">
        <image class="logo" src="/static/imgs/logo@3x.png" />
        <view class="title">欢迎来到贝亲</view>
        <view class="btn flex-center">
            <image class="img" src="/static/imgs/icon_wechat@3x.png" />
            <text class="text">微信授权登录</text>
        </view>
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
.logo {
    display: block;
    width: 450upx;
    height: 138upx;
    margin: 280upx auto 50upx;
}
.title {
    font-size: 36upx;
    font-weight: 500;
    text-align: center;
}
.btn {
    width: 410upx;
    height: 88upx;
    margin: 80upx auto 0;
    background: #D6544F;
    border-radius: 44upx;
    font-size: 28upx;
    font-weight: 500;
    color: #FFFFFF;
    .img {
        width: 32upx;
        height: 32upx;
        margin-right: 10upx;
    }
    .text {
        line-height: 40upx;
    }
}
</style>
