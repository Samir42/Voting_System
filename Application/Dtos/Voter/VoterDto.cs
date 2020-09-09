namespace Application.Dtos.Voter
{
    public class VoterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }



        public static VoterDto EmptyVoter = new VoterDto();
    }
}
