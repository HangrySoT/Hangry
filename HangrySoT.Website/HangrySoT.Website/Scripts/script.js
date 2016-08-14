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

//Set visability
  document.getElementById("loadingScreen").style.display = "none";

  function loadingFunct() {
      document.getElementById("mainScreen").style.display = "none";
      document.getElementById("loadingScreen").style.display = "block";
  }