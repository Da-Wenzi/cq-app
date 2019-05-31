import Vue from "vue";
import Vuex from "vuex";
import note from "./modules/note.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    content: ""
  },
  mutations: {
    increment(state) {
      state.content = "abc";
    }
  },
  modules: {
    note
  }
});
