angular.module('BSBookstore').service('linqHelper', linqHelperService);

linqHelperService.$inject = ['$linq'];

function linqHelperService($linq) {

    //#region Base Functions

    this.where = function (objList, whereFunction) {
        return $linq.Enumerable().From(objList).Where(whereFunction).ToArray();
    };

    this.sort = function (objList, field) {
        return $linq.Enumerable().From(objList).OrderBy(function (o) { return o[field] }).ToArray();
    };

    //#endregion

};



/*
    Globals
*/

String.prototype.replaceAll = function (search, replacement) {
    var target = this;
    return target.replace(new RegExp(search, 'g'), replacement);
};

String.prototype.replaceParams = function (params, pattern) {
    var message = this.toString();
    var patternReplace = pattern || '{*}';

    try {
        if (Object.prototype.toString.call(params) === '[object Array]') {
            if (params) {
                for (i in params) {
                    var dynamicPattern = patternReplace.replace('*', i);
                    message = message.replace(dynamicPattern, params[i]);
                }
            }
        } else {
            message = message.replace(patternReplace, params);
        }
    } catch (ex) {
        return message;
    }

    return message;
};

clone = function (obj) {
    return angular.copy(obj);
};

//////////////////////////////////////////