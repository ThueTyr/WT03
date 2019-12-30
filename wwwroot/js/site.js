// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let footerNode = document.getElementById("footer");
let newHtml = "<p>wwwroot->js->site.js shows that the site was last edited on: " + document.lastModified + "</p>";
footerNode.innerHTML += newHtml;