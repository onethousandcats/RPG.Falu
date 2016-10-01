
function getLoadingHtml() {
    return '<div class="center-load"><i class="fa fa-spinner fa-pulse fa-fw fa-4x"></i></div>';
}

function ODataDateParser(data) {
    if (data != undefined || data != null) {
        var m = data.split(/[T-]/);
        var d = new Date(parseInt(m[0]), parseInt(m[1] - 1), parseInt(m[2]));

        return d.getMonth() + 1 + "/" + d.getDate() + "/" + d.getFullYear();
    }
}

function ODataHyperlink(data) {
    if (data != undefined || data != null) {
        return "<a href='#' class='remove btn btn-danger btn-sm' id='" + data + "'>Remove</a>";
    }
}

function CloseMessagesListener() {
    $('.close').on('click', function () {
        $(this).parent().hide();
    });
}

function ShowSuccessMessage(message) {
    var s = $('#success');
    var sm = $('#success > .alert-message');
    s.show();
    sm.html(message);
}

$('.partial').each(function () {
    $(this).load($(this).data('url'));
});

$.fn.reload = function () {
    this.each(function () {
        $(this).load($(this).data('url'));
    });
};

$('.currency').inputmask("decimal", {
    radixPoint: ".",
    groupSeparator: ",",
    digits: 2,
    autoGroup: true,
    prefix: '$',
    rightAlign: false,
    autoUnmask: true
});

$('.password').prop('type', 'password');

$('.popover-link').popover();

$('.ssn-mask').on('keyup', function () {

    var res = this.value,
        len = res.length,
        max = 9,
        stars = len > 0 ? len > 1 ? len > 2 ? len > 3 ? len > 4 ? '***-**-' : '***-*' : '***-' : '**' : '*' : '',
        result = stars + res.substring(5);

    var t = $('#' + $(this).data('target'));

    $(this).attr('maxlength', max);
    t.val(result);

});

function MaskInputs() {
    Inputmask.extendDefinitions({
        '*': {
            casing: "upper"
        }
    });

    $('.ssn1').inputmask("999", { removeMaskOnSubmit: true });
    $('.ssn2').inputmask("99", { removeMaskOnSubmit: true });
    $('.ssn3').inputmask("9999", { removeMaskOnSubmit: true });

    $('.ssn').inputmask("999-99-9999", { removeMaskOnSubmit: true });
    $('.phone').inputmask("(999) 999-9999", { removeMaskOnSubmit: true });
    $('.zip').inputmask("99999[-9999]", { greedy: false, removeMaskOnSubmit: true });
    $('.date').inputmask("99/99/9999", { placeholder: 'MM/DD/YYYY' });
    $('.code').inputmask("****-****-****-****", { placeholder: 'XXXX-XXXX-XXXX-XXXX', removeMaskOnSubmit: true });
}

MaskInputs();