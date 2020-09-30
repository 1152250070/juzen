<template>
  <div class="img-box" :style="wrapStyle">
		<template v-if="mode === 'widthFix'">
			<img v-if="lazy" v-lazy="value" class="img width-fix" mode="widthFix" />
			<img v-else :src="value" class="img width-fix" mode="widthFix" />
		</template>
		<template v-else>
			<div v-if="lazy" class="img" v-lazy:background-image="value" :style="styleObj" ></div>
			<div v-else class="img" :style="styleObj" ></div>			
		</template>
  </div>
</template>

<script>
import { imageBg } from 'uni.scss'
export default {
  props: {
    value: {
      type: String,
      default: ''
    },
    width: {
      type: Number,
      default: 160
    },
    height: {
      type: Number,
      default: 100
    },
    mode: {
      type: String,
      default: 'cover'
    },
    position: {
      type: String,
      default: 'center'
    },
    bg: {
      type: String,
      default: imageBg
    },
    extend: {
      type: Boolean,
      default: false
    },
		lazy: {
      type: Boolean,
      default: true
		}
  },
  data() {
    return {
      _height: 0
    }
  },
  computed: {
    wrapStyle() {
      return {
        backgroundColor: this.bg,
        width: this.extend ? '100%' : this.width + 'px',
        height: this.extend ? '100%' : this.height + 'px'
      }
    },
    styleObj() {
      return {
        width: this.extend ? '100%' : this.width + 'px',
        height: this.extend ? '100%' : this.height + 'px',
        backgroundSize: this.mode,
        backgroundPosition: this.position,
				backgroundImage: this.lazy ? null : this.value
      }
    }
  },
	methods: {
		loadImage() {
			
		}
	}
}
</script>

<style lang="scss" scoped>
.img-box {
  display: inline-block;
	font-size: 0;
  .img {
    background-position: center;
    background-repeat: no-repeat;
    transition: opacity .7s;
    width: 100%;
    height: 100%;
		opacity: 0;
		&.width-fix {
			height: auto;
		}
  }
	.img[lazy=loading] {
		opacity: 1;
	}
	.img[lazy=loaded] {
		opacity: 1;
	}
}
</style>