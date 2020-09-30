<template>
    <view class="input-wrap">
        <view class="top">{{ title }}</view>
        <picker v-if="isPicker" :range="range" :mode="mode" :range-key="rangekey" @change="pickerChange">
            <view class="bot flex c-center">
                <input class="input" :placeholder="placeholder" disabled v-model="pickerValue" />
                <image class="img" src="/static/imgs/icon_go@2x.png" />
            </view>
        </picker>
        <view v-else class="bot flex c-center" @click="handleClick">
            <input 
                v-if="type !== 'textarea'"
                class="input" 
                :type="type" 
                :placeholder="placeholder" 
                :disabled="isNavigator || disabled" 
                :value="inputValue" 
                @input="inputChange" 
                @blur="handleConfirm"
                @confirm="handleConfirm"
            />
            <textarea 
                v-else 
                class="input" 
                auto-height
                :placeholder="placeholder" 
                :disabled="isNavigator || disabled" 
                :value="inputValue" 
                @input="inputChange" 
                @blur="handleConfirm"
                @confirm="handleConfirm"
            />
            <image v-if="isNavigator" class="img" src="/static/imgs/icon_go@2x.png" />
        </view>
    </view>
</template>

<script>
	export default {
        props: {
            title: {
                type: String,
                default: ''
            },
            placeholder: {
                type: String,
                default: ''
            },
            value: {
                type: String | Number | Boolean,
                default: null
            },
            isPicker: {
                type: Boolean,
                default: false
            },
            isNavigator: {
                type: Boolean,
                default: false
            },
            range: {
                type: Array,
                default: () => {
                    return []
                }
            },
            mode: {
                type: String,
                default: 'selector'
            },
            rangekey: {
                type: String,
                default: 'label'
            },
            rangeid: {
                type: String,
                default: 'id'
            },
            rangeindex: {
                type: Number,
                default: 0
            },
            disabled: {
                type: Boolean,
                default: false
            },
            type: {
                type: String,
                default: 'text'
            }
        },
        computed: {
            inputValue() {
                return this.value
            }
        },
        watch: {
            range(newV, oldV) {
                this.initPicker()
            }
        },
		data() {
			return {
				pickerValue: this.value
			}
		},
		mounted() {
		},
		methods: {
            initPicker() {
                const rangeid = this.rangeid
                const rangekey = this.rangekey
                this.range.forEach(item => {
                    if (item[rangeid] == this.value) {
                        this.pickerValue = item[rangekey]
                    }
                })
            },
            handleClick() {
                if (this.isNavigator) {
                    this.$emit('handleClick')
                }
            },
            pickerChange(val) {
                if (this.mode === 'selector') {
                    const rangeid = this.rangeid
                    const rangekey = this.rangekey
                    const index = val.detail.value
                    const id = this.range[index][rangeid]
                    const value = this.range[index][rangekey]
                    this.pickerValue = value
                    this.$emit('change', id, value)
                } else {
                    this.$emit('change', val)
                }
            },
            inputChange(val) {
                this.$emit('input', val.detail.value)
            },
            handleConfirm(val) {
                this.$emit('handleConfirm', val.detail.value)
            }
        }
	}
</script>

<style lang="scss" scoped>
.input-wrap {
    padding: 40upx 0;
    border-bottom: 2upx solid #EFEFEF;
    .top {
        font-size: 24upx;
        color:rgba(102,102,102,1);
    }
    .bot {
        margin-top: 20upx;
        .input {
            width: 100%;
            height: 50upx;
            font-size: 32upx;
        }
        .img {
            width: 40upx;
            height: 40upx;
            flex-shrink: 0;
        }
    }
}
</style>
