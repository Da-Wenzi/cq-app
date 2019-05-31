<template>
  <div class="note-list padding-6">
    <el-row
      v-bind:class="['note-item', { 'note-item-select': i === index }]"
      v-for="(note, index) in notes"
      v-bind:key="note.id"
      v-on:click.native="select(index, note)"
    >
      <el-col :span="24">
        <div class="note-item-title">
          {{ note.title }}
        </div>
        <div class="note-item-content">
          {{ note.description }}
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
  props: ["notes"],
  data() {
    return {
      i: null
    };
  },
  methods: {
    select: function(index, note) {
      this.i = index;
      this.$store.dispatch("note/selectNote", note);
    }
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

.note-item .note-item-title {
  height: 30px;
  line-height: 30px;
  padding: 2px;
  font-weight: 500;
}

.note-list .note-item:first-child {
  border-top: 1px solid #f3f3f3;
}

.note-list .note-item:hover {
  background-color: #eff8fe;
  border: 1px solid #c3e5f5;
}

.note-list .note-item:hover + .note-item {
  border-top: none;
}

.note-list .note-item-select {
  background-color: #c1deec;
  border: 1px solid #8bcbe8;
}

.note-list .note-item-select + .note-item {
  border-top: none;
}

.note-list .note-item-select.note-item:hover {
  background-color: #c1deec;
  border: 1px solid #8bcbe8;
}

.note-list .note-item:first-child.note-item-select {
  border-top: 1px solid #8bcbe8;
}
</style>
