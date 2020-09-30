<template>
	<image 
	:class='[extendCls, observeName, show ? "active" : "", "observe-img"]'
	:src='showSrc'
	:mode='mode'>
	</image>
</template>

<script>
	export default {
		props: {
			mode: {
				type: String,
				default: 'aspectFit'
			},
			src: {
				type: String,
				default: ''
			},
			lazy: {
				type: String,
				default: '/static/img/default-img.png'
			},
			interval: {
				type: Number,
				default: 0
			},
			extendCls: {
				type: String,
				default: ''
			}
		},
		data() {
			return {
				showSrc: '',
				show: false,
				observeName: '',
				saveSrc: ''
			}
		},
		created() {
			this.observeName = 'observe-' + this.__wxExparserNodeId__
			this._setOvserve()
		},
		watch: {
			src: function(val) {
				this._setOvserve()
			}
		},
		methods: {
			_setOvserve() {
				this._setDefault()
				setTimeout(() => {
					const intersectionObserver = this.createIntersectionObserver()
					intersectionObserver.relativeToViewport().observe(`.${this.observeName}`, (res) => {
						if (res && res.intersectionRatio > 0.01) {
							this.showSrc = this.src
							intersectionObserver.disconnect()
							this.show = true
						}
					})
				}, this.interval)
			},
			_setDefault() {
				this.showSrc = this.lazy
				this.show = false
			}
		}
	}
</script>

<style lang="scss">
.observe-img {
	width: 100%;
	height: 100%;
	&.active {
		animation: opacity .5s 1;
	}
}

@keyframes opacity {
	0% {
		opacity: 0
	}

	100% {
		opacity: 1
	}
}
</style>
