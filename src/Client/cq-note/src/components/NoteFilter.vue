<template>
  <div class="note-filter padding-6">
    <el-row class="note-filter-title">
      <el-col :span="24">博客</el-col>
    </el-row>
    <el-row class="note-filter-toolbar">
      <el-col :span="12" class="note-filter-toolbar-num">
        共6条
      </el-col>
      <el-col :span="12" class="tar note-filter-toolbar-btn">
        <i class="el-icon-sort"></i>
        <i class="el-icon-star-off"></i>
        <i class="el-icon-more"></i>
      </el-col>
    </el-row>
    <el-row>
      <el-col :span="24">
        <el-input size="mini" placeholder="请输入筛选条件">
          <i class="el-icon-search el-input__icon" slot="suffix"> </i>
        </el-input>
      </el-col>
    </el-row>
  </div>
</template>

<script>
export default {
  name: "cq-note-filter"
};
</script>

<style scoped>
.note-filter {
  border-right: 1px solid #ccc;
  border-left: 1px solid #ccc;
  border-bottom: 1px solid #ccc;
  background-color: #f3f3f3;
}

.note-filter-title {
  height: 30px;
  line-height: 30px;
  font-weight: 600;
}

.note-filter-toolbar {
  height: 29px;
  line-height: 29px;
}

.note-filter-toolbar-num {
  font-size: 12px;
  color: #ccc;
}

.note-filter-toolbar-btn {
  font-size: 16px;
  color: #787e81;
}

.note-filter-toolbar-btn i {
  margin-left: 6px;
}
</style>
