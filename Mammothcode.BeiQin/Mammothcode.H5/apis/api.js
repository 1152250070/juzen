import Request from './utils/request.js'
// 请求地址
export const ajaxUrl = 'http://yuyiyujiaapi.juzhentech.com/'
export const imgUrl = 'http://yuyiyujiaapi.juzhentech.com/'

// export const ajaxUrl = 'http://localhost:54774/'
// export const imgUrl = 'http://localhost:54774/'

export const qiniu = {
    open: false,
	region: 'yuyiyujiaimg',
    tokenUrl: 'api/Config/GetQiniuUploadToken',
    uploadUrl: 'https://upload.qiniup.com/',
    fileUrl: 'http://qiniuyuyiyujiauploadapi.juzhentech.com/'
}

let request = new Request({
	name: 'api',
	baseUrl: ajaxUrl,
	freeUrls: ['api/News/GetNewList']
})

export let token = request.token

export const GetQiniuUploadTokenAjax = (data, config) => {
	return request.post(qiniu.tokenUrl, data, config)
}

// 图片上传
export const UploadImgAjax = (path, {
    basePath
} = {
    basePath: 'api/upload/file'
}) => {
    return new Promise((resolve, reject) => {
        uni.uploadFile({
            url: ajaxUrl + basePath,
            name: 'file',
            filePath: path,
            formData: {
                path: 'uploadfile',
                file: path
            },
            success: function (res) {
                // 上传成功 处理数据
                resolve(res.data)
            },
            fail: function (res) {
                reject(res)
            }
        })
    })
}

export const UploadQiniuImgAjax = (path) => {
    return new Promise(async (resolve, reject) => {
        const tokenResult = await GetQiniuUploadTokenAjax({}, { // 获取上传token
            noError: true
        })
        const date = new Date()
        const _y = date.getFullYear()
        const _m = date.getMonth() + 1
        const _d = date.getDate()
        const name = `${qiniu.region}/${_y}${_m}${_d}/${Math.random().toString().slice(2)}` // 生成文件名
        const data = {
            token: tokenResult.data,
            key: name,
            file: path
        }
        uni.uploadFile({ // 上传文件到七牛
            url: qiniu.uploadUrl,
            name: 'file',
            filePath: path,
            formData: data,
            success: function (res) {
                // 上传成功 处理数据
                console.log(res)
                const data = JSON.parse(res.data)
                data.data = data.key
                resolve(JSON.stringify(data))
            },
            fail: function (res) {
                reject(res)
            }
        })
    })
}

// 配置

// 七牛云token
export const GetQiniuUploadToken = (data, config) => {
	return request.post('api/Config/GetQiniuUploadToken', data, config)
}
// 获取幻灯片列表
export const GetAdvertiseList = (data, config) => {
	return request.post('api/Config/GetAdvertiseList', data, config)
}
// 获取系统配置
export const GetSysConfig = (data, config) => {
	return request.post('api/Config/GetSysConfig', data, config)
}
// 根据城市获取经纬度
export const CityGetGoldLatitude = (data, config) => {
	return request.post('api/Config/CityGetGoldLatitude', data, config)
}
// 获取经验要求
export const GetExperienceList = (data, config) => {
	return request.post('api/Config/GetExperienceList', data, config)
}
// 获取学历要求
export const GetSalaryList = (data, config) => {
	return request.post('api/Config/GetSalaryList', data, config)
}
// 获取公司规模
export const GetCompanySizeList = (data, config) => {
	return request.post('api/Config/GetCompanySizeList', data, config)
}
// 获取公司行业
export const GetCompanyIndustryList = (data, config) => {
	return request.post('api/Config/GetCompanyIndustryList', data, config)
}
// 获取学历要求
export const GetDegreeLevelList = (data, config) => {
	return request.post('api/Config/GetDegreeLevelList', data, config)
}
// 获取证书分类
export const GetCertificateMenuList = (data, config) => {
	return request.post('api/Config/GetCertificateMenuList', data, config)
}
// 获取证书列表
export const GetCertificateList = (data, config) => {
	return request.post('api/Config/GetCertificateList', data, config)
}
// 获取城市配置
export const GetCityConfig = (data, config) => {
	return request.post('api/Config/GetCityConfig', data, config)
}

// 公司

// 获取经验要求
export const GetCompanyInform = (data, config) => {
	return request.post('api/Company/GetCompanyInform', data, config)
}
// 修改公司基本信息
export const SetetCompanyInform = (data, config) => {
	return request.post('api/Company/SetetCompanyInform', data, config)
}
// 新增公司基本信息
export const InsertCompanyInform = (data, config) => {
	return request.post('api/Company/InsertCompanyInform', data, config)
}
// 新建公司高管管理
export const AddCompanyExecutives = (data, config) => {
	return request.post('api/Company/AddCompanyExecutives', data, config)
}
// 修改公司高管管理
export const UpdateCompanyExecutives = (data, config) => {
	return request.post('api/Company/UpdateCompanyExecutives', data, config)
}
// 删除公司高管管理
export const DeleteCompanyExecutives = (data, config) => {
	return request.post('api/Company/DeleteCompanyExecutives', data, config)
}
// 获取公司高管管理列表
export const GetCompanyExecutivesList = (data, config) => {
	return request.post('api/Company/GetCompanyExecutivesList', data, config)
}
// 获取公司高管管理列表
export const GetCompanyExecutiveDetails = (data, config) => {
	return request.post('api/Company/GetCompanyExecutiveDetails', data, config)
} 

// 奖品

// 获取奖品配置列表
export const GetLDPrizeConfigList = (data, config) => {
	return request.post('api/LuckyDraw/GetLDPrizeConfigList', data, config)
}
// 随机中奖
export const RandomLDPrize = (data, config) => {
	return request.post('api/LuckyDraw/RandomLDPrize', data, config)
}
// 提交邀请码
export const SubmitInviteCode = (data, config) => {
	return request.post('api/LuckyDraw/SubmitInviteCode', data, config)
}
// 获取邀请记录
export const GetInviteRecordList = (data, config) => {
	return request.post('api/LuckyDraw/GetInviteRecordList', data, config)
}
// 保存中奖记录
export const SaveWinningRecord = (data, config) => {
	return request.post('api/LuckyDraw/SaveWinningRecord', data, config)
}
// 获取中奖记录
export const GetWinningRecordList = (data, config) => {
	return request.post('api/LuckyDraw/GetWinningRecordList', data, config)
}
// 获取中奖记录
export const GetMemberInvite = (data, config) => {
	return request.post('api/LuckyDraw/GetMemberInvite', data, config)
}

// 用户

// 手机号码用户注册
export const MemberRegister = (data, config) => {
	return request.post('api/Member/MemberRegister', data, config)
}
// H5用户注册
export const H5Register = (data, config) => {
	return request.post('api/Member/H5Register', data, config)
}
// 获取用户基本信息
export const GetMemberInfo = (data, config) => {
	return request.post('api/Member/GetMemberInfo', data, config)
}
// 发送短信验证码
export const SendMobileMessage = (data, config) => {
	return request.post('api/Member/SendMobileMessage', data, config)
}
// 用户登录
export const MemberLogin = (data, config) => {
	return request.post('api/Member/MemberLogin', data, config)
}
// 重置密码
export const SetForgetPossword = (data, config) => {
	return request.post('api/Member/SetForgetPossword', data, config)
}
// 用户手机号验证码登录
export const MemberMobileLogin = (data, config) => {
	return request.post('api/Member/MemberMobileLogin', data, config)
}
// 验证Token是否失效
export const CheckLogin = (data, config) => {
	return request.post('api/Member/CheckLogin', data, config)
}
// 完善个人信息
export const SetMemInfm = (data, config) => {
	return request.post('api/Member/SetMemInfm', data, config)
}
// 修改手机号
export const SetMemberMobile = (data, config) => {
	return request.post('api/Member/SetMemberMobile', data, config)
}
// 修改密码
export const SetMemberPossword = (data, config) => {
	return request.post('api/Member/SetMemberPossword', data, config)
}
// 新建期望职位
export const AddApplicantExpectedPosition = (data, config) => {
	return request.post('api/Member/AddApplicantExpectedPosition', data, config)
}
// 修改期望职位
export const UpdateApplicantExpectedPosition = (data, config) => {
	return request.post('api/Member/UpdateApplicantExpectedPosition', data, config)
}
// 删除期望职位
export const DeleteApplicantExpectedPosition = (data, config) => {
	return request.post('api/Member/DeleteApplicantExpectedPosition', data, config)
}
// 获取期望职位列表
export const GetApplicantExpectedPositionList = (data, config) => {
	return request.post('api/Member/GetApplicantExpectedPositionList', data, config)
}
// 新建工作经历
export const AddApplicantWorkExperience = (data, config) => {
	return request.post('api/Member/AddApplicantWorkExperience', data, config)
}
// 修改工作经历
export const UpdateApplicantWorkExperience = (data, config) => {
	return request.post('api/Member/UpdateApplicantWorkExperience', data, config)
}
// 删除工作经历
export const DeleteApplicantWorkExperience = (data, config) => {
	return request.post('api/Member/DeleteApplicantWorkExperience', data, config)
}
// 获取工作经历列表
export const GetApplicantWorkExperienceList = (data, config) => {
	return request.post('api/Member/GetApplicantWorkExperienceList', data, config)
}
// 新建教育经历
export const AddApplicantEduExperience = (data, config) => {
	return request.post('api/Member/AddApplicantEduExperience', data, config)
}
// 修改教育经历
export const UpdateApplicantEduExperience = (data, config) => {
	return request.post('api/Member/UpdateApplicantEduExperience', data, config)
}
// 删除教育经历
export const DeleteApplicantEduExperience = (data, config) => {
	return request.post('api/Member/DeleteApplicantEduExperience', data, config)
}
// 获取教育经历列表
export const GetApplicantEduExperienceList = (data, config) => {
	return request.post('api/Member/GetApplicantEduExperienceList', data, config)
}
// 求职者对自己喜欢的职位留言
export const SaveApplicantLeaveMessage = (data, config) => {
	return request.post('api/Member/SaveApplicantLeaveMessage', data, config)
}
// 招聘者对牛人留言
export const SaveCompanyLeaveMessage = (data, config) => {
	return request.post('api/Member/SaveCompanyLeaveMessage', data, config)
}
// 获取求职者的会话框列表
export const GetLeaveFriendList = (data, config) => {
	return request.post('api/Member/GetLeaveFriendList', data, config)
}
// 获取招聘者的会话框列表
export const GetComLeaveFriendList = (data, config) => {
	return request.post('api/Member/GetComLeaveFriendList', data, config)
}
// 获取消息详情
export const GetLeaveFriendMessageList = (data, config) => {
	return request.post('api/Member/GetLeaveFriendMessageList', data, config)
}
// 全部置为已读
export const SetLeaveMessage = (data, config) => {
	return request.post('api/Member/SetLeaveMessage', data, config)
}
// 招聘者给求职发消息留言
export const ComSendApplicantMessage = (data, config) => {
	return request.post('api/Member/ComSendApplicantMessage', data, config)
}
// 求职者给招聘者发消息留言
export const ApplicantSendComMessage = (data, config) => {
	return request.post('api/Member/ApplicantSendComMessage', data, config)
}
// 统计用户共有多少条没有阅读的消息
export const SumLeaveMessageNum = (data, config) => {
	return request.post('api/Member/SumLeaveMessageNum', data, config)
}
// 统计用户发布，点赞，评论数量
export const SumPostLikeCommentNum = (data, config) => {
	return request.post('api/Member/SumPostLikeCommentNum', data, config)
}
// 统计留言数，感兴趣数
export const SumLeaveLikeNum = (data, config) => {
	return request.post('api/Member/SumLeaveLikeNum', data, config)
}
// 改变用户求职状态
export const SetMemberJobStatus = (data, config) => {
	return request.post('api/Member/SetMemberJobStatus', data, config)
}
// 招聘者是否完善招聘信息
export const ComIsPerfectInform = (data, config) => {
	return request.post('api/Member/ComIsPerfectInform', data, config)
}
// 改变用户角色
export const UpdateMemRole = (data, config) => {
	return request.post('api/Member/UpdateMemRole', data, config)
}
// 用户反馈建议
export const SendSuggestion = (data, config) => {
	return request.post('api/Member/SendSuggestion', data, config)
}

// 职位

// 获取获取一级类目分类
export const GetPositionMenuList = (data, config) => {
	return request.post('api/Position/GetPositionMenuList', data, config)
}
// 获取获取二级级类目分类
export const GetPositionMenuTweList = (data, config) => {
	return request.post('api/Position/GetPositionMenuTweList', data, config)
}
// 获取公司职位分类
export const GetPositionMenuAllList = (data, config) => {
	return request.post('api/Position/GetPositionMenuAllList', data, config)
}
// 获取职位列表
export const GetPositionList = (data, config) => {
	return request.post('api/Position/GetPositionList', data, config)
}
// 获取我发布的职位列表
export const GetMyPositionList = (data, config) => {
	return request.post('api/Position/GetMyPositionList', data, config)
}
// 统计公司上架中的职位数量
export const GetComPositionCount = (data, config) => {
	return request.post('api/Position/GetComPositionCount', data, config)
}
// 获取职位详情
export const GetPositionDetails = (data, config) => {
	return request.post('api/Position/GetPositionDetails', data, config)
}
// 发布职位
export const ReleasePosition = (data, config) => {
	return request.post('api/Position/ReleasePosition', data, config)
}
// 修改职位
export const EditPosition = (data, config) => {
	return request.post('api/Position/EditPosition', data, config)
}
// 打开关闭职位
export const IsUpPosition = (data, config) => {
	return request.post('api/Position/IsUpPosition', data, config)
}
// 删除公司职位
export const DelPosition = (data, config) => {
	return request.post('api/Position/DelPosition', data, config)
}
// 获取企业列表
export const GetCompanyList = (data, config) => {
	return request.post('api/Position/GetCompanyList', data, config)
}
// 获取企业详情
export const GetCompanyDetails = (data, config) => {
	return request.post('api/Position/GetCompanyDetails', data, config)
}
// 获取牛人列表
export const GetApplicantList = (data, config) => {
	return request.post('api/Position/GetApplicantList', data, config)
}
// 查看求职者简历
export const GetApplicantDetails = (data, config) => {
	return request.post('api/Position/GetApplicantDetails', data, config)
}
// 查看求职者简历上一页下一页
export const GetApplicantPageDetails = (data, config) => {
	return request.post('api/Position/GetApplicantPageDetails', data, config)
}
// 职位查看人
export const GetPositionLookList = (data, config) => {
	return request.post('api/Position/GetPositionLookList', data, config)
}
// 职位留言人
export const GetMLeaveMessageList = (data, config) => {
	return request.post('api/Position/GetMLeaveMessageList', data, config)
}

// 咨询

// 获取资讯列表
export const GetInformationList = (data, config) => {
	return request.post('api/Social/GetInformationList', data, config)
}
// 获取资讯详情
export const GetInformationDetails = (data, config) => {
	return request.post('api/Social/GetInformationDetails', data, config)
}
// 获取话题分类列表
export const GetTopicMenuList = (data, config) => {
	return request.post('api/Social/GetTopicMenuList', data, config)
}
// 获取话题列表
export const GetTopicContentList = (data, config) => {
	return request.post('api/Social/GetTopicContentList', data, config)
}
// 获取话题详情
export const GetTopicContentDetails = (data, config) => {
	return request.post('api/Social/GetTopicContentDetails', data, config)
}
// 获取帖子列表
export const GetTopicPostList = (data, config) => {
	return request.post('api/Social/GetTopicPostList', data, config)
}
// 获取用户点赞的帖子
export const GetTopicZanList = (data, config) => {
	return request.post('api/Social/GetTopicZanList', data, config)
}
// 获取帖子详情
export const GetTopicPostDetails = (data, config) => {
	return request.post('api/Social/GetTopicPostDetails', data, config)
}
// 获取我发布的帖子列表
export const GetMyTopicPostList = (data, config) => {
	return request.post('api/Social/GetMyTopicPostList', data, config)
}
// 发布帖子
export const InsertMyTopicPost = (data, config) => {
	return request.post('api/Social/InsertMyTopicPost', data, config)
}
// 编辑帖子
export const EditMyTopicPost = (data, config) => {
	return request.post('api/Social/EditMyTopicPost', data, config)
}
// 获取我发布的帖子详情
export const GetMyTopicPostDetails = (data, config) => {
	return request.post('api/Social/GetMyTopicPostDetails', data, config)
}
// 删除我发布的帖子
export const DelMyTopicPostDetails = (data, config) => {
	return request.post('api/Social/DelMyTopicPostDetails', data, config)
}
// 获取帖子评论管理
export const GetTopicPostComments = (data, config) => {
	return request.post('api/Social/GetTopicPostComments', data, config)
}
// 新增用户评论
export const AddTopicPostComment = (data, config) => {
	return request.post('api/Social/AddTopicPostComment', data, config)
}
// 新增用户回复
export const AddTopicPostReply = (data, config) => {
	return request.post('api/Social/AddTopicPostReply', data, config)
}
// 删除用户回复
export const DelCommentReply = (data, config) => {
	return request.post('api/Social/DelCommentReply', data, config)
}
// 删除用户评论
export const DelComment = (data, config) => {
	return request.post('api/Social/DelComment', data, config)
}
// 判断用户是否对这条帖子点赞
export const BoolMemberZan = (data, config) => {
	return request.post('api/Social/BoolMemberZan', data, config)
}
// 用户对这条帖子点赞
export const AddTopicPostLike = (data, config) => {
	return request.post('api/Social/AddTopicPostLike', data, config)
}
// 删除用户点赞
export const DelPostLike = (data, config) => {
	return request.post('api/Social/DelPostLike', data, config)
}
// 判断用户感兴趣
export const BoolMInterestedPosition = (data, config) => {
	return request.post('api/Social/BoolMInterestedPosition', data, config)
}
// 用户对感兴趣
export const AddMInterestedPosition = (data, config) => {
	return request.post('api/Social/AddMInterestedPosition', data, config)
}
// 删除感兴趣
export const DelMInterestedPosition = (data, config) => {
	return request.post('api/Social/DelMInterestedPosition', data, config)
}
// 获取用户感兴趣的职位
export const GetMInterestedPositionList = (data, config) => {
	return request.post('api/Social/GetMInterestedPositionList', data, config)
}
// 获取用户留言的职位
export const GetMLeavePositionList = (data, config) => {
	return request.post('api/Social/GetMLeavePositionList', data, config)
}
// 判断用户是否关注话题
export const BoolTopicFocusOn = (data, config) => {
	return request.post('api/Social/BoolTopicFocusOn', data, config)
}
// 用户关注话题
export const AddTopicFocusOn = (data, config) => {
	return request.post('api/Social/AddTopicFocusOn', data, config)
}
// 删除关注话题
export const DelTopicFocusOn = (data, config) => {
	return request.post('api/Social/DelTopicFocusOn', data, config)
}
// 获取用户关注话题
export const GetTopicFocusOnList = (data, config) => {
	return request.post('api/Social/GetTopicFocusOnList', data, config)
}
// 获取用户评论过的帖子
export const GetMEvaluateTopicPostList = (data, config) => {
	return request.post('api/Social/GetMEvaluateTopicPostList', data, config)
}