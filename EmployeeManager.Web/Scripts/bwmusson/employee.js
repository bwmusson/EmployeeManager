function formatDate(dateIn) {
    var date = new Date(parseInt(dateIn.substr(6)));
    date = date.toISOString().split('T')[0];
    return date;
}

function searchEmployee() {
    var search = $("#searchString").val();

    $.ajax({
        url: "Search",
        data: { searchString: search }
    }).done(function(data) {
        $("#recordGuid").val(data.RecordGuid);
        $("#firstName").val(data.FirstName);
        $("#middleName").val(data.MiddleName);
        $("#lastName").val(data.LastName);
        $("#birthDate").val(formatDate(data.BirthDate));
        $("#hireDate").val(formatDate(data.HireDate));
		$("#department").val(data.Department);
        $("#jobTitle").val(data.JobTitle);
        $("#payRate").val(data.PayRate);
		$("#salaryType").val(data.SalaryType);
		$("#employeeId").val(data.EmployeeId);
        $("#availableHours").val(data.AvailableHours);
        $("#successMessage").removeClass("d-block")
            .addClass("d-none");
        $("#errorMessage").removeClass("d-block")
            .addClass("d-none");
    });
}

function updateEmployee() {
    var recordGuid = $("#recordGuid").val();
    var firstName = $("#firstName").val();
    var middleName = $("#middleName").val();
    var lastName = $("#lastName").val();
    var birthDate = $("#birthDate").val();
    var hireDate = $("#hireDate").val();
    var department = $("#department").val();
    var jobTitle = $("#jobTitle").val();
    var payRate = $("#payRate").val();
    var salaryType = $("#salaryType").val();
    var employeeId = $("#employeeId").val();
    var availableHours = $("#availableHours").val();

    $.ajax({
        url: "Update",
        dataType: "json",
        data: {
            RecordGuid: recordGuid,
            FirstName: firstName,
            MiddleName: middleName,
            LastName: lastName,
            BirthDate: birthDate,
            HireDate: hireDate,
            Department: department,
            JobTitle: jobTitle,
            PayRate: payRate,
            SalaryType: salaryType,
            EmployeeId: employeeId,
            AvailableHours: availableHours
        }
    }).done(function(data) {
        if (data) {
            $("#errorMessage").removeClass("d-block")
                .addClass("d-none");
            $("#successMessage").removeClass("d-none")
                .addClass("d-block");
        } else {
            $("#errorMessage").removeClass("d-none")
                .addClass("d-block");
            $("#successMessage").removeClass("d-block")
                .addClass("d-none");
        }
    });
}