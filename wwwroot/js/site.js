'use strict';

var userAgent = navigator.userAgent;

var isIOS = /iP(hone|od|ad)/.test(userAgent);
var isIOS9 = false;

var isWindowsPC = /Windows NT/.test(userAgent);
var isWindows = /Windows Phone/.test(userAgent) || isWindowsPC;
var isWin10 = false;

var isAndroid = /Android/.test(userAgent) && (!isWindows);
var isMac = /Mac/.test(userAgent);
var isLinux = /Linux/.test(userAgent);

var isEdge = /Edge/.test(userAgent);
var isOpera = /OPR/.test(userAgent);
var isChrome = /Chrome/.test(userAgent) && !(isOpera || isEdge); // no opera
var isFirefox = /Firefox/.test(userAgent);

if(isIOS)
{
    var v = (navigator.appVersion).match(/OS (\d+)_(\d+)_?(\d+)?/);
    v = [parseInt(v[1], 10), parseInt(v[2], 10), parseInt(v[3] || 0, 10)];
    isIOS9 = v[0] >= 9;
}

if(isWindows) 
{
    try 
    {
        var index = 0;
        if(isWindowsPC) 
            index = userAgent.indexOf('Windows NT') + 11;
        else
            index = userAgent.indexOf('Windows Phone') + 14;

        if(index > 0) 
        {
            var v = '';
            for(i = 0; i < 10; i++) 
            {
                var c = userAgent[i + index];
                if(c >= '0' && c <= '9')
                    v += c;
                else
                    break;
            }

            isWin10 = (parseInt(v) >= 10);
        }
    } 
    catch(e) 
    {
    }
}

$(function() {
    
    $(document).delegate('*[data-toggle="lightbox"]', 'click', function(event) 
    {
        event.preventDefault();
        $(this).ekkoLightbox();
    });

    $("#copyclipboard").click(function () {
        var copyText = document.getElementById("schemeurl");
        copyText.select();
        document.execCommand("copy");
    });

    // Activate Tooltips & Popovers
    $('[data-toggle="tooltip"]').tooltip();
    $('[data-toggle="popover"]').popover();

    // Dismiss Popovers on next click
    $('.popover-dismiss').popover({
      trigger: 'focus'
    });

    // Bootstrap Fixed Header
    // Check to see if there is a bakcground class on loading
    if ($('.js-navbar-scroll').offset().top > 150) {
      $('.js-navbar-scroll').addClass('navbar-bg-onscroll');
    }

    // Check to add a background class on scrolling
    $(window).on('scroll', function() {
      var navbarOffset = $('.js-navbar-scroll').offset().top > 150;
      if(navbarOffset) {
        $('.js-navbar-scroll').addClass('navbar-bg-onscroll');
      }
      else {
        $('.js-navbar-scroll').removeClass('navbar-bg-onscroll');
        $('.js-navbar-scroll').addClass('navbar-bg-onscroll--fade');
      }
    });

    // Scroll to (Section)
    $('a[href*=#js-scroll-to-]:not([href=#js-scroll-to-])').on('click', function() {
      if (location.pathname.replace(/^\//, '') === this.pathname.replace(/^\//, '') && location.hostname === this.hostname) {
        var target = $(this.hash);
        target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
        if (target.length) {
          $('html,body').animate({
            scrollTop: target.offset().top
          }, 1000);
          return false;
        }
      }
    });

    window.cookieconsent.initialise({
      "palette": {
        "popup": {
          "background": "#014871"
        },
        "button": {
          "text": "#ffffff",
          "background": "#141125"
        }
      },
      "theme": "edgeless",
      "content": {
        "href": "/privacy ",
        "message": "This website uses cookies.",
        "target": ""
      }
    });

    /*
    if(isAndroid || isMac || isWin10)
    {
        $.smartbanner({
            title:"Heleus Core",
            author:"Marko Ludolph",
            appendToSelector:'html'
        });
        }
    */

    var debugMessage =  "isIOS: " + isIOS + "\n" +
                        "isIOS9: " + isIOS9  + "\n" +
                        "isWindows: " + isWindows  + "\n" +
                        "isWin10: " + isWin10  + "\n" +
                        "isMac: " + isMac  + "\n" +
                        "isAndroid: " + isAndroid  + "\n" +
                        "isLinux: " + isLinux  + "\n" +
                        "isEdge: " + isEdge  + "\n" +
                        "isOpera: " + isOpera  + "\n" +
                        "isChrome: " + isChrome  + "\n" +
                        "isFirefox: " + isFirefox  + "\n";
    //alert(debugMessage);
});
