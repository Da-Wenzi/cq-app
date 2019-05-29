<template>
  <div class="cq-toolbar">
    <div class="cq-toolbar-logo fl">
      <i class="el-icon-menu"></i>
    </div>
    <div class="cq-toolbar-menu fl">
      <el-dropdown class="cq-toolbar-menu-item">
        <span class="el-dropdown-link">
          文件
        </span>
        <el-dropdown-menu slot="dropdown">
          <el-dropdown-item>新建笔记</el-dropdown-item>
          <el-dropdown-item>新建标签</el-dropdown-item>
          <el-dropdown-item>新建笔记本</el-dropdown-item>
          <el-dropdown-item divided>导入</el-dropdown-item>
          <el-dropdown-item>导出</el-dropdown-item>
          <el-dropdown-item divided>退出</el-dropdown-item>
        </el-dropdown-menu>
      </el-dropdown>
      <el-dropdown class="cq-toolbar-menu-item">
        <span class="el-dropdown-link">
          编辑
        </span>
        <el-dropdown-menu slot="dropdown">
          <el-dropdown-item>撤销</el-dropdown-item>
          <el-dropdown-item>重做</el-dropdown-item>
          <el-dropdown-item divided>剪切</el-dropdown-item>
          <el-dropdown-item>复制</el-dropdown-item>
          <el-dropdown-item>粘贴</el-dropdown-item>
          <el-dropdown-item divided>删除</el-dropdown-item>
          <el-dropdown-item>全选</el-dropdown-item>
          <el-dropdown-item divided>查找和替换</el-dropdown-item>
        </el-dropdown-menu>
      </el-dropdown>
      <el-dropdown class="cq-toolbar-menu-item">
        <span class="el-dropdown-link">
          帮助
        </span>
        <el-dropdown-menu slot="dropdown">
          <el-dropdown-item>帮助</el-dropdown-item>
          <el-dropdown-item>入门指南</el-dropdown-item>

          <el-dropdown-item divided>我的账户页</el-dropdown-item>
          <el-dropdown-item>升级</el-dropdown-item>
          <el-dropdown-item divided>检查更新</el-dropdown-item>
          <el-dropdown-item>更新说明</el-dropdown-item>
          <el-dropdown-item divided>活动日志</el-dropdown-item>
          <el-dropdown-item divided>关于我们</el-dropdown-item>
        </el-dropdown-menu>
      </el-dropdown>
    </div>
    <div class="cq-toolbar-title fl tac">标题</div>
    <div class="cq-toolbar-btn fr">
      <div class="cq-toolbar-btn-close tac fr">
        <i class="el-icon-close"></i>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "cq-toolbar"
};
</script>

<style>
.cq-toolbar {
  height: 30px;
  line-height: 30px;
  background-color: #dddddd;
  color: #333333;
  -webkit-user-select: none;
  -webkit-app-region: drag;
}

.cq-toolbar-logo {
  width: 50px;
  height: 30px;
}

.cq-toolbar-logo i {
  margin-left: 10px;
}

.cq-toolbar-menu {
  width: 200px;
  height: 30px;
}

.cq-toolbar-title {
  width: calc(100% - 480px);
  height: 30px;
  overflow: hidden;
}

.cq-toolbar-btn {
  width: 230px;
  height: 30px;
}

.cq-toolbar-btn-close {
  width: 60px;
  height: 30px;
  -webkit-app-region: no-drag;
}

.cq-toolbar-btn i {
  margin: 0px 6px 0px 6px;
}
.cq-toolbar-btn-close:hover {
  background-color: red;
}

.cq-toolbar-menu-item {
  padding: 0px 6px;
  -webkit-app-region: no-drag;
}
</style>
