$(window).on('load',function(){
    
//////////////
//flexslider//
//////////////
	if ($().flexslider) {
		//Team Slider Shortcode
		jQuery('.flexslider.team-slider').flexslider({
			slideshow: false,
            directionNav: false,
			manualControls: ".flex-control-nav-1 li",
		});
		
		var $introSlider = $(".page_slider .flexslider");
		$introSlider.each(function(index){
			var $currentSlider = $(this);
			var data = $currentSlider.data();
			var nav = (data.nav !== 'undefined') ? data.nav : true;
			var dots = (data.dots !== 'undefined') ? data.dots : true;
			var speed = (data.speed !== 'undefined') ? data.speed : 7000;

			$currentSlider.flexslider({
				animation: "fade",
				pauseOnHover: true, 
				useCSS: true,
				controlNav: dots,   
				directionNav: nav,
				prevText: "",
				nextText: "",
				smoothHeight: false,
				slideshowSpeed:speed,
				animationSpeed:600,
				start: function( slider ) {
					slider.find('.intro_layers').children().css({'visibility': 'hidden'});
					slider.find('.flex-active-slide .intro_layers').children().each(function(index){
						var self = $(this);
						var animationClass = !self.data('animation') ? 'fadeInDown' : self.data('animation');
						setTimeout(function(){
							self.addClass("animated "+animationClass);
						}, index*500);
					});
				},
				after :function( slider ){
					slider.find('.flex-active-slide .intro_layers').children().each(function(index){
						var self = $(this);
						var animationClass = !self.data('animation') ? 'fadeInDown' : self.data('animation');
						setTimeout(function(){
							self.addClass("animated "+animationClass);
						}, index*500);
					});
				},
				end :function( slider ){
					slider.find('.intro_layers').children().each(function() {
						var self = $(this);
						var animationClass = !self.data('animation') ? 'fadeInDown' : self.data('animation');
						self.removeClass('animated ' + animationClass).css({'visibility': 'hidden'});
							// $(this).attr('class', '');
					});
				},

			})
			//wrapping nav with container - uncomment if need
			// .find('.flex-control-nav')
			// .wrap('<div class="container nav-container"/>')
		}); //.page_slider flex slider

		$(".flexslider").each(function(index){
			var $currentSlider = $(this);
			//exit if intro slider already activated 
			if ($currentSlider.find('.flex-active-slide').length) {
				return;
			}
			$currentSlider.flexslider({
				animation: "fade",
				useCSS: true,
				controlNav: true,   
				directionNav: false,
				prevText: "",
				nextText: "",
				smoothHeight: false,
				slideshowSpeed:5000,
				animationSpeed:800,
			})
		});
	}


	////////////////
	//owl carousel//
	////////////////
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
				filters = data.filters ? data.filters : false;

			 

			$carousel.owlCarousel({
				loop: loop,
				margin: margin,
				nav: nav,
				autoplay: autoplay,
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