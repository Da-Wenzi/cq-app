<template>
  <div class="note-title">
    <el-row>
      <el-col :span="24">
        <div class="line-2"></div>
        <div class="note-title-left fl">
          <el-input
            size="mini"
            class="note-title-input"
            placeholder="请输入标题内容"
          ></el-input>
        </div>
        <div class="note-title-right fr tar">
          <i class="el-icon-share"></i>
          <i class="el-icon-more"></i>
        </div>
      </el-col>
    </el-row>
    <el-row>
      <el-col :span="24">
        <div class="line-2"></div>
        <div class="note-title-tag-left fl">
          <el-tag class="note-title-tag" closable type="info" size="mini">
            资料
          </el-tag>
          <el-tag class="note-title-tag" closable type="info" size="mini">
            资料
          </el-tag>

          <el-tag class="note-title-tag" closable type="info" size="mini">
            资料
          </el-tag>

          <el-tag class="note-title-tag" closable type="info" size="mini">
            资料
          </el-tag>
        </div>
        <div class="note-title-tag-right fr tar">
          <span>
            2019年5月28日
          </span>
        </div>
      </el-col>
    </el-row>
  </div>
</template>

<script>
export default {
  name: "cq-note-title"
};
</script>

<style>
.note-title {
  overflow: hidden;
  height: 60px;
}

.note-title-left {
  width: calc(100% - 100px);
  height: 30px;
  line-height: 30px;
  font-size: 16px;
}

.note-title-input input {
  border: none;
}

.note-title-right {
  width: 100px;
  height: 30px;
  line-height: 30px;
  font-size: 16px;
}

.note-title-right i {
  margin-left: 6px;
  margin-right: 6px;
}

.note-title-tag {
  margin-left: 10px;
}

.note-title-tag-left {
  width: calc(100% - 100px);
  line-height: 26px;
  font-size: 16px;
}

.note-title-tag-right {
  width: 100px;
  line-height: 26px;
  font-size: 12px;
  color: #ccc;
}

.note-title-tag-right span {
  margin-right: 6px;
}
</style>
