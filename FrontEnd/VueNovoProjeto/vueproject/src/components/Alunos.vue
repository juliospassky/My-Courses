<template>
  <div>
    <h1>{{nome}}</h1>
    <input type="text" placeholder="Nome Aluno" v-model="nome" />
    <button class="btn" @click="addAluno()">Add</button>
    <table class="table">
      <table class="table table-dark">
        <thead>
          <tr>
            <th>Matrícula</th>
            <th>Aluno</th>
            <th>Ação</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(aluno, index) in alunos" :key="index">
            <td>a</td>
            <td {{aluno.nome}}></td>
            <td>b</td>
          </tr>
        </tbody>
      </table>
    </table>
  </div>
</template>

<script>
export default {
  data() {
    return {
      nome: "",
      alunos: []
    };
  },
  props: {},
  methods: {
    addAluno() {
      console.log("oi");
      let _aluno = { nome: this.nome };
      this.alunos.push(_aluno);
    }
  }
};
</script>

<style scoped>
</style>
