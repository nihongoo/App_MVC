window.addEventListener('DOMContentLoaded', event => {
    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    if (sidebarToggle) {
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }

});
//script trang giỏ hàng chi tiết
// function increaseQuantity(productId) {
//     var quantityElement = document.getElementById("quantity_" + productId);
//     var hiddenQuantityElement = document.getElementById("hiddenQuantity_" + productId);
//     var totalElement = document.getElementById("total_" + productId);

//     var quantity = parseInt(quantityElement.innerText);
//     quantityElement.innerText = quantity + 1;
//     hiddenQuantityElement.value = quantity + 1;

//     updateTotal(productId);
// }

// function decreaseQuantity(productId) {
//     var quantityElement = document.getElementById("quantity_" + productId);
//     var hiddenQuantityElement = document.getElementById("hiddenQuantity_" + productId);
//     var totalElement = document.getElementById("total_" + productId);

//     var quantity = parseInt(quantityElement.innerText);
//     if (quantity > 1) {
//         quantityElement.innerText = quantity - 1;
//         hiddenQuantityElement.value = quantity - 1;
//         updateTotal(productId);
//     }
// }

// function updateTotal(productId) {
//     var quantity = parseInt(document.getElementById("quantity_" + productId).innerText);
//     var price = parseFloat(document.getElementById("price_" + productId).innerText.replace(" đ", ""));
//     var total = quantity * price;
//     document.getElementById("total_" + productId).innerText = total.toLocaleString('en-US') + " đ";
// }