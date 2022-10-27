/**
 * @param {string} request Url to make to the request
 * @returns API data as json
 */
async function getAjax(request) {
    const result = await $.ajax({
        url: request,
        method: "GET",
        dataType: "json",
    });
    return result;
}
