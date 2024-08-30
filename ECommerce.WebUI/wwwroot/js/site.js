//let products = [];

//window.onload = function () {
//    fetch('/Product/GetProducts')
//        .then(response => response.json())
//        .then(data => {
//            console.log(data);
//            products = data;
//            displayProducts(products);
//        });
//};

//function displayProducts(products) {
//    const tbody = document.getElementById('productTableBody');
//    tbody.innerHTML = '';

//    products.forEach(product => {
//        let style = product.UnitsInStock === 0 ? "background-color:indianred" : "";

//        const row = `
//            <tr style="${style}">
//                <td>${product.ProductName}</td>
//                <td>${product.UnitPrice}</td>
//                <td>${product.UnitsInStock}</td>
//                <td>
//                    ${product.UnitsInStock > 0 ? `<a class="btn btn-xs btn-success" href="/Cart/AddToCart?productId=${product.ProductId}&page=1&category=0">Add To Cart</a>` : ''}
//                </td>
//            </tr>
//        `;
//        tbody.innerHTML += row;
//    });
//}

//function filterProducts() {
//    const searchTerm = document.getElementById('searchBox').value.toLowerCase();
//    const filteredProducts = products.filter(product =>
//        product.ProductName.toLowerCase().includes(searchTerm)
//    );
//    displayProducts(filteredProducts);
//}


function filterProducts() {
    var input = document.getElementById('searchInput');
    var filter = input.value.toLowerCase();
    var table = document.getElementById('productTable');
    var tr = table.getElementsByTagName('tr');

    for (var i = 1; i < tr.length; i++) {
        var td = tr[i].getElementsByClassName('productName')[0];
        if (td) {
            var txtValue = td.textContent || td.innerText;
            if (txtValue.toLowerCase().includes(filter)) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}