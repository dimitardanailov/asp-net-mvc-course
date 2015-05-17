// This module configures crossroads.js, a routing library. If you prefer, you
// can use any other routing library (or none at all) as Knockout is designed to
// compose cleanly with external libraries.
//
// You *don't* have to follow the pattern established here (each route entry
// specifies a 'page', which is a Knockout component) - there's nothing built into
// Knockout that requires or even knows about this technique. It's just one of
// many possible ways of setting up client-side routes.

import ko = require("knockout");
import crossroads = require("crossroads");
import hasher = require("hasher");
export = router;

module router {
    /**
     * An observable value that changes to represent the current route.
     */
    export var currentRoute = ko.observable(<RouteEntry>{});

    var allRoutes = [
        { url: '',          params: { page: 'home-page' } },
        { url: 'about',     params: { page: 'about-page' } }
    ];

    // Register routes with crossroads.js
    ko.utils.arrayForEach(allRoutes, (route) => {
        crossroads.addRoute(route.url, (requestParams) => {
            currentRoute(<RouteEntry>ko.utils.extend(requestParams, route.params));
        });
    });

    // Activate crossroads
    function parseHash(newHash, oldHash) { crossroads.parse(newHash); }
    crossroads.normalizeFn = crossroads.NORM_AS_OBJECT;
    hasher.initialized.add(parseHash);
    hasher.changed.add(parseHash);
    hasher.init();

    export interface RouteEntry {
        /**
         * The URL pattern matched by this route entry
         */
        url: string;

        /**
         * Parameters extracted from the URL, or defined on this route entry
         */
        params: { [key: string]: string };
    }
}
