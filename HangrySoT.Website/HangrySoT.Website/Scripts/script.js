//Collect loaction in lat and lon
navigator.geolocation.getCurrentPosition(foundLocation, noLocation);


//Set visability
  //document.getElementById("loadingScreen").style.display = "none";

  function loadingFunct() {
      document.getElementById("mainScreen").style.display = "none";
      document.getElementById("loadingScreen").style.display = "block";
  }