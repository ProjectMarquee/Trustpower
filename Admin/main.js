  //   $(function () {
  //     $('[data-toggle="popover"]').popover()
  // })

  // $('.popover-dismiss').popover({
  //   trigger: 'focus'
  // })
  $(document).ready(function () {
    $('[data-toggle="popover"]').popover({
      placement: 'top',
      html: true,
      title: 'Would you like to do? <a href="#" class="close" data-dismiss="alert">&times;</a>',      //Put HTML inside this 2 places 
      content: '<a type="button" class="btn btn-secondary btn-trustgray" data-dismiss="modal" href="#HOMEPAHE.html">Home</a> \n<div class="popover-space"></div>\n <a type="button" class="btn btn-secondary btn-trust" data-dismiss="modal" href="ApplicationBookingReview.html">Back to Application Booking</a>'
    });
    $(document).on("click", ".popover .close", function () {
      $(this).parents(".popover").popover('hide');
    });
  });