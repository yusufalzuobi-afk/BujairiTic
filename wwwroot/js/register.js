document.addEventListener("DOMContentLoaded", function () {

    const form = document.getElementById("registrationForm");
    const feedback = document.getElementById("feedbackBox");

    form.addEventListener("submit", function (e) {

        feedback.style.opacity = "1";
        feedback.style.transform = "translateY(0)";

        setTimeout(() => {
            feedback.style.opacity = "0";
            feedback.style.transform = "translateY(40px)";
        }, 4000);

    });

});
