angular.module('Atendimento').config(function ($routeProvider) {
  $routeProvider
    .when('/login', {
      controller: 'loginController',
      templateUrl: 'login/login.html'
    })
    .when('/cadastroCliente', {
      controller: 'cadastroClieController',
      templateUrl: 'cliente/cadastroClie.html'
    })
    .when('/cadastroUsuario', {
      controller: 'cadastroUsuController',
      templateUrl: 'usuario/cadastroUsu.html'
    })
    .when('/atendimento', {
      controller: 'atendimentoController',
      templateUrl: 'atendimento/atendimento.html'
    })
    .otherwise({
      redirectTo: '/login'
    });
});
