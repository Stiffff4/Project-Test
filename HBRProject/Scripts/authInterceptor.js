const IsNotLogged = () => {
    if (!localStorage.getItem('isLogged')) {
        window.location.href = 'https://localhost:44388/User';
    }
}


const IsLogged = () => {
    if (localStorage.getItem('isLogged')) { //Ta jevi ahi. En verdad crei que seria mas dificil implementar esta logica, pero aprendi algo hoy xd Gracias compai, tat antes de que te vayas, puedes chequear un chin el codigo
        //pa que me digas que puedo mejorar? Ok, dejame chequearlo rapido
        window.location.href = 'https://localhost:44388/Product';
    }
}



