<template>
	<view class="container">
		<tab
		id="tab"
		class="tab"
		@change='handleTabChange'
		:tabs='tabs'
		:left='30'
		:right='30'
		background= "#4255B3"
		barColor="#FFFFFF"
		:current='currentTab'></tab>

		<view v-if="currentTab == 0" class="viewAll flex" @click="handelViewAll"> 
			<view class="fg1"></view>
			<view class="flex c-center">
				<image mode="widthFix" class="item-img fs0" src="../../static/img/icon_read.png"></image>
				全部已读
			</view>
		</view>
		<view class="message-wrap">
			<view class="message-item" v-for="(item,index) in table.list" :key="index" @click="handelMemssegeRead(item)">
				<view class="message-title text-hidden flex ">
					<view class="message-name fg1 c-center flex">
						{{ item.title || '' }}
						<view v-if="currentTab == 0" class="dot"></view>
					</view>
					<text class="message-time fs0">{{item.createTime}}</text>
				</view>
				<view class="message-tip">{{ item.messageText || '' }}</view>
			</view>
		</view>
		<list :status="table.status" 
		errorImg='/static/img/error.png'
		noDataImg='/static/img/error.png'
		text='未查询到数据'
		@retry='getPageList'>
		</list>
		<YLoading ref='loading'></YLoading>

	</view>
</template>

<script>
	import {
		GetMemMemssegeList,
		GetMemMemssegeIsReadCount,
		GetMemMemssegeReadCount,
		SetAllMemMemssege,
		GetMemMemssegeSingle,
		token
	} from '@/apis/api.js'
	import tab from '@/components/base/tab.vue'
	import ListPage from '@/lib/class/createList.js'
	let listPage = new ListPage({
		api: GetMemMemssegeList,
		data: {
            token: true,
            IsRead: false
		}
	})
	export default {
		components: {
			tab
		},
		mixins: [listPage],
		data() {
			return {
				currentTab: 0,
				table: {
					list: []
				},
				tabs: [
					{text: '未读信息(0)'},
					{text: '已读信息(0)'}
				]
			}
		},
		onLoad(options) {
			this.init()
		},
		onShow() {
			if(token.value){
				this.$store.dispatch('getMemssege')
			}
		},
		methods: {
			// 初始化
			init() {
				if(token.value){
					this.getPageList()
					this.getMemMemssegeIsReadCount()
					this.getMemMemssegeReadCount()
				}
			},
			async getMemMemssegeIsReadCount() {
				let memssegeCount = await GetMemMemssegeIsReadCount({
					token: true
				})
				this.tabs[0].text = '未读信息('+ memssegeCount +')'
			},
			async getMemMemssegeReadCount() {
				let memssegeCount = await GetMemMemssegeReadCount({
					token: true
				})
				this.tabs[1].text = '已读信息('+ memssegeCount +')'
			},
			async handelMemssegeRead(item) {
				if( this.currentTab ){
					return false
				}
				await GetMemMemssegeSingle({
					token: true,
					messageId: item.id
				})
				this.$store.dispatch('getMemssege')
				this.resetList()
				this.getMemMemssegeIsReadCount()
				this.getMemMemssegeReadCount()
			},
			async handelViewAll() {
				await SetAllMemMemssege({
					token: true
				})
				this.$store.dispatch('getMemssege')
				this.resetList()
				this.getMemMemssegeIsReadCount()
				this.getMemMemssegeReadCount()
			},
			handleTabChange(index) {
				if (!token.value) {
					uni.navigateTo({
						url: '/pages/login/login'
					})
					return false
				}
				this.currentTab = index * 1
				this.addParams({
					IsRead: this.currentTab? true : false
				})
				this.resetList()
			}
		}
	}
</script>

<style lang="scss">
	.viewAll{
		color: #999999;
		margin: 30upx 30upx 0;
		.item-img{
			width: 35upx;
			height: 28upx;
			margin-right: 12upx;
		}
	}
	.message-wrap{
		margin:20upx 30upx 0;
		.message-item{
			margin-bottom: 20upx;
			padding: 20upx 14upx 20upx 20upx;
			background:#FFFFFF;
			box-shadow:0px 4upx 8upx 0px rgba(0,0,0,0.1);
			border-radius:10upx;
			.message-name{
				font-size: 32upx;
				font-weight: 700;
				margin-bottom: 10upx;
				.dot{
					width: 12upx;
					height: 12upx;
					border-radius: 50%;
					background: #AC2124;
					margin-left: 10upx;
				}
			}
			.message-time{
				color: #999999;
			}
			.message-tip{
				color: #999999;
			}
		}
	}
</style>