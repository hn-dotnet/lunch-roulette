jQuery.extend(jQuery.fn.dataTableExt.oSort, {
    "de_datetime-asc": function (a, b) {
        var x, y;
        if (jQuery.trim(a) !== '') {
            var deDatea = jQuery.trim(a).split(' ');
            var deTimea = deDatea[1].split(':');
            var deDatea2 = deDatea[0].split('.');
            x = (deDatea2[2] + deDatea2[1] + deDatea2[0] + deTimea[0] + deTimea[1]) * 1;
        } else {
            x = Infinity; // = l'an 1000 ...
        }

        if (jQuery.trim(b) !== '') {
            var deDateb = jQuery.trim(b).split(' ');
            var deTimeb = deDateb[1].split(':');
            deDateb = deDateb[0].split('.');
            y = (deDateb[2] + deDateb[1] + deDateb[0] + deTimeb[0] + deTimeb[1]) * 1;
        } else {
            y = Infinity;
        }
        var z = ((x < y) ? -1 : ((x > y) ? 1 : 0));
        return z;
    },

    "de_datetime-desc": function (a, b) {
        var x, y;
        if (jQuery.trim(a) !== '') {
            var deDatea = jQuery.trim(a).split(' ');
            var deTimea = deDatea[1].split(':');
            var deDatea2 = deDatea[0].split('.');
            x = (deDatea2[2] + deDatea2[1] + deDatea2[0] + deTimea[0] + deTimea[1]) * 1;
        } else {
            x = Infinity;
        }

        if (jQuery.trim(b) !== '') {
            var deDateb = jQuery.trim(b).split(' ');
            var deTimeb = deDateb[1].split(':');
            deDateb = deDateb[0].split('.');
            y = (deDateb[2] + deDateb[1] + deDateb[0] + deTimeb[0] + deTimeb[1]) * 1;
        } else {
            y = Infinity;
        }
        var z = ((x < y) ? 1 : ((x > y) ? -1 : 0));
        return z;
    },

    "de_date-asc": function (a, b) {
        var x, y;
        if (jQuery.trim(a) !== '') {
            var deDatea = jQuery.trim(a).split('.');
            x = (deDatea[2] + deDatea[1] + deDatea[0]) * 1;
        } else {
            x = Infinity; // = l'an 1000 ...
        }

        if (jQuery.trim(b) !== '') {
            var deDateb = jQuery.trim(b).split('.');
            y = (deDateb[2] + deDateb[1] + deDateb[0]) * 1;
        } else {
            y = Infinity;
        }
        var z = ((x < y) ? -1 : ((x > y) ? 1 : 0));
        return z;
    },

    "de_date-desc": function (a, b) {
        var x, y;
        if (jQuery.trim(a) !== '') {
            var deDatea = jQuery.trim(a).split('.');
            x = (deDatea[2] + deDatea[1] + deDatea[0]) * 1;
        } else {
            x = Infinity;
        }

        if (jQuery.trim(b) !== '') {
            var deDateb = jQuery.trim(b).split('.');
            y = (deDateb[2] + deDateb[1] + deDateb[0]) * 1;
        } else {
            y = Infinity;
        }
        var z = ((x < y) ? 1 : ((x > y) ? -1 : 0));
        return z;
    }
});


// ************************
// Datatables und Knockout
ko.observableArray.fn.subscribeArrayChanged = function (addCallback, deleteCallback) {
    var previousValue = undefined;
    this.subscribe(function (_previousValue) {
        previousValue = _previousValue.slice(0);
    }, undefined, 'beforeChange');
    this.subscribe(function (latestValue) {
        var editScript = ko.utils.compareArrays(previousValue, latestValue);
        for (var i = 0, j = editScript.length; i < j; i++) {
            switch (editScript[i].status) {
                case "retained":
                    break;
                case "deleted":
                    if (deleteCallback)
                        deleteCallback(editScript[i].value);
                    break;
                case "added":
                    if (addCallback)
                        addCallback(editScript[i].value);
                    break;
            }
        }
        previousValue = undefined;
    });
};