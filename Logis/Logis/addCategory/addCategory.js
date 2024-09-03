async function getallcategory() {
  let urlcat = "https://localhost:44389/api/Categories/Api/categories";
  let request = await fetch(urlcat);

    let data = await request.json();

    let container = document.getElementById("AllCategoriesContainer");

    // Create the table structure only once
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
                  <a href="../addCategory/allProducts.html"> Products</a>
                  
                </li>
                <li>
                  <a href="Users/User.html">Login</a>
                </li>
              </ul>
            </div>
          </div>
          <div class="col-md-10">
            <h1>Categories</h1>
      <a href="../addCategory/addCategory.html"><button class="btn btn-success">Add Category</button></a>
            <table class="table table-striped">
              <thead>
                <tr>
                  <th>Category id</th>
                  <th>Category Name</th>
                  <th>Category image</th>
                  <th>Actions</th>
                </tr>
              </thead>
              <tbody id="categories-tbody">
              </tbody>
            </table>
          </div>
        </div>
      </div>
    `;

    // Append table rows for each category
  data.forEach((category) => {
    document.getElementById("categories-tbody").innerHTML += `
    <tr>
      <td>${category.cId}</td>
      <td>${category.cName}</td>
      <td><img src="../categories/images/${category.cImage}.jpg" alt="${category.cName}"></td>
      <td>
        <a href="../addCategory/editCategory.html"><button onclick="storeCategoryId(${category.cId})" class="btn btn-primary">Edit</button></a>
      </td>
    </tr>
  `;
  debugger
      
  });
   
}

function storeCategoryId(id) {
 localStorage.setItem('categoryId', id);
}

getallcategory();

const url = "https://localhost:44389/api/Categories";

var form = document.getElementById("formProducts");

async function addCategory() {
    event.preventDefault();
  

  var formSwager = new FormData(form);
  let response = await fetch(url, { method: "POST", body: formSwager });

  let data = response;
  form.reset();
    alert('Caregory adedd sucsessfuly')
}






///////////////////////////////////////////edit category /////////////////////////
let n = localStorage.getItem("categoryId");
const Cat_uel = `https://localhost:44389/api/Categories/${n}`;

var editform = document.getElementById("editform");

async function EditCategory() {
  event.preventDefault();
  let formData = new FormData(editform);
  console.log(formData);

  let response = await fetch(Cat_uel, {
    method: 'PUT',
    body: formData,
  });
  editform.reset();
  alert("Success");
}