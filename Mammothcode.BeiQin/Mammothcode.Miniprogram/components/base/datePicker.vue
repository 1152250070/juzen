<template>
	<view class="picker-wrap">
		<picker @change="handleChange" @columnchange='handleColumnChange' mode="multiSelector" :value="multiIndex" :range="rangeData" range-key='label'>
			<slot></slot>
		</picker>
	</view>
</template>

<script>
	// 月份最大天数
	const DAY_MAX = [31, 0, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31]
	export default {
		props: {
			start: {
				type: Number,
				default: 1970
			},
			end: {
				type: Number,
				default: 2099
			},
			mode: {
				type: String,
				default: 'datetime'
			},
			defaultTime: ''
		},
		computed: {
			modeIndexs() {
				switch (this.mode) {
					case 'datetime':
						return [0, 5]
					case 'date':
						return [0, 3]
					case 'time':
						return [3, 5]
				}
			},
			valueIndexs() {
				switch (this.mode) {
					case 'datetime':
						return [0, 5]
					case 'date':
						return [0, 3]
					case 'time':
						return [0, 2]
				}
			}
		},
		created() {
			this.initRangeData()
		},
		data() {
			return {
				rangeData: [],
				multiIndex: [0, 0, 0, 0, 0]
			}
		},
		methods: {
			// 列数据改变
			handleColumnChange(e) {
				let info = e.detail
				let value = info.value
				this.$set(this.multiIndex, info.column, value)
				if (this.mode !== 'time' && ~[0, 1, 2].indexOf(info.column)) {
					this.checkFeb()
				}
			},
			// 检查月份天数是否正常
			checkFeb() {
				let multiIndex = this.multiIndex
				let monthIndex = multiIndex[1]
				let maxDay = 31
				if (monthIndex === 1) {
					// 二月 获取年份判断天数
					maxDay = this.rangeData[0][multiIndex[0]].value % 4 
					? 28 
					: 29
				} else {
					// 不是二月
					maxDay = DAY_MAX[monthIndex]
				}
				if (multiIndex[2] >= maxDay) {
					// 月份天数超出最大 重置0
					this.$set(multiIndex, 2, 0)
				}
			},
			handleChange(e) {
				let indexs = e.detail.value
				if (!indexs) {
					return
				}
				let rangeData = this.rangeData
				let data = indexs.map((item, index) => {
					return rangeData[index][item].value
				})
				let valueIndexs = this.valueIndexs
				data = data.slice(valueIndexs[0], valueIndexs[1])
				let value = ''
				if (data.length > 3) {
					// datetime
					value = data.slice(0, 3).join('-') + ' ' + data.slice(3).join(':') + ':00'
				} else {
					value = data.join(data.length > 2 ? '-' : ':')
				}
				e.detail.value = value
				this.$emit('change', e)
			},
			initRangeData() {
				let years = this.generate(this.start, this.end, '年')
				let months = this.generate(1, 13, '月')
				let days = this.generate(1, 32, '日')
				let hours = this.generate(1, 24, '时')
				let minutes = this.generate(0, 60, '分')
				this.rangeData = [years, months, days, hours, minutes].slice(this.modeIndexs[0], this.modeIndexs[1])
				this.setDefaultTime()
			},
			generate(start, end, text) {
				let list = []
				for (let i=start;i<end;i++) {
					i = (i + '')[1] ? i : '0' + i
					list.push({
						label: i + text,
						value: i
					})
				}
				return list
			},
			// 设置默认时间
			setDefaultTime() {
				let date = this.defaultTime
				if (!date) {
					return [0, 0, 0, 0, 0]
				}
				if (typeof date !== 'object') {
					date = new Date(date)
				}
				let timeArr = [date.getFullYear(), date.getMonth() + 1, date.getDate(), date.getHours(), date.getMinutes()]
				this.multiIndex = timeArr.slice(this.modeIndexs[0], this.modeIndexs[1]).map((item, index) => {
					let findIndex =  this.rangeData[index].findIndex(iitem => iitem.value * 1 === item * 1)
					return findIndex === -1 ? 0 : findIndex
				})
			}
		}
	}
</script>
