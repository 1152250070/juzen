import request from '@/utils/request'
import config from '@/config'

// 获得上传token
function getUploadToken() {
  return request({
    url: config.qiniu.tokenUrl,
    method: 'post',
    headers: {
      configData: {
        noError: true
      }
    }
  })
}
// 上传单个文件
export const uploadFile = (file, onUploadProgress) => {
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
      formData.append('token', token)
      const fileResult = await request({
        url: config.qiniu.uploadUrl,
        method: 'post',
        data: formData,
        onUploadProgress,
        cancelToken: file.source.token,
        headers: {
          configData: {
            noError: true
          }
        }
      })
      const data = {
        title: file.name,
        url: config.qiniu.fileUrl + fileResult.key,
        file: file,
        result: true
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
