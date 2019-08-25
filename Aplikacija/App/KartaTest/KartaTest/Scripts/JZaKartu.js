$(document).ready(function () {
    $("#kontenjer").addClass("container-fluid body-content");
    $("#kontenjer").removeClass("container body-content");
});

var map;
var geoJSON;
var request;
var gettingData = false;
var openWeatherMapKey = "af8fb6bdc62c7991812b3da96e86fc5d"
var GraniceHrvatska = {
    north: 46.555029,
    south: 42.1765993,
    west: 13.2104814,
    east: 19.4470842,
};
function initialize() {
    var mapOptions = {
        zoom: 9,
        center: new google.maps.LatLng(45.475, 16.78194),
        restriction: {
            latLngBounds: GraniceHrvatska,
            strictBounds: false,
        },
        minZoom: 8,
        maxZoom: 12
    };
    map = new google.maps.Map(document.getElementById("mapCanvas"),
        mapOptions);
    // Add interaction listeners to make weather requests
    google.maps.event.addListener(map, 'idle', checkIfDataRequested);
    // Sets up and populates the info window with details
    map.data.addListener('click', function (event) {
        infowindow.setContent(
            "<img src=" + event.feature.getProperty("icon") + ">"
            + "<br /><strong>" + event.feature.getProperty("city") + "</strong>"
            + "<br />" + event.feature.getProperty("temperature") + "&deg;C"
            + "<br />" + event.feature.getProperty("weather")
        );
        infowindow.setOptions({
            position: {
                lat: event.latLng.lat(),
                lng: event.latLng.lng()
            },
            pixelOffset: {
                width: 0,
                height: -15
            }
        });
        infowindow.open(map);
    });
}
var checkIfDataRequested = function () {
    // Stop extra requests being sent
    while (gettingData === true) {
        request.abort();
        gettingData = false;
    }
    getCoords();
};
// Get the coordinates from the Map bounds
var getCoords = function () {
    var bounds = map.getBounds();
    var NE = bounds.getNorthEast();
    var SW = bounds.getSouthWest();
    getWeather(NE.lat(), NE.lng(), SW.lat(), SW.lng());
};
// Make the weather request
var getWeather = function (northLat, eastLng, southLat, westLng) {
    gettingData = true;
    var requestString = "https://api.openweathermap.org/data/2.5/box/city?bbox="
        + westLng + "," + northLat + "," //left top
        + eastLng + "," + southLat + "," //right bottom
        + map.getZoom()
        + "&cluster=yes&format=json&lang=hr"
        + "&APPID=" + openWeatherMapKey;
    request = new XMLHttpRequest();
    request.onload = proccessResults;
    request.open("get", requestString, true);
    request.send();
};
// Take the JSON results and proccess them
var proccessResults = function () {
    console.log(this);
    var results = JSON.parse(this.responseText);
    if (results.list.length > 0) {
        resetData();
        for (var i = 0; i < results.list.length; i++) {
            geoJSON.features.push(jsonToGeoJson(results.list[i]));
        }
        drawIcons(geoJSON);
    }
};
var infowindow = new google.maps.InfoWindow();
// For each result that comes back, convert the data to geoJSON
var jsonToGeoJson = function (weatherItem) {
    var feature = {
        type: "Feature",
        properties: {
            city: weatherItem.name,
            weather: weatherItem.weather[0].description,
            temperature: weatherItem.main.temp,
            min: weatherItem.main.temp_min,
            max: weatherItem.main.temp_max,
            humidity: weatherItem.main.humidity,
            pressure: weatherItem.main.pressure,
            windSpeed: weatherItem.wind.speed,
            windDegrees: weatherItem.wind.deg,
            windGust: weatherItem.wind.gust,
            icon: "http://openweathermap.org/img/w/"
                + weatherItem.weather[0].icon + ".png",
            coordinates: [weatherItem.coord.Lon, weatherItem.coord.Lat]
        },
        geometry: {
            type: "Point",
            coordinates: [weatherItem.coord.Lon, weatherItem.coord.Lat]
        }
    };
    // Set the custom marker icon
    map.data.setStyle(function (feature) {
        return {
            icon: {
                url: feature.getProperty('icon'),
                anchor: new google.maps.Point(50, 50)
            }
        };
    });
    // returns object
    return feature;
};
// Add the markers to the map
var drawIcons = function (weather) {
    map.data.addGeoJson(geoJSON);
    // Set the flag to finished
    gettingData = false;
};
// Clear data layer and geoJSON
var resetData = function () {
    geoJSON = {
        type: "FeatureCollection",
        features: []
    };
    map.data.forEach(function (feature) {
        map.data.remove(feature);
    });
};
google.maps.event.addDomListener(window, 'load', initialize);