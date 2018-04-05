angular.module('BSBookstore').config(function ($stateProvider, $httpProvider, $urlRouterProvider) {

    //#region Interceptor

    $httpProvider.interceptors.push(function ($q, bsMessages) {

        return {
            response: function (response) {
                return response;
            },
            responseError: function (rejection) {

                if (rejection.status == 417) {
                    bsMessages.showMessage({ msg: rejection.data.error }, EnumSwalType.Alert);
                } else {
                    return $q.reject(rejection);
                }
            }
        };
    });

    //#endregion

    //#region States

    $urlRouterProvider.otherwise("/home");

    $stateProvider.state({
        name: 'home',
        url: '/home',
        templateUrl: 'app/features/home/home.html'
    });

    $stateProvider.state({
        name: 'consulta',
        url: '/consulta'
    });

    $stateProvider.state({
        name: 'consulta.autor',
        url: '/autor',
        templateUrl: 'app/features/author/consulta.html',
        controller: 'autorConsultaCtrl',
        resolve: {
            loadPlugin: function ($ocLazyLoad) {
                return $ocLazyLoad.load([
                    {
                        name: 'vendors',
                        insertBefore: '#app-level-js',
                        files: [
                            'app/features/author/author.service.js',
                            'app/features/author/author.controller.js',
                            'app/shared/directives/bs-grid/bsGrid.Directive.js'
                        ]
                    }
                ]);
            }
        }
    });

    $stateProvider.state({
        name: 'consulta.categoria',
        url: '/categoria',
        templateUrl: 'app/features/category/consulta.html',
        controller: 'categoriaConsultaCtrl',
        resolve: {
            loadPlugin: function ($ocLazyLoad) {
                return $ocLazyLoad.load([
                    {
                        name: 'vendors',
                        insertBefore: '#app-level-js',
                        files: [
                            'app/features/category/category.service.js',
                            'app/features/category/category.controller.js',
                            'app/shared/directives/bs-grid/bsGrid.Directive.js'
                        ]
                    }
                ]);
            }
        }
    });

    $stateProvider.state({
        name: 'consulta.livro',
        url: '/livro',
        templateUrl: 'app/features/book/consulta.html',
        controller: 'livroConsultaCtrl',
        resolve: {
            loadPlugin: function ($ocLazyLoad) {
                return $ocLazyLoad.load([
                    {
                        name: 'vendors',
                        insertBefore: '#app-level-js',
                        files: [
                            'app/features/book/book.service.js',
                            'app/features/book/book.controller.js',
                            'app/shared/directives/bs-grid/bsGrid.Directive.js'
                        ]
                    }
                ]);
            }
        }
    });

    $stateProvider.state({
        name: 'cadastro',
        url: '/cadastro'
    });

    $stateProvider.state({
        name: 'cadastro.autor',
        url: '/autor/:id',
        templateUrl: 'app/features/author/cadastro.html',
        controller: 'autorCadastroCtrl',
        params: { id: null },
        resolve: {
            model: function (autorService, $stateParams) {
                if ($stateParams.id != null) {
                    return autorService.obter($stateParams.id);
                } else {
                    return null;
                }
            },
            loadPlugin: function ($ocLazyLoad) {
                return $ocLazyLoad.load([
                    {
                        name: 'vendors',
                        insertBefore: '#app-level-js',
                        files: [
                            'app/features/author/author.service.js',
                            'app/features/author/author.controller.js'
                        ]
                    }
                ]);
            }
        }
    });

    $stateProvider.state({
        name: 'cadastro.categoria',
        url: '/categoria/:id',
        templateUrl: 'app/features/category/cadastro.html',
        controller: 'categoriaCadastroCtrl',
        params: { id: null },
        resolve: {
            model: function (categoriaService, $stateParams) {
                if ($stateParams.id != null) {
                    return categoriaService.obter($stateParams.id);
                } else {
                    return null;
                }
            },
            loadPlugin: function ($ocLazyLoad) {
                return $ocLazyLoad.load([
                    {
                        name: 'vendors',
                        insertBefore: '#app-level-js',
                        files: [
                            'app/features/category/category.service.js',
                            'app/features/category/category.controller.js'
                        ]
                    }
                ]);
            }
        }
    });

    $stateProvider.state({
        name: 'cadastro.livro',
        url: '/livro/:id',
        templateUrl: 'app/features/book/cadastro.html',
        controller: 'livroCadastroCtrl',
        params: { id: null },
        resolve: {
            model: function (livroService, $stateParams) {
                if ($stateParams.id != null) {
                    return livroService.obter($stateParams.id);
                } else {
                    return null;
                }
            },
            loadPlugin: function ($ocLazyLoad) {
                return $ocLazyLoad.load([
                    {
                        name: 'vendors',
                        insertBefore: '#app-level-js',
                        files: [
                            'app/features/book/book.service.js',
                            'app/features/book/book.controller.js',
                            'app/features/author/author.service.js',
                            'app/features/category/category.service.js'
                        ]
                    }
                ]);
            }
        }
    });

    //#endregion
});