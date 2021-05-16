/*
 *  Document   : frontend_contact.js
 *  Author     : Jabil UX Design
 *  Description: Custom JS code used in Frontend Contact Page
 */

var FrontendContact = function() {
    // Init Contact Map with Gmaps.js, for more examples you can check out https://hpneo.github.io/gmaps/
    var initContactMap = function(){
        new GMaps({
            div: '#js-map-contact',
            lat: 27.7395519,
            lng: -82.6840133,
            zoom: 15,
            disableDefaultUI: true,
            scrollwheel: false
        }).addMarkers([
            {lat: 27.7393001, lng: -82.6816245, title: 'Marker #1', animation: google.maps.Animation.DROP, infoWindow: {content: '<strong>Jabil IT</strong><br>3201 34th St. South, Heron Building<br>St. Petersburg, FL 33711<br>P: (727) 200-9809</strong>'}}
        ]);
    };

    return {
        init: function () {
            // Init Contact Map
            initContactMap();
        }
    };
}();

// Initialize when page loads
jQuery(function(){ FrontendContact.init(); });