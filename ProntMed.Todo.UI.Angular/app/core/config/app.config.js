(function () {
    'use strict';

    angular.module('app').config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
        
    function config($stateProvider, $urlRouterProvider)
    
    {
        
        $urlRouterProvider.otherwise("/Listar");

        $stateProvider
          .state('main', {
              templateUrl: "app/todo/views/main.html",
              abstract: true,
          })
          .state('main.cadastrar', {
              url: "/Cadastrar",
              templateUrl: "app/todo/views/cadastrar.html",
              cache: false
          })
          .state('main.alterar', {
              url: "/Alterar:codigo",
              templateUrl: "app/todo/views/alterar.html",
              cache: false
          })
          .state('main.listar', {
              url: "/Listar",
              templateUrl: "app/todo/views/listar.html",
              cache: false
          })
          .state('main.remover', {
              url: "/Remover:codigo",
              templateUrl: "app/todo/views/listar.html",
              cache: false
          })
          .state('main.pesquisar', {
              url: "/Pesquisar",
              templateUrl: "app/todo/views/pesquisar.html",
              cache: false
          });
    }

})();
