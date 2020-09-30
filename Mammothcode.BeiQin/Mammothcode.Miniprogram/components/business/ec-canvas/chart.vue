<template>
	<canvas 
	class="ec-canvas" 
	:canvas-id="canvasId" 
	@touchstart="touchStart" 
	@touchmove="touchMove" 
	@touchend="touchEnd">
	</canvas>
</template>

<script>

	function wrapTouch(event) {
		for (let i = 0; i < event.touches.length; ++i) {
			const touch = event.touches[i];
			touch.offsetX = touch.x;
			touch.offsetY = touch.y;
		}
		return event;
	}

	import WxCanvas from './wx-canvas';
	import * as echarts from './echarts';
	
	let charts = {}

	export default {
		props: {
			canvasId: {
				type: String,
				default: 'ec-canvas'
			},
			option: {
				type: Object,
				default: null
			}
		},
		data() {
			return {
				chartId: null,
				isInit: false
			}
		},
		watch: {
			option() {
				this.init()
			}
		},
		beforeDestroy() {
			delete charts[this.chartId]
		},
		mounted() {
			this.init()
		},
		methods: {
			init: function() {
				if (this.isInit) {
					this.setOption()
				} else {
					if (!this.option) {
						return false
					}
					this.isInit = true
					let ctx = uni.createCanvasContext(this.canvasId, this);
					const canvas = new WxCanvas(ctx, this.canvasId);
					echarts.setCanvasCreator(() => {
						return canvas;
					});
					var query = uni.createSelectorQuery().in(this);
					query.select('.ec-canvas').boundingClientRect(res => {
						let chart = echarts.init(canvas, null, {
						  width: res.width,
						  height: res.height
						});
						this.chartId = chart.id
						charts[this.chartId] = chart
						canvas.setChart(chart)
						this.setOption()
					}).exec();					
				}
			},
			setOption() {
				charts[this.chartId] && charts[this.chartId].setOption(this.option)
			},
			touchStart(e) {
				if (charts[this.chartId] && e.touches.length > 0) {
					var touch = e.touches[0];
					var handler = charts[this.chartId].getZr().handler;
					handler.dispatch('mousedown', {
						zrX: touch.x,
						zrY: touch.y
					});
					handler.dispatch('mousemove', {
						zrX: touch.x,
						zrY: touch.y
					});
					handler.processGesture(wrapTouch(e), 'start');
				}
			},

			touchMove(e) {
				if (charts[this.chartId] && e.touches.length > 0) {
					var touch = e.touches[0];
					var handler = charts[this.chartId].getZr().handler;
					handler.dispatch('mousemove', {
						zrX: touch.x,
						zrY: touch.y
					});
					handler.processGesture(wrapTouch(e), 'change');
				}
			},

			touchEnd(e) {
				if (charts[this.chartId]) {
					const touch = e.changedTouches ? e.changedTouches[0] : {};
					var handler = charts[this.chartId].getZr().handler;
					handler.dispatch('mouseup', {
						zrX: touch.x,
						zrY: touch.y
					});
					handler.dispatch('click', {
						zrX: touch.x,
						zrY: touch.y
					});
					handler.processGesture(wrapTouch(e), 'end');
				}
			}
		}
	}
</script>

<style>
	.ec-canvas {
		width: 100%;
		height: 100%;
	}
</style>
