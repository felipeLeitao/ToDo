(function () {
    'use strict';

    angular.module('app').controller('todoListarController', todoListarController);

    todoListarController.$inject = ['$scope', 'todoService'];

    function todoListarController($scope, todoService) {

        //aqui eu jogo o $scope dentro da variável, pra ficar mais bonito e tal
        var vm = this;

        vm.tarefas = [];

        //esse objeto tarefa, vai ser a minha classe de modelo e tal
        todoService.Listar().success(function (tarefas) {
            vm.tarefas = tarefas;
        }).error();
    }
})();