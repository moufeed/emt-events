
jQuery.validator.setDefaults({
    errorElement: 'span',
    errorPlacement: function (error, element) {
        error.addClass('invalid-feedback');
        element.closest('.form-group').append(error);
    },
    highlight: function (element, errorClass, validClass) {
        $(element).addClass('is-invalid');
    }, 
    unhighlight: function (element, errorClass, validClass) {
        $(element).removeClass('is-invalid');
    }
});

if($('#contact_form').length){
    $('#contact_form').validate( 
        {
             
            rules: { 
                Name: {
                    required: true,
                    minlength: 2
                },
               
                Email:{
                    required: true, 
                    email: true
                },
                Message: {
                    required: true, 
                    minlength: 4
                },
            },
           
            submitHandler: function (form) {
                 
                var $form = $(form);
                    $form.find('.lds-spinner').removeClass('d-none');
                    $form.find('.btnsend').attr('disabled' ,"disabled");
                    $form.valid()
                    var url = $form.attr('action');
                    var message ={};
                    data = $form.serializeArray();
                    $.each(data,function(key,val){
                        message[val.name] = val.value;
                    })
                    
                    $.ajax({  
                        type: 'POST',
                        url: url,
                        data: message,  
                    })
                    .done(function (data) { 
                            if(data.success){
                                $form[0].reset();
                                $form.find('.lds-spinner').addClass('d-none');
                                $form.find('.btnsend').removeAttr('disabled' );
                                $('#ContactModel').modal('show');
                                $('#ContactModel').on('shown.bs.modal', function (e) {
                                    var modal = $(this);
                                        modal.find('.customer_name').text(message['Name']);
                                  })
                            }
                    })
                    .fail(function (jqXHR, Status) {
                            $form.find('.lds-spinner').addClass('d-none');
                            $form.find('.btnsend').removeAttr('disabled' );
                    });
    
                    return false;
            },
        }
    );
} 
