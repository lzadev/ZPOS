function GetClients() {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: "GET",
            url: '/Clients/GetClients',
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

function DeleteClient(id) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "DELETE",
            url: `/Clients/DeleteClient?id=${id}`,
            dataType: "json",
            async: true
        }).done(function (result) {
            resolve(result);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            reject(jqXHR.responseText);
        });
    });
}


function LoadFormCreateClient() {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: "GET",
            url: '/Clients/PostClient',
            contentType: "charset=UTF-8",
            dataType: "html",
            async: true,
            cache: false
        }).done((form) => {

            resolve(form);

        }).fail((jqXHR, textStatus, errorThrown) => {
            reject(jqXHR.responseText);
        });
    });
}