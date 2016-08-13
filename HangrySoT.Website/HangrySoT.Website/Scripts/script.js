//Collect loaction in lat and lon
navigator.geolocation.getCurrentPosition(foundLocation, noLocation);

  function foundLocation(position)
  {
    var lat = position.coords.latitude;
    var lon = position.coords.longitude;
    alert('Found location: ' + lat + ', ' + lon);
  }
  function noLocation()
 {
    alert('Could not find location');
  }

//Go to Loading Screen
