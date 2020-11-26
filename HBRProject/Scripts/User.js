const GetUser = async () => {
    let username = JSON.stringify({
        'username': localStorage.getItem('username')
    })

    let responseData = await $.ajax({
        contentType: 'application/json; charset=utf-8',
        type: 'POST',
        url: "/User/GetUser",
        datatype: 'JSON',
        data: username,
        success: function (response) {
            return response.data[0]
        }
    })

    return responseData.data[0]
}