
 $(document).ready(()=> {


// [==============================================================]
// [====================== related Products  =====================]
// [==============================================================]

  $("#relatedProducts").lightSlider({
    item:4,
    loop:false,
    slideMove:3,
    autoWidth:false,
    slideMargin:4,
    galleryMargin : 15,
    prevHtml : '&#xf100;',
    nextHtml :"&#xf101;",
    responsive : [
        {
            breakpoint:992,
            settings: {
                item:3,
                slideMove:1,
              }
        },
        {
            breakpoint:767,
            settings: {
                item:2,
                slideMove:2,
              }
        },
        {
            breakpoint:480,
            settings: {
                item:1,
                slideMove:1
              }
        } 
    ]
  })

// [==============================================================]
// [====================== product slider  =======================]
// [==============================================================]

  $("#productcarousel").lightSlider({
    gallery:true,
    item:1,
    loop:true,
    thumbItem:6,
    thumbMargin:4,
    slideMargin:0,
    responsive : [
      {
          breakpoint:992,
          settings: {
              item:1,
            }
      },
      {
          breakpoint:480,
          settings: {
              item:1,
              slideMove:1
            }
      } 
  ],
  onSliderLoad: function (el) {

    var firstImgHeight = 200,
        container = $(el),
        children = container.children();
    firstImgHeight = children.first().find('img').height();
    container.find('img').height(firstImgHeight);
    container.find('li').width('auto');
}
  });
 
// [==============================================================]
// [====================== product Quantity  =====================]
// [==============================================================]

    $('.quantity-wrapper').on('click',function(el){
      let input = $('.quantity_box #Quantity');
      let maxQty =  parseInt(input.data('max'));
      let qty = parseInt(input.val());
      if($(el.target).hasClass('pluse')){ 
          input.val(calculator.increase(qty,maxQty))
          if(qty ==  maxQty && $('body').find('div[data-notify]').length == 0) $notification.info("",`you can't add more than ${maxQty} items `);
      }
      else{
          input.val(calculator.decrease(qty))
          if(qty <=  1 && $('body').find('div[data-notify]').length == 0) $notification.info("",`you must add at least one item`);
      }
      
  })
  $('.quantity_box #Quantity').on('change',function(){
    let input = $(this);
    let maxQty =  parseInt(input.data('max'));
    let qty = parseInt(input.val());
    input.val( (qty > maxQty || isNaN(qty) )  ?  maxQty :  qty )
   
  })


// [==============================================================]
// [====================== review validation  ====================]
// [==============================================================]

  $("#reviewForm").validate({
    errorClass: "invalid-feedback is-invalid",
    validClass: "valid-feedback is-valid",
    rules: { 
    }
});


//--------------------------------------------
// end
 })

 