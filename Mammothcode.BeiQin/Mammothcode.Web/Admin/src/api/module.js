import request from '@/utils/request'

export function getModule(data) {
  return request({
    url: '/Admin/GetMenusListInAdmin',
    method: 'post',
    data
  })
}
export function delModule(data) {
  return request({
    url: '/Admin/DelMenusInAdmin',
    method: 'post',
    data
  })
}

export function addModule(data) {
  return request({
    url: '/Admin/AddMenusInAdmin',
    method: 'post',
    data
  })
}

export function updModule(data) {
  return request({
    url: '/Admin/UpdateMenusInAdmin',
    method: 'post',
    data
  })
}
