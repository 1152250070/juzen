export default class Pie {
	constructor(arg) {
		this.canvasId = arg.canvasId
		this.width = arg.width || 150
		this.height = arg.height || 150
		this.startDeg = 270
		this.startDegValue = this.startDeg / 180 * Math.PI
		if (!this.canvasId) {
			console.warn('canvasId 不能为空')
			return false
		}
		this.ctx = uni.createCanvasContext(this.canvasId)
		this.freshData(arg.data)
	}
	
	freshData(data) {
		this._setData(data)
		this.initData()
	}
	
	initData() {
		let ctx = this.ctx
		let data = this.data
		let total = data.reduce((start, item) => {
			return start + item.fee * 1
		}, 0)
		let renderData = []
		
		// 计算角度
		for (let i=0;i<data.length;i++) {
			let item = data[i]
			let beforeRenderData = data[i - 1]
			renderData[i] = item
			// 开始角start
			renderData[i].start = beforeRenderData 
			? beforeRenderData.end 
			: 0
			
			// 结束角end
			let deg = (item.fee / total * Math.PI * 2) || 0
			renderData[i].end = beforeRenderData 
			? deg + beforeRenderData.end
			: deg
		}
		// 计算角度值
		for (let i=0;i<renderData.length;i++) {
			renderData[i].start = (renderData[i].start + this.startDegValue) % (Math.PI * 2)
			renderData[i].end = (renderData[i].end + this.startDegValue) % (Math.PI * 2)
			if (renderData[i].fee && renderData[i].start === renderData[i].end) {
				renderData[i].end -= 0.000001
			}
		}
		this._renderData = renderData
		this.renderPie()
		this.renderText()
	}
	
	renderPie() {
		let renderData = this._renderData
		let width = this.width
		let height = this.height
		let x = width / 2
		let y = height / 2
		let radius = Math.min.apply(null, [width, height]) / 2
		this.radius = radius
		let ctx = this.ctx
		
		for (let i=0;i<renderData.length;i++) {
			let item = renderData[i]
			ctx.beginPath()
			ctx.arc(x, y, radius, item.start, item.end)
			ctx.lineTo(x, y)
			ctx.setFillStyle(item.color)
			ctx.closePath()
			ctx.fill()
		}
		ctx.draw()
	}
	
	renderText() {
		let ctx = this.ctx
		let radius = this.radius
		let renderData = this._renderData
		for (let i=0;i<renderData.length;i++) {
			let positionInfo = this._getTextPosition(renderData[i])
			let minX = 0;
			let maxX = 0;
			let minY = 0;
			let maxY = 0;
			let j = 0;
			let l = positionInfo.length
			for (;j<l;j++) {
				let info = positionInfo[j]
				minX = Math.min.apply(null, [minX, info[0]])
				maxX = Math.max.apply(null, [maxX, info[0]])
				minY = Math.min.apply(null, [minY, info[1]])
				maxY = Math.max.apply(null, [maxY, info[1]])
			}
			ctx.setFillStyle('#FFFFFF')
			ctx.setTextAlign('center')
			ctx.setTextBaseline('middle')
			if (renderData[i].fee) {
				ctx.fillText(renderData[i].fee, (minX + maxX) / 2 + radius, -((minY + maxY) / 2) + radius)
			}
		}
		ctx.draw(true)
	}
	
	_getTextPosition(info) {
		let posArr = []
		const perDeg = 1
		const START_DEG = info.start / Math.PI * 180
		const END_DEG = info.end / Math.PI * 180
		let curDeg = START_DEG
		
		for (let i = 0;i<360;i++) {
			posArr.push(this._getTextPosByDeg(curDeg))
			if (Math.floor(nextDeg - END_DEG) === 0) {
				break
			}
			let nextDeg = curDeg + perDeg
			curDeg = nextDeg >= 360 ? nextDeg - 360 : nextDeg
		}
		return posArr
	}
	
	_getTextPosByDeg(deg) {
		let radius = this.radius
		if (deg >= 0 && deg < 90) {
			// 第四象限
			let degValue = deg / 180 * Math.PI
			return [Math.cos(degValue) * radius, -Math.sin(degValue) * radius]
		} else if (deg >= 90 && deg < 180) {
			// 第三象限
			let degValue = (deg - 90) / 180 * Math.PI
			return [-Math.sin(degValue) * radius, -Math.cos(degValue) * radius]
		} else if (deg >= 180 && deg < 270) {
			// 第二象限
			let degValue = (deg - 180) / 180 * Math.PI
			return [-Math.cos(degValue) * radius, Math.sin(degValue) * radius]
		} else if (deg >= 270 && deg < 360) {
			// 第一象限
			let degValue = (deg - 270) / 180 * Math.PI
			return [Math.sin(degValue) * radius, Math.cos(degValue) * radius]
		}
	}
	
	_setData(data) {
		this.data = data.filter(item => item.show)
	}
	
}