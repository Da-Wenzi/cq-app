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
                  <cq-note-list></cq-note-list>
                </el-main>
              </el-container>
            </el-aside>
            <el-main class="padding-0">
              <el-container class="full">
                <el-header height="60px" class="padding-0">
                  <cq-note-title></cq-note-title>
                </el-header>
                <el-main class="padding-0">
                  <mavon-editor class="full" />
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
  }
};
</script>

<style></style>
