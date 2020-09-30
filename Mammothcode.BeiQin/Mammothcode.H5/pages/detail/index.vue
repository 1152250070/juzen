<template>
    <view class="page-wrap">
        <view class="video-wrap">
            <view class="cover"></view>
            <view class="tip-btn">未开播</view>
            <image class="play-btn" src="/static/imgs/icon_play@3x.png" />
            <view class="left-time">剩 01 小时 00 分 00 秒 开播</view>
        </view>
        <view class="title-wrap">
            <view class="top flex-between">
                <view class="left">
                    专题一：母乳喂养须知母乳喂养须知母乳喂养须知
                </view>
                <view class="right flex-center" @click="showMask = true">
                    <image class="img" src="/static/imgs/icon_share@3x.png" />分享
                </view>
            </view>
            <view class="bot">
                <view class="teacher">
                    <image class="img" src="/static/imgs/img1.png" />
                    <text>xx老师</text>
                </view>
                <view class="desc">
                    简介：简介内容简介内容简介内容简介内容简介内容简介内容简介内容简介内容简介。
                </view>
            </view>
        </view>
        <view class="common-wrap">
            <view class="head flex-between">
                <view class="left">评价（2）</view>
                <!-- <view class="right" @click="maskShow = true">写评论</view> -->
            </view>
            <view class="items flex" v-for="(item, index) in 2" :key="index">
                <image class="right" src="/static/imgs/img1.png" />
                <view class="left">
                    <view class="user">春天的雨</view>
                    <view class="user">2020.08.12</view>
                    <view class="content">这个非常好看，很棒很棒的！</view>
                </view>
            </view>
        </view>
        <view class="footer-wrap flex c-center">
            <view class="input">说点什么...</view>
            <view class="item flex c-center">
                <image class="img" src="/static/imgs/icon_like-l@3x.png" /> 3333
            </view>
            <view class="item flex c-center">
                <image class="img" src="/static/imgs/icon_comment@3x.png" /> 3333
            </view>
            <view class="item flex c-center" @click="showMask = true">
                <image class="img" src="/static/imgs/icon_rt@3x.png" /> 转发
            </view>
        </view>
        <view class="share-mask" v-if="showMask" @click.stop.prevent="showMask = false">
            <image class="img" src="/static/imgs/icon_touch@3x.png" />
            <text class="text">
                点击右上角“···”
                选择分享到朋友圈
            </text>
        </view>
    </view>
</template>

<script>
    import {

    } from '@/apis/api.js'

	export default {
		data() {
			return {
                showMask: false
			}
		},
		onLoad() {
            uni.setNavigationBarTitle({
                title: '母乳喂养需知'
            })
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
.page-wrap {
    background: #F7F7F7;
    height: 100%;
    padding-bottom: 130upx;
    box-sizing: border-box;
}
.video-wrap {
    width: 750upx;
    height: 420upx;
    position: relative;
    background-image: url('/static/imgs/banner2.png');
    background-size: cover;
    .cover {
        position: absolute;
        width: 100%;
        height: 100%;
        background: #000000;
        opacity: 0.35;
    }
    .tip-btn {
        position: absolute;
        left: 30upx;
        top: 24upx;
        width: 112upx;
        height: 50upx;
        background: rgba(255, 255, 255, 0.95);
        border-radius: 25upx;
        font-size: 24upx;
        font-weight: 500;
        color: #D6544F;
        text-align: center;
        line-height: 50upx;
    }
    .play-btn {
        position: absolute;
        left: 330upx;
        top: 166upx;
        width: 90upx;
        height: 90upx;
    }
    .left-time {
        position: absolute;
        left: 136upx;
        bottom: 40upx;
        width: 478upx;
        height: 72upx;
        background: #D6544F;
        border-radius: 36upx;
        font-size: 28upx;
        font-weight: 500;
        color: #FFFFFF;
        text-align: center;
        line-height: 72upx;
    }
}
.title-wrap {
    padding: 0 30upx;
    background: #FFFFFF;
    .top {
        padding: 30upx 0;
        border-bottom: 2upx solid #EFEFEF;
        .left {
            width: 524upx;
            font-size: 32upx;
            font-weight: 500;
        }
        .right {
            width: 136upx;
            height: 56upx;
            background: #D6544F;
            border-radius: 28upx;
            font-size: 28upx;
            font-weight: 500;
            color: #FFFFFF;
            line-height: 40upx;
            .img {
                width: 40upx;
                height: 40upx;
                margin-right: 6upx; 
            }
        }
    }
    .bot {
        padding: 30upx 0;
        .teacher {
            font-size: 32upx;
            color: #333333;
            .img {
                width: 48upx;
                height: 48upx;
                border-radius: 50%;
                margin-right: 16upx;
            }
        }
        .desc {
            margin-top: 12upx;
            font-size: 28upx;
            color: #999999;
        }
    }
}
.common-wrap {
    margin-top: 20upx;
    padding: 20upx 30upx;
    background: #FFFFFF;
    .head {
        padding: 20upx 0;
        border-bottom: 2upx solid #F2F4F7;
        .left {
            font-size: 32upx;
            font-weight: 500;
            color:rgba(51,51,51,1);
        }
        .right {
            font-size: 28upx;
            color:rgba(106,158,73,1);
        }
    }
    .items {
        border-bottom: 2upx solid #F2F4F7;
        padding: 20upx 0;
        .right {
            width: 60upx;
            height: 60upx;
            border-radius: 50%;
        }
        .left {
            width: 610upx;
            margin-left: 20upx;
            .user {
                font-size: 24upx;
                color:rgba(153,153,153,1);
            }
            .content {
                font-size: 28upx;
                color:rgba(51,51,51,1);
                margin-top: 10upx;
            }
            .replys {
                border-top: 2upx solid #F2F4F7;
                padding-bottom: 20upx;
                margin-top: 20upx;
                .reply {
                    margin-top: 20upx;
                    .r_name {
                        font-size: 28upx;
                        color:rgba(153,153,153,1);
                    }
                    .r_content {
                        font-size: 28upx;
                        color:rgba(51,51,51,1);
                    }
                }
            }
        }
    }
}
.footer-wrap {
    position: fixed;
    bottom: 0;
    left: 0;
    right: 0;
    height: 100upx;
    background: #FFFFFF;
    box-shadow: 0px -4upx 8upx 0px rgba(0, 0, 0, 0.1);
    .input {
        width: 240upx;
        height: 76upx;
        background: #F7F7F7;
        border-radius: 38upx;
        padding-left: 30upx;
        line-height: 76upx;
        font-size: 28upx;
        color: #666666;
        margin-left: 30upx;
        box-sizing: border-box;
    }
    .item {
        margin-left: 30upx;
        font-size: 24upx;
        .img {
            width: 60upx;
            height: 60upx;
            margin-right: 10upx;
        }
    }
}
.share-mask {
    position: fixed;
    left: 0;
    right: 0;
    top: 0;
    bottom: 0;
    background: rgba(0, 0, 0, 0.8);
    .img {
        position: absolute;
        top: 20upx;
        right: 50upx;
        width: 120upx;
        height: 120upx;
    }
    .text {
        position: absolute;
        top: 150upx;
        right: 50upx;
        width: 288upx;
        height: 100upx;
        font-size: 36upx;
        color: #FFFFFF;
        line-height: 50upx;
    }
}
</style>
