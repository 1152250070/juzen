module.exports = {
	search: function(menus, routeName) {
		let cIndex = null
		function search(menus, routeName) {
			let target = []
			let hiddenCount = 0
			for (let i = 0; i < menus.length; i++) {
				const menu = menus[i]
				if (menu.hidden) {
					hiddenCount++
				}
				if (menu.url === '/' + routeName) {
					target = [menu]
					cIndex = menu.hidden ? menu.activeIndex : (i - hiddenCount)
					break
				} else if (menu.children) {
					const result = search(menu.children, routeName)
					if (result.length) {
						target = [menu].concat(result)
					}
				}
			}
			return target
		}
		const target = search(menus, routeName)
		target.cIndex = cIndex
		return target
	},
	menus: [
		{
			text: '首页',
			icon: 'icon_menu',
			url: '/pages/index/index',
			// switchTab: true
		},
		{
			text: '波尔介绍',
			icon: 'icon_menu',
			children: [
				{
					text: '公司简介',
					en: 'Company profile',
					icon: 'icon_company',
					url: '/pages/other/index'
				},
				{
					text: '企业文化',
					en: 'Cultural philosophy',
					icon: 'icon_introduce',
					url: '/pages/other/philosophy'
				},
				{
					text: '企业荣誉',
					en: 'Cultural honor',
					icon: 'icon_honor',
					url: '/pages/other/honor'
				},
				{
					text: '发展历史',
					en: 'Company milestones',
					icon: 'icon_develop',
					url: '/pages/other/milestones'
				}
			]
		},
		{
			text: '波尔产品',
			icon: 'icon_menu',
			url: '/pages/products/index',
			// switchTab: true
		},
		{
			text: '波尔案例',
			icon: 'icon_menu',
			children: [
				{ text: '工程案例', en: 'Engineering Case', icon: 'icon_project-case', url: '/pages/example/case' },
				{ text: '工程案例详情', en: 'Engineering Case', icon: 'icon_project-case', url: '/pages/example/case-detail', hidden: true, activeIndex: 0 },
				{ text: '应用行业', en: 'Application Industry', icon: 'icon_industry', url: '/pages/example/application' },
				{ text: '应用行业详情', en: 'Engineering Case', icon: 'icon_project-case', url: '/pages/example/application-detail', hidden: true, activeIndex: 1 },
				{ text: '合作伙伴', en: 'Cooperative Partner', icon: 'icon_cooperation', url: '/pages/example/partner' }
			]
		},
		{
			text: '波尔服务',
			icon: 'icon_menu',
			children: [
				{
					text: '试压查询',
					icon: 'icon_pressure-test',
					url: '/pages/service/index'
				},
				{
					text: '管路图查询',
					icon: 'icon_piping-diagram',
					url: '/pages/service/map'
				},
				{
					text: '合作流程',
					en: 'Cooperation Process',
					icon: 'icon_cooperation',
					url: '/pages/service/coperation'
				},
				{
					text: '服务流程',
					en: 'Service Process',
					icon: 'icon_service-process',
					url: '/pages/service/progress'
				},
				{
					text: '服务承诺',
					en: 'Service promise',
					icon: 'icon_service-promise',
					url: '/pages/service/promise'
				}
			]
		},
		{
			text: '资讯中心',
			icon: 'icon_menu',
			children: [
				{
					text: '新闻',
				  en: 'news', 
				  icon: 'icon_information-center',
					url: '/pages/news/boer-news'
				},
				{
					text: '新闻详情',
				  en: 'Engineering Case', 
				  icon: 'icon_information-center',
					url: '/pages/news/boer-news-detail',
					hidden: true,
					activeIndex: 0
				},
				{
					text: '行业动态',
					en: 'Application Industry',
					icon: 'icon_industry-trends',
					url: '/pages/news/industry'
				},
				{
					text: '行业动态详情',
					en: 'Application Industry',
					icon: 'icon_industry-trends',
					url: '/pages/news/industry-detail',
					hidden: true,
					activeIndex: 1
				},
				{
					text: '视频中心',
					en: 'video center',
					icon: 'icon_video-center',
					url: '/pages/news/videos'
				},
				{
					text: '视频详情',
					en: 'video center',
					icon: 'icon_video-center',
					url: '/pages/news/video-detail',
					hidden: true,
					activeIndex: 2
				}
			]
		},
		{
			text: '经销商服务',
			icon: 'icon_menu',
			children: [
				{
					text: '加盟合作',
					en: 'Join us',
					icon: 'icon_join-in',
					url: '/pages/trade-service/index'
				},
				// {
				// 	text: '资料下载',
				// 	url: '/pages/trade-service/download'
				// }
			]
		},
		{
			text: '联系波尔',
			icon: 'icon_menu',
			children: [
				{
					text: '网点查询',
					en: 'Sales Network Inquiry', 
					icon: 'icon_Networkquery',
					url: '/pages/contact/index'
				},
				{
					text: '联系方式',
					en: 'Contact information', 
					icon: 'icon_contact-way',
					url: '/pages/contact/contact',
					// switchTab: true
				},
				{
					text: '留言咨询',
					en: 'Download', 
					icon: 'icon_message',
					url: '/pages/contact/consult'
				}
			]
		}
	]
}