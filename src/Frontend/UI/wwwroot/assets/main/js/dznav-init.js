var body = $('body');
	
function dzSettings({themeFullColor_value,themeLayout_value,headerOption_value,backgroundColor_value,themeVersion_value}) {
	
	this.themeFullColor_value = themeFullColor_value || "color_1";
	this.themeLayout_value = themeLayout_value || "wide-layout";
	this.headerOption_value = headerOption_value || "sticky-header";
	this.backgroundColor_value = backgroundColor_value || "color_1";
	this.themeVersion_value = themeVersion_value || "light";

	this.manageLayout();
	this.managePrimaryColor();
	this.manageHeaderOption();
	this.manageBackgroundColorOption();
	this.manageThemeOption();
}

dzSettings.prototype.manageBackgroundColorOption = function() {
	switch(this.backgroundColor_value) {
		case "color_0": 
			body.attr("data-body-bg", "color_0");
			break;					
		case "color_1": 
			body.attr("data-body-bg", "color_1");
			 break;
		case "color_2": 
			body.attr("data-body-bg", "color_2");
			break;
		case "color_3": 
			body.attr("data-body-bg", "color_3");
			break;
		case "color_4": 
			body.attr("data-body-bg", "color_4");
			break;
		case "color_5": 
			body.attr("data-body-bg", "color_5");
			break;
		case "color_6": 
			body.attr("data-body-bg", "color_6");
			break;	
		case "color_7": 
			body.attr("data-body-bg", "color_7");
			break;
		default:
			body.attr("data-body-bg", "color_0");
	}
}

dzSettings.prototype.managePrimaryColor = function() {
	switch(this.themeFullColor_value) {
		case "color_1": 
			body.attr("data-color", "color_1");
			 break;
		case "color_2": 
			body.attr("data-color", "color_2");
			break;
		case "color_3": 
			body.attr("data-color", "color_3");
			break;
		case "color_4": 
			body.attr("data-color", "color_4");
			break;
		case "color_5": 
			body.attr("data-color", "color_5");
			break;
		case "color_6": 
			body.attr("data-color", "color_6");
			break;	
		case "color_7": 
			body.attr("data-color", "color_7");
			break;
		default:
			body.attr("data-color", "color_1");
	}
}
dzSettings.prototype.manageLayout = function() {
	switch(this.themeLayout_value){
		case "wide-layout": 
			body.attr("data-layout", "wide-layout");
			 break;
		case "boxed": 
			body.attr("data-layout", "boxed");
			break;
		case "frame": 
			body.attr("data-layout", "frame");
			break;
		default:
			body.attr("data-layout", "wide-layout");
	}
}
dzSettings.prototype.manageHeaderOption = function() {
	switch(this.headerOption_value){
		case "sticky-header": 
			body.attr("data-headerposition", "sticky-header");
			 break;
		case "sticky-no": 
			body.attr("data-headerposition", "sticky-no");
			break;
		default:
			body.attr("data-headerposition", "sticky-header");
	}
}
dzSettings.prototype.manageThemeOption = function() {
	switch(this.themeVersion_value){
		case "light": 
			body.attr("data-theme-version", "light");
			 break;
		case "dark": 
			body.attr("data-theme-version", "dark");
			break;
		default:
			body.attr("data-theme-version", "light");
	}
}

"use strict"
var dzSettingsOptions = {};

(function($) {

	"use strict"
	dzSettingsOptions = {
		themeFullColor_value: "color_1",
		themeLayout_value: "wide-layout",
		headerOption_value: "sticky-header",
		backgroundColor_value: "color_1",
		themeVersion_value: "light",
	};
	
	new dzSettings(dzSettingsOptions); 
	
})(jQuery);