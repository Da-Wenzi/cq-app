<template>
  <el-container class="nav full">
    <el-header>
      <div class="line-10"></div>
      <el-button icon="el-icon-plus" v-on:click="addNote">添加新笔记</el-button>
    </el-header>
    <el-main class="padding-0">
      <el-tree class="full" :data="nav"> </el-tree>
    </el-main>
  </el-container>
</template>

<script>
export default {
  name: "cq-nav",
  data() {
    return {
      nav: [
        {
          id: 1,
          label: "快捷方式",
          children: [
            {
              id: 4,
              icon: "el-icon-upload",
              label: "系统架构师1111"
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
  },
  methods: {
    addNote: function() {
      this.$store.dispatch("note/addNote");
    }
  }
};
</script>

<style>
.nav,
.nav .el-tree {
  background-color: #2c2c2c;
  color: #ababab;
}

.nav .el-tree-node__content:hover {
  background-color: #2c2c2c;
  color: #fff;
}

.nav .el-tree-node:focus > .el-tree-node__content {
  background-color: #2c2c2c;
  color: #fff;
}

.nav .el-button {
  background-color: #2c2c2c;
  color: #ababab;
}
</style>
