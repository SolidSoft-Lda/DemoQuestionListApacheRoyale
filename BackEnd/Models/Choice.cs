using System.Runtime.Serialization;

namespace DemoListQuestions.Models;

public class Choice
{
    public Choice()
    {
        Questions = new HashSet<Question>();
    }

    [DataMember(Name = "id")]
    public int Id { get; set; }
    [DataMember(Name = "choice")]
    public string Description { get; set; } = null!;
    [DataMember(Name = "votes")]
    public int Votes { get; set; }
    public ICollection<Question> Questions { get; set; }
}