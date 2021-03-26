using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Octokit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using JW;
using UserSearch.Models;

namespace UserSearch.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        
        [BindProperty(SupportsGet = true)]
        public string UserQuery { get; set; }

        public List<Models.User> FoundUsers = new List<Models.User>();
        
        //public PaginatedList<IndexModel> Results { get; private set; }
        public void OnGet()
        {

        }
        
        public async Task OnPost()
        {

            var client = new GitHubClient(new ProductHeaderValue("UserSearch"));
            var result = await client.Search.SearchUsers(new SearchUsersRequest(UserQuery));
            
            int CountLimit = 100;

            if (result.TotalCount > 0)
            {
                if(result.TotalCount < 100)
                {
                    CountLimit = result.TotalCount;
                    
                }

                for (int i = 0; i < CountLimit; i++)
                {
                    var searchResult = new Models.User();
                    searchResult.Id = result.Items[i].Id;
                    searchResult.Login = result.Items[i].Login;
                    searchResult.Avatar = result.Items[i].AvatarUrl;
                    searchResult.Url = result.Items[i].Url;
                    searchResult.Followers = result.Items[i].Followers;
                    searchResult.Following = result.Items[i].Following;
                    searchResult.SiteAdmin = result.Items[i].SiteAdmin;

                    FoundUsers.Add(searchResult);
                }
            }


        }
    }
}
