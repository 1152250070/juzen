/* 根据name输出不同token */
export default class Token {
	constructor(name) {
		this.name = name
		this.refresh()
	}
	refresh() {
		return this.value = uni.getStorageSync(this.name)
	}
	setValue(val) {
		uni.setStorageSync(this.name, val)
		this.refresh()
	}
	getValue() {
		return this.value ? this.value : this.refresh()
	}
	remove() {
		this.value = ''
		uni.removeStorageSync(this.name)
	}
	
}