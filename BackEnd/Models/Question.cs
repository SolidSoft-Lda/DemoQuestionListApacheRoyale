using System.Runtime.Serialization;
using DemoListQuestions.Helpers;

namespace DemoListQuestions.Models;

public class Question
{
    private ICollection<Choice>? choice;

    [DataMember(Name = "id")]
    public int Id { get; set; }
    [DataMember(Name = "question")]
    public string Description { get; set; } = null!;
    [DataMember(Name = "image_url")]
    public string? ImageURL { get; set; }
    [DataMember(Name = "thumb_url")]
    public string? ThumbURL { get; set; }
    [DataMember(Name = "published_at")]
    public DateTime PublishedAt { get; set; }

    [DataMember(Name = "choices")]
    public ICollection<Choice> Choices
    {
        get
        {
            if (choice == null)
            {
                using DataContext context = new DataContext();

                choice = (from c in context.Set<Choice>()
                          join qc in context.Set<QuestionChoice>() on c.Id equals qc.IdChoice
                          where qc.IdQuestion == Id
                          select c).ToList();
            }
            return choice;
        }
    }
}