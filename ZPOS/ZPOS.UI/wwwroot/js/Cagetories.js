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