function GetCategories() {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: "GET",
            url: "/Categories/GetCategories",
            contentType: "charset=UTF-8",
            dataType: "html",
            async: true,
            cache: false
        }).done((categories) => {
            resolve(categories);

        }).fail((jqXHR, textStatus, errorThrown) => {
            reject(jqXHR.responseText);
        });
    });
}



function DeleteCategory(id) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "DELETE",
            url: `/Categories/DeleteCategory?id=${id}`,
            dataType: "json",
            async: true
        }).done(function (result) {
            resolve(result);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            reject(jqXHR.responseText);
        });
    });
}


function LoadFormCreateCategory() {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: "GET",
            url: "/Categories/PostCategory",
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


function SaveNewCategory(model) {

    console.log("in fn")
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "Categories/PostCategory",
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


function LoadFormEditCategory(id) {
    return new Promise((resolve, reject) => {
        $.ajax({
            method: "GET",
            url: `/Categories/EditCategory?id=${id}`,
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


function SaveCategoryEdited(model) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: "PUT",
            url: "Categories/EditCategory",
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