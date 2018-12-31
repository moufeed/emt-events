// [==============================================================]
// [======================  generate URl   =======================]
// [==============================================================]
const generateUrl = function(token){
    var url = window.location.origin + window.location.pathname;   
    let sortPage = $("#sortPage").val();
    let pageSize = $("#pageSize").val();
    url += `?pagesize=${pageSize}`;
    url += (sortPage.length > 0) ? `&${sortPage}` : '';
    let brands = $('.block [name="brands[]"]:checked').map(function (_, el) {
        return $(el).val();
    }).get();
    url += (brands.length > 0) ? `&brandid=${brands.join()}` : '';
    if(token){
        url += `&pagenumber=${encodeURIComponent(token)}`;
    }
    window.location.href = url;
}

  
 
// [==============================================================]
// [======================  calculator   =========================]
// [==============================================================]


const calculator = {
    increase(num, max) {
        return (num < max) ? ++num : num;
    },
    decrease(num) {
        return (num > 0) ? --num : num;
    }
}





// [==============================================================]
// [====================== shopping list  ========================]
// [==============================================================]
//  hide shopinglist when click out side
$(document).mouseup((e) => {
    let container = $("#shopinglist");
    if (container.hasClass('show') && !container.is(e.target) && container.has(e.target).length === 0)
        container.removeClass('show');
});

$(document).ready(() => {
    $('.shopinglist-toggle').on('click', () => $('#shopinglist').toggleClass('show'));

    $('[data-toggle="tooltip"]').tooltip();


    // [==============================================================]
    // [====================== collapse menu  ========================]
    // [==============================================================]


    $('.item-has-children').children('a').on('click', function (event) {
        event.preventDefault();
        $(this).toggleClass('submenu-open').next('.sublist')
            .slideToggle(200).end().parent('.item-has-children')
            .siblings('.item-has-children').children('a')
            .removeClass('submenu-open').next('.sublist').slideUp(200);
    });


    // [==============================================================]
    // [====================== change view  ==========================]
    // [==============================================================]

    $('.view-selector-grid').click(function () {
        $(this).addClass('active');
        $('.view-selector-list').removeClass('active');
        $('.products-view').removeClass('list-view').addClass('grid-view');
        localStorage.setItem('viewType', 'grid-view');
    })
    $('.view-selector-list').click(function () {
        $(this).addClass('active');
        $('.view-selector-grid').removeClass('active');
        $('.products-view').removeClass('grid-view').addClass('list-view');
        localStorage.setItem('viewType', 'list-view');
    })


    // [==============================================================]
    // [======================  share bar   ==========================]
    // [==============================================================]

    $('.sharebtn').click(function (event) {
        event.preventDefault();
        let width = 650,
            height = 450,
            windowSRC = $(this).attr('href'),
            windowTitle = $(this).parents('ul').data('window-title');
        window.open(
            windowSRC, windowTitle,
            `menubar=no,toolbar=no,resizable=yes,scrollbars=yes,width=${width},height=${height},top=${(screen.height/2-height/2)},left=${(screen.width/2-width/2)}`
        );
    });



    //-----------------------------------------------------------------
    // [==============================================================]
    // [======================  Custom Scrollbar   ===================]
    // [==============================================================]
    

    $('[data-scroll]').each((index,el)=>{
        var datascroll = $(el).data("scroll");
        
        $(el).mCustomScrollbar( (typeof datascroll == 'object') ? datascroll : {} );
    })

    // [==============================================================]
    // [======================  sort bar   ==========================]
    // [==============================================================]
    $('.block [name="brands[]"] , .block [name="categories[]"] ,#sortPage ,#pageSize ').on('change',()=> generateUrl(false))

 
    //end
});  