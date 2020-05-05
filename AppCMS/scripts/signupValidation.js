$(function () {
    $("form[name='signupForm']").validate({
        rules: {
            Name: "required",
            Email: {
                required: true,
                email: true
            },
            Password: {
                required: true,
                minlength: 10
            },
            PasswordRepeat: {
                required: true,
                minlength: 10,
                equalTo: "#Password"
            }
        },
        message: {
            Name: "Please enter your name",
            Email: "Please enter valid email address",
            Password: {
                required: "Please provide a password",
                minlength: "Password must be 10 characters long"
            },
            PasswordRepeat: {
                required: "Please enter password again",
                minlength: "Must be 10 characters long",
                equalTo: "Must be identical"
            }
        },
        submitHandler: function (form) {
            form.submit();
        }
    });
});