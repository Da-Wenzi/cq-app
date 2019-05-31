import * as noteApi from "../../api/note.js";

const state = {
  notes: [],
  editNote: null,
  editNotes: [],
  error: null
};

const getters = {};

const actions = {
  getNotes(context) {
    noteApi
      .getNotes()
      .then(function(data) {
        if (data && data.length > 0) {
          context.commit("setEditNote", data[0]);
        }
        context.commit("setNotes", data);
      })
      .catch(function(error) {
        context.commit("setError", error);
      });
  },
  selectNote(context, note) {
    context.commit("setEditNote", note);
  },

  modifyNoteContent(context, content) {
    var desc = content;
    if (content && content.length > 100) {
      desc = content.substring(0, 100);
    }
    context.commit("setEditNoteDescription", desc);
    context.commit("pushEditNote", context.state.editNote);
  },

  modifyNoteTitle(context, title) {
    context.commit("setEditNoteTitle", title);
    context.commit("pushEditNote", context.state.editNote);
  },

  async(context) {
    noteApi.async(context.state.editNotes);
  }
};

const mutations = {
  setNotes(state, data) {
    state.notes = data;
  },

  setEditNote(state, note) {
    state.editNote = note;
  },

  setError(state, error) {
    state.error = error;
  },

  setEditNoteDescription(state, desc) {
    state.editNote.description = desc;
  },

  setEditNoteTitle(state, title) {
    state.editNote.title = title;
  },

  pushEditNote(state, note) {
    if (note && state.editNotes.indexOf(note) == -1) {
      state.editNotes.push(note);
    }
    console.log(state);
  }
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
};
