// [==============================================================]
// [======================  product Manager ======================]
// [==============================================================]
const $productManage = {

    notify: null,
    AddToCart(id) {
        $notification.success("", "The product has been added to your cart");

        //-- AddToCart 
    },


    AddToCompare(sku, link, el) {
        $el = $(el);
        var clist = [];

        if (localStorage.getItem('comparelist') === null) {
            clist.push(sku)
            localStorage.setItem('comparelist', JSON.stringify(clist));
            $(el).addClass('inlist').tooltip('dispose');
        } else {
            clist = JSON.parse(localStorage.getItem('comparelist'));
            if (clist.length < 3) {
                if (clist.indexOf(sku) < 0) {
                    clist.push(sku)
                    localStorage.setItem('comparelist', JSON.stringify(clist));
                    if ($('body').has('div[data-notify].alert-success').length > 0) {
                        this.notify.close();
                    }
                    this.notify = $notification.success("", `The product has been added to your <a href='${link}?products=${encodeURIComponent(clist.join())}'>product comparison</a>`, 15000);
                }
                $(el).addClass('inlist').tooltip('dispose');
            } else {
                if ($('body').has('div[data-notify].alert-warning').length > 0) {
                    this.notify.close();
                }
                this.notify = $notification.warning("Opps", `you already have three products to <a href='${link}?products=${encodeURIComponent(clist.join())}'>compare list</a>`, 150000);
            }
        }
        //-- AddToCompare 
    },
    RemoveFromCompare(sku ,link ,event){
        event.preventDefault();
        if (localStorage.getItem('comparelist') != null) {
            var clist = JSON.parse(localStorage.getItem('comparelist'));
                clist = clist.filter(e => e !== sku ) 
                localStorage.setItem('comparelist', JSON.stringify(clist));
        }
         window.location.href = window.location.origin  +  link;
    },
    AddToWhitelist(id) {



        $notification.warning("", "you must log in first");

        //-- AddToWhitelist 
    } 


}