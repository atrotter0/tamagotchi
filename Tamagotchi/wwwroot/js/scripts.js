var seconds = 0;

function startTimer() {
  if (petsCreated() && timerNotGoing()) runTimer();
}

function petsCreated() {
  return ($(".grid-item").length / 2) > 0;
}

function timerNotGoing() {
  return seconds <= 0;
}

function runTimer() {
  console.log(seconds++);
  if (seconds % 10 == 0) runPetDecay();

  setTimeout(function() { runTimer(); }, 1000);
}

function createPet(petName) {
  $.ajax({
    type: 'GET',
    data: { name: petName },
    dataType: 'json',
    contentType: 'application/json',
    url: '/Home/CreatePet',
    success: function (data) {
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
      updatePetData(data);
    },
    error: function(error) {
      console.log("Error, not working: " + JSON.stringify(error));
    }
  });
}

function runPetDecay() {
  $.ajax({
    type: 'GET',
    url: '/Home/Decay',
    success: function (result) {
      $(".grid-container").html(result);
    }
  });
}

function updatePetData(data) {
  $("#pet-hunger-" + data.id).text(data.food);
  $("#pet-happiness-" + data.id).text(data.attention);
  $("#pet-energy-" + data.id).text(data.rest);
}

function getId(element) {
  return $(element).parents().parents(".grid-item").attr("id");
}

function disableBtn(element) {
  $(element).prop("disabled", true);
}

function buryPet(id) {
  $.ajax({
    type: 'POST',
    data: { id: id },
    url: '/pet/bury/' + id,
    success: function (result) {
      console.log("Success!");
      $(".grid-container").append(result);
    },
    error: function(error) {
      console.log("Error, not appending: " + JSON.stringify(error));
    }
  });
}

$(document).ready(function() {
  startTimer();

  $("#add-pet").click(function(e) {
    e.preventDefault();

    var name = $("#name").val();
    createPet(name);
    setTimeout(function() { startTimer() }, 3000);
  });

  $(document).on("click", ".feed-pet", function() {
    var id = getId(this);
    feedPet(id);
    disableBtn(this);
  });

  $(document).on("click", ".play-pet", function() {
    var id = getId(this);
    playPet(id);
    disableBtn(this);
  });

  $(document).on("click", ".rest-pet", function() {
    var id = getId(this);
    restPet(id);
    disableBtn(this);
  });

  $(document).on("click", ".bury-pet", function() {
    var id = getId(this);
    buryPet(id);
  });
});
