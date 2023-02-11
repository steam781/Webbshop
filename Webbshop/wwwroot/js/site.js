// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.getElementById("add").addEventListener("click", function () {
    var input = document.getElementById("New").value;
    document.getElementById("purchasinglist").innerHTML += input + ",";
});
