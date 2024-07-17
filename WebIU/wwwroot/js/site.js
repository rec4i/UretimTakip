function successAlert(message) {
    Swal.fire({
        position: 'bottom-end',
        text: '' + message,
        showConfirmButton: false,
        timer: 1500,
        icon: 'success'
    })
}

function SetSelectedDeviceFromController(Ids) {
    $.ajax({
        url: "/Device/SetSelectedDeviceIdsToSession",
        type: "POST",
        data: { Ids },
        success: function (html) {

        }
    });
}
function setWindowLocation(url) {
    window.location.href = url;
}


function entityDelete(href, name) {
    Swal.fire({
        title: name + ' silinecektir!',
        text: 'Silmek istediğinizden emin misiniz?',
        icon: 'warning',
        showCancelButton: true,
        cancelButtonText: "Geri dön",
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sil'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "GET",
                url: href,
                success: function (response) {
                    if (response != null) {
                        location.reload(true);
                        if (response.indexOf("/") != -1) {
                            location.href = response;
                        } else {
                            location.reload(true);
                        }

                    } else {
                        alert("Birşeyler ters gitti")
                    }
                }
            });
        }
    })
}
$('#select-all').click(function (event) {
    if (this.checked) {
        // Iterate each checkbox
        $(':checkbox').each(function () {
            this.checked = true;
        });
    } else {
        $(':checkbox').each(function () {
            this.checked = false;
        });
    }
});

$(document).ready(function () {
    $('[data-Mask="currency"]').inputmask({ 'alias': 'currency', radixPoint: ',', negative: false, rightAlign: true, 'removeMaskOnSubmit': true });
    $('[data-Mask="decimal"]').inputmask({ 'alias': 'currency', radixPoint: ',', negative: false, rightAlign: false, 'removeMaskOnSubmit': true });
    $('[data-Mask="numeric"]').inputmask({ 'alias': 'numeric', negative: false, rightAlign: false, 'removeMaskOnSubmit': true });
    $('[data-Mask="biggerThanZero"]').inputmask('numeric', { min: 1, rightAlign: false });
    $('[data-Mask="TelefonNumarası"]').inputmask({ 'mask': '0 (999) 999 99 99', 'removeMaskOnSubmit': true });
})



//$(function () {
//    //Initialize Select2 Elements
//    $('.select2').select2()

//    // 
//    $('.select2Tags').select2({
//        tags: true
//    })

//    //Initialize Select2 Elements
//    $('.select2bs4').select2({
//        theme: 'bootstrap4'
//    })
//});

//User Lockout checkbox
$(function () {
    if ($(".LockoutEnabledCheckbox").checked == true) {
        $(".LockoutEndArea").show();
    } else {
        $(".LockoutEndArea").hide();
    }
});

$(".LockoutEnabledCheckbox").change(function () {
    if (this.checked) {
        $(".LockoutEndArea").show(1000);
    } else {
        $(".LockoutEndArea").hide(1000);
    }
});

//Upload image show
var loadFile = function (event) {
    $('.UploadImage').attr('src', URL.createObjectURL(event.target.files[0]));
};


//World Map
$(function () {
    $(".map path").hover(function (event) {
        $(".countryName").html($(this).attr('title'))
        var shortName = $(this).attr('id');
        GetData(shortName)
    })
})
$(function () {
    $(".map path").click(function (event) {
        var shortName = $(this).attr('id');
        GetImplementerInformation(shortName);
    })
})
function GetData(shortName) {
    $.ajax({
        type: "GET",
        url: "/Implementer/GetImplementerWorldMap?shortName=" + shortName,
        success: function (response) {
            if (response != null) {
                var implementerCount = response.impementerCount;
                var userCount = response.userCount;
                $(".implementerCount").html(implementerCount)
                $(".userCount").html(userCount)
            } else {
                alert("Birşeyler ters gitti")
            }
        }
    });
}
function GetImplementerInformation(shortName) {
    window.location.href = "/Implementer/ImplementerList?countryShortName=" + shortName
}
$(function () {

    //Datemask dd/mm/yyyy
    $('#datemask').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })
    //Datemask2 mm/dd/yyyy
    $('#datemask2').inputmask('mm/dd/yyyy', { 'placeholder': 'mm/dd/yyyy' })

    //Date picker
    $('#reservationdate').datetimepicker({
        format: 'L'
    });

    //Date and time picker
    $('#reservationdatetime').datetimepicker({ icons: { time: 'far fa-clock' } });

    //Date range picker
    //for all tags 
    $('input[id=reservation]').each(function () {

        $(this).daterangepicker()
    })
    //Date range picker with time picker
    $('#reservationtime').daterangepicker({
        timePicker: true,
        timePickerIncrement: 30,
        locale: {
            format: 'MM/DD/YYYY hh:mm A'
        }
    })

    $("input[data-bootstrap-switch]").each(function () {
        $(this).bootstrapSwitch('state', $(this).prop('checked'));
    })
})
