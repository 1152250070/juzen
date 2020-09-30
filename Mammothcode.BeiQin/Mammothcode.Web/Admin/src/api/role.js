import request from '@/utils/request'

export function getRole(data) {
  return request({
    url: '/Admin/GetRolesListInAdmin',
    method: 'post',
    data
  })
}
export function delRole(data) {
  return request({
    url: '/Admin/DelRolesInAdmin',
    method: 'post',
    data
  })
}

export function addRole(data) {
  return request({
    url: '/Admin/AddRolesInAdmin',
    method: 'post',
    data
  })
}

export function updRole(data) {
  return request({
    url: '/Admin/UpdateRolesInAdmin',
    method: 'post',
    data
  })
}

export function getUser(data) {
  return request({
    url: '/Admin/GetUserListInAdmin',
    method: 'post',
    data
  })
}
export function delUser(data) {
  return request({
    url: '/Admin/DelUserInAdmin',
    method: 'post',
    data
  })
}

export function addUser(data) {
  return request({
    url: '/Admin/AddUserInAdmin',
    method: 'post',
    data
  })
}

export function updUser(data) {
  return request({
    url: '/Admin/UpdateUserInAdmin',
    method: 'post',
    data
  })
}

export function adminUpdPwd(data) {
  return request({
    url: '/Admin/UpdatePasswordInAdmin',
    method: 'post',
    data
  })
}

export function userUpdPwd(data) {
  return request({
    url: '/Admin/UpdatePasswordInMember',
    method: 'post',
    data
  })
}
