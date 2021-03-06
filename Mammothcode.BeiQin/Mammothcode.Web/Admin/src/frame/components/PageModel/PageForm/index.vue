<template>
  <div class="form-page" :class="{ 'use-tab': isUseTabs }">
    <el-form
      v-if="formData"
      ref="commonForm"
      class="page-form"
      :model="formData"
      :style="form.style"
      :size="form.size || useConfig.size"
      :label-width="form.labelWidth"
      :rules="form.rules"
      :label-position="form.labelPosition"
    >

      <!-- 普通表单 -->
      <template v-if="!isUseTabs">
        <formEls :els="formEls" :form-data="formData" :static-data="staticData" />
        <el-col>
          <el-form-item>
            <el-button type="danger" @click="cancel">
              取消
            </el-button>
            <el-button :loading="isButtonLoading" type="success" @click="doSave">
              {{ isAdd ? '添加' : '保存' }}
            </el-button>
          </el-form-item>
        </el-col>
      </template>

      <!-- 有tabs -->
      <template v-else>
        <el-tabs v-model="activeName" v-bind="tabsProperty.props" v-on="tabsProperty.events">
          <el-tab-pane
            v-for="(item, index) in formEls"
            :key="index"
            :label="item.text"
            :name="`${index.toString()}`"
          >
            <el-scrollbar :vertical="true">
              <formEls :els="item.els" :form-data="formData" :static-data="staticData" />
            </el-scrollbar>
          </el-tab-pane>
        </el-tabs>
        <div class="fixed-bottom-btns flex-center">
          <el-button type="danger" @click="cancel">
            取消
          </el-button>
          <el-button :loading="isButtonLoading" type="success" @click="doSave">
            {{ isAdd ? '添加' : '保存' }}
          </el-button>
        </div>
      </template>

    </el-form>
    <component :is="renderComponent.name" v-if="renderComponent" :ref="renderComponent.ref" />
  </div>
</template>

<script>
import { commonAjax, combineReqData } from '@/utils/tools'
import { wrapFc } from '../utils'
import formEls from '../components/formEls'
export default {
  name: 'PageForm',
  componentName: 'PageForm',
  components: {
    formEls
  },
  props: {
    staticData: {
      type: Object,
      default: () => {}
    },
    useConfig: {
      type: Object,
      default: () => ({})
    },
    isUseTabs: {
      type: Boolean,
      default: false
    }
  },
  provide() {
    return {
      context: this.context
    }
  },
  data() {
    return {
      activeName: '0',
      isButtonLoading: false,
      formData: {},
      context: this,
      isAdd: true,
      componentIndex: 0
    }
  },
  computed: {
    form() {
      return this.useConfig.form || {}
    },
    tabsProperty() {
      const tabs = this.form.tabs || {}
      tabs.events = tabs.events || {}
      for (const k in tabs.events) {
        tabs.events[k] = tabs.events[k].bind(this)
      }
      return tabs
    },
    formEls() {
      return this.form.els
    },
    renderComponent() {
      const components = this.form.components
      if (components) {
        return {
          name: components.list[this.componentIndex],
          ref: components.ref || 'form-component'
        }
      } else {
        return null
      }
    }
  },
  created() {
    this.resetValue()
    this.setComponentIndex()
  },
  methods: {
    wrapFc,
    cancel() {
      this.$emit('close')
    },
    // 绑定数据处理
    bindDataProcess(data) {
      if (this.form.bindData && typeof this.form.bindData === 'function') {
        data = this.form.bindData.call(this, data)
      }
      return data
    },
    // 提交数据处理
    submitDataProcess(data) {
      if (this.form.beforeSubmit && typeof this.form.beforeSubmit === 'function') {
        data = this.form.beforeSubmit.call(this, data)
      }
      data = combineReqData(data)
      return data
    },
    // 重置表单值
    resetValue() {
      let data = null
      try {
        data = Object.assign({}, this.form.init.data || {})
      } catch (e) {
        data = {}
      }
      this.isAdd = true
      this.formData = this.bindDataProcess(data)
    },
    setComponentIndex(index) {
      if (this.form && this.form.components) {
        this.componentIndex = index != null ? index : this.form.components.index
      }
    },
    // 设置表单值
    setValue(value) {
      this.isAdd = false
      this.formData = this.bindDataProcess(this.cloneObj(value))
    },
    doSave() {
      this.$refs.commonForm.validate(async(valid) => {
        if (valid) {
          const data = this.submitDataProcess({ ...this.formData })
          if (!data) {
            return false
          }
          this.isButtonLoading = true
          const api = !this.isAdd
            ? this.useConfig.updUrl
            : this.useConfig.addUrl
          try {
            await commonAjax.call(this, true, api, data)
            this.$message.success('操作成功!')
            this.$emit('success')
          } catch (error) {
            //
          }
          this.isButtonLoading = false
        }
      })
    }
  }
}
</script>

<style lang="scss">
$fixed_bottom: 80px;
.form-page {
  padding: 22px 25px 20px;
  &.use-tab {
    height: 100%;
    box-sizing: border-box;
    .page-form {
      position: relative;
      height: 100%;
      padding-bottom: $fixed_bottom;
      box-sizing: border-box;
    }
    .el-tabs {
      height: 100%;
    }
    .el-tabs__content {
      height: calc(100% - 40px);
    }
    .el-tab-pane {
      height: 100%;
    }
    .el-scrollbar {
      height: 100%;
      .el-scrollbar__wrap {
        overflow-x: hidden;
      }
    }
  }
  .page-form {
    font-size: 0;
  }
  .postInfo-container-item {
    float: left;
    white-space: nowrap;
  }
  .item-fix {
    display: inline-block;
    color: #666;
    &.prefix {
      margin-right: 6px;
    }
    &.suffix {
      margin-left: 6px;
    }
  }
  .item-help-text {
    color: #999;
  }

  .fixed-bottom-btns {
    position: absolute;
    bottom: -20px;
    left: -40px;
    right: 0;
    z-index: 9;
    background-color: #fff;
    height: $fixed_bottom;
    text-align: center;
    box-shadow: -4px -2px 0px 0px rgba(0, 0, 0, .05);
  }
}
.mobile {
  .form-page {
    padding: 0;
    .fixed-bottom-btns {
      bottom: 0;
      left: -15px;
    }
  }
}

</style>
