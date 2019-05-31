import axios from "./index.js";

export function getNotes() {
  return axios.get("/api/note").then(function(response) {
    return response.data;
  });
}

export function async(notes) {
  axios.post("/api/note", notes);
}
