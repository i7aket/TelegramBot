using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Interface;
public interface IUpdateHandlerResult
{ 
    public bool IsSuccessful { get; set; } 
}