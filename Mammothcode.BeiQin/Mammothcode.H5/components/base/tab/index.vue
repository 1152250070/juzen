<template>
    <div class="tabs flex" :style="{backgroundColor: backgroundColor,height: height}">
        <div 
            v-for="(tab, index) in tabs" 
            :key="index" 
            class="tabs-item flex-center flex-direction fg1"
            @click="click(index)"
        >
            <div 
                class="tab-text-wrap flex-center" 
                :style="{ color: current === index ? activeColor : color, width: width || 'auto' }"
            >
                <div 
                    class="tab-text" 
                    :style="{ borderBottom: current === index ? borderBottom : 'none',lineHeight: height }"
                >
                    {{ tab.text }}
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props: {
        current: {
            type: Number,
            default: 0
        },
        tabs: {
            type: Array,
            default: () => ([])
        },
        backgroundColor: {
            type: String,
            default: '#404A63'
        },
        color: {
            type: String,
            default: 'rgba(255, 255, 255, 0.75)'
        },
        activeColor: {
            type: String,
            default: 'rgba(255, 255, 255, 1)'
        },
        borderBottom: {
            type: String,
            default: '2px solid #fff'
        },
        width: {
            type: String,
            default: ''
        },
        height: {
            type: String,
            default: ''
        }
    },
    methods: {
        click(index) {
            this.$emit('update:current', index)
            this.$emit('change', index)
        }
    }
}
</script>

<style lang="scss" scoped>
.tabs {
    position: relative;
    z-index: 2;
    border-bottom: 2upx solid #EFEFEF;
}
.tabs-item {
    height: 100%;
    cursor: pointer;
    .tab-text-wrap {
        height: 100%;
        font-size: $font-size-base;
        font-weight: 500;
        color: rgba(255,255,255,0.75);
        .tab-text {
            height: 100%;
            display: inline-block;
            height: calc(100% - 2px);
        }
    }
}
</style>