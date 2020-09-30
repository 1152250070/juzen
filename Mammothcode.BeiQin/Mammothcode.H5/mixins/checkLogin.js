export default {
    onLoad() {
        this.$store.dispatch('checkLogin', this.auth)
    }
}