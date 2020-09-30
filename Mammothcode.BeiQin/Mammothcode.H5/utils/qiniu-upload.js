import config from '@/config'

// 获得上传token
function getUploadToken() {
  return window.$axios.post(config.qiniu.tokenUrl, {}, {
    noError: true
  })
}
// 上传单个文件
export const uploadFile = (file) => {
  return new Promise(async(resolve, reject) => {
    try {
      const [, detailtype] = file.type.split('/')
      const token = await getUploadToken()
      const formData = new FormData()
      const date = new Date()
      const _y = date.getFullYear()
      const _m = date.getMonth() + 1
      const _d = date.getDate()
      const filename = file.newname || `${Math.random().toString().slice(2)}.${detailtype}`
      const name = `${config.qiniu.region}/${_y}${_m}${_d}/${filename}`
      formData.append('file', file)
      formData.append('key', name)
      formData.append('token', token.response.data)
      const fileResult = await window.$axios.post(config.qiniu.uploadUrl, formData, {
        noError: true
      })
      const data = {
        title: file.name,
        url: config.qiniu.fileUrl + fileResult.response.data.key,
        file: file
      }
      resolve({
        data
      })
    } catch (error) {
      reject(error)
    }
  })
}

export default {
  uploadFile: uploadFile
}
