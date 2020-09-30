<template>
	<view class="container flex flex-direction">
		<view class="page-top center fs0">
			<view class="user-balance">
				<text class="fh">￥</text>
				<text>{{ userData.balanceCash || 0 }}</text>
			</view>
			<label for="">余额</label>
		</view>
		<view class="content-wrap fg1">
			<scroll-view class="scroll-view" scroll-y @scrolltolower="scrollToBottom">
				<view class="list-item flex c-center" v-for="(item, index) in table.list" :key='index'>
					<view class="fg1">
						<view class="title">
							<text>充值</text>
						</view>
						<view class="time">
							<text>{{ item.createTime }}</text>
						</view>
					</view>
					<view class="fs0 amount">
						<text>+￥{{ item.rechargeFee || 0}}</text>
					</view>
				</view>
				<list
				:status="table.status" 
				noDataImg='/static/img/error.png'
				text='未查询到数据'
				@retry='getPageList'></list>
			</scroll-view>
		</view>
		<view class="btn-recharge-wrap">
			<navigator class="btn-recharge" url="/pages/recharge/recharge">
				充值
			</navigator>
		</view>
		<view class="h30"></view>
		
		<YLoading ref='loading'></YLoading>
		
		<home></home>
		
	</view>
</template>

<script>
	import {
		GetTransferLogAjax
	} from '@/apis/api.js'
	import tab from '@/components/base/tab.vue'
	import ListPage from '@/lib/class/createList.js'
	let listPage = new ListPage({
		api: GetTransferLogAjax,
		data: {
			token: true,
			queryAll:1
		}
	})
	export default {
		mixins: [listPage],
		components: {
			tab
		},
		data() {
			return {
				userData: {},
				table: {
					list: []
				},
				tabs: [
					{text: '收入'},
					{text: '支出'}
				],
				config: {},
				currentTab: 0
			}
		},
		onShow() {
			this.addParams({
				TransferType: 1
			})
			this.getUserInfo()
			this.resetList()
			// this.config = this.$store.state.config.config
		},
		methods: {
			async getUserInfo() {
				this.ySetUserData()
				this.userData = await this.$store.dispatch('getUserData')
				console.log(this.userData)
			},
			handleTabChange(index) {
				this.currentTab = index * 1
				this.addParams({
					TransferType: this.currentTab == 0? 1 : 2
				})
				this.resetList()
			}
		}
	}
</script>

<style lang="scss" scoped>
.container {
	background: $bg-color-grey;
	min-height: 100vh;
	position: relative;
}
@import "../../style/business/my-bag.scss";
</style>
