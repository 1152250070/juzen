module.exports = {
	supports: Array.apply(null, {
		length: 8
	}).map((_, index) => ({
		title: '电熔旁通马鞍' + (index + 1),
		img: `/static/img/product/${index + 1}.png`,
		id: index + 1
	})),
	// 合作伙伴
	partners: Array.apply(null, {
		length: 8
	}).map((item, index) => ({
		img: `/static/img/partner/${index + 1}.png`
	}))
}