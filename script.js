//-------------------------------------//
//FACTORY 54 EMPLOYEE MANAGMENT SYSTEM //
//-------------------------------------//
//Developer = > Erez Goren - 2022

//session storage for user name to apear in all pages
async function GetUserFullName()
{
      let userData = sessionStorage["user"]
      let user = JSON.parse(userData)
      let helloH1 = document.getElementById("helloToUser")
      helloH1.innerText = "Hello " + user
}


//LOGIN PAGE//
// function send obj-json with username & password with post in login page
async function CheckUsernamePassword()
{
          let UserWithPasswordObj = {
                                        User: document.getElementById("username").value,
                                        Password: document.getElementById("password").value,
                                      }

          let fetchParams = {
                              method : 'POST',
                              body : JSON.stringify(UserWithPasswordObj),
                              headers : {"Content-Type" : "application/json"}
                            }

          let response = await fetch ("https://localhost:44395/api/Login", fetchParams)
          let data = await response.json()
          
          //stringify response from server
          let stringAnswer = JSON.stringify(data)
          let wrongDetails = "Wrong details" 
          //check if user exist
          if(stringAnswer != wrongDetails)
          {
              let user = stringAnswer
              sessionStorage["user"] = user
              location.href = "Home Page.html"
          }
          else
          {
              alert(stringAnswer)
          }
}


//DEPARTMENT PAGE//
// function load all department data table
async function ShowAllDepartments()
{
          let response = await fetch("https://localhost:44395/api/department")
          let data = await response.json();
          
          let tblObj = document.getElementById("tbl0");

          data.forEach(user => {

              //Create new td's objects
              let tdId = document.createElement("td");
              let tdName = document.createElement("td");
              let tdManager = document.createElement("td");
              let tdChanges = document.createElement("td");

              //Set text in the td's 
              tdId.innerText = user.ID;
              tdName.innerText =user.Name ;
              tdManager.innerText = user.Manager;
              
              //create buttons &
              //add button and aherf as child
              let editBtn = document.createElement("input")
              editBtn.type = "button"
              editBtn.class = "button"
              editBtn.value = "Edit"
              
              let editAherf = document.createElement("a")
              editAherf.href = "Edit Department Page.html?departmentid=" + user.ID

              editAherf.appendChild(editBtn)
              tdChanges.appendChild(editAherf)

              //delete button create & function create
              if(user.Manager != 0)
              {
              let deleteBtn = document.createElement("input")
              deleteBtn.type = "button"
              deleteBtn.class = "button"
              deleteBtn.value = "Delete"
              deleteBtn.onclick = async function DeleteDepartmentFromDepPage(event)
                {
                  let fetchParams = {  
                                      method : "DELETE",                  
                                      headers : {"Content-type"  :"application/json" }
                                    }

                  let resp = await fetch("https://localhost:44395/api/Department/" + user.ID, fetchParams);
                  let status = await resp.json();                 
                  alert(status);
                  event.preventDefault()
                }

              tdChanges.appendChild(deleteBtn)
              }

              //Crate a new tr object
              let trObj = document.createElement("tr");

              //Add the td's to the tr
              trObj.appendChild(tdId);
              trObj.appendChild(tdName);
              trObj.appendChild(tdManager);
              trObj.appendChild(tdChanges);

              //Add the tr to the table
              tblObj.appendChild(trObj);

          })
}

let  departmentid

//CREATE DEPARTMENT PAGE//
//add department to the db
async function AddDepartment()
{
          let DepartmentObj = {
            Name: document.getElementById("departmentName").value,
            Manager: parseInt(document.getElementById("departmentManagerID").value),
                             }

        let fetchParams = {
                method : 'POST',
                body : JSON.stringify(DepartmentObj),
                headers : {"Content-Type" : "application/json"}
                          }

        let response = await fetch ("https://localhost:44395/api/Department/", fetchParams)
        let status = await response.json()
        alert(status)        
        location.href="Department Page.html"
}


//DEPARTMENT PAGE
//load data of department choosen in department page inside the textboxes
async function LoadDepartmentData()
{
        // Get the params of the query string
        const params = new URLSearchParams(window.location.search);
        departmentid  =  params.get("departmentid");

        let resp = await fetch("https://localhost:44395/api/Department/" + departmentid);
        let data = await resp.json();
      
        document.getElementById("departmentID").value = data.ID;
        document.getElementById("departmentName").value = data.Name;
        document.getElementById("managerNumber").value = data.Manager;
}


//EDIT DEPARTMENT PAGE
// update department in db choosen in department page followed to edit department page
async function UpdateDepartment()
{
        let depObj = { ID : parseInt(document.getElementById("departmentID").value),
                       Name : document.getElementById("departmentName").value,
                       Manager : parseInt(document.getElementById("managerNumber").value)
                     }
          
                

          let fetchParams = {  
                          method : "PUT",
                          body : JSON.stringify(depObj),
                          headers : {"Content-type"  :"application/json" }
                        }

          let resp = await fetch("https://localhost:44395/api/Department/" + departmentid, fetchParams);
          let status = await resp.json();
        
          alert(status);

          location.href = "Department Page.html";
}


//SHIFTS PAGE//
//load all shifts from db when page load
async function ShowAllShifts()
{
  let response = await fetch("https://localhost:44395/api/ShiftsWithEmployeeNames")
  let data = await response.json();

  let tblObj = document.getElementById("tbl1");

  data.forEach(shift => {
    //Create new td's objects
    let tdDate = document.createElement("td");
    let tdStartTime = document.createElement("td");
    let tdEndTime = document.createElement("td");
    let tdEmployees = document.createElement("td");

    //Set text in the td's 
    tdDate.innerText = shift.Date;
    tdStartTime.innerText =shift.StartTime ;
    tdEndTime.innerText = shift.EndTime;
    
    //create aherf to move to employee edit page & list of shifts
    let ulEmployee = document.createElement("ul")

    for(let i = 0; i < shift.employees.length; i++)
    {
      let liEmployee = document.createElement("li")
      liEmployee.innerText = shift.employees[i]
      let editEmployeeAherf = document.createElement("a")
      editEmployeeAherf.href = "Edit Employee Page.html?employeeid=" + shift.empID
      editEmployeeAherf.appendChild(liEmployee)
      ulEmployee.appendChild(editEmployeeAherf)
      tdEmployees.appendChild(ulEmployee)    
    }

    //Crate a new tr object
    let trObj = document.createElement("tr");

    //Add the td's to the tr
    trObj.appendChild(tdDate);
    trObj.appendChild(tdStartTime);
    trObj.appendChild(tdEndTime);
    trObj.appendChild(tdEmployees);

    //Add the tr to the table
    tblObj.appendChild(trObj);
  })
} 

//ADD SHIFT PAGE//
//add shift to db
async function AddNewShift()
{
          let shifttObj = {
            Date: document.getElementById("ShiftDateId").value,
            StartTime: parseInt(document.getElementById("StartTimeId").value),
            EndTime: parseInt(document.getElementById("EndTimeId").value)
                             }

        let fetchParams = {
                method : 'POST',
                body : JSON.stringify(shifttObj),
                headers : {"Content-Type" : "application/json"}
                          }

        let response = await fetch ("https://localhost:44395/api/Shift/", fetchParams)
        let data = await response.json()                 
        location.href="Shift Page.html"
}

let employeeid
//EMPLOYEE PAGE//
//onload of employee page show all employees data from db
async function ShowEmployeesData()
{
  let response = await fetch("https://localhost:44395/api/EmployeeDataWithShiftTime")
  let data = await response.json();

  let tblObj = document.getElementById("tbl2");

  data.forEach(employee => {

      //Create new td's objects
      let tdFirstName = document.createElement("td");
      let tdLastName = document.createElement("td");
      let tdStartYear = document.createElement("td");
      let tdDepartmentNumber = document.createElement("td");
      let tdShifts = document.createElement("td");
      let tdChanges = document.createElement("td");

      //Set text in the td's 
      tdFirstName.innerText = employee.FirstName;
      tdLastName.innerText =employee.LastName ;
      tdStartYear.innerText = employee.StartWorkYear;
      tdDepartmentNumber.innerText = employee.DepartmentID;

      //create list of shifts
      let ulShifts = document.createElement("ul")
      for(let i = 0; i < employee.ShiftsTimeDate.length; i++)
      {
        let liShifts = document.createElement("li")
        liShifts.innerText = employee.ShiftsTimeDate[i]
        ulShifts.appendChild(liShifts)
        tdShifts.appendChild(ulShifts)    
      }

      //create buttons &
      //add button and aherf as child
      let editBtn = document.createElement("input")
      editBtn.type = "button"
      editBtn.class = "button"
      editBtn.value = "Edit"
      
      let editAherf = document.createElement("a")
      editAherf.href = "Edit Employee Page.html?employeeid=" + employee.EmpID

      editAherf.appendChild(editBtn)
      tdChanges.appendChild(editAherf)

      let deleteBtn = document.createElement("input")
      deleteBtn.type = "button"
      deleteBtn.class = "button"
      deleteBtn.value = "Delete"
      //delete button & its function
      deleteBtn.onclick = async function DeleteEmployeeAndHisShifts(event)
            {
              let fetchParams = {  
                method : "DELETE",                  
                headers : {"Content-type"  :"application/json" }
              }

              let resp = await fetch("https://localhost:44395/api/EmployeeShift/" + employee.EmpID, fetchParams);
              let status = await resp.json();                 

              let fetchParams1 = {  
                                  method : "DELETE",                  
                                  headers : {"Content-type"  :"application/json" }
                                }

              let resp1 = await fetch("https://localhost:44395/api/Employee/" + employee.EmpID, fetchParams1);
              let status1 = await resp1.json();                 
              alert(status1)
              event.preventDefault()

            }
      tdChanges.appendChild(deleteBtn)

      //add shift button & aherf to its page
      let addShiftBtn = document.createElement("input")
      addShiftBtn.type = "button"
      addShiftBtn.class = "button"
      addShiftBtn.value = "Add Shift"
      
      let addShiftPageAherf = document.createElement("a")
      addShiftPageAherf.href = "Employee Add Shift Page.html"

      addShiftPageAherf.appendChild(addShiftBtn)
      tdChanges.appendChild(addShiftPageAherf)

      //Crate a new tr object
      let trObj = document.createElement("tr");

      //Add the td's to the tr
      trObj.appendChild(tdFirstName);
      trObj.appendChild(tdLastName);
      trObj.appendChild(tdStartYear);
      trObj.appendChild(tdDepartmentNumber);
      trObj.appendChild(tdShifts);
      trObj.appendChild(tdChanges);

      //Add the tr to the table
      tblObj.appendChild(trObj);

  })
}


//EDIT EMPLOYEE PAGE//
//load department number from db in dropdown list
async function LoadEmployeeData()
{
        // Get the params of the query string
        const params = new URLSearchParams(window.location.search);
        employeeid  =  params.get("employeeid");

        let resp = await fetch("https://localhost:44395/api/Employee/" + employeeid);
        let data = await resp.json();

        document.getElementById("firstNameID").value = data.FirstName
        document.getElementById("lastNameID").value = data.LastName
        document.getElementById("StartWorkYearID").value = data.StartWorkYear

        //get all department data to extract department names
        let resp2 = await fetch("https://localhost:44395/api/Department");
        let data2 = await resp2.json();

        //add names of department to the combobox
        data2.forEach(element => {
                                    let option = document.createElement("option")
                                    option.innerText = element.Name
                                    option.value = element.ID
                                    let combobox = document.getElementById("departmentCombobox")
                                    combobox.appendChild(option)
                                 })
}


//EDIT EMPLOYEE PAGE
// update employee in db
async function UpdateEmployee()
{
        let empObj = { FirstName : document.getElementById("firstNameID").value,
                       LastName : document.getElementById("lastNameID").value,
                       StartWorkYear : parseInt(document.getElementById("StartWorkYearID").value),
                       DepartmentID : parseInt(document.getElementsByTagName("option").value)
                     } 
          
          let fetchParams = {  
                          method : "PUT",
                          body : JSON.stringify(empObj),
                          headers : {"Content-type"  :"application/json" }
                        }

          let resp = await fetch("https://localhost:44395/api/Employee/" + employeeid, fetchParams);
          let status = await resp.json();
        
          alert(status);

          location.href = "Employee Page.html";
}


//EMPLOYEE ADD SHIFT PAGE//
//add shift to employee in db employeey shift
async function AddShiftToEmployee()
{
        let shiftObj = {
          EmployeeID: parseInt(document.getElementById("employeeid").value),
          ShiftID: parseInt(document.getElementById("shiftid").value),
                          }

      let fetchParams = {
              method : 'POST',
              body : JSON.stringify(shiftObj),
              headers : {"Content-Type" : "application/json"}
                        }

      let response = await fetch ("https://localhost:44395/api/EmployeeShift/", fetchParams)
      let status = await response.json()
      alert(status)               
      location.href="Employee Page.html"
}


async function UserActions()
{
  let userObj = {
                    ID : user.ID
                }

let fetchParams = {
        method : 'POST',
        body : JSON.stringify(userObj),
        headers : {"Content-Type" : "application/json"}
                  }

let response = await fetch ("https://localhost:44395/api/Login/", fetchParams)
let data = await response.json()                 
}


