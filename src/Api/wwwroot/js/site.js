var map;
var markerArray = [];
var markerCluster;

function initMap() {

  map = new google.maps.Map(document.getElementById("map"), {
    center: { lat: -19.9023386, lng: -44.1041377 },
    zoom: 10,
  });

  $.getJSON("/maps/locations.json", function(data)
  {
    markerCluster = new MarkerClusterer(map, [], {
      imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m'
    });
  
    displayMarkers(data);

  });
}

function displayMarkers(data) 
{
  var bounds = new google.maps.LatLngBounds();

  $.each(data, function(key,data)
    {
      var myLatLng = new google.maps.LatLng(data.Longitude, data.Latitude);
      
      createMarker(myLatLng);

      bounds.extend(myLatLng);

      map.fitBounds(bounds);

    });
}

function createMarker(latlng)
{
  var marker = new google.maps.Marker({
    map: map,
    position: latlng,
  });

  markerArray.push(marker);

  markerCluster.addMarker(marker);
}
