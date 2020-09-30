const isProduction = process.env.NODE_ENV === 'production'

module.exports = {
  /**
   * @description 请求地址
   */
  baseUrl: isProduction ? 'http://yuyiyujiaapi.juzhentech.com/' : 'http://localhost:54774/',
  /**
   * @description 是否生产环境 通常和图片上传请求地址相关
   */
  isProduction: isProduction,

  /**
   * 七牛云相关参数配置
   * @param {Boolean} open 是否开启
   * @param {String} region 空间名称
   * @param {String} tokenUrl 七牛云token后台请求地址
   * @param {String} uploadUrl 七牛云上传接口地址
   * @param {String} fileUrl 七牛云文件域名地址
   */
  qiniu: {
    open: false,
    region: 'yuyiyujiaimg',
    tokenUrl: '/api/Config/GetQiniuUploadToken',
    uploadUrl: 'https://upload.qiniup.com/',
    fileUrl: 'http://qiniuyuyiyujiauploadapi.juzhentech.com/'
  }
}
