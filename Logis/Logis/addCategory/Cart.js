const url = "https://localhost:44389/api/CartItems";
debugger
async function getCartItems() {
    let response = await fetch(url);
    var result = await response.json();
    console.log(response);
    var container = document.getElementById("Cart");
    result.forEach(element => {
        container.innerHTML +=
            `
        <tr>
            <td>${element.cartId}</td>
            <td>${element.pdto.pName}</td>
            <td><input type="number" name="quantity" id="quantity" value="${element.quantity}" ></input></td>
            <td><a class="btn btn-primary"  onclick="store(${element.cartItemId})">Edit</a></td>
        </tr>
        `
    })

}
function store(id) {
    localStorage.setItem("cartItemId", id);
}

function reset() {
    localStorage.clear();
}

getCartItems();


////////////////////////////////////////////////// display the product details //////////////////////////////


const n = localStorage.getItem("productId");

const url1 = `https://localhost:44389/api/Products/Api/product/${n}`;

async function getCategory() {
    try {
        let response = await fetch(url1);

        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        let result = await response.json();
        console.log(result);

        let container = document.getElementById("container");

        container.innerHTML = `
                    <div class="container mt-5">
                        <div class="row justify-content-center">
                            <div class="col-md-4">
                                <div class="card shadow-lg">
                                    <img src="../categories/images/${result.pImage}.jpg" class="card-img-top" alt="Card image">
                                    <div class="card-body text-center">
                                        <h3 class="card-title">${result.pId}</h3>
                                        <h5 class="card-title">${result.pName}</h5>
                                        <h5 class="card-title">The Price: ${result.pPric}</h5>
                                        <p class="card-text">${result.pDes}</p>
                                    </div>
                                    <input type="number" name="quantity" id="quantity" class="form-control" placeholder="quantity">
                                        <button type="button" class="btn btn-primary mt-4 w-100" onclick="addToCart()">Add To Cart</button>
                                </div>
                            </div>
                        </div>
                    </div>
                `;
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
}

getCategory();


///////////////////////////////////////////





async function addToCart() {
    let quantity = document.getElementById("quantity").value;
    const url1 = "https://localhost:44389/api/CartItems"
    var request = {
        productId: n,
        quantity: quantity,
        cartId: 1
    }
    let response = await fetch(url1,
        {
            method: 'POST',
            body: JSON.stringify(request),
            headers: {
                'Content-Type': 'application/json'
            }
        }
    )


    alert("Product added to cart");

}











