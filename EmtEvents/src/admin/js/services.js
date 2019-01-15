var errorTitle = window.localization.error ;
$(document).ready(()=>{
    
   

    $(document).on("click",".delete-service",function(event){
        event.preventDefault();
        var $this = $(this);
        var dataurl = $this.data('url');

        $Confirm({},function(result){
            if (result.value) {
                $.ajax({
                    url: dataurl ,
                    type: 'Get',
                    dataType: "json",  
                    data: {}
                })
                .done(function(data){
                    if(data.success){
                        $notification.success("",window.localization.deleted_successfully , 2000, "fa fa-check");
                        $this.parent().parent().parent().remove();
                    }else{ 
                        var errors = data.errors;
                        $notification.error("<strong>"+errors[0].key+"</strong>", "<span>"+errors[0].value[0]+"</span>", 2000, "fa fa-exclamation-circle");
                    }
  
                 }
            ) .fail(function (jqXHR, Status) {
                $notification.error(errorTitle, jqXHR.statusText, 2000, "fa fa-exclamation-circle");
            })  
            }
        })
    })

    $(document).on("click",".toggle_publish",function(event){
        event.preventDefault();
        var $this = $(this);
        var dataurl = $this.data('url');
        var unpublished = $this.data('unpublished') || "unpublished";
        var published = $this.data('published') || "published";
        var $tr  = $this.parents("tr");
        $this.find('i').removeClass().addClass("fa fa-spinner fa-pulse");

        $.ajax({
            url: dataurl,
            type: 'GET',
            dataType: "json",
            data: {}
        }) 
        .done(function (data) {
            var title = $tr.find(".ser-title");
             if($this.hasClass('unpublished')){
                title.attr("href",title.attr("data-href")).addClass("underline");
             }else{
                title.attr("data-href",title.attr("href")).removeAttr("href").removeClass("underline");
             }
            if(data.success){
                togglePublishBtn($this , true , published ,unpublished)
            }else{
                var errors = data.errors;
                $notification.error("<strong>"+errors[0].key+"</strong>", "<span>"+errors[0].value[0]+"</span>", 2000, "fa fa-exclamation-circle");
                togglePublishBtn($this , false ,published ,unpublished);
            }
        })
        .fail(function (jqXHR, Status) {
            $notification.error(errorTitle, jqXHR.statusText, 2000, "fa fa-exclamation-circle");
            togglePublishBtn($this , false, published ,unpublished);
        });
    })

});