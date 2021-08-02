  let map;
  function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
      center: { lat: -19.9023386, lng: -44.1041377 },
      zoom: 8,
    });
    
  }