﻿var http = {
    post: function (url, data) {
        var params = {
            __RequestVerificationToken: $(':hidden[name="__RequestVerificationToken"]:first').val()
        };

        $.extend(true, params, data);

        return $.post(url, params);
    }
};

$(function () {
    $('[data-toggle="logout"]').on('click', function () {
        http.post('/Kooboo-Submit/SignOut')
            .done(function (result) {
                if (result.Success) {
                    location.href = result.RedirectUrl;
                }
            });
    });

    $('.ajaxForm').each(function () {
        var form = $(this);
        form.ajaxForm({
            sync: true,
            beforeSerialize: function ($form, options) {
            },
            beforeSend: function () {
                var form = $(this);
                form.find("[type=submit]").addClass("disabled").attr("disabled", true);
            },
            beforeSubmit: function (arr, $form, options) {
            },
            success: function (responseData, statusText, xhr, $form) {
                form.find("[type=submit]").removeClass("disabled").removeAttr("disabled");
                if (!responseData.Success) {
                    var validator = form.validate();
                    //                            var errors = [];
                    for (var i = 0; i < responseData.FieldErrors.length; i++) {
                        var obj = {};
                        var fieldName = responseData.FieldErrors[i].FieldName;
                        if (fieldName == "") {
                            alert(responseData.FieldErrors[i].ErrorMessage);
                        }
                        obj[fieldName] = responseData.FieldErrors[i].ErrorMessage;
                        validator.showErrors(obj);
                    }
                }
                else {
                    if (responseData.RedirectUrl != null) {
                        location.href = responseData.RedirectUrl;
                    }
                    else {
                        location.reload();
                    }

                }
            },
            error: function () {
                var form = $(this);
                form.find("[type=submit]").removeClass('disabled').removeAttr('disabled');
            }

        });
    });
});