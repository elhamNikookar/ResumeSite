
function StartLoading(element = 'body') {
    $(element).waitMe({
        effect: 'bounce',
        text: 'لطفا صبر کنید ...',
        bg: 'rgba(255, 255, 255, 0.7)',
        color: '#000'
    });
}

function CloseLoading(element = 'body') {
    $(element).waitMe('hide');
}




////////////////////////////////////////////// ThingIDo
function LoadThingIDoFormModal(id) {
    $.ajax({
        url: "/Admin/ThingIDo/LoadThingIDoFormModal",
        type: "get",
        data: {
            id: id
        },
        beforSend: function () {
            StartLoading();
        },
        success: function (res) {
            CloseLoading();

            $("#modal-left-content").html(res);

            $('#ThingIDoForm').data('validator', null);
            $.validator.unobtrusive.parse("#ThingIDoForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}


function ThingIDoFormSubmited(res) {
    CloseLoading();

    if (res.status === 'Success') {
        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success')
        $('#modal-left').modal('hide');
        $('#data-table-box').load(location.href + ' #data-table-box');
        $.getScript('/admin/js/data-table.js', function (data, textStatus, jqxhr) { });
    } else {
        showMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error')
    }

}


function DeleteThingIDo(id) {
    swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید ؟",
        icon: "warning",
        dangerMode : true ,
        showDenyButton : true,
        confirmButtonText: 'Delete',
        denyButtonText : 'No'
    }).then((willDelete) => {
        if (willDelete.isConfirmed) {

            $.ajax({
                url: "/Admin/ThingIDo/DeleteThingIDo",
                type: "get",
                data: {
                    id: id
                },
                beforSend: function () {
                    StartLoading();
                },
                success: function (res) {
                    CloseLoading();

                    if (res.status === "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');
                    }

                },
                error: function () {
                    CloseLoading();
                }
            });

        }
    });
}




/////////////////////////////////////////////// Education
function LoadEducationFormModal(id) {
    $.ajax({
        url: "/Admin/Education/LoadEducationFormModal",
        type: "get",
        data: {
            id: id
        },
        beforSend: function () {
            StartLoading();
        },
        success: function (res) {
            CloseLoading();

            $("#modal-left-content").html(res);

            $('#EducationForm').data('validator', null);
            $.validator.unobtrusive.parse("#EducationForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}


function EducationFormSubmited(res) {
    CloseLoading();

    if (res.status === 'Success') {
        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success')
        $('#modal-left').modal('hide');
        $('#data-table-box').load(location.href + ' #data-table-box');
        $.getScript('/admin/js/data-table.js', function (data, textStatus, jqxhr) { });
    } else {
        showMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error')
    }

}


function DeleteEducation(id) {
    swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید ؟",
        icon: "warning",
        dangerMode: true,
        showDenyButton: true,
        confirmButtonText: 'Delete',
        denyButtonText: 'No'
    }).then((willDelete) => {
        if (willDelete.isConfirmed) {

            $.ajax({
                url: "/Admin/Education/DeleteEducation",
                type: "get",
                data: {
                    id: id
                },
                beforSend: function () {
                    StartLoading();
                },
                success: function (res) {
                    CloseLoading();

                    if (res.status === "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');
                    }

                },
                error: function () {
                    CloseLoading();
                }
            });

        }
    });
}




//////////////// Experience
function LoadExperienceFormModal(id) {
    $.ajax({
        url: "/Admin/Experience/LoadExperienceFormModal",
        type: "get",
        data: {
            id: id
        },
        beforSend: function () {
            StartLoading();
        },
        success: function (res) {
            CloseLoading();

            $("#modal-left-content").html(res);

            $('#ExperienceForm').data('validator', null);
            $.validator.unobtrusive.parse("#ExperienceForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}


function ExperienceFormSubmited(res) {
    CloseLoading();

    if (res.status === 'Success') {
        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success')
        $('#modal-left').modal('hide');
        $('#data-table-box').load(location.href + ' #data-table-box');
        $.getScript('/admin/js/data-table.js', function (data, textStatus, jqxhr) { });
    } else {
        showMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error')
    }

}


function DeleteExperience(id) {
    swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید ؟",
        icon: "warning",
        dangerMode: true,
        showDenyButton: true,
        confirmButtonText: 'Delete',
        denyButtonText: 'No'
    }).then((willDelete) => {
        if (willDelete.isConfirmed) {

            $.ajax({
                url: "/Admin/Experience/DeleteExperience",
                type: "get",
                data: {
                    id: id
                },
                beforSend: function () {
                    StartLoading();
                },
                success: function (res) {
                    CloseLoading();

                    if (res.status === "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');
                    }

                },
                error: function () {
                    CloseLoading();
                }
            });

        }
    });
}




///////////////////////////// CustomerFeedback

function LoadCustomerFeedbackFormModal(id) {
    $.ajax({
        url: "/Admin/CustomerFeedback/LoadCustomerFeedbackFormModal",
        type: "get",
        data: {
            id: id
        },
        beforSend: function () {
            StartLoading();
        },
        success: function (res) {
            CloseLoading();

            $("#modal-left-content").html(res);

            $('#CustomerFeedbackForm').data('validator', null);
            $.validator.unobtrusive.parse("#CustomerFeedbackForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}


function CustomerFeedbackFormSubmited(res) {
    CloseLoading();

    if (res.status === 'Success') {
        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success')
        $('#modal-left').modal('hide');
        $('#data-table-box').load(location.href + ' #data-table-box');
        $.getScript('/admin/js/data-table.js', function (data, textStatus, jqxhr) { });
    } else {
        showMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error')
    }

}


function DeleteCustomerFeedback(id) {
    swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید ؟",
        icon: "warning",
        dangerMode: true,
        showDenyButton: true,
        confirmButtonText: 'Delete',
        denyButtonText: 'No'
    }).then((willDelete) => {
        if (willDelete.isConfirmed) {

            $.ajax({
                url: "/Admin/CustomerFeedback/DeleteCustomerFeedback",
                type: "get",
                data: {
                    id: id
                },
                beforSend: function () {
                    StartLoading();
                },
                success: function (res) {
                    CloseLoading();

                    if (res.status === "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');
                    }

                },
                error: function () {
                    CloseLoading();
                }
            });

        }
    });
}




///////////////////////////// CustomerLogo

function LoadCustomerFeedbackFormModal(id) {
    $.ajax({
        url: "/Admin/CustomerLogo/LoadCustomerLogoFormModal",
        type: "get",
        data: {
            id: id
        },
        beforSend: function () {
            StartLoading();
        },
        success: function (res) {
            CloseLoading();

            $("#modal-left-content").html(res);

            $('#CustomerLogoForm').data('validator', null);
            $.validator.unobtrusive.parse("#CustomerLogoForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}


function CustomerLogoFormSubmited(res) {
    CloseLoading();

    if (res.status === 'Success') {
        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success')
        $('#modal-left').modal('hide');
        $('#data-table-box').load(location.href + ' #data-table-box');
        $.getScript('/admin/js/data-table.js', function (data, textStatus, jqxhr) { });
    } else {
        showMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error')
    }

}


function DeleteCustomerLogo(id) {
    swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید ؟",
        icon: "warning",
        dangerMode: true,
        showDenyButton: true,
        confirmButtonText: 'Delete',
        denyButtonText: 'No'
    }).then((willDelete) => {
        if (willDelete.isConfirmed) {

            $.ajax({
                url: "/Admin/CustomerLogo/DeleteCustomerLogo",
                type: "get",
                data: {
                    id: id
                },
                beforSend: function () {
                    StartLoading();
                },
                success: function (res) {
                    CloseLoading();

                    if (res.status === "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');
                    }

                },
                error: function () {
                    CloseLoading();
                }
            });

        }
    });
}




///////////////////////////// Skill

function LoadSkillFormModal(id) {
    $.ajax({
        url: "/Admin/Skill/LoadSkillFormModal",
        type: "get",
        data: {
            id: id
        },
        beforSend: function () {
            StartLoading();
        },
        success: function (res) {
            CloseLoading();

            $("#modal-left-content").html(res);

            $('#SkillForm').data('validator', null);
            $.validator.unobtrusive.parse("#SkillForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}


function SkillFormSubmited(res) {
    CloseLoading();

    if (res.status === 'Success') {
        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success')
        $('#modal-left').modal('hide');
        $('#data-table-box').load(location.href + ' #data-table-box');
        $.getScript('/admin/js/data-table.js', function (data, textStatus, jqxhr) { });
    } else {
        showMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error')
    }

}


function DeleteSkill(id) {
    swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید ؟",
        icon: "warning",
        dangerMode: true,
        showDenyButton: true,
        confirmButtonText: 'Delete',
        denyButtonText: 'No'
    }).then((willDelete) => {
        if (willDelete.isConfirmed) {

            $.ajax({
                url: "/Admin/Skill/DeleteSkill",
                type: "get",
                data: {
                    id: id
                },
                beforSend: function () {
                    StartLoading();
                },
                success: function (res) {
                    CloseLoading();

                    if (res.status === "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');
                    }

                },
                error: function () {
                    CloseLoading();
                }
            });

        }
    });
}



//////////////////////////// PortFolioCategory


function LoadPortfolioCategoryFormModal(id) {
    $.ajax({
        url: "/Admin/PortfolioCategory/LoadPortfolioCategoryFormModal",
        type: "get",
        data: {
            id: id
        },
        beforSend: function () {
            StartLoading();
        },
        success: function (res) {
            CloseLoading();

            $("#modal-left-content").html(res);

            $('#PortfolioCategoryForm').data('validator', null);
            $.validator.unobtrusive.parse("#PortfolioCategoryForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}

function PortfolioCategoryFormSubmited(res) {
    CloseLoading();

    if (res.status === 'Success') {
        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success')
        $('#modal-left').modal('hide');
        $('#data-table-box').load(location.href + ' #data-table-box');
        $.getScript('/admin/js/data-table.js', function (data, textStatus, jqxhr) { });
    } else {
        showMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error')
    }

}

function DeletePortfolioCategory(id) {
    swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید ؟",
        icon: "warning",
        dangerMode: true,
        showDenyButton: true,
        confirmButtonText: 'حذف',
        denyButtonText: 'خیر'
    }).then((willDelete) => {
        if (willDelete.isConfirmed) {

            $.ajax({
                url: "/Admin/PortfolioCategory/DeletePortfolioCategory",
                type: "get",
                data: {
                    id: id
                },
                beforSend: function () {
                    StartLoading();
                },
                success: function (res) {
                    CloseLoading();

                    if (res.status === "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');
                    }

                },
                error: function () {
                    CloseLoading();
                }
            });

        }
    });
}



//////////////////////////// PortFolio


function LoadPortfolioFormModal(id) {
    $.ajax({
        url: "/Admin/Portfolio/LoadPortfolioFormModal",
        type: "get",
        data: {
            id: id
        },
        beforSend: function () {
            StartLoading();
        },
        success: function (res) {
            CloseLoading();

            $("#modal-left-content").html(res);

            $('#PortfolioForm').data('validator', null);
            $.validator.unobtrusive.parse("#PortfolioForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}

function PortfolioFormSubmited(res) {
    CloseLoading();

    if (res.status === 'Success') {
        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success')
        $('#modal-left').modal('hide');
        $('#data-table-box').load(location.href + ' #data-table-box');
        $.getScript('/admin/js/data-table.js', function (data, textStatus, jqxhr) { });
    } else {
        showMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error')
    }

}

function DeletePortfolio(id) {
    swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید ؟",
        icon: "warning",
        dangerMode: true,
        showDenyButton: true,
        confirmButtonText: 'حذف',
        denyButtonText: 'خیر'
    }).then((willDelete) => {
        if (willDelete.isConfirmed) {

            $.ajax({
                url: "/Admin/Portfolio/DeletePortfolio",
                type: "get",
                data: {
                    id: id
                },
                beforSend: function () {
                    StartLoading();
                },
                success: function (res) {
                    CloseLoading();

                    if (res.status === "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');
                    }

                },
                error: function () {
                    CloseLoading();
                }
            });

        }
    });
}


//////////////////////////// Information


function LoadInformationFormModal() {
    $.ajax({
        url: "/Admin/Information/LoadInformationFormModal",
        type: "get",
        data: {
        },
        beforSend: function () {
            StartLoading();
        },
        success: function (res) {
            CloseLoading();

            $("#modal-left-content").html(res);

            $('#InformationForm').data('validator', null);
            $.validator.unobtrusive.parse("#InformationForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}

function InformationFormSubmited(res) {
    CloseLoading();

    if (res.status === 'Success') {
        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success')
        $('#modal-left').modal('hide');
        $('#data-table-box').load(location.href + ' #data-table-box');
        $.getScript('/admin/js/data-table.js', function (data, textStatus, jqxhr) { });
    } else {
        showMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error')
    }

}


/////////////////////// Message

function DeleteMessage(id) {
    swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید ؟",
        icon: "warning",
        dangerMode: true,
        showDenyButton: true,
        confirmButtonText: 'حذف',
        denyButtonText: 'خیر'
    }).then((willDelete) => {
        if (willDelete.isConfirmed) {

            $.ajax({
                url: "/Admin/Message/DeleteMessage",
                type: "get",
                data: {
                    id: id
                },
                beforSend: function () {
                    StartLoading();
                },
                success: function (res) {
                    CloseLoading();

                    if (res.status === "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');
                    }

                },
                error: function () {
                    CloseLoading();
                }
            });

        }
    });
}



////////////////////////////////////////////// SocialMedia
function LoadSocialMediaFormModal(id) {
    $.ajax({
        url: "/Admin/SocialMedia/LoadSocialMediaFormModal",
        type: "get",
        data: {
            id: id
        },
        beforSend: function () {
            StartLoading();
        },
        success: function (res) {
            CloseLoading();

            $("#modal-left-content").html(res);

            $('#SocialMediaForm').data('validator', null);
            $.validator.unobtrusive.parse("#SocialMediaForm");

            $('#modal-left').modal('show');

        },
        error: function () {
            CloseLoading();
        }
    });
}


function SocialMediaFormSubmited(res) {
    CloseLoading();

    if (res.status === 'Success') {
        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success')
        $('#modal-left').modal('hide');
        $('#data-table-box').load(location.href + ' #data-table-box');
        $.getScript('/admin/js/data-table.js', function (data, textStatus, jqxhr) { });
    } else {
        showMessage('عملیات با شکست مواجه شد', 'پیغام خطا', 'error')
    }

}


function DeleteSocialMedia(id) {
    swal.fire({
        title: "اخطار",
        text: "آیا از حذف این آیتم اطمینان دارید ؟",
        icon: "warning",
        dangerMode: true,
        showDenyButton: true,
        confirmButtonText: 'Delete',
        denyButtonText: 'No'
    }).then((willDelete) => {
        if (willDelete.isConfirmed) {

            $.ajax({
                url: "/Admin/SocialMedia/DeleteSocialMedia",
                type: "get",
                data: {
                    id: id
                },
                beforSend: function () {
                    StartLoading();
                },
                success: function (res) {
                    CloseLoading();

                    if (res.status === "Success") {
                        ShowMessage('عملیات با موفقیت انجام شد.', 'پیغام موفقیت', 'success');
                        $(`#ListItem-${id}`).remove();
                    } else {
                        ShowMessage('عملیات با شکست مواجه شد.', 'پیغام خطا', 'error');
                    }

                },
                error: function () {
                    CloseLoading();
                }
            });

        }
    });
}

