#pragma warning disable CS8618 // Disable null warnings
namespace TheWall.Models; 
/* This file is for sending multiple items view our ViewModel, as the AllMessages.cshtml will hold multiple forms AND a list
of messages.  This will NOT be saved in our database, as this is not listed in our context file. */
public class MessagePostViewModel
{
    public Message Message {get;set;} // For our new message form
    public Comment Comment {get; set;} // For our comment forms
    public List<Message> AllMessages {get; set;} // For our list of messages
}