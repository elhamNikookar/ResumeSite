﻿using Resume.Domain.ViewModels.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Interfaces
{
    public interface IMessageService
    {
        Task<bool> CreateMessage(CreateMessageViewModel message);

        Task<List<MessageViewModel>> GetAllMessages();

        Task<bool> DeleteMessage(long id);
    }
}
