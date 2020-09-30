<script>
	import {
		token
	} from '@/apis/api.js'
	export default {
		onLaunch: function(options) {
			// if (options.query.parentId) {
			// 	this.$store.commit('updateParentId', options.query.parentId)
			// }
			// this.$store.dispatch('getUserData')
			this.$store.dispatch('getConfig')
		},
		onShow: function() {
		},
		onHide: function() {
		},
		methods: {
		}
	}
</script>

<style lang="scss">
@import "./style/base/common.scss";
</style>
