let ShowCreateForm = () => {
    $.ajax({
        url: "/home/create",
        method: "GET",
        dataType: "html",
        success: (partial) => {
            $("#CreateForm").html(partial);
        }
    })
}

let addToCart = (itemId) => {
    $.ajax({
        url: "/home/ShoppingCart/" + itemId,
        method: "POST",
        dataType: "html",
        success: (partial) => {
            $("#shoppingCart").html(partial);
        }
    });
}

let removeFromCart = (itemId) => {
    $.ajax({
        url: "/home/RemoveFromCart/" + itemId,
        method: "DELETE",
        dataType: "html",
        success: (partial) => {
            $("#cart").html(partial);
        }
    });
}



let getShoppingCart = () => {
    $.ajax({
        url: "/home/ShoppingCart",
        method: "GET",
        dataType: "html",
        success: (partial) => {
            $("#shoppingCart").html(partial);
        }
    });
}

$(document).ready(() => {

});