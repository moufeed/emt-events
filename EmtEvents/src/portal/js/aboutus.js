$(document).ready(function(){
    if ($().owlCarousel) { 
		$('.owl-carousel').each(function() {
			var $carousel = $(this);
			$carousel.find('> *').each(function (i) {
				$(this).attr('data-index', i);
			});
			var data = $carousel.data();

			var loop = data.loop ? data.loop : false,
				margin = (data.margin || data.margin === 0) ? data.margin : 30,
				nav = data.nav ? data.nav : false,
				navPrev = data.navPrev ? data.navPrev : '<i class="fa fa-angle-left">',
				navNext = data.navNext ? data.navNext : '<i class="fa fa-angle-right">',
				dots = data.dots ? data.dots : false,
				themeClass = data.themeclass ? data.themeclass : 'owl-theme',
				center = data.center ? data.center : false,
				items = data.items ? data.items : 4,
				autoplay = data.autoplay ? data.autoplay : true,
				responsiveXs = data.responsiveXs ? data.responsiveXs : 1,
				responsiveSm = data.responsiveSm ? data.responsiveSm : 2,
				responsiveMd = data.responsiveMd ? data.responsiveMd : 3,
				responsiveLg = data.responsiveLg ? data.responsiveLg : 4,
				draggable = (data.draggable === false) ? data.draggable : true,
				syncedClass = (data.syncedClass) ? data.syncedClass : false,
                hoverPause = (data.pause) ? data.pause : true,
				autoplayTimeout = (data.autoplaytimeout) ? data.autoplaytimeout : 3000,
				filters = data.filters ? data.filters : false;

			 

		    $carousel.owlCarousel({
		        autoplay: autoplay,
		        autoplayTimeout: autoplayTimeout,
		        autoplayHoverPause: hoverPause,
				loop: loop,
				margin: margin,
				nav: nav,
				dots: dots,
				themeClass: themeClass,
				center: center,
				navText: [navPrev,navNext],
				mouseDrag: draggable,
				touchDrag: draggable,
				items: items,
				responsive: {
					0:{
						items: responsiveXs
					},
					767:{
						items: responsiveSm
					},
					992:{
						items: responsiveMd
					},
					1200:{
						items: responsiveLg
					}
				},
			})
			.addClass(themeClass);
			if(center) {
				$carousel.addClass('owl-center');
			}

			$(window).on('resize', function() {
				$carousel.trigger('refresh.owl.carousel');
			});

			//topline two synced carousels
			if($carousel.hasClass('owl-news-slider-items') && syncedClass) {
				$carousel.on('changed.owl.carousel', function(e) {
					var indexTo = loop ? e.item.index+1 : e.item.index;
					$(syncedClass).trigger('to.owl.carousel', [indexTo]);
				})
			}


		});


	} //eof owl-carousel
})