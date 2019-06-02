<template>
  <div id="app" class="full">
    <el-container class="full">
      <el-header height="30px" class="padding-0">
        <cq-toolbar />
      </el-header>
      <el-container class="full">
        <el-aside width="200px" class="tac">
          <cq-nav></cq-nav>
        </el-aside>
        <el-main class="padding-0">
          <el-container class="full">
            <el-aside width="400px">
              <el-container class="full">
                <el-header height="100px" class="padding-0">
                  <cq-note-filter></cq-note-filter>
                </el-header>
                <el-main class="padding-0">
                  <cq-note-list :notes="notes"></cq-note-list>
                </el-main>
              </el-container>
            </el-aside>
            <el-main class="padding-0">
              <el-container class="full">
                <el-header height="60px" class="padding-0">
                  <cq-note-title :note="note"></cq-note-title>
                </el-header>
                <el-main class="padding-0">
                  <mavon-editor
                    class="full"
                    v-on:save="save"
                    v-model="note.content"
                    v-on:imgAdd="imgAdd"
                  />
                </el-main>
              </el-container>
            </el-main>
          </el-container>
        </el-main>
      </el-container>
    </el-container>
  </div>
</template>

<script>
import CqNav from "./components/Nav.vue";
import CqNoteList from "./components/NoteList.vue";
import CqNoteFilter from "./components/NoteFilter.vue";
import CqNoteTitle from "./components/NoteTitle.vue";
import CqToolbar from "./components/Toolbar.vue";

export default {
  name: "app",
  components: { CqNav, CqNoteList, CqNoteFilter, CqNoteTitle, CqToolbar },
  data() {
    return {};
  },
  watch: {
    "note.content": function(newVal) {
      this.$store.dispatch("note/modifyNoteContent", newVal);
    }
  },
  computed: {
    note() {
      var editNote = this.$store.state.note.editNote;
      if (editNote) {
        return this.$store.state.note.editNote;
      }
      return {};
    },
    notes() {
      return this.$store.state.note.notes;
    }
  },
  methods: {
    save: function() {
      this.$store.dispatch("note/async");
    },
    imgAdd: function(pos, file) {
      console.log(pos, file);
    }
  },
  created() {
    this.$store.dispatch("note/getNotes");
  }
};
</script>

<style></style>
