<template>
	<view class="container">
        <block v-if="isImg">
            <view class="upload-wrap" @click="handleChooseImage" v-if="!mult">
                <image class="show-img" v-show="src" :src="src" mode="aspectFit" :style="{borderRadius: border ? '50%' : 'none'}" />
                <view v-show='!src' class="upload-tip flex-center">
                    <!-- <image class="add-img" src="/static/h5img/icon_add@3x.png" /> -->
                    <text class="add-text">{{ text || '' }}</text>
                </view>
                <!-- <view class="cancel-mask" v-show="src">删除</view> -->
            </view>
            <scroll-view scroll-x class="mult-upload-wrap" v-if="mult">
                <view 
                class="upload-wrap mult"
                v-for="(item, index) in src"
                :key='index'
                :style="{width: width, height: height}"
                @click="handleChooseImageMult(index)">
                    <image class="show-img" v-show="item" :src="item" mode="aspectFit" />
                    <view v-show="!item" class="upload-tip flex-center">
                        <image class="add-img" src="/static/h5img/icon_add@3x.png" />
                        <text class="add-text">{{ text || '' }}</text>
                    </view>
                    <view class="cancel-mask" v-show="item && !disabled" @click.stop="handleCancelImage(index)">删除</view>
                </view>
            </scroll-view>
        </block>
        <block v-else>
            <view class="upload-wrap" @click="handleChooseVideo" v-if="!mult">
                <video class="show-video" v-show="src" :src="src"></video>
                <view v-show="!src" class="upload-tip flex-center">
                    <image class="add-img" src="/static/h5img/icon_add@3x.png" />
                    <text class="add-text">{{ text || '' }}</text>
                </view>
            </view>
            <view
            class="upload-wrap"
            v-for="(item, index) in src"
            :key='index'
            :style="{width: width, height: height}"
            @click="handleChooseImageMult(index)" v-else>
                <video class="show-video" v-show="item" :src="item"></video>
                <image class="cancel-img" v-show="item" src="/static/h5img/icon_del2@3x.png" @click.stop="handleCancelVideo(index)" />
                <view v-show="!item" class="upload-tip flex-center">
                    <image class="add-img" src="/static/h5img/icon_add@3x.png" />
                    <text class="add-text">{{ text || '' }}</text>
                </view>
            </view>	
        </block>
	</view>
</template>

<script>
    import {
        UploadImgAjax,
        GetQiniuUploadTokenAjax,
        UploadQiniuImgAjax,
        qiniu,
        imgUrl
    } from '@/apis/api.js'

    import {
        uploadMultImg
    } from '@/lib/utils/util.js'

	export default {
		props: {
			value: {
				type: String,
				default: ''
			},
			mult: { // 多图上传
				type: Boolean,
				default: false
            },
            isImg: {
                type: Boolean,
				default: true
            },
            text: {
                type: String,
				default: ''
            },
            qiniu: { // 七牛
                type: Boolean,
                default: true
            },
            width: {
                type: String,
                default: '100px'
            },
            height: {
                type: String,
                default: '100px'
            },
            border: {
                type: Boolean,
                default: false
            },
            disabled: {
                type: Boolean,
				default: true
            }
		},
		data() {
			return {
                src: ''
			}
        },
        watch: {
			value(val) {
				this.setSrc(val)
            }
        },
        computed: {
            mediaType() {
                return !this.isImg ? ['video'] : this.src.length > 1 ? ['image'] : ['image', 'video'] // 根据上传情况判断上传类型
            }
        },
		created() {
			this.setSrc(this.value)
		},
		methods: {
			// 多图
			handleChooseImageMult(index) {
                if (this.disabled) {
                    return
                }
				let src = this.src
                let isReplace = index !== src.length - 1
                let count = isReplace ? 1 : 9
                if (!isReplace && src.length > 9) { // 上传限制
                    uni.showToast({
                        title: '最多上传9张图片',
                        icon: 'none'
                    })
                    return
                }
                this.handleChooseMedia(index, src, isReplace, count)
            },
            handleChooseMedia(index, src, isReplace, count) {
                if (this.disabled) {
                    return
                }
                uni.chooseImage({
                    count: count,
                    sizeType: ['compressed'],
					success: async res => {
                        console.log(res)
                        uni.showLoading({
                            title: '上传中',
                            mask: true
                        })
                        try {
                            let tempFilePaths = res.tempFilePaths // 上传图片的数组
                            let totalLength = src.length - 1 + tempFilePaths.length
                            if (totalLength > 9) { // 上传限制
                                uni.showToast({
                                    title: '最多上传9张图片',
                                    icon: 'none'
                                })
                                return
                            }
                            if (this.qiniu) { // 七牛上传
                                let qiniuFilePaths = tempFilePaths.map(item => { return item }).join(',') // 媒体文件
                                // let posterFilePaths = tempFilePaths.filter(item => item.thumbTempFilePath) // 封面图
                                let path = await uploadMultImg(UploadQiniuImgAjax, qiniu.fileUrl, qiniuFilePaths) // 上传图片
                                let pathList = path.split(',')
                                this.src = this.src.concat(pathList)
                                // if (posterFilePaths.length) { // 视频
                                //     // 上传封面图
                                //     let poster = await uploadMultImg(UploadQiniuImgAjax, qiniu.fileUrl, posterFilePaths[0].thumbTempFilePath)
                                //     this.$emit('update:isImg', false)
                                //     this.$emit('input', this.src.filter(item => item).join(','))
                                //     this.$emit('addPoster', poster)
                                // } else { // 图片
                                    this.$emit('input', this.src.filter(item => item).join(','))
                                // }
                                this.$emit('change')
                            } else { // 本地上传
                                tempFilePaths.forEach(item => {
                                    UploadImgAjax(item.tempFilePath).then(res2 => {
                                        let url = imgUrl + JSON.parse(res2).data
                                        if (item.thumbTempFilePath) { // 视频
                                            this.src = []
                                            this.src.push(url)
                                            this.$emit('update:isImg', false)
                                            this.$emit('input', this.src.filter(item => item).join(','))
                                            UploadImgAjax(item.thumbTempFilePath).then(res3 => {
                                                let poster = imgUrl + JSON.parse(res3).data
                                                this.$emit('addPoster', poster)
                                            })
                                        } else { // 图片
                                            if (isReplace) {
                                                this.src[index] = url
                                            } else {
                                                this.src.push(url)
                                            }
                                            this.$emit('input', this.src.filter(item => item).join(','))
                                        }
                                        this.$emit('change')
                                    })
                                })
                            }
                        } finally {
                            uni.hideLoading()
                        }
					}
				})
            },
            handleCancelImage(index) {
                uni.showModal({
                    title: '是否删除当前图片',
                    success: res => {
                        if (res.confirm) {
                            let src = [...this.src]
                            src.splice(index,1)
                            this.$emit('input', src.filter(item => item).join(','))
                            this.$emit('change')
                        }
                    }
                })
            },
            handleCancelVideo(index) {
                uni.showModal({
                    title: '是否删除当前视频',
                    success: res => {
                        if (res.confirm) {
                            let src = [...this.src]
                            src.splice(index,1)
                            this.$emit('update:isImg', true)
                            this.$emit('input', src.filter(item => item).join(','))
                            this.$emit('change')
                        }
                    }
                })
            },
            handleChooseImage() {
                uni.chooseImage({
                    count: 1,
                    success: async res => {
                        uni.showLoading({
                            title: '上传中',
                            mask: true
                        })
                        try {
                            if (this.qiniu) {
                                let tempFilePaths = await uploadMultImg(UploadQiniuImgAjax, qiniu.fileUrl, res.tempFilePaths[0])
                                this.$emit('input', tempFilePaths)
                                this.$emit('change')
                            } else {
                                let res2 = await UploadImgAjax(res.tempFilePaths[0])
                                this.src = imgUrl + JSON.parse(res2).data
                                this.$emit('input', this.src)
                                this.$emit('change')
                            }
                            uni.hideLoading()
                        } catch(err) {
                            uni.hideLoading()
                        }
                    }
                })
            },
            handleChooseVideo() {
                uni.chooseVideo({
					success: async res => {
                        uni.showLoading({
                            title: '上传中',
                            mask: true
                        })
                        try {
                            if (this.qiniu) {
                                let tempFilePaths = await uploadMultImg(UploadQiniuImgAjax, qiniu.fileUrl, res.tempFilePath)
                                this.$emit('input', tempFilePaths)
                                this.$emit('change')
                            } else {
                                let res2 = await UploadImgAjax(res.tempFilePath)
                                this.src = imgUrl + JSON.parse(res2).data
                                this.$emit('input', this.src)
                                this.$emit('change')
                            }
                            uni.hideLoading()
                        } catch(err) {
                            uni.hideLoading()
                        }
					}
				})
            },
			setSrc(val) {
				if (this.mult) {
					if (!val) {
						this.src = ['']
					} else {
                        let src = val.split(',')
                        if (!this.disabled) {
                            src.push('')
                        }
						this.src = src						
					}
				} else {
					this.src = val
				}
			}
		}
	}
</script>

<style lang="scss" scoped>
    .container {
        width: 100%;
        height: 100%;
    }
    .mult-upload-wrap {
        width: 100%;
        height: 300upx;
        padding-right: 30upx;
        box-sizing: border-box;
        white-space: nowrap;
        vertical-align: middle;
    }
	.upload-wrap {
        background-color: #FFFFFF;
        position: relative;
        display: inline-block;
        vertical-align: top;
        width: 100%;
        height: 100%;
        &.mult {
            width: auto;
            height: auto;
            margin-right: 20upx;
            margin-top: 20upx;
            white-space: nowrap;
            vertical-align: middle;
        }
        .cancel-mask{
            position: absolute;
            left: 0;
            right: 0;
            bottom: 0;
            height: 68upx;
            background: linear-gradient(180deg,rgba(0,0,0,0) 0%,rgba(0,0,0,1) 100%);
            font-size: 28upx;
            color:rgba(255,255,255,1);
            text-align: center;
            line-height: 68upx;
        }
		.show-img {
			width: 100%;
            height: 100%;
        }
        .show-video {
            width: 100%;
            height: 100%;
        }
        .cancel-img {
            width: 36upx;
            height: 36upx;
            position: absolute;
            right: -18upx;
            top: -18upx;
        }
		.upload-tip {
			width: 100%;
            height: 100%;
            border:2upx dashed rgba(151,151,151,1);
            color: #ccc;
            flex-direction: column;
            border-radius: 10upx;
            .add-img {
                width: 60upx;
                height: 60upx;
                flex-shrink: 0;
            }
            .add-text {
                font-size: 24upx;
                margin-top: 16upx;
                color: #6A9E49;
            }
		}
	}
</style>
