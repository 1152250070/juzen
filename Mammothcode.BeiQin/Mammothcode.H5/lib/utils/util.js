// 获取scene参数
const getSceneParams = (scene, splitKey = '=') => {
	let params = {}
	if (!scene) {
		return params
	}
	decodeURIComponent(scene).split('&').forEach((sceneInfo) => {
		let sceneInfoArr = sceneInfo.split(splitKey)
		params[sceneInfoArr[0]] = sceneInfoArr[1]
	})
	return params
}

export const secretName = (name) => {
	function isNormal(str) {
		return /[\u4e00-\u9fa5\u0000-\u00ff\uff00-\uffff]/.test(str)
	}
	if (!name) {
		return '***'
	} else if (name.length === 1 || name.length === 2) {
		let str = isNormal(name.slice(0, 1))
			? name.slice(0, 1)
			: name.slice(0, 2)
		return str + '**'
	} else {
		let start = isNormal(name.slice(0, 1))
			? name.slice(0, 1)
			: name.slice(0, 2)
		let end = isNormal(name.slice(-1))
			? name.slice(-1)
			: name.slice(-2)
		return start + '***' + end
	}
}

const isIos = uni.getSystemInfoSync().system.toLowerCase().indexOf('ios') !== -1
// 微信工具
const wxUtils = {
	// 拨电话
	makePhonecall(phone) {
		if (isIos) {
			uni.makePhoneCall({
				phoneNumber: phone
			})
		} else {
			uni.showActionSheet({
				itemList: [phone, '呼叫'],
				success: res => {
					uni.makePhoneCall({
						phoneNumber: phone
					})
				}
			})
		}
	},
	isUseFlow() {
		return new Promise(resolve => {
			this.getNetworkType().then(type => {
				resolve(!!~['2g', '3g', '4g', '5g'].indexOf(type))
			})
		})
	},
	// 网络
	getNetworkType() {
		return new Promise(resolve => {
			uni.getNetworkType({
				success: res => {
					resolve(res.networkType)
				}
			})
		})
	},
	// 获取注册参数
	getRegisterData(detail) {
		return new Promise((resolve) => {
			uni.login({
				success: res => {
					resolve({
						jsCode: res.code,
						nickName: detail.userInfo.nickName,
						headImg: detail.userInfo.avatarUrl,
						sex: detail.userInfo.gender,
						encryptedData: detail.encryptedData,
						iv: detail.iv,
						signature: detail.signature
					})
				}
			})
		})
	},
	getJsCode() {
		return new Promise(resolve => {
			uni.login({
				success: res => {
					resolve(res.code)
				}
			})
		})
	},
	// 保存图片
	saveImage: function() {
		const save = (path) => {
			uni.saveImageToPhotosAlbum({
				filePath: path,
				success: function(res) {
					uni.showToast({
						title: '保存成功',
					})
				},
				fail: function(res) {
					console.log(res)
				}
			})
		}

		// 下载图片 获取临时路径
		uni.downloadFile({
			url: url,
			success: function(response) {
				// 获取当前的授权权限信息
				uni.getSetting({
					success: function(res) {
						// 如果没有授权
						if (!res.authSetting['scope.writePhotosAlbum']) {
							// 提示授权
							uni.authorize({
								scope: 'scope.writePhotosAlbum',
								// 接受授权
								success() {
									save(response.tempFilePath)
								},
								// 被拒绝 发出提示
								fail() {
									uni.showModal({
										title: '提示',
										content: '若不授权保存至相册，则无法保存图片只相册；点击授权可以去设置打开授权功能；若点击不授权，后期需要在删除该小程序后重新搜索才可以授权。',
										success: function(res) {
											if (res.confirm) {
												uni.openSetting()
											}
										}
									})
								}
							})
						} else {
							// 已经授权
							save(response.tempFilePath)
						}
					}
				})
			},
			fail: function(res) {
				console.log(res)
			}
		})
	},
	// 拉起支付
	doPayMemt: function(data) {
		return new Promise((resolve, reject) => {
			uni.requestPayment({
				nonceStr: data.nonceStr,
				package: data.package,
				signType: data.signType,
				paySign: data.sign,
				timeStamp: data.timeStamp,
				success: res => {
					resolve({
						isPay: true
					})
				},
				fail: res => {
					resolve({
						isPay: false,
						message: res
					})
				}
			})
		})
	}
}

function getType(val) {
  return Object.prototype.toString.call(val).slice(8, -1).toLowerCase()
}

function groupBy(data, o, sortKey, isAsc) {
  var ret = []; var i; var l
  if (typeof o === 'function') {
    ret[0] = []
    ret[1] = []
    for (i = 0, l = data.length; i < l; i++) {
      if (o(data[i], i)) {
        ret[0].push(data[i])
      } else {
        ret[1].push(data[i])
      }
    }
  } else {
    var keys = []
    for (i = 0, l = data.length; i < l; i++) {
      if (!data[i]) continue
      var keyValue = data[i][o]
      var keyIndex = keys.indexOf(keyValue)
      if (~keyIndex) {
        ret[keyIndex].push(data[i])
      } else {
        ret.push([data[i]])
        keys.push(keyValue)
      }
    }
    if (sortKey) {
      ret = ret.sort(function(a, b) {
        if (isAsc) {
          return (a[0][sortKey] || 0) - (b[0][sortKey] || 0)
        } else {
          return (b[0][sortKey] || 0) - (a[0][sortKey] || 0)
        }
      })
    }
  }
  return ret
}

function tree(data, superKey, subKey, sortKey, sortMode = 1) {
  const tree = []
  const leaves = []
  for (const v of data) {
    if (!v[subKey]) {
      tree.push(v)
    } else {
      const branch = tree.find(branch => branch[superKey] === v[subKey])
      if (branch) {
        branch.children = branch.children || []
        branch.children.push(v)
      } else {
        leaves.push(v)
      }
    }
  }
  function sortData(data, sortKey, sortMode) {
    if (!data || getType(data) !== 'array' || data.length === 0) {
      return false
    }
    if (!sortKey) {
      return data
    }
    data.sort((a, b) => {
      if (sortMode > 0) {
        return b[sortKey] - a[sortKey]
      } else {
        return a[sortKey] - b[sortKey]
      }
    })
  }
  function appendleave(data) {
    data.forEach(branch => {
      const children = leaves.filter(leave => leave[subKey] === branch[superKey])
      if (children && children.length > 0) {
        branch.children = (branch.children || []).concat(children)
      }
      sortData(branch.children, sortKey, sortMode)
      if (branch.children) {
        appendleave(branch.children)
      }
    })
  }
  appendleave(tree)
  sortData(tree, sortKey, sortMode)
  return tree
}

/* 合并对象 */
function merge() {
	let result = {};

	function assignValue(val, key) {
		if (typeof result[key] === 'object' && typeof val === 'object') {
			result[key] = merge(result[key], val)
		} else {
			result[key] = val
		}
	}
	for (let i = 0, l = arguments.length; i < l; i++) {
		let obj = arguments[i]
		for (let k in obj) {
			if (Object.prototype.hasOwnProperty.call(obj, k)) {
				assignValue(obj[k], k)
			}
		}
	}
	return result
}

/* JSON Copy */
function cloneObj(o) {
	return JSON.parse(JSON.stringify(o))
}

/* 读取对象属性 */
function readObjInfo(obj, routes) {
	let data = cloneObj(obj)
	for (var i = 0, l = routes.length; i < l; i++) {
		data = data[routes[i]]
	}
	return data
}

/* 图片上传 */
function uploadMultImg(api, head, imgsText) {
	let promiseList = imgsText.split(',').map(item => {
		return new Promise((resolve) => {
			api(item).then(res => {
				resolve(res)
			})
		})
	})
	return Promise.all(promiseList).then(res => {
		return res.map(item => {
			let src = ''
			try{
				src =  head + JSON.parse(item).data
			} catch(e){
				src = ''
			}
			return src
		}).join(',')
	})
} 

function isVideo(url) {
	const array = url.split('.')
	const suffix = array[array.length - 1]
	if (!suffix) {
		return false
	}
	return !!~['mp4','flv','avi','rm','rmvb'].indexOf(suffix)
}

module.exports = {
	wxUtils,
	uploadMultImg,
	getSceneParams,
	merge,
	readObjInfo,
	cloneObj,
	isVideo,
	secretName,
	groupBy,
	tree,
	getType
}
