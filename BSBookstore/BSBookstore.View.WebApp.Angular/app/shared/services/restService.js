angular.module('BSBookstore').service('restService', restServiceFunction);

restServiceFunction.$inject = ['$http', '$rootScope', '$q', '$state'];

function restServiceFunction ($http, $rootScope, $q, $state) {
    var sendRequest = function (url, method, dataSent, isFile, hideLoad) {
        if ($rootScope.baseURL) {
            var baseURL = $rootScope.baseURL;

            if (dataSent && dataSent.hideLoad) {
                hideLoad = true;
            }

            if (method === "JSON") {
                method = "GET";
            } else {
                url = baseURL + url;
            }
            var options = {
                method: method,
                hideLoad: hideLoad,
                url: url,
                data: dataSent,
                headers: {
                    'Content-Type': 'application/json; charset=UTF-8'
                }
            }

            if (isFile)
                options.responseType = 'arraybuffer';

            var response = $http(options);

            return response;
        } else {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: "WebApi.ashx"
            }).then(
                function (data) {
                    $rootScope.baseURL = data.data;

                    var baseURL = data.data;

                    if (method === "JSON") {
                        method = "GET";
                    } else {
                        url = baseURL + url;
                    }

                    var options = {
                        method: method,
                        url: url,
                        data: dataSent,
                        headers: {
                            'Content-Type': 'application/json; charset=UTF-8'
                        }
                    }

                    if (isFile)
                        options.responseType = 'arraybuffer';

                    var response = $http(options);

                    deferred.resolve(response);
                },
                function (data) {
                    alert('Falha ao carregar URL do serviço WebApi.');
                }
                );
            return deferred.promise;
        }
    }
    return {
        request: function (url, method, data, isFile, hideLoad) {
            return sendRequest(url, method, data, isFile, hideLoad);
        }
    }
};