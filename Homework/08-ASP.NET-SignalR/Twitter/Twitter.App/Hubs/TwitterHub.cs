namespace Twitter.App.Hubs
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    using Twitter.App.Models.ViewModels;

    [HubName("twitter")]
    public class TwitterHub : Hub
    {
        public void Tweet(TweetViewModel viewModel)
        {
            this.Clients.All.viewTweet(viewModel);
        }
    }
}