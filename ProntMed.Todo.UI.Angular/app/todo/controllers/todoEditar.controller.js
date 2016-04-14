(function () {
    'use strict';

    angular.module('app').controller('todoEditarController', todoEditarController);

    todoEditarController.$inject = ['$scope', '$stateParams', 'todoService', '$state'];

    function todoEditarController($scope, $stateParams, todoService, $state) {
        //aqui eu jogo o $scope dentro da variável, pra ficar mais bonito e tal
        var vm = this;

        vm.tarefa = {};
        todoService.GetByID($stateParams.codigo)
            .success(function (tarefa) {
                vm.tarefa = tarefa;
            }).error(function (erro) {
                alert(erro);
            });

        //isto é uma função de primeira classe. ao chamar o método submit, ele executa a função.
        vm.submit = function (tarefa) {
            todoService.Alterar(tarefa)
            .success(function () {
                alert("Tarefa editada com sucesso!");
                $state.go('main.listar');
            }).error(function (erro) {
                alert(erro.ExceptionMessage)
            });
        };

    }
})();