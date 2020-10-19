using System;

using System.Linq;
using System.Threading.Tasks;
using ClearSky.Data;
using ClearSky.Entities;
using ClearSky.Entities.DTOs;
using ClearSky.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClearSky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController
    {
        private readonly DataContext _db;
        private readonly ICurrentUser _currentUser;

        public MessageController(DataContext db, ICurrentUser currentUser)
        {
            // _loggerFactory = loggerFactory;
            _currentUser = currentUser;
            _db = db;

        }

        [HttpPost("{id}/sendMessage")]
        public string SendMessageForProperty(int id, [FromBody] MessageDTO messageIn)
        {
            var user = _currentUser.GetCurrentAccountHolder().Result;

            if(user==null)
            {
               throw new System.NotImplementedException("User Cannot Be Found");
            }

            var property = _db.Properties.Where(x => x.Id == id).FirstOrDefault();

             if(property==null)
            {
               throw new System.NotImplementedException("Problem issueing to Property");
            }

            if(messageIn==null)
            {
                return "Message Properties Empty";

                // could use validator here, will add if have time
            }

            Message messageSend = new Message {

                MessageTitle = messageIn.MessageTitle,
                MessageBody = messageIn.MessageBody,
                PropertyId = property.Id,
                AccountHolderId = user.Id,
                // Property = property,
                // AccountHolder = user

            };
            
             user.Messages.Add(messageSend);
           
             _db.SaveChanges();
             // should have db save changes here for potential error

             return "Message Saved";


        }

        [HttpGet]
        public AccountUserDTO GetCurrentUserLoggedIn()
        {
            var user = _currentUser.GetCurrentAccountHolder();
        
            return new AccountUserDTO{
                UserName = user.Result.UserName,
                Email = user.Result.Email,
                Token = ""
            };
        }
    }
}