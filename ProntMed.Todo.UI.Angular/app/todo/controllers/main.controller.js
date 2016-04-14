(function () {
    'use strict';

    angular.module('app').controller('mainController', mainController);

    mainController.$inject = ['$scope', 'todoService', '$state'];

    function mainController($scope, todoService, $state) {
        //aqui eu jogo o $scope dentro da variável, pra ficar mais bonito e tal
        var vm = this;

        vm.pesquisar = function (descricao) {
            todoService.Pesquisar(descricao)
                .success(function (tarefas) {
                    todoService.TarefasPesquisadas = tarefas;
                    $state.go('main.pesquisar');
                }).error(function (erro) {
                    alert(erro);
                });
        }
    }
})();