worker.onMessage((res) => {
    setTimeout(() => {
        if (!validateHandler(res.handlerId, res.currentHandlerId)) {
            worker.postMessage({
                post: false,
                message: `${handlerId} not match right handler ${res.currentHandlerId}`
            })
            return
        } else {
            worker.postMessage({
                post: true
            })
        }
    }, res.timeOut)
})

function validateHandler(handlerId, currentHandlerId) {
    return handlerId === currentHandlerId
}