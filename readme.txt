
To get around the Invalid Cert. error in browsers so that the Blazor WASM can successfully consume the Web API project, 
type the following command in chrome to turn off checking for valid certificates in chrome.

chrome://flags/#allow-insecure-localhost 


Taken from the following : 

https://stackoverflow.com/questions/7580508/getting-chrome-to-accept-self-signed-localhost-certificate/42917227#42917227 

 To Do Code fixes :

 1) EditBlog requires an image to be uploaded. Cannot put conditional statements in http call

 EditBlog 

            if (imgFile == null)
            {
            -->    error = "Please select a file to upload";
            }
            else
            {
                Status = await BlogService.UpdateBlog(imgFile, Blog.ID, Blog.Title, Blog.Body, Blog.user.UserName);
            }


            public async Task<string> PostBlog<T>(string uri, IBrowserFile file, int blogid, string title, string body, string username)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
          
            var content = new MultipartFormDataContent();
            content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data");

            content.Add(new StringContent(blogid.ToString()), "blogid");
            content.Add(new StringContent(title), "title");
            content.Add(new StringContent(body), "body");
            content.Add(new StringContent(username), "username");
             --> cant condition below code to not include filestream
            var resized = await file.RequestImageFileAsync(file.ContentType, maxWidth: 500, maxHeight: 800);
            using Stream fileStream = resized.OpenReadStream();
            content.Add(new StreamContent(fileStream, (int)fileStream.Length), "files", "NewFile.png");
             -->
            request.Content = content;
            return await sendRequestFormData<T>(request);
        }


        and in blog controller , after converting from IBtowserFile to PostedFile, file's content type
        is missing , hence cannot be verified as an image. 