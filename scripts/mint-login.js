// ==UserScript==
// @name         Mint Login
// @namespace    http://tampermonkey.net/
// @version      0.1
// @description  try to take over the world!
// @author       You
// @match        https://accounts.intuit.com/index.html?offering_id=Intuit.ifs.min*
// @grant        none
// ==/UserScript==

(function(jQuery) {
    'use strict';
    setTimeout(function() {
        jQuery('#ius-sign-in-submit-btn').click();
    }, 5000);
})(jQuery);