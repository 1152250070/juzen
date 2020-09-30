import request from '@/utils/request'

export function login(data) {
  return request({
    url: '/Admin/Login',
    method: 'post',
    data
  })
}

export function checkLogin(token, configData) {
  return request({
    url: '/Admin/CheckLogin',
    method: 'post',
    data: { token },
    headers: {
      configData
    }
  })
}

export function getMenus(token) {
  return request({
    url: '/Admin/GetMenusListInAdmin',
    method: 'post',
    data: { token }
  })
}

export function getPowers(roCode) {
  return request({
    url: '/Admin/GetPowerInAdmin',
    method: 'post',
    data: { roCode }
  })
}

export function updPowers(data) {
  return request({
    url: '/Admin/UpdatePowerInAdmin',
    method: 'post',
    data
  })
}

export function getInfo(token) {
  return request({
    url: '/user/info',
    method: 'get',
    params: { token }
  })
}
