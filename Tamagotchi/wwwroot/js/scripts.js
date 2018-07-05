var seconds = 0;

function timer() {
  console.log(seconds++);
  if (seconds % 3 == 0) {
    decay();
  }
  setTimeout(function() { timer(); }, 1000);
}

function createPet(petName) {
  $.ajax({
    type: 'GET',
    data: { name: petName },
    dataType: 'json',
    contentType: 'application/json',
    url: '/Home/CreatePet',
    success: function (data) {
      console.log(data);
      displayPetData(data.id);
    },
    error: function(error) {
      console.log("Error, not working: " + JSON.stringify(error));
    }
  });
}

function displayPetData(id) {
  $.ajax({
    type: 'GET',
    data: { id: id },
    url: '/Home/DisplayPetData',
    success: function (result) {
      console.log("Appended new pet");
      $(".grid-container").append(result);
    },
    error: function(error) {
      console.log("Error, not appending: " + JSON.stringify(error));
    }
  });
}

function feedPet(id) {
  $.ajax({
    type: 'GET',
    data: { id: id },
    dataType: 'json',
    contentType: 'application/json',
    url: '/Home/AddFood',
    success: function (data) {
      console.log(data);
      updatePetData(data);
    },
    error: function(error) {
      console.log("Error, not working: " + JSON.stringify(error));
    }
  });
}

function playPet(id) {
  $.ajax({
    type: 'GET',
    data: { id: id },
    dataType: 'json',
    contentType: 'application/json',
    url: '/Home/AddAttention',
    success: function (data) {
      console.log(data);
      updatePetData(data);
    },
    error: function(error) {
      console.log("Error, not working: " + JSON.stringify(error));
    }
  });
}

function restPet(id) {
  $.ajax({
    type: 'GET',
    data: { id: id },
    dataType: 'json',
    contentType: 'application/json',
    url: '/Home/AddRest',
    success: function (data) {
      console.log(data);
      updatePetData(data);
    },
    error: function(error) {
      console.log("Error, not working: " + JSON.stringify(error));
    }
  });
}

function decay() {
  $.ajax({
    type: 'GET',
    url: '/Home/Decay',
    success: function (result) {
      console.log("Success");
      $(".grid-container").html(result);
    }
  });
}

function updatePetData(data) {
  $("#pet-hunger-" + data.id).text(data.food);
  $("#pet-happiness-" + data.id).text(data.attention);
  $("#pet-energy-" + data.id).text(data.rest);
}

$(document).ready(function() {
  timer();

  $("#add-pet").click(function() {
    var name = $("#name").val();
    createPet(name);
  });

  $(document).on("click", ".feed-pet", function() {
    var id = $(this).parents().parents(".grid-item").attr("id");
    feedPet(id);
  });

  $(document).on("click", ".play-pet", function() {
    var id = $(this).parents().parents(".grid-item").attr("id");
    playPet(id);
  });

  $(document).on("click", ".rest-pet", function() {
    var id = $(this).parents().parents(".grid-item").attr("id");
    restPet(id);
  });
});
