'use strict';

const appRoutes = [
    new Route('home', true),
    new Route('city')
];
(function () {
    function init() {
        var router = new Router(appRoutes);
    }
    init();
}());