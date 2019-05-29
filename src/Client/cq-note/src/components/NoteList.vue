<template>
  <div class="note-list padding-6">
    <el-row class="note-item" v-for="note in notes" v-bind:key="note.id">
      <el-col :span="24">
        <div class="note-item-title">
          {{ note.title }}
        </div>
        <div class="note-item-content">
          {{ note.desc }}
          <div class="note-item-content-date">
            <span>{{ note.date }}</span>
          </div>
        </div>
      </el-col>
    </el-row>
  </div>
</template>

<script>
export default {
  name: "cq-note-list",
  data() {
    return {
      notes: [
        {
          id: 1,
          title: "企业信息化战略与实施",
          desc:
            "是对物料需求计划所需能力进行核算的一种计划管理方法，通过分析比较MRP的需求和企业现有的生产能力，及早的发现能力瓶颈所在，为实现企业生产计划而提供能力方面的保障。",
          content: "",
          date: "2019-5-28"
        },
        {
          id: 2,
          title: "企业信息化战略与实施",
          desc:
            "是对物料需求计划所需能力进行核算的一种计划管理方法，通过分析比较MRP的需求和企业现有的生产能力，及早的发现能力瓶颈所在，为实现企业生产计划而提供能力方面的保障。",
          content: "",
          date: "2019-5-28"
        },
        {
          id: 3,
          title: "企业信息化战略与实施",
          desc:
            "是对物料需求计划所需能力进行核算的一种计划管理方法，通过分析比较MRP的需求和企业现有的生产能力，及早的发现能力瓶颈所在，为实现企业生产计划而提供能力方面的保障。",
          content: "",
          date: "2019-5-28"
        },
        {
          id: 4,
          title: "企业信息化战略与实施",
          desc:
            "是对物料需求计划所需能力进行核算的一种计划管理方法，通过分析比较MRP的需求和企业现有的生产能力，及早的发现能力瓶颈所在，为实现企业生产计划而提供能力方面的保障。",
          content: "",
          date: "2019-5-28"
        }
      ]
    };
  }
};
</script>

<style scoped>
.note-list {
  border-right: 1px solid #ccc;
  border-left: 1px solid #ccc;
  height: calc(100% - 12px);
  background-color: #f3f3f3;
}

.note-list .note-item {
  border-top: 1px solid #d9dcdd;
  border-right: 1px solid #f3f3f3;
  border-left: 1px solid #f3f3f3;
}

.note-list .note-item:first-child {
  border-top: 1px solid #f3f3f3;
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
  color: #666;
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
  font-weight: 500;
}
</style>
