function GetRoles() {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: "GET",
            url: '/Administration/GetRoles',
            contentType: "charset=UTF-8",
            dataType: "html",
            async: true,
            cache: false
        }).done((result) => {
            resolve(result);
        }).fail((jqXHR, textStatus, errorThrown) => {
            reject(jqXHR.responseText);
        });
    });
}

function LoadFormCreateRole() {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: "GET",
            url: '/Administration/PostRole',
            contentType: "charset=UTF-8",
            dataType: "html",
            async: true,
            cache: false
        }).done((result) => {
            resolve(result);
        }).fail((jqXHR, textStatus, errorThrown) => {
            reject(jqXHR.responseText);
        });
    });
}

function SaveNewRole(model) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/Administration/PostRole",
            data: model,
            dataType: "json",
            async: true

        }).done(function (result) {
            resolve(result);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            reject(jqXHR.responseText);
        });
    });
}