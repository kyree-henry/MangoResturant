(function($) {

	

	"use strict";

	

	//Hide Loading Box (Preloader)

	function handlePreloader() {

		if($('.preloader').length){

			$('.preloader').delay(200).fadeOut(500);

		}

	}

	

	

	//Update Header Style and Scroll to Top
	function headerStyle() {
		if($('.main-header').length){
			var windowpos = $(window).scrollTop();
			var siteHeader = $('.main-header');
			var scrollLink = $('.scroll-to-top');
			var scrollLink = $('.scroll-to-toped');
			
			var HeaderHight = $('.main-header').height();
			if (windowpos >= HeaderHight) {
				siteHeader.addClass('fixed-header');
				scrollLink.fadeIn(300);
			} else {
				siteHeader.removeClass('fixed-header');
				scrollLink.fadeOut(300);
			}
			
		}
	}


	

	headerStyle();

	

	

	//Submenu Dropdown Toggle

	if($('.main-header .navigation li.dropdown ul').length){

		$('.main-header .navigation li.dropdown').append('<div class="dropdown-btn"><span class="fa fa-angle-down"></span></div>');

		

		//Dropdown Button

		$('.main-header .navigation li.dropdown .dropdown-btn').on('click', function() {

			$(this).prev('ul').slideToggle(500);

		});

		

		//Disable dropdown parent link

		$('.navigation li.dropdown > a').on('click', function(e) {

			e.preventDefault();

		});

	}

	

	

	//Fixed Right Top Consultation Form Toggle

	if($('.main-header .outer-box .reservation-form-btn').length){

		//Show Form

		$('.main-header .outer-box .reservation-form-btn').on('click', function(e) {

			e.preventDefault();

			$('body').addClass('cosult-form-visible');

		});

		//Hide Form

		$('.consulting-form .inner-box .cross-icon,.form-back-drop').on('click', function(e) {

			e.preventDefault();

			$('body').removeClass('cosult-form-visible');

		});

	}

	

	//Add One Page nav

	if($('.scroll-nav').length) {

		$('.scroll-nav ul').onePageNav();

	}

	

	// Three Item Carousel

	if ($('.three-item-corousel').length) {

		$('.three-item-corousel').owlCarousel({

			loop:true,

			margin:30,

			nav:true,

			smartSpeed: 500,

			autoplay: 4000,

			navText: [ '<span class="fa fa-angle-left"></span>', '<span class="fa fa-angle-right"></span>' ],

			responsive:{

				0:{

					items:1

				},

				480:{

					items:1

				},

				600:{

					items:1

				},

				767:{

					items:2

				},

				800:{

					items:2

				},

				1024:{

					items:3

				}

			}

		});    		

	}

	

	

	// Sponsors Carousel

	if ($('.sponsors-carousel').length) {

		$('.sponsors-carousel').owlCarousel({

			loop:true,

			margin:0,

			nav:true,

			smartSpeed: 500,

			autoplay: 4000,

			navText: [ '<span class="fa fa-angle-left"></span>', '<span class="fa fa-angle-right"></span>' ],

			responsive:{

				0:{

					items:1

				},

				480:{

					items:2

				},

				600:{

					items:4

				},

				800:{

					items:5

				},

				1024:{

					items:6

				}

			}

		});    		

	}

	

	

	//Date Picker

	if($('.datepicker').length){

		$( '.datepicker' ).datepicker();

	}

	

	

	//Custom Seclect Box

	if($('.custom-select-box').length){

		$('.custom-select-box').selectmenu().selectmenu('menuWidget').addClass('overflow');

	}

	

	

	//Jquery Spinner / Quantity Spinner

	if($('.quantity-spinner').length){

		$("input.quantity-spinner").TouchSpin({

		  verticalbuttons: true

		});

	}

	

	

	//Price Range Slider

	if($('.price-range-slider').length){

		$( ".price-range-slider" ).slider({

			range: true,

			min: 0,

			max: 90,

			values: [ 8, 85 ],

			slide: function( event, ui ) {

			$( "input.property-amount" ).val( ui.values[ 0 ] + " - " + ui.values[ 1 ] );

			}

		});

		

		$( "input.property-amount" ).val( $( ".price-range-slider" ).slider( "values", 0 ) + " - $" + $( ".price-range-slider" ).slider( "values", 1 ) );	

	}

	

	

	//Tabs Box

	if($('.tabs-box').length){

		$('.tabs-box .tab-buttons .tab-btn').on('click', function(e) {

			e.preventDefault();

			var target = $($(this).attr('data-tab'));

			

			if ($(target).is(':visible')){

				return false;

			}else{

				target.parents('.tabs-box').find('.tab-buttons').find('.tab-btn').removeClass('active-btn');

				$(this).addClass('active-btn');

				target.parents('.tabs-box').find('.tabs-content').find('.tab').fadeOut(0);

				target.parents('.tabs-box').find('.tabs-content').find('.tab').removeClass('active-tab');

				$(target).fadeIn(300);

				$(target).addClass('active-tab');

			}

		});

	}

	

	

	//Single Item Carousel

	if ($('.single-item-carousel').length) {

		$('.single-item-carousel').owlCarousel({

			loop:true,

			margin:30,

			nav:true,

			smartSpeed: 700,

			autoplay: 5000,

			navText: [ '<span class="fa fa-angle-left"></span>', '<span class="fa fa-angle-right"></span>' ],

			responsive:{

				0:{

					items:1

				},

				480:{

					items:1

				},

				

				768:{

					items:1

				},

				

				800:{

					items:1

				},

				960:{

					items:1

				},

				1024:{

					items:1

				}

			}

		});    		

	}

	

	

	//Two Item Carousel

	if ($('.two-item-carousel').length) {

		$('.two-item-carousel').owlCarousel({

			loop:true,

			margin:60,

			nav:true,

			smartSpeed: 700,

			autoplay: 5000,

			navText: [ '<span class="fa fa-angle-left"></span>', '<span class="fa fa-angle-right"></span>' ],

			responsive:{

				0:{

					items:1

				},

				480:{

					items:1

				},

				600:{

					items:1

				},

				800:{

					items:2

				},

				1024:{

					items:2

				},

				1100:{

					items:2

				}

			}

		});    		

	}

	

	

	//Event Countdown Timer

	if($('.time-countdown').length){  

		$('.time-countdown').each(function() {

		var $this = $(this), finalDate = $(this).data('countdown');

		$this.countdown(finalDate, function(event) {

			var $this = $(this).html(event.strftime('' + '<div class="counter-column"><span class="count">%D</span>Days</div> ' + '<div class="counter-column"><span class="count">%H</span>Hours</div>  ' + '<div class="counter-column"><span class="count">%M</span>Minutes</div>  ' + '<div class="counter-column"><span class="count">%S</span>Seconds</div>'));

		});

	 });

	}

	

	

	//Typeit Text On Main Page

	if ($('.variable-text').length) {

		

		$('.variable-text').typeIt({

			 strings: ["shangrila <span class='theme_color'>Cafe</span> & Restaurant", "& Fast Food."],

			 speed: 150,

			 breakLines: true,

			 loop:true,

			 autoStart: true

		});	

	}

	

	

	//Jquery Spinner / Quantity Spinner

	if($('.quantity-spinner').length){

		$("input.quantity-spinner").TouchSpin({

		  verticalbuttons: true

		});

	}

	



	//Gallery Filters

	if($('.filter-list').length){

		$('.filter-list').mixItUp({});

	}

	

	

	//LightBox / Fancybox

	if($('.lightbox-image').length) {

		$('.lightbox-image').fancybox({

			openEffect  : 'fade',

			closeEffect : 'fade',

			helpers : {

				media : {}

			}

		});

	}

	

	

	//Contact Form Validation

	if($('#contact-form').length){

		$('#contact-form').validate({

			rules: {

				username: {

					required: true

				},

				email: {

					required: true,

					email:true

				},

				subject: {

					required: true,

				},

				message: {

					required: true

				}

			}

		});

	}

	

	

	// Scroll to a Specific Div

	if($('.scroll-to-target').length){

		$(".scroll-to-target").on('click', function() {

			var target = $(this).attr('data-target');

		   // animate

		   $('html, body').animate({

			   scrollTop: $(target).offset().top

			 }, 1000);

	

		});

	}

	

	

	// Elements Animation

	if($('.wow').length){

		var wow = new WOW(

		  {

			boxClass:     'wow',      // animated element css class (default is wow)

			animateClass: 'animated', // animation css class (default is animated)

			offset:       0,          // distance to the element when triggering the animation (default is 0)

			mobile:       false,       // trigger animations on mobile devices (default is true)

			live:         true       // act on asynchronously loaded content (default is true)

		  }

		);

		wow.init();

	}



/* ==========================================================================

   When document is Scrollig, do

   ========================================================================== */

	

	$(window).on('scroll', function() {

		headerStyle();

	});

	

/* ==========================================================================

   When document is loaded, do

   ========================================================================== */

	

	$(window).on('load', function() {

		handlePreloader();

	});	



})(window.jQuery);