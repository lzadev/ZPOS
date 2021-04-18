function GetProductos() {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: "GET",
            url: "/Products/GetProducts",
            contentType: "charset=UTF-8",
            dataType: "html",
            async: true,
            cache: false
        }).done((products) => {
            resolve(products);

        }).fail((jqXHR, textStatus, errorThrown) => {
            reject(jqXHR.responseText);
        });
    });
}

function SaveNewProduct(model) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "Products/PostProduct",
            data: model,
            dataType: "json",
            async: true

        }).done(function (result) {
            resolve({ message: result });
        }).fail(function (jqXHR, textStatus, errorThrown) {
            reject(jqXHR.responseText);
        });
    });
}

function LoadFormCreateProduct() {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: "GET",
            url: "/Products/PostProduct",
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

function DeleteProduct(id) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "DELETE",
            url: `/Products/DeleteProduct?id=${id}`,
            dataType: "json",
            async: true
        }).done(function (result) {
            resolve(result);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            reject(jqXHR.responseText);
        });
    });
}

function LoadFormEditProduct(id) {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: "GET",
            url: `/Products/EditProduct?id=${id}`,
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

function SaveProductEdited(model) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "PUT",
            url: "Products/EditProduct",
            dataType: "json",
            data: model,
            async: true
        }).done(function (result) {
            resolve(result);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            reject(jqXHR.responseText);
        });
    });
}

