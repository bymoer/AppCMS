$(function () {
    $("form[name='loginForm']").validate({
        rules: {
            Login: "required",
            Password: {
                required: true
            }
        },
        messages: {

            Login: "Please enter your login",
            Password: {
                required: "Please enter your password"
            }
        },
        submitHandler: function (form) {
            form.submit();
        }
    });
});