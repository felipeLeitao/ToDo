(function () {
    'use strict';

    angular.module('app').controller('todoPesquisarController', todoPesquisarController);

    todoPesquisarController.$inject = ['$scope', 'todoService'];

    function todoPesquisarController($scope, todoService) {
        //aqui eu jogo o $scope dentro da variável, pra ficar mais bonito e tal
        var vm = this;

        vm.tarefas = todoService.TarefasPesquisadas;
    }
})();