function getAppointmentsFromApi() {
    const url = "https://localhost:64670/api/Appointment?page=1&itemsPerPage=10";

    fetch(url)
        .then(function (response) {
            return console.log(response.json());
        })
        

}

function createAppointmentTable(data) {

    const appointmentTableDiv = document.getElementById("appointment-table");
    appointmentTableDiv.innerHTML = data;
}

