start chrome.exe -new-window "https://accounts.intuit.com/index.html?offering_id=Intuit.ifs.mint&namespace_id=50000026&redirect_url=https%%3A%%2F%%2Fmint.intuit.com%%2Foverview.event%%3Futm_medium%%3Ddirect%%26cta%%3Dnav_login_dropdown"
timeout /T 30 /nobreak >nul
taskkill /IM chrome.exe /FI "WINDOWTITLE eq Mint*"