<template>
  <div id="app" class="full">
    <el-container class="full">
      <el-aside width="200px" class="f-tac">
        <el-tree class="full" :data="nav"></el-tree>
      </el-aside>
      <el-main>
        <el-container class="full">
          <el-aside width="400px" class="note-list">
            <el-row class="note-item">
              <el-col :span="24">
                <div class="note-item-title">
                  <b>字段名称不一致</b>
                </div>
                <div class="note-item-content">
                  定义规则模板，如果事业部业务系统字段不相同则配置规则模板。
                  业务字段与学员中心字段关系配置。
                  <div class="note-item-content-date">
                    <span>2019-01-02</span>
                  </div>
                </div>
              </el-col>
            </el-row>
          </el-aside>
          <el-main class="full">
            <mavon-editor class="full" />
          </el-main>
        </el-container>
      </el-main>
    </el-container>
  </div>
</template>

<script>
export default {
  name: "app",
  components: {},
  data() {
    return {
      nav: [
        {
          id: 1,
          label: "快捷方式",
          children: [
            {
              id: 4,
              label: "系统架构师"
            },
            {
              id: 4,
              label: "资料"
            }
          ]
        },
        {
          id: 2,
          label: "全部笔记"
        },
        {
          id: 2,
          label: "笔记本",
          children: [
            {
              id: 5,
              label: "博客"
            },
            {
              id: 6,
              label: "资料"
            }
          ]
        },
        {
          id: 3,
          label: "标签",
          children: [
            {
              id: 7,
              label: "学习"
            },
            {
              id: 8,
              label: "工作"
            }
          ]
        },
        {
          id: 3,
          label: "回收站"
        }
      ],
      defaultProps: {
        children: "children",
        label: "label"
      }
    };
  }
};
</script>

<style>
.el-main {
  margin: 0px;
  padding: 0px;
}

.note-list {
  border-right: 1px solid #ccc;
  border-left: 1px solid #ccc;
  padding: 2px;
}

.note-list .note-item {
  border-top: 1px solid #d9dcdd;
  border-right: 1px solid #fff;
  border-left: 1px solid #fff;
}

.note-list .note-item:first-child {
  border-top: 1px solid #fff;
}

.note-list .note-item:hover {
  background-color: #c1deec;
  border: 1px solid #8bcbe8;
}

.note-list .note-item:hover + .note-item {
  border-top: none;
}

.note-item .note-item-content {
  padding: 2px;
  height: 70px;
  overflow: hidden;
}

.note-item .note-item-content .note-item-content-date {
  height: 20px;
  line-height: 20px;
  color: #4982c2;
  margin-top: 6px;
  margin-bottom: 6px;
}

.note-item-title {
  height: 30px;
  line-height: 30px;
  padding: 2px;
}
</style>
