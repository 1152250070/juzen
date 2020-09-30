export const dateFormat = function (date, formatStr = 'yyyy-MM-dd', netTimeStamp = false) {
  if (!date || date === '') return '-/-/-'
  if (typeof date === 'string') {
    // 去除时区时差影响
    date = date.replace('T', ' ').replace(/-/g, '/')
    date = new Date(date)
  } else if (typeof date === 'number') {
    if (netTimeStamp) {
      // 如果是 .net 时间戳, 单位为秒
      date = new Date(date * 1000)
    } else {
      // 不是则自动判断
      // 如果 * 1000 后超过 2100/12/31 则自动判断为毫秒时间戳
      // 否则则自动判断为秒时间戳
      if (date * 1000 > 4133865600000) {
        date = new Date(date)
      } else {
        date = new Date(date * 1000)
      }
    }
  } else {
    date = new Date(date)
  }
  var week = {
    '0': '\u65e5',
    '1': '\u4e00',
    '2': '\u4e8c',
    '3': '\u4e09',
    '4': '\u56db',
    '5': '\u4e94',
    '6': '\u516d'
  }
  var map = {
    'M': date.getMonth() + 1, // 月份
    'd': date.getDate(), // 日
    'h': date.getHours(), // 小时
    'm': date.getMinutes(), // 分
    's': date.getSeconds(), // 秒
    'q': Math.floor((date.getMonth() + 3) / 3), // 季度
    'S': date.getMilliseconds() // 毫秒
  }
  formatStr = formatStr.replace(/([yMdhmsEqS])+/g, function (all, t) {
    var v = map[t]
    if (v !== undefined) {
      if (all.length > 1) {
        v = '0' + v
        v = v.substr(v.length - 2)
      }
      return v
    } else if (t === 'y') {
      return (date.getFullYear() + '').substr(4 - all.length)
    } else if (t === 'E') {
      var w = week[date.getDay()]
      if (all.length === 1) {
        return w
      } else if (all.length === 2) {
        return '\u5468' + w
      } else {
        return '\u661f\u671f' + w
      }
    }
    return all
  })
  return formatStr
}

function formatNumber(n) {
	n += ''
	return n[1] != null ? n : '0' + n
}

function dateTextValid(text) {
  return text ? text.replace('T', ' ').replace(/-/g, '/') : ''
}

export const dateTextToDate = function(text) {
  return new Date(dateTextValid(text))
}

export const dateTextToStamp = function(text) {
  return new Date(dateTextValid(text)).getTime()
}

export const validIsDateOn = function(start, end) {
  if (!start || !end) {
    return false
  }
  const now = Date.now()
  return dateTextToStamp(start) < now && dateTextToStamp(end) > now
}

export const date2Text = function(date, date2) {
  const stamp2 = date.getTime()
  const stamp1 = date2 ? date2.getTime() : Date.now()
  const _second = ((stamp1 - stamp2) / 1000).toFixed(0) - 0
  const second = 60 - 1
  const minute = 60 * 60 - 1
  const hour = 60 * 60 * 24 - 1
  const day = 60 * 60 * 24 * 30 - 1
  const month = 60 * 60 * 24 * 30 * 12 - 1
  let text = ''
  if (_second > month) {
    text = Math.floor(_second / month) + '年'
  } else if (_second > day) {
    text = Math.floor(_second / day) + '月'
  } else if (_second > hour) {
    text = Math.floor(_second / hour) + '天'
  } else if (_second > minute) {
    text = Math.floor(_second / minute) + '小时'
  } else if (_second > second) {
    text = Math.floor(_second / second) + '分钟'
  } else {
    text = _second + '秒前'
  }
  return text
}

// 获取剩余时间数组
export const getLeftTime = (date) => {
  let now = Date.now()
  let endStamp = dateTextToStamp(date)
  var StatusSecond = (endStamp - now) / 1000
	var day = formatNumber(parseInt(Math.floor(StatusSecond / 86400)));
  var hour = formatNumber(parseInt(StatusSecond / 3600 % 24));
  var min = formatNumber(parseInt(StatusSecond / 60 % 60));
  var sec = formatNumber(parseInt(StatusSecond % 60));
  return [day, hour, min, sec]
}

export default {
  dateTextToStamp: dateTextToStamp,
  validIsDateOn: validIsDateOn,
  dateFormat: dateFormat,
  dateTextToDate: dateTextToDate,
  date2Text: date2Text,
  getLeftTime: getLeftTime
}