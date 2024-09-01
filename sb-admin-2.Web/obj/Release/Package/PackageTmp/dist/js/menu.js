////$("#sidebarMenu").load("menu.html", function () {
////  var url = window.location;
////  var element = $('.nav-item a').filter(function () {
////    return this.href == url;
////  });
////  element.addClass("active");
////  var parent = element.parent().parent().parent();
////  if (undefined == parent)
////    return;
////  parent.addClass("menu-open");
////  parent.children()[0].classList.add("active");
////});

//$.ajax({
//    method: "get",
//    dataType: "html",
//    async:false,
//    url:"menu.html",
//    success: function (data) {
//        $("#sidebarMenu").html(data);
//        var url = window.location;
//        var element = $('.nav-item a').filter(function () {
//            return this.href == url;
//        });
//        element.addClass("active");
//        var parent = element.parent().parent().parent();
//        if (parent.length <= 0)
//            return;
//        parent.addClass("menu-open");
//        parent.children()[0].classList.add("active");
//    },
//    error: function () {
//        console.log(this,arguments);
//    }
//});