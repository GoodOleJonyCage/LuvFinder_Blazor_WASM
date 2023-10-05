
To get around the Invalid Cert. error in browsers so that the Blazor WASM can successfully consume the Web API project, 
type the following command in chrome to turn off checking for valid certificates in chrome.

chrome://flags/#allow-insecure-localhost 


Taken from the following : 

https://stackoverflow.com/questions/7580508/getting-chrome-to-accept-self-signed-localhost-certificate/42917227#42917227 

 n image. 