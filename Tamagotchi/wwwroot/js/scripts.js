function createPet(petName) {
  $.ajax({
    type: 'GET',
    data: { name: petName },
    dataType: 'json',
    contentType: 'application/json',
    url: '/Home/CreatePet',
    success: function (data) {
      console.log("Success!");
      console.log(data);
      //displayPetData();
    },
    error: function(error) {
      console.log("Error, not working: " + JSON.stringify(error));
    }
  });
}

function displayPetData() {
  $.ajax({
    type: 'GET',
    url: '/Home/DisplayPetData',
    success: function (result) {
      console.log("Success!");
      $(".grid-container").append("<div>This is a new div!</div>");
    },
    error: function(error) {
      console.log("Error, not appending: " + JSON.stringify(error));
    }
  });
}

function feedPet() {

}

$(document).ready(function() {
  $("#add-pet").click(function() {
    var name = $("#name").val();
    createPet(name);
  });

  $("#feed-pet").click(function() {
    feedPet();
  });
});
