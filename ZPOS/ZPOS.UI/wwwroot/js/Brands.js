function GetBrands() {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: "GET",
            url: '/Brands/GetBrands',
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


function DeleteBrand(id) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "DELETE",
            url: `/Brands/DeleteBrand?id=${id}`,
            dataType: "json",
            async: true
        }).done(function (result) {
            resolve(result);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            reject(jqXHR.responseText);
        });
    });
}


function LoadFormCreateBrand() {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: "GET",
            url: '/Brands/PostBrand',
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


function SaveNewBrand(model) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "Brands/PostBrand",
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


function LoadFormEditBrand(id) {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: "GET",
            url: `/Brands/EditBrand?id=${id}`,
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

function SaveEditedBrand(model) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "PUT",
            url: "Brands/EditBrand",
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
