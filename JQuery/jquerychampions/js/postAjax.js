/**
 * @param {string} request  Request url to make the POST
 * @param {Object} objetoInsertar Data to insert with POST request
 * @returns
 */
async function postAjax(request, objetoInsertar) {
    await $.ajax({
        url: request,
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(objetoInsertar),
    });
}
