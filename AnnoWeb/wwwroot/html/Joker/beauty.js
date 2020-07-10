/// <reference path="../../js/scripts/base.js" />
/// <reference path="../../js/vue.js" />
/// <reference path="../../js/jquery.min.js" />
$(function () {
    var input = bif.getInput();
    input.channel = "Anno.Plugs.Logic";
    input.method = "BeautyPic";
    input.router = "Joke";
    input.page = 1;
    input.page_size = 30;
    bif.process(input, function (data) {
        if (data.status) {
            console.log(data);
        }
    });
});