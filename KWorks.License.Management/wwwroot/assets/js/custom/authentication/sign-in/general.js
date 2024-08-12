/******/ (() => { // webpackBootstrap
/******/ 	"use strict";
    var __webpack_exports__ = {};
    /*!*******************************************************************************************!*\
      !*** ../../../themes/metronic/html/demo6/src/js/custom/authentication/sign-in/general.js ***!
      \*******************************************************************************************/


    // Class definition
    var KTSigninGeneral = function () {
        // Elements
        var form;
        var submitButton;
        var validator;

        // Handle form
        var handleForm = function (e) {
            // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
            validator = FormValidation.formValidation(
                form,
                {
                    fields: {
                        'loginId': {
                            validators: {
                                notEmpty: {
                                    message: '아이디를 입력하세요.'
                                }
                            }
                        },
                        'password': {
                            validators: {
                                notEmpty: {
                                    message: '패스워드를 입력하세요.'
                                }
                            }
                        }
                    },
                    plugins: {
                        trigger: new FormValidation.plugins.Trigger(),
                        bootstrap: new FormValidation.plugins.Bootstrap5({
                            rowSelector: '.fv-row'
                        })
                    }
                }
            );

            // Handle form submit
            submitButton.addEventListener('click', function (e) {
                // Prevent button default action
                e.preventDefault();

                // Validate form
                validator.validate().then(function (status) {
                    if (status == 'Valid') {
                        // Show loading indication
                        submitButton.setAttribute('data-kt-indicator', 'on');

                        // Disable button to avoid multiple click 
                        submitButton.disabled = true;


                        // Simulate ajax request
                        setTimeout(function () {
                            // Hide loading indication
                            submitButton.removeAttribute('data-kt-indicator');

                            // Enable button
                            submitButton.disabled = false;

                            //console.debug();
                            var ajaxData = {
                                id: form.querySelector('[name="id"]').value.toString(),
                                password: form.querySelector('[name="password"]').value.toString(),
                                remember: form.querySelector('[name="remember"]').checked
                            };

                            //
                            $.ajax({
                                type: 'POST',
                                url: "/Default.aspx/SignIn",
                                contentType: "application/json; charset=utf-8",
                                data: JSON.stringify(ajaxData),
                                datatype: "json",
                                async: "true",
                                success: function (response) {
                                    response = $.parseJSON(response.d);
                                    //.debug();

                                    if (!response.Success) {
                                        Swal.fire({
                                            text: response.Message,
                                            icon: "error",
                                            buttonsStyling: false,
                                            confirmButtonText: "확인",
                                            customClass: {
                                                confirmButton: "btn btn-primary"
                                            }
                                        });
                                    }
                                    else {
                                        window.location.href = '/Default.aspx';
                                    }
                                },
                                error: function (response) {
                                    response = $.parseJSON(response.d);
                                    //.debug();

                                    Swal.fire({
                                        text: "잘못된 접근입니다.",
                                        icon: "error",
                                        buttonsStyling: false,
                                        confirmButtonText: "확인",
                                        customClass: {
                                            confirmButton: "btn btn-primary"
                                        }
                                    });
                                }
                            });
                        }, 1000);
                    }
                    else {
                        Swal.fire({
                            text: "아이디 및 패스워드를 입력하시기 바랍니다.",
                            icon: "error",
                            buttonsStyling: false,
                            confirmButtonText: "확인",
                            customClass: {
                                confirmButton: "btn btn-primary"
                            }
                        });
                    }
                });
            });
        }

        // Public functions
        return {
            // Initialization
            init: function () {
                form = document.querySelector('#kt_sign_in_form');
                submitButton = document.querySelector('#kt_sign_in_submit');

                handleForm();
            }
        };
    }();

    // On document ready
    KTUtil.onDOMContentLoaded(function () {
        KTSigninGeneral.init();
    });

    /******/
})();
;
//# sourceMappingURL=general.js.map