async function getallProducts() {
  let url = "https://localhost:44389/api/Products";
  var getToken = localStorage.getItem("jwtToken");
  if (getToken == null){

    alert("plz login")
  }
  const request = await fetch(url, {
    headers: {
      "Authorization": `Bearer ${getToken}`
    }
  });

  let data = await request.json();
  console.log(data)

  let container = document.getElementById("AllProductsContainer");

  container.innerHTML = `
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-2">
          <div class="sidebar">
            <br>
            <br>
            <ul>
              <li>
                <a href="#" class="active">BSR</a>
              </li>
              <br>
              <li>
                <a href="#">Categories</a>
              </li>
              <li>
                <a href="#"> Products</a>
              </li>
              <li>
                <a href="#">More</a>
              </li>
            </ul>
          </div>
        </div>
        <div class="col-md-10">
          <h1>Products</h1>
          <a href="../addCategory/addProducts.html"><button class="btn btn-success">Add Products</button></a>
          <table class="table table-striped">
            <thead>
              <tr>
                <th>Product id</th>
                <th>Product Name</th>
                <th>Product image</th>
                <th>Actions</th>
              </tr>
            </thead>
            <tbody id="products-tbody">
            </tbody>
          </table>
        </div>
      </div>
    </div>
  `;


  data.forEach((Product) => {

    document.getElementById("products-tbody").innerHTML += `
    <tr>
      <td>${Product.pId}</td>
      <td>${Product.pName}</td>
      <td><img src="../categories/images/${Product.pImage}.jpg" alt="${Product.pName}"></td>
      <td>
        <a href="../addCategory/editProduct.html"><button onclick="storeProductId(${Product.pId})" class="btn btn-primary">Edit</button></a>
        <a href="../addCategory/ProductDetails.html"><button onclick="storeProductId(${Product.pId})" class="btn btn-primary">Details</button></a>
      </td>
    </tr>
    `;
  });
}

function storeProductId(id) {
  localStorage.setItem('productId', id);
}

getallProducts();


const url = "https://localhost:44389/api/Products";

var form = document.getElementById("producteditform");
form.addEventListener("submit", addProduct)

async function addProduct(event) {
  event.preventDefault();


  var formSwager = new FormData(form);
  let response = await fetch(url, { method: "POST", body: formSwager });

  let data = response;
  form.reset();
  alert('Product adedd sucsessfuly')
}



///////////////////////////////////////////edit category /////////////////////////
let n = localStorage.getItem("product"); // Fix: use the correct key
const Cat_url = `https://localhost:44389/api/Products/${n}`;

var editform = document.getElementById("producteditform");

editform.addEventListener("submit", Editproduct)
async function Editproduct(event) { // Fix: pass the event object as an argument
  event.preventDefault();
  let formData = new FormData(editform);
  console.log(formData);

  let response = await fetch(Cat_url, {
    method: 'PUT',
    headers: { // Fix: add the Content-Type header
      'Content-Type': 'multipart/form-data'
    },
    body: formData,
  });
  editform.reset();
  alert("Success");
}



///////////////////////// product Details ////////////////////////////////


