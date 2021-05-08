function GetUsers() {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: "GET",
            url: '/Administration/GetUsers',
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


function LoadFormCreateUser() {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: "GET",
            url: '/Administration/PostUser',
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


function SaveNewUser(model) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/Administration/PostUser",
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


function LoadFormEditUser(id) {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: "GET",
            url: `/Administration/EditUser?id=${id}`,
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


function SaveEditedUser(model) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "PUT",
            url: "/Administration/EditUser",
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


function DeleteUser(id) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "DELETE",
            url: `/Administration/DeleteUser?id=${id}`,
            dataType: "json",
            async: true
        }).done(function (result) {
            resolve(result);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            reject(jqXHR.responseText);
        });
    });
}