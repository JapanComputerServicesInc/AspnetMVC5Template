var jModule = (function () {
    return {
        "getAjaxJsonRequest": function (_url, _data) {
            return ajaxRequest("GET", _url, _data);
        },
        "postAjaxJsonRequest": function (_url, _data) {
            return ajaxRequest("POST", _url, _data);
        }
    }

    function ajaxRequest(_type, _url, _data) {
        return $.ajax({
            type: _type,
            url: _url,
            dataType: "json",
            data: _data,
            async: false
        }).done(function () {
            return new jQuery.Deferred();
        }).fail(function () {
            return new jQuery.Deferred();
        });
    }
})();