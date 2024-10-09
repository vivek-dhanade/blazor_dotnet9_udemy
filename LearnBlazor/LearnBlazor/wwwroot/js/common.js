window.showToastr = function (type, message) {

    if (type == "success") {
        toastr.success(message);
    }
    if (type == "error") {
        toastr.error(message);
    }
}


window.sweetAlert = function (type, message) {

    if (type == "success") {
        Swal.fire({
            title: "Good job",
            text: message,
            icon: "success"
        });
    }
    if (type == "error") {
        Swal.fire({
            title: "Error occured",
            text: message,
            icon: "error"
        });
    }

}
