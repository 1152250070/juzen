<template>
    <view class="page-wrap">
        <!-- 用户信息编辑 -->
        <view class="content-wrap">
            <view class="user-wrap flex-between c-center">
                <view class="left">头像</view>
                <view class="right">
                    <multUpload v-model="form.headImg" border @change="uploadChange" />
                </view>
            </view>
            <CommonInput 
                title="昵称" 
                placeholder="请输入昵称" 
                v-model="form.realName" 
            />
            <CommonInput 
                title="真实姓名" 
                placeholder="请输入真实姓名" 
                v-model="form.realName" 
            />
            <CommonInput 
                title="宝宝年龄（单位：月）" 
                placeholder="请输入宝宝年龄" 
                v-model="form.realName" 
            />
            <view class="btn-wrap flex-center">保存</view>
        </view>
    </view>
</template>

<script>
    import {

    } from '@/apis/api.js'

    import multUpload from '@/components/business/multUpload'

	export default {
        components: {
            multUpload
        },
		data() {
			return {
                form: {

                }
			}
        },
        computed: {

        },
		onLoad() {

		},
		methods: {

        }
	}
</script>

<style lang="scss" scoped>
.content-wrap {
    padding: 0 30upx;
}
.user-wrap {
    padding: 30upx 0 40upx;
    border-bottom: 2upx solid #EFEFEF;
    .left {
        font-size: 32upx;
        color:rgba(102,102,102,1);
    }
    .right {
        width: 120upx;
        height: 120upx;
        border: 2upx solid rgba(239,239,239,1);
        border-radius: 50%;
    }
}
.btn-wrap {
    width: 410upx;
    height: 88upx;
    background: #D6544F;
    box-shadow: 0px 4upx 16upx 0px rgba(0, 0, 0, 0.1);
    border-radius: 44upx;
    font-size: 28upx;
    font-weight: 500;
    color: #FFFFFF;
    margin: 60upx auto 0;
}
</style>
