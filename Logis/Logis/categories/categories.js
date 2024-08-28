async function getallcategory() {

    let url = "https://localhost:44389/api/Categories/Api/categories";
    let request = await fetch(url);

    let data = await request.json();


    let container = document.getElementById("categoriescontainer");

    data.forEach(category => {

        container.innerHTML +=
        `
        <div class="card" style="width: 18rem;">
                <img class="card-img-top" src="images/${category.cImage}.jpg" alt="${category.cImage}" style="width: 100%; height: 40vh;">
            <div class="card-body">
                <h5 class="card-title">${category.cName}</h5>
                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                <a onclick="store(${category.cId})" class="btn btn-primary">Show Products</a>
            </div>
         </div>
        `
    });
}
function store(id){   
    window.location.href = 'pro_details.html'
    sessionStorage.cId = id;
}
getallcategory();   

/////////////////////////////// Get All Product ///////////////////////////////////////

// ... (rest of the code remains the same)

// Call the allProducts function when the product page is loaded
window.addEventListener("load", allProducts);

async function allProducts() {
    const allProductsUrl = "https://localhost:44389/api/Products";
    const fetchall = await fetch(allProductsUrl);
    const request = await fetchall.json();
    const AllProducts = document.getElementById("AllProducts");
    
    AllProducts.innerHTML = ""; // Clear the container before adding new content

    request.forEach(all => {
        AllProducts.innerHTML += `
         <div class="card" style="width: 18rem;">
                <img class="card-img-top" src="images/${all.pImage}.jpg" alt="${all.pImage}" style="width: 100%; height: 40vh;">
            <div class="card-body">
                <h5 class="card-title">${all.pName}</h5>
                <p class="card-text">${all.pDes}</p>
                <a href="#" class="btn btn-primary">View Product</a>
            </div>  
         </div>
        `
    });
}

///////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////product by id ///////////////////////////////////////
const restore = Number(sessionStorage.getItem("cId"));

const pr_url = `https://localhost:44389/api/Categories/Api/Category/${restore}`;
var productscontainer = document.getElementById("detailscontainer");
async function getprodu(){
debugger
    const p_request = await fetch(pr_url);
    const p_responce = await p_request.json();
    var arrayData = [p_responce];
   
    let htmlContent = '';
    arrayData.forEach(product => {

        htmlContent +=
            `
        <div class="card" style="width: 18rem;">
                <img class="card-img-top" src="images/${product.pImage}.jpg" alt="${product.pImage}" style="width: 100%; height: 40vh;">
            <div class="card-body">
                <h5 class="card-title">${product.pName}</h5>
                <p class="card-text">${product.pDes}.</p>
                <a onclick="store(${product.pId})" class="btn btn-primary"> Add To Ca   rt</a>
            </div>
         </div>
        `
    });

    productscontainer.innerHTML += htmlContent;
}
getprodu();

