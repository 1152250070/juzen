<template>
    <view class="page-wrap">
        <view class="item-wrap flex" v-for="(item, index) in 4" :key="index" @click="goDetail(item)">
            <image class="left" src="/static/imgs/banner2.png" />
            <view class="right flex-between">
                <view class="top two-hidden">母乳喂养的基本原则母乳喂养的基本原则母乳喂养的基本原则</view>
                <view class="bot flex-between">
                    <text>2020.08.12 12:00:00</text>
                    <image class="img" src="/static/imgs/icon_del@3x.png" />
                </view>
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
    padding: 0 30upx;
}
.item-wrap {
    padding: 30upx 0;
    border-bottom: 2upx solid #EFEFEF;
    .left {
        width: 320upx;
        height: 180upx;
        border-radius: 10upx;
    }
    .right {
        width: 350upx;
        margin-left: 20upx;
        flex-direction: column;
        .top {
            width: 350upx;
            font-size: 32upx;
            color: #333333;
        }
        .bot {
            font-size: 24upx;
            color: #999999;
            align-items: flex-end;
            .img {
                width: 36upx;
                height: 36upx;
            }
        }
    }
}
</style>
