<script>
    import {
        GetLDPrizeConfigList
    } from '@/apis/api.js'

	export default {
		onLaunch: async function(options) {
            this.$store.dispatch('getConfig')
            this.$store.dispatch('getUserData')
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
@import "./style/business/icon-font.css";
@import "./style/business/editor-content.min.css";
body {
	margin: 0;
}
</style>
