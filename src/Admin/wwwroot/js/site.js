$(document).ready(function () {

    $('.init-data-table').DataTable();

    $("#ddlTypes").change(function () {

        var typeId = $("#ddlTypes").val();
        if (typeId === "1") {
            $("#divTopics").show();
            $("#divScheduledDate").hide();
        }
        else {
            $("#divTopics").hide();
            $("#divScheduledDate").show();
        }
    });

    if ($("#hdfPrayerNoteId").val() === "0") {
        $("#divScheduledDate").hide();
    }
    else {
        $("#ddlTypes").change();
    }
});

$('#confirmationModel').on('show.bs.modal', function (event) {
    let button = $(event.relatedTarget);

    let targetUrl = button.data('targeturl');
    let targetId = button.data('targetid');
    let confirmationMessage = button.data('confirmationmessage');
    let successMessage = button.data('successmessage');
    let failureMessage = button.data('failuremessage');

    var modal = $(this);
    modal.find('.modal-body #lblMessage').html(confirmationMessage);

    //let targetUrl = button.data('targeturl');
    //let targetId = button.data('targetid');
    //let targetDiv = button.data('targetdiv');
    //let objectName = button.data('objectname');
    //let actionType = button.data('action');

    //let successMessage = "";
    //let failureMessage = "";

    //var modal = $(this);
    //if (actionType === "delete") {

    //    modal.find('.modal-body #lblMessage').html('Are you sure you want to delete the ' + objectName.toLowerCase() + '?');

    //    successMessage = objectName + ' deleted successfully';
    //    failureMessage = 'Some error occured while deleting ' + objectName.toLowerCase();
    //}
    //else if (actionType === "enable") {
    //    modal.find('.modal-body #lblMessage').html('Are you sure you want to enable the ' + objectName.toLowerCase() + '?');

    //    successMessage = objectName + ' enabled successfully';
    //    failureMessage = 'Some error occured while enabling ' + objectName.toLowerCase();
    //}
    //else if (actionType === "disable") {
    //    modal.find('.modal-body #lblMessage').html('Are you sure you want to disable the ' + objectName.toLowerCase() + '?');

    //    successMessage = objectName + ' disabled successfully';
    //    failureMessage = 'Some error occured while disabling ' + objectName.toLowerCase();
    //}

    modal.find('#btnYes').unbind('click').click(function () {
        $.ajax({
            method: "GET",
            url: targetUrl,
            data: { id: targetId },
            success: function () {
				window.location.href = 'https://admin.doc-coach-sports.logicstones.net/Trainee'
                SuccessMessage(successMessage);
            },
            error: function () {
                FailureMessage(failureMessage);
            },
            complete: function () {
                $('#confirmationModel').modal('hide');
            }
        });
    });
});

function SuccessMessage(msg) {
    toastr.success(msg);
}

function FailureMessage(msg) {
    toastr.error(msg);
}