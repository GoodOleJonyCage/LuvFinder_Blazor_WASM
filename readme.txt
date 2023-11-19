
1) To get around the Invalid Cert. error in browsers so that the Blazor WASM can successfully consume the Web API project, 
type the following command in chrome to turn off checking for valid certificates in chrome.


For localhost only (Chrome 119 and above)
	Simply visit this link in your Chrome:

	chrome://flags/#temporary-unexpire-flags-m118
	You should see highlighted text saying:

	Temporarily unexpire flags that expired as of M118. These flags will be removed soon. – Mac, Windows, Linux, ChromeOS, Android, Fuchsia, Lacros

	Click Enable Then relauch Chrome.

For localhost only (Chrome 118 and below)
	Simply visit this link in your Chrome:

	chrome://flags/#allow-insecure-localhost
	You should see highlighted text saying:

	Allow invalid certificates for resources loaded from localhost

	Click Enable.

Taken from the following : 

https://stackoverflow.com/questions/7580508/getting-chrome-to-accept-self-signed-localhost-certificate/42917227#42917227 

 2) Autocomplete and Date controls are from MudBlazor. 

 https://www.mudblazor.com/getting-started/installation#online-playground