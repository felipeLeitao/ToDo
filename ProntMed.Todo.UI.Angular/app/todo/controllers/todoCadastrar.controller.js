(function () {
    'use strict';

    angular.module('app').controller('todoCadastrarController', todoCadastrarController);

    todoCadastrarController.$inject = ['$scope', 'todoService', '$state'];

    function todoCadastrarController($scope, todoService, $state) {

        //aqui eu jogo o $scope dentro da variável, pra ficar mais bonito e tal
        var vm = this;

        //esse objeto tarefa, vai ser a minha classe de modelo e tal
        vm.tarefa = {};
        vm.tarefa.Status = "BackLog";

        //isto é uma função de primeira classe. ao chamar o método submit, ele executa a função.
        vm.submit = function (tarefa) {
            todoService.Cadastrar(tarefa)
                .success(function () {
                    alert("Tarefa cadastrada com sucesso!");
                    $state.go('main.listar');
                }).error(function (erro) {
                    alert(erro.ExceptionMessage)
                });
        };

    }
})();