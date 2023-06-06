using deepro.BookStore.Models;
using deepro.BookStore.Repository;
using deepro.BookStore.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace deepro.BookStore.Controllers
{

    public class HomeController : Controller
    {
        private readonly NewBookAlertConfig _newBookAlertConfigration;
        private readonly NewBookAlertConfig _thirdPartyBookConfigration;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IMessageRepository _messageRepository;
        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlertConfigration, 
            IMessageRepository messageRepository,
            IUserService userService, IEmailService emailService)  
        {
            _newBookAlertConfigration = newBookAlertConfigration.Get("InternalBook");
            _thirdPartyBookConfigration = newBookAlertConfigration.Get("ThirdPartyBook");
            _messageRepository = messageRepository;
            _userService = userService;
            _emailService = emailService;
        }

        [ViewData]
        public string CustomProperty { get; set; }
        [ViewData]
        public string hTitle { get; set; }
        public async Task<ViewResult> Index()
        {


            //UserEmailOptions options = new UserEmailOptions()
            //{
            //    ToEmails = new List<string>()
            //    {
            //         "test@gmail.com"
            //    },
            //    PlaceHolders = new List<KeyValuePair<string, string>>()
            //    {
            //       new KeyValuePair<string, string>("{{UserName}}", "deepro")
            //    }
            //};


            //await _emailService.SendTestEmail(options);
            //var userId = _userService.getUserId();

            //var isLogedIn = _userService.IsAuthinticated();

            //bool isDisplay = _newBookAlertConfigration.DisplayNewBookAlert;
            //bool isDisplay1 = _thirdPartyBookConfigration.DisplayNewBookAlert;



            //var value = _messageRepository.GetName();
            //var newBook = _configuration.GetSection("NewBookAlert");
            //var result = newBook.GetValue<bool>("DisplayNewBookAlert");
            //var bookName = newBook.GetValue<string>("BookName");


            //var result = _configuration["AppName"];
            //var key1 = _configuration["infoObj:key1"];
            //var key2 = _configuration["infoObj:key2"];
            //var key3 = _configuration["infoObj:key3:Key3obj1"];
            //hTitle = "Home Page From Conttroler";
            //CustomProperty = "Custom Value";

            //ViewData["property1"] = "deepro";

            //ViewData["book"] = new BookModel() { Id= 1 , Author = "Donasi"};

            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
