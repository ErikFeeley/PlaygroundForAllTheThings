"use strict";
exports.__esModule = true;
var Koa = require("koa");
var app = new Koa();
app.use(function (ctx) {
    ctx.body = 'Hello koa';
});
app.listen(3000);
