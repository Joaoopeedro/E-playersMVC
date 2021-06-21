// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var menu = document.getElementById("Link");
        function botaodoMenu() {
            if (screen.width <= 768) {
                if (menu.style.display === "flex") {
                    // esconder o menu
                    menu.style.display = "none";
                } else {
                    // Mostrar o menu 
                    menu.style.display = "flex";
                }
            }
        }
        function fecharMenu() {
            var fechar_menu =
                document.getElementById("Link");
            if (fechar_menu.style.display === "flex") {
                // esconder menu
                fechar_menu.style.display = "none";
            }
        }
        window.onresize = () => {
            if (screen.width > 768) {
                menu.style.display = "flex";
            } else {
                menu.style.display = "none";
            }
        }