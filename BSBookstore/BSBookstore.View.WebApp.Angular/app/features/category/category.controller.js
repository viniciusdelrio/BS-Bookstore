angular.module('BSBookstore').controller('categoriaConsultaCtrl', categoriaConsultaCtrlFunction);

categoriaConsultaCtrlFunction.$inject = ['$scope', '$state', 'categoriaService'];

function categoriaConsultaCtrlFunction($scope, $state, categoriaService) {

    $scope.gridConsulta = {
        name: 'gridConsulta',
        datalist: categoriaService.listar,
        columns: [
            { field: 'name', displayName: "Nome" }
        ],
        events: {
            showEdit: function () {
                return true;
            },
            showDelete: function () {
                return true;
            },
            onEdit: function (row) {
                $state.go('cadastro.categoria', { id: row.entity.id });
            }
        },
        exclude: {
            action: categoriaService.excluir,
            getMessage: function (msg, entity) {
                return msg.replaceParams(["da categoria {0}"]).replaceParams([entity.name]);
            }
        }

    };

};

///////////////////////////////////////////////////////////////

angular.module('BSBookstore').controller('categoriaCadastroCtrl', categoriaCadastroCtrlFunction);

categoriaCadastroCtrlFunction.$inject = ['$scope', 'bsMessages', 'categoriaService', 'model'];

function categoriaCadastroCtrlFunction($scope, bsMessages, categoriaService, model) {

    var initial = {};

    if (model) {
        $scope.model = clone(model.data);
        $scope.isEdit = true;
    } else {
        $scope.model = clone(initial);
        $scope.isEdit = false;
    }

    function callbackSave() {
        bsMessages.showSaveSuccessMessage($scope.isEdit, 'consulta.categoria');
    };

    $scope.salvar = function (isValid) {
        if (isValid) {
            categoriaService.salvar($scope.model, callbackSave);
        }
    };

    $scope.limpar = function () {
        $scope.model = clone(initial);
    };

};