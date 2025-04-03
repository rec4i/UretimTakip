function successAlert(message, duration) {
    Swal.fire({
        position: 'bottom-end',
        text: '' + message,
        showConfirmButton: false,
        timer: duration == null ? 1500 : duration,
        icon: 'success'
    })
}
function getParameterByName(name) {
    // name parametresi ile eşleşen parametreyi bulmak için regex oluştur
    const regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
    const results = regex.exec(window.location.href);

    // Parametre bulunamazsa null döner
    if (!results) return null;

    // Bulunan parametreyi decode ederek döner
    return decodeURIComponent(results[1].replace(/\+/g, ' '));
}
function errorAlert(message) {
    Swal.fire({
        position: 'bottom-end',
        text: '' + message,
        showConfirmButton: false,
        timer: 1500,
        icon: 'error'
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
    DataMask()
})
function DataMask() {
    $('[data-Mask="currency"]').inputmask({ 'alias': 'currency', radixPoint: ',', negative: false, rightAlign: true, 'removeMaskOnSubmit': true });
    $('[data-Mask="decimal"]').inputmask({ 'alias': 'currency', radixPoint: ',', negative: false, rightAlign: false, 'removeMaskOnSubmit': true });
    $('[data-Mask="withdot"]').inputmask({ 'alias': 'decimal', radixPoint: '.', negative: false, rightAlign: false, 'removeMaskOnSubmit': true });



    $('[data-Mask="numeric"]').inputmask({ 'alias': 'numeric', negative: false, rightAlign: false, 'removeMaskOnSubmit': true });
    $('[data-Mask="biggerThanZero"]').inputmask('numeric', { min: 1, rightAlign: false });
    $('[data-Mask="biggerThanEqualZero"]').inputmask('numeric', { min: 0, rightAlign: false });
    $('[data-Mask="TelefonNumarası"]').inputmask({ 'mask': '0 (999) 999 99 99', 'removeMaskOnSubmit': true });
    $('[data-Mask="OneToTwelve"]').inputmask({ 'mask': '0 (999) 999 99 99', 'removeMaskOnSubmit': true });
    $('[data-Mask="OneToTwelve"]').inputmask({
        mask: '9[9]',
        placeholder: '',
        regex: "^(1[0-2]|[1-9])$",
        onBeforePaste: function (pastedValue) {
            var value = pastedValue.toString().replace(/[^0-9]/g, '');
            return value;
        }
    });
    $('[data-Mask="portNumber"]').inputmask({
        mask: "99999",
        greedy: false,
        jitMasking: true,
        placeholder: "",
        oncomplete: function () {
            var value = $(this).val();
            if (parseInt(value) > 65535) {
                alert("Port numarası 65535'ten büyük olamaz.");
                $(this).val("");
            }
        }
    });
    $('[data-Mask="ipAdress"]').inputmask({
        alias: "ip",
        greedy: false,
        jitMasking: true
    });
    $('[data-Mask="ZeroToTwelve"]').inputmask({
        mask: "09",
        placeholder: "0",
        onBeforePaste: function (pastedValue) {
            return pastedValue;
        },
        definitions: {
            '0': {
                validator: "[0-1]",
                cardinality: 1,
            },
            '9': {
                validator: "[0-9]",
                cardinality: 1,
            }
        },
        postValidation: function (buffer) {
            var value = parseInt(buffer.join(''));
            return value >= 0 && value <= 12;
        }
    });
    $('[data-Mask="ZeroToFiftyNine"]').inputmask({
        mask: "09",
        placeholder: "0",
        onBeforePaste: function (pastedValue) {
            return pastedValue;
        },
        definitions: {
            '0': {
                validator: "[0-5]",
                cardinality: 1,
            },
            '9': {
                validator: "[0-9]",
                cardinality: 1,
            }
        },
        postValidation: function (buffer) {
            var value = parseInt(buffer.join(''));
            return value >= 0 && value <= 59;
        }
    });
    $('[data-Mask="SıfırdanYirmiDörte"]').inputmask({
        mask: "09",
        placeholder: "0",
        definitions: {
            '0': {
                validator: "[0-2]",
                cardinality: 1,
            },
            '9': {
                validator: "[0-9]",
                cardinality: 1,
            }
        },
        postValidation: function (buffer) {
            var value = parseInt(buffer.join(''));
            return value >= 0 && value <= 24;
        }
    });

    $('[data-Mask="Mikar"]').each(function () {
        var prefixValue = $(this).attr('data-prefix') || ''; // Eğer data-prefix tanımlı değilse boş string kullan
        var suffixValue = $(this).attr('data-suffix') || ''; // Eğer data-prefix tanımlı değilse boş string kullan
        $(this).inputmask({
            'alias': 'numeric',
            prefix: prefixValue,
            suffix: suffixValue,
            radixPoint: '.',
            negative: false,
            rightAlign: false,
            digits: 5, 
            digitsOptional: false, 
            'removeMaskOnSubmit': true
        });
    });

}
$(document).ready(function () {
    $('[data-Mask="currency"]').inputmask({ 'alias': 'currency', radixPoint: ',', negative: false, rightAlign: true, 'removeMaskOnSubmit': true });
    $('[data-Mask="decimal"]').inputmask({ 'alias': 'currency', radixPoint: ',', negative: false, rightAlign: false, 'removeMaskOnSubmit': true });
    $('[data-Mask="bigDecimal"]').inputmask({ 'alias': 'decimal', radixPoint: ',', negative: false, rightAlign: false, 'removeMaskOnSubmit': true });
    $('[data-Mask="numeric"]').inputmask({ 'alias': 'numeric', negative: false, rightAlign: false, 'removeMaskOnSubmit': true });
    $('[data-Mask="biggerThanZero"]').inputmask('numeric', { min: 1, rightAlign: false });
    $('[data-Mask="biggerThanEqualZero"]').inputmask('numeric', { min: 0, rightAlign: false });
    $('[data-Mask="TelefonNumarası"]').inputmask({ 'mask': '0 (999) 999 99 99', 'removeMaskOnSubmit': true });
    $('[data-Mask="OneToTwelve"]').inputmask({ 'mask': '0 (999) 999 99 99', 'removeMaskOnSubmit': true });
    $('[data-Mask="OneToTwelve"]').inputmask({
        mask: '9[9]',
        placeholder: '',
        regex: "^(1[0-2]|[1-9])$",
        onBeforePaste: function (pastedValue) {
            var value = pastedValue.toString().replace(/[^0-9]/g, '');
            return value;
        }
    });
    $('[data-Mask="portNumber"]').inputmask({
        mask: "99999",
        greedy: false,
        jitMasking: true,
        placeholder: "",
        oncomplete: function () {
            var value = $(this).val();
            if (parseInt(value) > 65535) {
                alert("Port numarası 65535'ten büyük olamaz.");
                $(this).val("");
            }
        }
    });
    $('[data-Mask="ipAdress"]').inputmask({
        alias: "ip",
        greedy: false,
        jitMasking: true
    });
    $('[data-Mask="ZeroToTwelve"]').inputmask({
        mask: "09",
        placeholder: "0",
        onBeforePaste: function (pastedValue) {
            return pastedValue;
        },
        definitions: {
            '0': {
                validator: "[0-1]",
                cardinality: 1,
            },
            '9': {
                validator: "[0-9]",
                cardinality: 1,
            }
        },
        postValidation: function (buffer) {
            var value = parseInt(buffer.join(''));
            return value >= 0 && value <= 12;
        }
    });
    $('[data-Mask="ZeroToFiftyNine"]').inputmask({
        mask: "09",
        placeholder: "0",
        onBeforePaste: function (pastedValue) {
            return pastedValue;
        },
        definitions: {
            '0': {
                validator: "[0-5]",
                cardinality: 1,
            },
            '9': {
                validator: "[0-9]",
                cardinality: 1,
            }
        },
        postValidation: function (buffer) {
            var value = parseInt(buffer.join(''));
            return value >= 0 && value <= 59;
        }
    });
    $('[data-Mask="SıfırdanYirmiDörte"]').inputmask({
        mask: "09",
        placeholder: "0",
        definitions: {
            '0': {
                validator: "[0-2]",
                cardinality: 1,
            },
            '9': {
                validator: "[0-9]",
                cardinality: 1,
            }
        },
        postValidation: function (buffer) {
            var value = parseInt(buffer.join(''));
            return value >= 0 && value <= 24;
        }
    });
    //Modal Kapatma Butonu
    $('button[data-dismiss="modal"]').click(function () {
        $(this).parent().parent().parent().parent().modal('hide')
    })
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
