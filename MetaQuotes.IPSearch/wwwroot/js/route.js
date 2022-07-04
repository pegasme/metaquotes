'use strict';

function Route() {
}

Route.prototype = {
    name: undefined,
    default: undefined,
    constructor: function (name, defaultRoute) {
        this.name = name;
        this.default = defaultRoute;
    },
    isActiveRoute: function (path) {
        return this.name.trim() == path;
    }
}