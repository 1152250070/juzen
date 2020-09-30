<template>
    <view class="page-wrap">
        <view class="head-wrap flex c-center">
            <image class="img" src="/static/imgs/img1.png" />
            <text class="text">时尚育儿</text>
        </view>
        <view class="tool-wrap">
            <view class="tool flex-between c-center" @click="goUrl('/pages/info/index')">
                <view class="left flex c-center">
                    <image class="img" src='/static/imgs/icon_personal-data@3x.png' />
                    编辑个人资料
                </view>
                <image class="right" src="/static/imgs/icon_go@3x.png" />
            </view>
            <view class="tool flex-between c-center" @click="goUrl('/pages/history/index')">
                <view class="left flex c-center">
                    <image class="img" src='/static/imgs/icon_history@3x.png' />
                    观看记录
                </view>
                <image class="right" src="/static/imgs/icon_go@3x.png" />
            </view>
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
            goUrl(url) {
                uni.navigateTo({
                    url: url
                })
            }
        }
	}
</script>

<style lang="scss" scoped>
.head-wrap {
    width: 750upx;
    height: 180upx;
    background: #D6544F;
    .img {
        width: 100upx;
        height: 100upx;
        border-radius: 50%;
        margin-left: 30upx;
    }
    .text {
        font-size: 32upx;
        font-weight: 500;
        color: #FFFFFF;
        margin-left: 20upx;
    }
}
.tool-wrap {
    padding: 0 30upx;
    .tool {
        padding: 30upx 0;
        border-bottom: 2upx solid #EFEFEF;
        font-size: 32upx;
        color: #333333;
        .left {
            .img {
                width: 44upx;
                height: 44upx;
                margin-right: 20upx;
            }
        }
        .right {
            width: 36upx;
            height: 36upx;
        }
    }
}
</style>
