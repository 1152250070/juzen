<template>
    <view class="page-wrap">
        <image class="banner-wrap" src="/static/imgs/banner@3x.png" />
        <view class="title-wrap">
            <view class="text">最新课程</view>
            <view class="line"></view>
        </view>
        <view class="list-wrap">
            <view class="new-item" v-for="(item, index) in 1" :key="index" @click="goDetail(item)">
                <view class="cover"></view>
                <view class="title">母乳喂养需知</view>
                <image class="btn" src="/static/imgs/icon_play@3x.png" />
                <view class="footer flex-between c-center">
                    <text>2020.02.29 上午10:00:00</text>
                    <text>独家直播LIVE</text>
                </view>
            </view>
        </view>
        <view class="title-wrap">
            <view class="text">热门课程</view>
            <view class="line"></view>
        </view>
        <view class="list-wrap">
            <view class="hot-item" v-for="(item, index) in 2" :key="index" @click="goDetail(item)">
                <view class="title">母乳喂养需知</view>
                <image class="post" src="/static/imgs/banner2.png" />
                <view class="footer flex-between c-center">
                    <view class="left flex">
                        <view class="tip flex c-center">
                            <image class="img" src="/static/imgs/icon_view@3x.png" /> 9999
                        </view>
                        <view class="tip flex c-center">
                            <image class="img" src="/static/imgs/icon_like@3x.png" /> 9999
                        </view>
                    </view>
                    <view class="right flex-center">立即观看</view>
                </view>
            </view>
        </view>
        <image class="btn-wrap" src="/static/imgs/tab3@3x.png" @click="goUser" />
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
            goUser() {
                uni.navigateTo({
                    url: '/pages/my/index'
                })
            },
            goDetail(item) {
                uni.navigateTo({
                    url: '/pages/detail/index'
                })
            }
        }
	}
</script>

<style lang="scss" scoped>
.page-wrap {
    padding-bottom: 30upx;
    box-sizing: border-box;
}
.banner-wrap {
    width: 750upx;
    height: 1000upx;
}
.title-wrap {
    font-size: 36upx;
    font-weight: 500;
    padding: 0 30upx;
    margin-top: 60upx;
    .line {
        width: 690upx;
        height: 4upx;
        background: linear-gradient(270deg, rgba(255, 255, 255, 0) 0%, #D6544F 100%);
        border-radius: 4upx;
        margin-top: 10upx;
    }
}
.list-wrap {
    padding: 0 30upx;
    .new-item {
        position: relative;
        width: 690upx;
        height: 380upx;
        box-shadow: 0px 4upx 8upx 0px rgba(0, 0, 0, 0.1);
        border-radius: 20upx;
        margin-top: 30upx;
        background-image: url('/static/imgs/banner2.png');
        background-size: cover;
        .cover {
            position: absolute;
            width: 100%;
            height: 100%;
            background: #000000;
            border-radius: 20upx;
            opacity: 0.35;
        }
        .title {
            position: absolute;
            left: 20upx;
            top: 20upx;
            font-size: 32upx;
            font-weight: 500;
            color: #FFFFFF;
        }
        .btn {
            position: absolute;
            left: 300upx;
            top: 146upx;
            width: 90upx;
            height: 90upx;
        }
        .footer {
            position: absolute;
            left: 0upx;
            right: 0upx;
            bottom: 0upx;
            height: 72upx;
            background: #D6544F;
            color: #FFFFFF;
            font-size: 28upx;
            border-radius: 0 0 20upx 20upx;
            padding: 0 20upx;
            box-sizing: border-box;
        }
    }
    .hot-item {
        width: 690upx;
        height: 544upx;
        background: #FFFFFF;
        box-shadow: 0px 4upx 8upx 0px rgba(0, 0, 0, 0.1);
        border-radius: 20upx;
        margin-top: 30upx;
        padding: 20upx;
        box-sizing: border-box;
        .title {
            font-size: 32upx;
            font-weight: 500;  
        }
        .post {
            width: 650upx;
            height: 360upx;
            border-radius: 10upx;
            margin-top: 20upx;
        }
        .footer {
            margin-top: 30upx;
            .tip {
                margin-right: 40upx;
                font-size: 28upx;
                color: #979797;
                .img {
                    width: 40upx;
                    height: 40upx;
                    margin-right: 6upx;
                }
            }
            .right {
                width: 180upx;
                height: 60upx;
                background: #D6544F;
                border-radius: 30upx;
                font-size: 28upx;
                font-weight: 500;
                color: #FFFFFF;
            }
        }
    }
}
.btn-wrap {
    position: fixed;
    left: 30upx;
    bottom: 60upx;
    width: 100upx;
    height: 100upx;
    border-radius: 50%;
    box-shadow: 0px 4upx 8upx 0px rgba(0, 0, 0, 0.15);
}
</style>
