
var empId = document.getElementById("employeeid");
var emptyProjectListContainer = document.getElementById("projectsList");
var emptyProjectList = document.getElementById("projectid");

addEventListener("change", async () => {
    var projectResponse = await fetch(`http://localhost:5226/Employee/getProjects/${empId.value}`);
    var filledList = await projectResponse.text();
    emptyProjectListContainer.innerHTML = filledList;
    emptyProjectList = document.getElementById("projectid");


    var hoursContainer = document.getElementById("projectHours");

    addEventListener("change", async () => {
        var hoursResponse = await fetch(`http://localhost:5226/Employee/getHours/${empId.value}/${emptyProjectList.value}`)

        var hoursResult = await hoursResponse.text();
        hoursContainer.innerHTML = hoursResult;
    });
})

