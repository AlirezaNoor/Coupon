/**
 * 
 * Template Name: KuponHub
 * Template URL:  https://codenpixel.com/demos
 * Description:   Deals and discounts Bootstrap template
 * Version:       1.0.0
 * Author:        @codenpixel 
 * Author URI:    https://codenpixel.com
 * 
 */
$(document).ready(function () {
    "use strict";
    // Loading 
    $(".animsition").animsition({
            inClass: "fade-in"
            , outClass: "fade-out"
            , inDuration: 300
            , outDuration: 300
            , linkElement: ".animsition-link"
            , loading: !0
            , loadingParentElement: "body"
            , loadingClass: "animsition-loading"
            , unSupportCss: ["animation-duration", "-webkit-animation-duration", "-o-animation-duration"]
            , overlay: !1
            , overlayClass: "animsition-overlay-slide"
            , overlayParentElement: "body"
        })
        , // Carousel
        $(".main-slider").owlCarousel({
            items: 1
            , loop: !1
            , center: !0
            , margin: 10
            , autoplayHoverPause: !0
            , dots: !1
            , nav: !1
        })
        , // Tooltips
        $('[data-toggle="tooltip"]').tooltip(), $().button("toggle")
        , // Add image via data attr
        $(".bg-image").css("background", function () {
            var a = "url(" + $(this).data("image-src") + ") no-repeat center center";
            return a
        }), $(".bg-image").css("background-size", "cover")
        , // Navigation
        $(".navbar-toggle").on("click", function (a) {
            $(this).toggleClass("open"), $("#navigation").slideToggle(400)
        })
        , $(".navigation-menu>li").slice(-1).addClass("last-elements"), $('.navigation-menu li.has-submenu a[href="#"]').on("click", function (a) {
            $(window).width() < 987 && (a.preventDefault(), $(this).parent("li").toggleClass("open").find(".submenu:first").toggleClass("open"))
        })
        , $(function () {
            //caches a jQuery object containing the header element
            var header = $(".header");
            $(window).scroll(function () {
                var scroll = $(window).scrollTop();
                if (scroll >= 80) {
                    header.addClass("shadow");
                }
                else {
                    header.removeClass("shadow");
                }
            });
        });
});