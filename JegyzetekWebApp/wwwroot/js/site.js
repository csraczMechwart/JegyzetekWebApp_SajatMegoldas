// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ujKartya() {
    var kartyaNev = document.getElementById("UjKartya").value;
    if (kartyaNev != "") {
        var xhr = new XMLHttpRequest();
        xhr.withCredentials = true;

        xhr.addEventListener("readystatechange", function () {
            if (this.readyState === 4) {
                console.log(this.responseText);                
            }
            
        });

        xhr.open("POST", "https://localhost:7080/api/Jegyzet/ujKartya/" + kartyaNev);

        xhr.send();
    }
}

function ujTeendo(kartyaId) {
    var azon = "ujTeendo" + kartyaId
    console.log(azon)
    var teendoTartalom = document.getElementById(azon).value;
    console.log(teendoTartalom);
    /*if (teendoTartalom != "") {
        var xhr = new XMLHttpRequest();
        xhr.withCredentials = true;

        xhr.addEventListener("readystatechange", function () {
            if (this.readyState === 4) {
                console.log(this.responseText);
                console.log(teendoTartalom);
                console.log(kartyaId);
            }

        });

        xhr.open("POST", "https://localhost:7080/api/Jegyzet/ujTeendo/" + teendoTartalom + "/" + kartyaId);

        xhr.send();
    }*/

}