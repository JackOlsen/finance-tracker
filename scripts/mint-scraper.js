// ==UserScript==
// @name         Mint Scrape
// @namespace    http://tampermonkey.net/
// @version      0.1
// @description  try to take over the world!
// @author       You
// @match        https://mint.intuit.com/overview.event*
// @grant        none
// ==/UserScript==

(function() {
    'use strict';

     function downloadObjectAsJson(exportObj, exportName){
         var dataStr = "data:text/json;charset=utf-8," + encodeURIComponent(JSON.stringify(exportObj));
         var downloadAnchorNode = document.createElement('a');
         downloadAnchorNode.setAttribute("href", dataStr);
         downloadAnchorNode.setAttribute("download", exportName + ".json");
         document.body.appendChild(downloadAnchorNode); // required for firefox
         downloadAnchorNode.click();
         downloadAnchorNode.remove();
     }

    var accounts = [];

    window.setTimeout(function() {
        jQuery('#module-accounts .accounts-data-li').each(function(index, account) {
            let $account = jQuery(account);
            accounts.push({
                accountId: account.id.substring(8),
                accountName: $account.find('.accountName')[0].innerHTML,
                accountBalance: $account.find('.balance')[0].innerHTML.replace('$', '').replace('-', '')
            });
        });

        downloadObjectAsJson(accounts, `mint_scrape_${new Date().getTime()}`);
    }, 15000);
})();