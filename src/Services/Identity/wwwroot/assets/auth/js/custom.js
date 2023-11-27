$(function(){



    
    
    
    
    
    
    
    
    
    
    




// mobile nav
const openBtn = document.querySelector("#nav-opn-btn");
const closeBtn = document.querySelector("#nav-cls-btn");
const offcanvasContainer = document.querySelector("#offcanvas-nav");

function openNav() {
  document.body.style.overflowY = "hidden";
  offcanvasContainer.classList.add("open");
}

function closeNav() {
  document.body.style.overflowY = "";
  offcanvasContainer.classList.remove("open");
}

openBtn.addEventListener("click", openNav);
closeBtn.addEventListener("click", closeNav);



  // back to top
  $(" .back-to-top i").click(function () {
    $("html,body").animate({
      scrollTop: 0,
    });
  });

  $(window).scroll(function () {
    var scrolling = $(this).scrollTop();

    if (scrolling > 50) {
      $(".menu-bg").addClass("nav-bg");
    } else {
      $(".menu-bg").removeClass("nav-bg");
    }

    var scrolling = $(this).scrollTop();
    if (scrolling > 20) {
      $(".back-to-top i").fadeIn(500);
    } else {
      $(".back-to-top i").fadeOut(500);
    }
  });






  
  $(window).on('load', function () {
    if ($(".shafull-container").length > 0) {
        var $grid = $('.shafull-container');
        $grid.shuffle({
            itemSelector: '.shaf-item',
            sizer: '.shaf-sizer'
        });
        /* reshuffle when user clicks a filter item */
        $('.shaf-filter li').on('click', function () {
            // set active class
            $('.shaf-filter li').removeClass('active');
            $(this).addClass('active');
            // get group name from clicked item
            var groupName = $(this).attr('data-group');
            // reshuffle grid
            $grid.shuffle('shuffle', groupName);
        });
    }
});





// profile dropdown 
const dropdownProfile=document.getElementsByClassName('click')
const allDropdown= document.getElementsByClassName("header-dropdown")
document.getElementsByTagName("html")[0].addEventListener("click",(event)=>{
  for(let i=0; i<allDropdown.length;i++){
     !event.target?.attributes?.["data-name"]?.value&&  allDropdown[i].classList.remove("active-dropdown")
  }
})
const toggleDropdown=(event)=>{
  console.log(event.target)
const openId = event.target.attributes["data-name"].value
for(let i=0;i<allDropdown.length;i++){
  if(allDropdown[i].attributes.id.value===openId){
    allDropdown[i].classList.toggle("active-dropdown")
  }
  else{
    allDropdown[i].classList.remove("active-dropdown")
  }
}
}

for(let i=0; i<dropdownProfile.length; i++){
  dropdownProfile[i].addEventListener("click",(event)=>toggleDropdown(event))


}








// map 




$('.slider-for').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
  arrows: false,
  fade: true,
  asNavFor: '.slider-nav',
  autoplay:true,
  autoplaySpeed:1500,
  speed:2000,
});
$('.slider-nav').slick({
  slidesToShow: 4,
  slidesToScroll: 1,
  asNavFor: '.slider-for',
  arrows: false,
  dots: false,
  centerMode: true,
  centerPadding:"0",
  focusOnSelect: true,
  speed:2000,


  responsive: [
    {
      breakpoint: 991,
      settings: {
        slidesToShow: 3,
      }
    },

    {
      breakpoint: 767,
      settings: {
        slidesToShow: 3,
      }
    }
  ]
});




  // featured-slick  

  

  
$('.featured-slick ').slick({
  infinite: true,
  slidesToShow: 3,
  slidesToScroll: 1,
  arrows:false,
  dots:true,
  autoplay:true,
  speed:"1500",
  autoplaySpeed:"1500",


  responsive: [
    {
      breakpoint: 991,
      settings: {
        slidesToShow: 2,
      }
    },

    {
      breakpoint: 767,
      settings: {
        slidesToShow: 1,
      }
    }
  ]

});


$('.news-slick ').slick({
  infinite: true,
  slidesToShow: 3,
  slidesToScroll: 1,
  arrows:false,
  dots:true,
  autoplay:true,
  speed:"1500",
  autoplaySpeed:"1500",

  responsive: [
    {
      breakpoint: 991,
      settings: {
        slidesToShow: 2,
      }
    },

    {
      breakpoint: 767,
      settings: {
        slidesToShow: 1,
      }
    }
  ]

});


//AOS Animation
AOS.init({
    duration: 1200,
    offset: 120,
    mobile: false,
    once: false,
});






new VenoBox({
  selector: '.my-video-links',
});





});


