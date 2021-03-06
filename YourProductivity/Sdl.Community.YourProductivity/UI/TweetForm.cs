﻿using System;
using System.Windows.Forms;
using Sdl.Community.YourProductivity.Services;

namespace Sdl.Community.YourProductivity.UI
{
    public partial class TweetForm : Form
    {
        private readonly ShareService _shareService;
        private readonly TweetMessageService _tweetMessageService;
        private readonly ProductivityService _productivityService;

        public TweetForm()
        {
            InitializeComponent();
            
        }
        public TweetForm(ShareService shareService, TweetMessageService tweetMessageService, ProductivityService productivityService):this()
        {
            _shareService = shareService;
            _tweetMessageService = tweetMessageService;
            _productivityService = productivityService;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            txtTweetMessage.Text = _tweetMessageService.GetTwitterMessage(_productivityService.Score);
        }
          

        private void btnTweet_Click(object sender, EventArgs e)
        {
            _shareService.Share();
            this.Close();
        }

    }
}
