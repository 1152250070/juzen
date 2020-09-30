<template>
    <view class="head-wrap flex-between c-center">
        <image class="left" src="/static/imgs/logo3.png" mode="widthFix" />
        <!-- 功能 -->
        <view class="right flex c-center" v-if="type">
            <image v-if="type === 1" class="search" src="/static/imgs/icon_search-in@2x.png" />
            <view v-if="type === 2" class="address flex-center">
                <image class="img" src="/static/h5img/" />
                <view class="city">{{ city }}</view>
                <view @click="changeCity">[切换城市]</view>
            </view>
            <view v-if="type === 3" class="like flex-center" @click="handleLike">
                <image class="img" :src="isLike ? '/static/h5img/icon_like-in@3x.png' : '/static/h5img/icon_like@3x.png'" />
                <view>感兴趣</view>
            </view>
            <view v-if="type === 4" class="sort" @click="handleClick">
                {{ text }}
            </view>
            <view v-if="type === 5" class="btn flex-center" @click="handleSave">
                保存
            </view>
            <view v-if="type === 6" class="like flex-center" @click="handleClick">
                <image class="img" src="/static/h5img/icon_email@2x.png" />
                <view>全部已读</view>
            </view>
        </view>
    </view>
</template>

<script>
	export default {
        props: {
            type: { // 类型
                type: Number,
                default: 0 // 
            },
            city: { // 城市名
                type: String,
                default: ''
            },
            isLike: { // 是否喜欢
                type: Boolean,
                default: false
            },
            isFollow: { // 是否关注
                type: Boolean,
                default: false
            },
            text: { // 显示内容
                type: String,
                default: ''
            }
        },
		data() {
			return {
				
			}
		},
		mounted() {

		},
		methods: {
            goRecord() {
                uni.navigateTo({
                    url: '/pages/my/luckRecord'
                })
            },
            handleSave() {
                this.$emit('handleSave')
            },
            handleLike() {
                this.$emit('handleLike')
            },
            handleClick() {
                this.$emit('handleClick')
            },
            changeCity() {
                uni.navigateTo({
                    url: '/pages/edit/city'
                })
            }
        }
	}
</script>

<style lang="scss" scoped>
.head-wrap {
    width: 100%;
    height: 100upx;
    background:rgba(106,158,73,1);
    color: #ffffff;
    padding: 18upx 30upx;
    box-sizing: border-box;
    position: fixed;
    left: 0;
    top: 0;
    z-index: 100;
    .left {
        width:220upx;
        height:64upx;
    }
    .search {
        width: 44upx;
        height: 44upx;
    }
    .address {
        .img {
            width: 36upx;
            height: 36upx;
        }
        .city {
            font-size:$font-size-lg;
            margin: 0 20upx 0 15upx;
        }
    }
    .sort {
        font-size:$font-size-lg;
    }
    .btn {
        padding: 10upx 20upx;
        border-radius: 26upx;
        font-size: 24upx;
        background: #ffffff;
        color: rgba(106,158,73,1);
    }
    .like {
        .img {
            width: 48upx;
            height: 48upx;
            margin-right: 10upx;
        }
    }
    .follow {
        width:110upx;
        height:48upx;
        background:rgba(255,255,255,1);
        border-radius:44upx;
        font-size:$font-size-sm;
        color: $theme-color;
    }
}
</style>
