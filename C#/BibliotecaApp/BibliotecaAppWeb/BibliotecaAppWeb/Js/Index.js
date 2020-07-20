var gitHub = document.querySelector('#idGitHub');

gitHub.addEventListener('click', function (e) {
    location.href = "https://github.com/sanpedrofabianezequiel";
})

var contactos = document.querySelectorAll('.sPequeña');
for (var i = 0; i < 4; i++) {
        contactos[i].addEventListener('click', function (e) {
                    location.href = "https://www.linkedin.com/in/ezequiel-san-pedro-24439b17b/";
        })
}


/*var seleccion = document.querySelectorAll('td');

for (var i = 0; i < seleccion.length; i++) {

    seleccion[i].addEventListener('click', function (e) {
        var index = document.querySelector('#idGridView')

        console.log("dato campturado " + index[i].innerHTML);
    })

}*/
