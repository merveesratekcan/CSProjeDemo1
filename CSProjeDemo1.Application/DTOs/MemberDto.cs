namespace CSProjeDemo1.Application.DTOs
{

    public class MemberDto
    {
        public string MemberNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime MembershipDate { get; set; }
        public List<BookDto> BorrowedBooks { get; set; }

        public MemberDto()
        {
            BorrowedBooks = new List<BookDto>();
        }
    }


    public class CreateMemberDto
    {
        public string MemberNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }


    public class UpdateMemberDto
    {
        public string MemberNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
} 