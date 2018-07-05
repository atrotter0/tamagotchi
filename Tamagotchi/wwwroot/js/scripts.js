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
      $('#result1').html(data.name);
    },
    error: function(error) {
      console.log("Error, not working: " + JSON.stringify(error));
    }
  });
}

$(document).ready(function() {
  $("#add-pet").click(function() {
    var name = $("#name").val();
    createPet(name);
  });
});
