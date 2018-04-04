angular.module('BSBookstore').controller('livroConsultaCtrl', livroConsultaCtrlFunction);

livroConsultaCtrlFunction.$inject = ['$scope', '$state', 'livroService'];

function livroConsultaCtrlFunction($scope, $state, livroService) {

    $scope.gridConsulta = {
        name: 'gridConsulta',
        datalist: livroService.listar,
        columns: [
            { field: 'title', displayName: "Título" },
            { field: 'publishedYear', displayName: "Ano de Publicação" },
            { field: 'author.name', displayName: "Autor" },
            { field: 'category.name', displayName: "Categoria" }
        ],
        events: {
            showEdit: function () {
                return true;
            },
            showDelete: function () {
                return true;
            },
            onEdit: function (row) {
                $state.go('cadastro.livro', { id: row.entity.id });
            }
        },
        exclude: {
            action: livroService.excluir,
            getMessage: function (msg, entity) {
                return msg.replaceParams(["do livro {0}"]).replaceParams([entity.title]);
            }
        }

    };

};

///////////////////////////////////////////////////////////////

angular.module('BSBookstore').controller('livroCadastroCtrl', livroCadastroCtrlFunction);

livroCadastroCtrlFunction.$inject = ['$scope', 'bsMessages', 'livroService', 'autorService', 'categoriaService', 'model'];

function livroCadastroCtrlFunction($scope, bsMessages, livroService, autorService, categoriaService, model) {

    var initial = {};

    if (model) {
        $scope.model = clone(model.data);
        $scope.isEdit = true;
    } else {
        $scope.model = clone(initial);
        $scope.isEdit = false;
    }

    autorService.listar().then(function (data) {
        $scope.authors = data.data;
    });

    categoriaService.listar().then(function (data) {
        $scope.categories = data.data;
    });

    function callbackSave() {
        bsMessages.showSaveSuccessMessage($scope.isEdit, 'consulta.livro');
    };

    $scope.salvar = function (isValid) {
        if (isValid) {
            livroService.salvar($scope.model, callbackSave);
        }
    };

    $scope.limpar = function () {
        $scope.model = clone(initial);
    };

};