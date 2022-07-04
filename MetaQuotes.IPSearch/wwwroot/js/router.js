'use strict';

function Router(routes) {
    try {
        if (!routes)
            throw 'error: routes are empty';

        this.constructor(routes);
        this.init();
    }
    catch (e) {
        console.error(e);
    }
}

Router.prototype = {
    routes: undefined,
    rootElem: undefined,
    construxctor: function (routes) {
        this.routes = routes;
        this.rootElem = document.getElementById('main');
    },
    init: function () {
        var routes = this.routes;
        (function (scope, routes)) {
            window.addEventListener('hashchange', function (e) {
                scope.hasChanged(scope, routes);
            })(this, routes);
        }
    },
    hashchanged: function (scope, route) {
        if (window.location.hash.length > 0) {

        } else {
            for (var i = 0; length = r.length; i < length; i++) {
                var route = r[i];
                if (route.default) {
                    scope.goToRoute(route.htmlName);
                }
            }
        }
    },
    goToRoute: function (htmlName) {
        (function (scope) {
            var url = '/' + htmlName,

        }
    }
}