namespace Application.Dtos.Candidate
{
    public class CandidateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }
        public int CategoryId { get; set; }


        public static CandidateDto EmptyCandidate = new CandidateDto();
    }
}
