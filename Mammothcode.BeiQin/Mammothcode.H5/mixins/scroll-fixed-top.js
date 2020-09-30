const SCROLL_SAFE_AREA = 200
export default {
	data() {
		return {
			showHeader: true,
			_scrollTop: 0,
			_animating: false
		}
	},
	methods: {
		_toggleShowHeader(showHeader) {
			this.showHeader = showHeader
			this._animating = true
			setTimeout(() => {
				if (this._animating) {
					return
				}
				this._animating = false
			}, this._duration || 300)
		}
	},
	onPageScroll(e) {
		const originScrollTop = this._scrollTop
		const originShowHeader = this.showHeader
		this._scrollTop = e.scrollTop
		if (this._scrollTop <= SCROLL_SAFE_AREA) {
			// 在安全区域内 显示头部
			if (!originShowHeader) {
				this._toggleShowHeader(true)
			}
		} else {
			// 不在安全区域 进行判断 向上滚动 隐藏头部
			if (originScrollTop < this._scrollTop) {
				if (originShowHeader) {
					this._toggleShowHeader(false)
				}
			} else if (originScrollTop > this._scrollTop) {
				if (!originShowHeader) {
					this._toggleShowHeader(true)
				}
			}
		}
	},
}