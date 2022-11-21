using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoListQuestions.Helpers;
using DemoListQuestions.Models;

namespace DemoListQuestions.Controllers;

[ApiController]
public class QuestionsController : ControllerBase
{
    [HttpGet]
    [Route("questions")]
    public List<Question> Get(int limit, int offset, string? filter)
    {
        using DataContext context = new DataContext();

        return (from q in context.Set<Question>()
                where filter == null || q.Description.Contains(filter)
                select q).Skip(offset).Take(limit).ToList();
    }

    [HttpGet]
    [Route("questions/{id}")]
    public Question? Get(int id)
    {
        using DataContext context = new DataContext();

        return (from q in context.Set<Question>()
                where q.Id == id
                select q).FirstOrDefault();
    }

    [HttpPost]
    [Route("questions")]
    public async Task<bool> Post(List<Question> questions)
    {
        if (questions == null || questions.Count == 0)
            return true; //this is for demo purpose. we could use a mechanism of return codes.

        using DataContext context = new DataContext();

        try
        {
            //a possible addition is to support for questions + choice at once
            foreach (Question question in questions)
            {
                context.Entry(question).State = EntityState.Added;
            }
            await context.SaveChangesAsync();
        }
        catch
        {
            //a possible improvement would be log the exception for posterior analysis
            return false;
        }

        return true;
    }

    [HttpPut]
    [Route("questions/{question}")]
    public async Task<bool> Put(Question question)
    {
        if (question == null)
            return true; //this is for demo purpose. we could use a mechanism of return codes.

        using DataContext context = new DataContext();

        try
        {
            //a possible addition is to support for questions + choice at once
            context.Entry(question).State = EntityState.Added;
            await context.SaveChangesAsync();
        }
        catch
        {
            //a possible improvement would be log the exception for analysis
            return false;
        }

        return true;
    }

    [HttpPost]
    [Route("share")]
    public bool Share(string destination_email, string content_url)
    {
        EMailSender emailSender = new EMailSender("<REPLACE_MAIL_SERVER>", "<REPLACE_EMAIL>", "<REPLACE_PASSWORD>", "<REPLACE_EMAIL>");
        return emailSender.Send(destination_email, "Partilha de conteúdo", string.Format("Segue em anexo o URL do conteúdo: {0}", content_url));
    }
}