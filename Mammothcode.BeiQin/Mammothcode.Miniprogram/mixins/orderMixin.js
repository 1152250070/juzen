const MIN_30_STAMP = 1800000 // 30分钟stamp
import {
	getLeftTime,
	dateFormat,
	dateTextToStamp
} from '@/lib/utils/dateFormat.js'
import {
	ConfirmGoodsAjax,
	CancelOrderAjax,
	SetOrderInstallEvaluateAjax,
	UpdateOrderedTimeAjax,
	UploadImgAjax,
	Payment1Ajax,
	Payment2Ajax,
	ajaxUrl
} from '@/apis/api.js'
import {
	wxUtils,
	uploadMultImg
} from '@/lib/utils/util.js'

export default {
	data() {
		return {
			orderStates: {}
		}
	},
	created() {
		// 设置状态对象
		this.orderStates = this.yOrderState
	},
	methods: {
		// 付尾款
		doContinuToPay2(orderInfo, fromPage) {
			if (orderInfo.payType2 !== null) {
				return false
			}
			this.$store.commit('updatePayMentOrderInfo', this.cloneObj(orderInfo))
			uni.navigateTo({
				url: `/pages/payMent2/payMent2?from=${fromPage}`
			});
		},
		// 跳转售后
		handleToSaleAfter(item, fromPage) {
			if (item.isSaleAfter) {
				uni.navigateTo({
					url: `/pages/orderAfterSale/orderAfterSale?orderNo=${item.orderNo}&isApply=1`
				});
			} else {
				uni.navigateTo({
					url: `/pages/orderAfterSale/orderAfterSale?orderNo=${item.orderNo}&from=${fromPage}`
				});
			}
		},
		// 跳转开票
		async handleToTicket(item, fromPage) {
			if (item.isTaxTicket) {
				uni.navigateTo({
					url: `/pages/orderTicket/orderTicket?orderNo=${item.orderNo}&isApply=1`
				});
			} else {
				uni.navigateTo({
					url: `/pages/orderTicket/orderTicket?orderNo=${item.orderNo}&from=${fromPage}`
				});
			}
		},
		// 确认订单评价
		doConfirmComment(formData, orderNo, orderFee2) {
			uni.showModal({
				title: '提示',
				content: '是否确认评价订单？',
				success: async res => {
					if (!res.confirm) {
						return false
					}
					if (!this.validForm(formData, [
						{
							key: 'evaluateText',
							text: '请填写评价~'
						}
					])) {
						return false
					}
					if (formData.showImgs) {
						formData.showImgs = await uploadMultImg(UploadImgAjax, ajaxUrl, formData.showImgs)
					}
					this.showPageLoading()
					let result = await SetOrderInstallEvaluateAjax({
						orderNo: orderNo,
						token: true,
						...formData
					})
					uni.showToast({
						title: '评价成功',
						icon: 'none'
					})
					this.$refs.commentForm.hide()
					this.hidePageLoading()
					this.doCommentSuccess(orderNo, orderFee2 * 1)
				}
			})
		},
		// 显示订单评价
		doShowComment() {
			this.$refs.commentForm.show()
		},
		// 设置安装时间
		async doSetInstallTime() {
			let formData = this.$refs.installTimeForm.formData
			if (!formData.orderedTime) {
				uni.showToast({
					title: '请选择时间!',
					icon: 'none'
				})
				return false
			}
			if (dateTextToStamp(formData.orderedTime) < new Date().getTime()) {
				uni.showToast({
					title: '不能选择过去时间!',
					icon: 'none'
				})
				return false
			}
			this.showPageLoading()
			await UpdateOrderedTimeAjax({
				token: true,
				...formData
			})
			this.$refs.commonDialog.hide()
			this.hidePageLoading()
			uni.showToast({
				title: '预约安装时间成功',
				icon: 'none'
			})
			this.doSetInstallTimeSuccess(formData.orderNo, formData.orderedTime)
		},
		// 显示设置安装时间
		doShowSetInstallTime(orderNo) {
			// 需要安装显示装修时间
			this.$refs.commonDialog.show()
			this.$nextTick(() => {
				this.$refs.installTimeForm.resetForm(orderNo)
			})	
		},
		// 确认收货
		doConfirmOrder(orderNo, isInstall) {
			uni.showModal({
				title: '提示',
				content: '是否确认收货？',
				success: async res => {
					if (!res.confirm) {
						return false
					}
					this.showPageLoading()
					let result = await ConfirmGoodsAjax({
						orderNo: orderNo
					})
					uni.showToast({
						title: '确认收货成功',
						icon: 'none'
					})
					this.hidePageLoading()
					this.doConfirmSuccess(orderNo, isInstall)
					if (isInstall) {
						// 需要安装显示装修时间
						this.doShowSetInstallTime(orderNo)
					}
				}
			})
		},
		// 支付操作
		async doContinuToPay(orderInfo) {
			if (orderInfo.companyName) {
				uni.showToast({
					title: '等待后台验证',
					icon: 'none'
				})
				return false
			}
			this.showPageLoading()
			let orderNo = orderInfo.orderNo
			let payType = orderInfo.payType1
			let payData = await Payment1Ajax({
				orderNo: orderNo,
				payType: payType,
				token: true
			})
			if (payType === this.payTypes['微信支付']) {
				// 拉起支付
				let payResult = await wxUtils.doPayMemt(payData)
				this.hidePageLoading()
				if (payResult.isPay) {
					// 微信支付成功
					uni.showToast({
						title: '支付成功',
						icon: 'none'
					})
					this.doPaySuccess(orderNo)
				}
			} else {
				// 微信支付成功
				uni.showToast({
					title: '支付成功',
					icon: 'none'
				})
				this.doPaySuccess(orderNo)
			}
		},
		// 取消操作
		doCancelOrder(orderNo) {
			uni.showModal({
				title: '提示',
				content: '是否确定要取消订单？',
				success: async res => {
					if (!res.confirm) {
						return false
					}
					this.showPageLoading()
					let result = await CancelOrderAjax({
						orderNo: orderNo
					})
					uni.showToast({
						title: '取消订单成功',
						icon: 'none'
					})
					this.hidePageLoading()
					this.doCancelSuccess(orderNo)						
				}
			})
		}
	}
}