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
  
jQuery('#module-accounts .accounts-data-li').each(function(index, account) { 
	let $account = jQuery(account);
	accounts.push({
		accountId: account.id,
		accountName: $account.find('.accountName')[0].innerHTML,
		accountBalance: $account.find('.balance')[0].innerHTML.substring(1)
	});
});

downloadObjectAsJson(accounts, `mint_scrape_${new Date().getTime()}`);
